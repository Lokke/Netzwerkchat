using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Netzwerkchat
{
    public partial class ucPosts : UserControl
    {
        public ucPosts()
        {
            InitializeComponent();
            btnPost.Click += btnPost_Click;
            txtPost.KeyDown += txtPost_KeyDown;
        }

        private void SendPost()
        {
            string message = txtPost.Text.Trim();
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            new Network().sendBroadcast(message);
            txtPost.Clear();
        }

        private void btnPost_Click(object? sender, EventArgs e)
        {
            SendPost();
        }

        private void txtPost_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            e.SuppressKeyPress = true;
            SendPost();
        }
    }
}
