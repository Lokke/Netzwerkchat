using Avalonia.Layout;
using Avalonia.Media;

namespace Netzwerkchat
{
    public class vecMessage
    {
        public string Sender { get; set; } = string.Empty;

        public string MessageContent { get; set; } = string.Empty;

        public bool IsOwnMessage { get; set; }

        public HorizontalAlignment BubbleAlignment { get; set; } = HorizontalAlignment.Left;

        public IBrush BubbleBackground { get; set; } = Brushes.SlateGray;

        public IBrush BubbleForeground { get; set; } = Brushes.White;
    }
}