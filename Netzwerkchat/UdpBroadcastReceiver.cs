using System;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Netzwerkchat
{
    internal sealed class UdpBroadcastReceiver : IDisposable
    {
        private const int Port = 1234;
        private readonly CancellationTokenSource cancellationTokenSource = new();
        private readonly UdpClient receiver = new(Port);
        private bool started;

        public event EventHandler<vecChatPacket>? PacketReceived;

        public void Start()
        {
            if (started)
            {
                return;
            }

            started = true;
            _ = ReceiveBroadcastLoopAsync();
        }

        private async Task ReceiveBroadcastLoopAsync()
        {
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                try
                {
                    UdpReceiveResult result = await receiver.ReceiveAsync(cancellationTokenSource.Token);
                    vecChatPacket? packet = JsonSerializer.Deserialize<vecChatPacket>(result.Buffer);
                    if (packet is null)
                    {
                        continue;
                    }

                    PacketReceived?.Invoke(this, packet);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (ObjectDisposedException)
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

    internal static class UdpBroadcastSender
    {
        private const int Port = 1234;

        public static async Task SendAsync(vecChatPacket packet)
        {
            byte[] data = JsonSerializer.SerializeToUtf8Bytes(packet);

            using UdpClient udp = new() { EnableBroadcast = true };
            await udp.SendAsync(data, data.Length, new IPEndPoint(IPAddress.Broadcast, Port));
        }
    }
}