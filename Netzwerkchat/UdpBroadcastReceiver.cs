using System;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Netzwerkchat
{
    internal sealed class vecPacketReceivedEventArgs : EventArgs
    {
        public vecPacketReceivedEventArgs(vecChatPacket packet, IPAddress remoteAddress)
        {
            Packet = packet;
            RemoteAddress = remoteAddress;
        }

        public vecChatPacket Packet { get; }

        public IPAddress RemoteAddress { get; }
    }

    internal sealed class UdpBroadcastReceiver : IDisposable
    {
        private const int Port = 1234;
        private readonly CancellationTokenSource cancellationTokenSource = new();
        private readonly UdpClient receiver = CreateReceiver();
        private bool started;

        public event EventHandler<vecPacketReceivedEventArgs>? PacketReceived;

        private static UdpClient CreateReceiver()
        {
            UdpClient client = new(AddressFamily.InterNetwork);
            client.ExclusiveAddressUse = false;
            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            client.Client.Bind(new IPEndPoint(IPAddress.Any, Port));
            return client;
        }

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

                    PacketReceived?.Invoke(this, new vecPacketReceivedEventArgs(packet, result.RemoteEndPoint.Address));
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

        public static Task SendBroadcastAsync(vecChatPacket packet)
        {
            return SendAsync(packet, IPAddress.Broadcast, true);
        }

        public static Task SendDirectAsync(vecChatPacket packet, IPAddress remoteAddress)
        {
            return SendAsync(packet, remoteAddress, false);
        }

        private static async Task SendAsync(vecChatPacket packet, IPAddress remoteAddress, bool enableBroadcast)
        {
            byte[] data = JsonSerializer.SerializeToUtf8Bytes(packet);

            using UdpClient udp = new();
            udp.EnableBroadcast = enableBroadcast;
            await udp.SendAsync(data, data.Length, new IPEndPoint(remoteAddress, Port));
        }
    }
}