using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Threading;

namespace Netzwerkchat
{
    public partial class MainWindow : Window
    {
        private readonly Network network;

        public ObservableCollection<vecBuddy> Buddies { get; } = new();

        public ObservableCollection<vecMessage> Messages { get; } = new();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            // Buddies
            Buddies.Add(new vecBuddy { AvatarText = "CH", BuddyName = "Christan Harten", BuddyStatus = "online" });
            Buddies.Add(new vecBuddy { AvatarText = "OM", BuddyName = "Olga Machslochov", BuddyStatus = "online" });
            Buddies.Add(new vecBuddy { AvatarText = "CS", BuddyName = "Christoph Smaul", BuddyStatus = "online" });

            // Willkommensnachricht
            Messages.Add(CreateMessage("System", "Chat gestartet.", false));

            // Netzwerk starten
            network = new Network();
            network.MessageReceived += OnMessageReceived;
            network.Start();

            // Events
            SendButton.Click += SendButton_OnClick;
            MessageInput.KeyDown += MessageInput_OnKeyDown;
            Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object? sender, EventArgs e)
        {
            network.MessageReceived -= OnMessageReceived;
            network.Dispose();
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

            Messages.Add(CreateMessage(Environment.UserName, message, true));
            MessageInput.Clear();
            ScrollToLatestMessage();

            await network.SendBroadcastAsync(Environment.UserName, message);
        }

        private void OnMessageReceived(object? sender, ChatPacket packet)
        {
            Dispatcher.UIThread.Post(() =>
            {
                Messages.Add(CreateMessage(packet.SenderName, packet.Message, false));
                ScrollToLatestMessage();
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

        private void ScrollToLatestMessage()
        {
            if (MessagesList.ItemCount > 0)
                MessagesList.ScrollIntoView(MessagesList.ItemCount - 1);
        }
    }
}
