using System;
using System.Net;
using System.Threading.Tasks;

namespace Netzwerkchat
{
    internal sealed class Network : IDisposable
    {
        private readonly string clientId = Guid.NewGuid().ToString("N");
        private readonly UdpBroadcastReceiver receiver = new();

        public string ClientId => clientId;

        public event EventHandler<vecPacketReceivedEventArgs>? MessageReceived;

        public Network()
        {
            receiver.PacketReceived += Receiver_PacketReceived;
        }

        public void Start()
        {
            receiver.Start();
        }

        public Task SendPresenceAsync(string senderName)
        {
            return SendAsync(vecChatPacketKind.Presence, senderName, string.Empty, string.Empty, IPAddress.Broadcast);
        }

        public Task SendHelloAsync(string senderName, IPAddress remoteAddress)
        {
            return SendAsync(vecChatPacketKind.Hello, senderName, "Hallo", string.Empty, remoteAddress);
        }

        public Task SendBroadcastAsync(string senderName, string message)
        {
            return SendAsync(vecChatPacketKind.Broadcast, senderName, message, string.Empty, IPAddress.Broadcast);
        }

        public Task SendDirectAsync(string senderName, string message, string recipientClientId, IPAddress remoteAddress)
        {
            return SendAsync(vecChatPacketKind.Direct, senderName, message, recipientClientId, remoteAddress);
        }

        private async Task SendAsync(vecChatPacketKind kind, string senderName, string message, string recipientClientId, IPAddress remoteAddress)
        {
            vecChatPacket packet = new()
            {
                ClientId = clientId,
                Kind = kind,
                SenderName = senderName,
                RecipientClientId = recipientClientId,
                Message = message,
                Timestamp = DateTimeOffset.Now
            };

            if (remoteAddress.Equals(IPAddress.Broadcast))
            {
                await UdpBroadcastSender.SendBroadcastAsync(packet);
                return;
            }

            await UdpBroadcastSender.SendDirectAsync(packet, remoteAddress);
        }

        private void Receiver_PacketReceived(object? sender, vecPacketReceivedEventArgs e)
        {
            if (e.Packet.ClientId == clientId)
            {
                return;
            }

            MessageReceived?.Invoke(this, e);
        }

        public void Dispose()
        {
            receiver.PacketReceived -= Receiver_PacketReceived;
            receiver.Dispose();
        }
    }
}





