using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Netzwerkchat
{
    internal sealed class Network : IDisposable
    {
        private const int Port = 1234;
        private readonly CancellationTokenSource cancellationTokenSource = new();
        private readonly UdpClient receiver = new(Port);
        private readonly string clientId = Guid.NewGuid().ToString("N");
        private Task? receiveTask;

        public event EventHandler<ChatPacket>? MessageReceived;

        public void Start()
        {
            if (receiveTask != null)
            {
                return;
            }

            receiveTask = Task.Run(ReceiveBroadcastLoopAsync);
        }

        public async Task SendBroadcastAsync(string senderName, string message)
        {
            ChatPacket packet = new()
            {
                ClientId = clientId,
                SenderName = senderName,
                Message = message,
                Timestamp = DateTimeOffset.Now
            };

            byte[] data = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(packet));

            using UdpClient udp = new();
            udp.EnableBroadcast = true;
            await udp.SendAsync(data, data.Length, new IPEndPoint(IPAddress.Broadcast, Port));
        }

        private async Task ReceiveBroadcastLoopAsync()
        {
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                try
                {
                    UdpReceiveResult result = await receiver.ReceiveAsync(cancellationTokenSource.Token);
                    string payload = Encoding.UTF8.GetString(result.Buffer);
                    ChatPacket? packet = ChatPacket.TryParse(payload);
                    if (packet is null || packet.ClientId == clientId)
                    {
                        continue;
                    }

                    MessageReceived?.Invoke(this, packet);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
        }

        public void Dispose()
        {
            cancellationTokenSource.Cancel();
            receiver.Dispose();
            cancellationTokenSource.Dispose();
        }
    }

    internal sealed class ChatPacket
    {
        public string ClientId { get; set; } = string.Empty;

        public string SenderName { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;

        public static ChatPacket? TryParse(string payload)
        {
            try
            {
                return JsonSerializer.Deserialize<ChatPacket>(payload);
            }
            catch (JsonException)
            {
                if (string.IsNullOrWhiteSpace(payload))
                {
                    return null;
                }

                return new ChatPacket
                {
                    ClientId = "legacy",
                    SenderName = "Unbekannt",
                    Message = payload,
                    Timestamp = DateTimeOffset.Now
                };
            }
        }

    }
}





