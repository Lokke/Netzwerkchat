using System;

namespace Netzwerkchat
{
    internal enum vecChatPacketKind
    {
        Presence,
        Hello,
        Broadcast,
        Direct
    }

    internal sealed class vecChatPacket
    {
        public string ClientId { get; set; } = string.Empty;

        public vecChatPacketKind Kind { get; set; } = vecChatPacketKind.Broadcast;

        public string SenderName { get; set; } = string.Empty;

        public string RecipientClientId { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;
    }
}