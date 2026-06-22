using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Netzwerkchat
{
    public partial class ucMessage : UserControl
    {
#pragma warning disable WFO1000 // Missing code serialization configuration for property content

        public string MessageContent
#pragma warning restore WFO1000 // Missing code serialization configuration for property content
        {
            set { this.lblMessage.Text = value; }
            get { return this.lblMessage.Text; }
        }

        public ucMessage()
        {
            InitializeComponent();
        }
    }
}
