using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace Netzwerkchat {
  public partial class ucMessage: UserControl {
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string MessageContent {
      set {
        lblMessage.Text = value;
      }
      get {
        return lblMessage.Text;
      }
    }
    [DefaultValue(true)]
    public bool IsRight {
      get;
      set;
    } = true;
    [DefaultValue(typeof (Color), "LightBlue")]
    public Color BubbleColor {
      get;
      set;
    } = Color.LightBlue;
    public ucMessage() {
      InitializeComponent();
      DoubleBuffered = true;
    }
    private void ucMessage_Paint(object sender, PaintEventArgs e) {
      e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      int radius = 20;
      int diameter = radius * 2;
      int w = Width - 10;
      int h = Height - 10;
      GraphicsPath path = new GraphicsPath();
      // TL
      path.AddArc(0, 0, diameter, diameter, 180, 90);
      // TR
      path.AddArc(w - diameter, 0, diameter, diameter, 270, 90);
      if (IsRight) {
        // RE -> BR
        path.AddLine(w, radius, w, h);

        // BE
        path.AddLine(w, h, radius, h);
        // BL
        path.AddArc(0, h - diameter, diameter, diameter, 90, 90);
      } else {
        // BR
        path.AddArc(w - diameter, h - diameter, diameter, diameter, 0, 90);
        // BE -> BL
        path.AddLine(w - radius, h, 0, h);
        // LE
        path.AddLine(0, h, 0, radius);
      }
      path.CloseFigure();
      using(SolidBrush brush = new SolidBrush(BubbleColor)) {
        e.Graphics.FillPath(brush, path);
      }
    }
  }
}