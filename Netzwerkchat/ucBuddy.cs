using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Netzwerkchat
{
    public partial class ucBuddy : UserControl
    {
#pragma warning disable WFO1000 // Missing code serialization configuration for property content
        public string BuddyName
#pragma warning restore WFO1000 // Missing code serialization configuration for property content
        {
            set { this.lblName.Text = value; }
            get { return this.lblName.Text; }
        }

#pragma warning disable WFO1000 // Missing code serialization configuration for property content
        public string BuddyStatus
#pragma warning restore WFO1000 // Missing code serialization configuration for property content
        {
            set { this.lblStatus.Text = value; }
            get { return this.lblStatus.Text; }
        }

#pragma warning disable WFO1000 // Missing code serialization configuration for property content
        public Image BuddyIcon
#pragma warning restore WFO1000 // Missing code serialization configuration for property content
        {
            set { this.pbxIcon.Image = value; }
            get { return this.pbxIcon.Image; }
        }


        public ucBuddy()
        {
            InitializeComponent();

        }

        private void Buddy_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
    }
}
