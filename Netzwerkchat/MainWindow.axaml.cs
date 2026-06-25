using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Threading;

namespace Netzwerkchat
{
    public partial class MainWindow : Window
    {
        private const string BroadcastConversationKey = "__broadcast__";
        private const string UserName = "Lokke";

        private readonly Dictionary<string, List<vecMessage>> conversationHistory = new(StringComparer.OrdinalIgnoreCase);
        private readonly HashSet<string> greetedClientIds = new(StringComparer.OrdinalIgnoreCase);
        private readonly Network? network;
        private vecBuddy? selectedBuddy;

        public ObservableCollection<vecBuddy> Buddies { get; } = new();

        public ObservableCollection<vecMessage> Messages { get; } = new();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
            UsernameText.Text = UserName;
            StatusText.Text = $"IP: {GetLocalIpAddress()}";
            ChatTopicText.Text = "Broadcast";

            Buddies.Add(new vecBuddy { ClientId = BroadcastConversationKey, AvatarText = "ALL", BuddyName = "Alle", BuddyStatus = "Broadcast", IpAddress = string.Empty });
            Buddies.Add(new vecBuddy { AvatarText = "CH", BuddyName = "Christan Harten", BuddyStatus = "IP unbekannt", IpAddress = string.Empty });
            Buddies.Add(new vecBuddy { AvatarText = "OM", BuddyName = "Olga Machslochov", BuddyStatus = "IP unbekannt", IpAddress = string.Empty });
            Buddies.Add(new vecBuddy { AvatarText = "CS", BuddyName = "Christoph Smaul", BuddyStatus = "IP unbekannt", IpAddress = string.Empty });

            conversationHistory[BroadcastConversationKey] = new List<vecMessage>
            {
                CreateMessage("System", "Chat gestartet.", false)
            };
            LoadConversation(BroadcastConversationKey);

            if (Design.IsDesignMode)
            {
                return;
            }

            network = new Network();

            network.MessageReceived += OnMessageReceived;
            network.Start();
            _ = network.SendPresenceAsync(UserName);

            SendButton.Click += SendButton_OnClick;
            MessageInput.KeyDown += MessageInput_OnKeyDown;
            BuddyList.SelectionChanged += BuddyList_SelectionChanged;

            Closed += MainWindow_Closed;

            BuddyList.SelectedIndex = 0;
        }

        private void MainWindow_Closed(object? sender, EventArgs e)
        {
            if (network is null)
            {
                return;
            }

            network.MessageReceived -= OnMessageReceived;
            network.Dispose();
        }

        private void BuddyList_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            selectedBuddy = BuddyList.SelectedItem as vecBuddy;

            if (selectedBuddy is null || selectedBuddy.ClientId == BroadcastConversationKey)
            {
                ChatTopicText.Text = "Broadcast";
                LoadConversation(BroadcastConversationKey);
                return;
            }

