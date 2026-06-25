using System;

namespace Netzwerkchat
{
    internal sealed class vecChatPacket
    {
        public string ClientId { get; set; } = string.Empty;
        public string SenderName { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;
    }
}