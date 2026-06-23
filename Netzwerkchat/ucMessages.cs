using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace Netzwerkchat
{
    public partial class ucMessages : UserControl
    {

        public List<vecMessage> messagesList = new List<vecMessage>();
        
    public void generateMessages()
        {
            foreach (vecMessage m in messagesList)
            {
                ucMessage message = new ucMessage
                {
                    MessageContent = m.MessageContent
                };

                message.MessageContent = m.MessageContent;
                message.Dock = DockStyle.Top;
                this.panel2.Controls.Add(message);
                message.BringToFront();
            }
        }






        public ucMessages()
        {
            InitializeComponent();
    
            this.messagesList.Add(new vecMessage()
            {
                MessageContent = "foobar 0000fooo0000 barrrrr",
            });


            this.messagesList.Add(new vecMessage()
            {
                MessageContent = "foobar111 fooo1111 barrrrr",
            });


            this.messagesList.Add(new vecMessage()
            {
                MessageContent = "foobar2222 fooo 2222barrrrr",
            });


            this.messagesList.Add(new vecMessage()
            {
                MessageContent = "foobar 3333fooo 33333barrrrr",
            });

            this.generateMessages();



        }

    }
}
