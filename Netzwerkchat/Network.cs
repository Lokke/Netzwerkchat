using System;
using System.Threading.Tasks;

namespace Netzwerkchat
{
    internal sealed class Network : IDisposable
    {
        private readonly string clientId = Guid.NewGuid().ToString("N");
        private readonly UdpBroadcastReceiver receiver = new();

        public event EventHandler<vecChatPacket>? MessageReceived;

        public Network()
        {
            receiver.PacketReceived += Receiver_PacketReceived;
        }

        public void Start()
        {
            receiver.Start();
        }

        public async Task SendBroadcastAsync(string senderName, string message)
        {
            vecChatPacket packet = new()
            {
                ClientId = clientId,
                SenderName = senderName,
                Message = message,
                Timestamp = DateTimeOffset.Now
            };
            await UdpBroadcastSender.SendAsync(packet);
        }

        private void Receiver_PacketReceived(object? sender, vecChatPacket packet)
        {
            if (packet.ClientId == clientId)
            {
                return;
            }

            MessageReceived?.Invoke(this, packet);
        }

        public void Dispose()
        {
            receiver.PacketReceived -= Receiver_PacketReceived;
            receiver.Dispose();
        }
    }
}