            ChatTopicText.Text = string.IsNullOrWhiteSpace(selectedBuddy.IpAddress)
                ? $"Direktchat mit {selectedBuddy.BuddyName}"
                : $"Direktchat mit {selectedBuddy.BuddyName} ({selectedBuddy.IpAddress})";
            LoadConversation(selectedBuddy.BuddyName);
        }

        private async void SendButton_OnClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            await SendCurrentMessageAsync();
        }

        private async void MessageInput_OnKeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;

            e.Handled = true;
            await SendCurrentMessageAsync();
        }

        private async Task SendCurrentMessageAsync()
        {
            string message = MessageInput.Text?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(message))
                return;

            vecMessage ownMessage = CreateMessage(UserName, message, true);
            if (selectedBuddy is null || selectedBuddy.ClientId == BroadcastConversationKey)
            {
                AddMessageToConversation(BroadcastConversationKey, ownMessage);
            }
            else
            {
                AddMessageToConversation(selectedBuddy.BuddyName, ownMessage);
            }

            MessageInput.Clear();
            ScrollToLatestMessage();

            if (network is null)
            {
                return;
            }

            if (selectedBuddy is not null
                && selectedBuddy.ClientId != BroadcastConversationKey
                && IPAddress.TryParse(selectedBuddy.IpAddress, out IPAddress? targetAddress))
            {
                await network.SendDirectAsync(UserName, message, selectedBuddy.ClientId, targetAddress);
                return;
            }

            await network.SendBroadcastAsync(UserName, message);
        }

        private void OnMessageReceived(object? sender, vecPacketReceivedEventArgs e)
        {
            Dispatcher.UIThread.Post(() =>
            {
                vecChatPacket packet = e.Packet;
                vecBuddy buddy = RegisterOrUpdateBuddy(packet.SenderName, packet.ClientId, e.RemoteAddress);

                if ((packet.Kind == vecChatPacketKind.Broadcast || packet.Kind == vecChatPacketKind.Presence) && greetedClientIds.Add(packet.ClientId))
                {
                    _ = network?.SendHelloAsync(UserName, e.RemoteAddress);
                }

                string incomingText = GetIncomingText(packet);

                if (packet.Kind == vecChatPacketKind.Broadcast || packet.Kind == vecChatPacketKind.Presence || packet.Kind == vecChatPacketKind.Hello)
                {
                    AddMessageToConversation(BroadcastConversationKey, CreateMessage(packet.SenderName, incomingText, false));

                    if (selectedBuddy is null || selectedBuddy.ClientId == BroadcastConversationKey)
                    {
                        ScrollToLatestMessage();
                    }

                    return;
                }

                if (packet.Kind == vecChatPacketKind.Direct)
                {
                    AddMessageToConversation(buddy.BuddyName, CreateMessage(packet.SenderName, packet.Message, false));

                    if (selectedBuddy is not null && string.Equals(selectedBuddy.BuddyName, buddy.BuddyName, StringComparison.OrdinalIgnoreCase))
                    {
                        ScrollToLatestMessage();
                    }
                }
            });
        }

        private vecMessage CreateMessage(string sender, string message, bool isOwnMessage)
        {
            return new vecMessage
            {
                Sender = sender,
                MessageContent = message,
                IsOwnMessage = isOwnMessage,
                BubbleAlignment = isOwnMessage ? Avalonia.Layout.HorizontalAlignment.Right : Avalonia.Layout.HorizontalAlignment.Left,
                BubbleBackground = isOwnMessage ? new SolidColorBrush(Color.Parse("#2563EB")) : new SolidColorBrush(Color.Parse("#E2E8F0")),
                BubbleForeground = isOwnMessage ? Brushes.White : Brushes.Black
            };
        }

        private void AddMessageToConversation(string conversationKey, vecMessage message)
        {
            if (!conversationHistory.TryGetValue(conversationKey, out List<vecMessage>? history))
            {
                history = new List<vecMessage>();
                conversationHistory[conversationKey] = history;
            }

            history.Add(message);

            if (selectedBuddy is null || (selectedBuddy.ClientId == BroadcastConversationKey && conversationKey == BroadcastConversationKey) || string.Equals(selectedBuddy.BuddyName, conversationKey, StringComparison.OrdinalIgnoreCase))
            {
                Messages.Add(message);
            }
        }

        private void LoadConversation(string conversationKey)
        {
            Messages.Clear();

            if (!conversationHistory.TryGetValue(conversationKey, out List<vecMessage>? history))
            {
                return;
            }

            foreach (vecMessage message in history)
            {
                Messages.Add(message);
            }

            ScrollToLatestMessage();
        }

        private vecBuddy RegisterOrUpdateBuddy(string senderName, string clientId, IPAddress remoteAddress)
        {
            string ipAddress = remoteAddress.ToString();
            vecBuddy? buddy = Buddies.FirstOrDefault(item => string.Equals(item.BuddyName, senderName, StringComparison.OrdinalIgnoreCase));

            if (buddy is null)
            {
                buddy = new vecBuddy
                {
                    ClientId = clientId,
                    AvatarText = CreateAvatarText(senderName),
                    BuddyName = senderName,
                    BuddyStatus = ipAddress,
                    IpAddress = ipAddress
                };

                Buddies.Add(buddy);
                return buddy;
            }

            buddy.ClientId = clientId;
            buddy.BuddyStatus = ipAddress;
            buddy.IpAddress = ipAddress;
            return buddy;
        }

        private static string GetIncomingText(vecChatPacket packet)
        {
            return packet.Kind switch
            {
                vecChatPacketKind.Presence => "ist da.",
                vecChatPacketKind.Hello => packet.Message,
                vecChatPacketKind.Broadcast => packet.Message,
                vecChatPacketKind.Direct => packet.Message,
                _ => packet.Message
            };
        }

        private static string CreateAvatarText(string name)
        {
            string[] parts = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0)
            {
                return "??";
            }

            if (parts.Length == 1)
            {
                return parts[0].Length >= 2 ? parts[0][..2].ToUpperInvariant() : parts[0].ToUpperInvariant();
            }

            return string.Concat(parts[0][0], parts[1][0]).ToUpperInvariant();
        }

        private static string GetLocalIpAddress()
        {
            foreach (IPAddress address in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (address.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(address))
                {
                    return address.ToString();
                }
            }

            return "127.0.0.1";
        }

        private void ScrollToLatestMessage()
        {
            if (MessagesList.ItemCount > 0)
                MessagesList.ScrollIntoView(MessagesList.ItemCount - 1);
        }
    }
}
