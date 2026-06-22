using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Netzwerkchat
{
    public partial class ucBuddies : UserControl
    {
        public List<vecBuddy> buddyList = new List<vecBuddy>();

        




        
        public void generateBuddies()
        {
            foreach (vecBuddy item in buddyList)
            {
                ucBuddy buddy = new ucBuddy
                {
                    BuddyName = item.BuddyName,
                    BuddyStatus = item.BuddyStatus,
                    BuddyIcon = item.BuddyIcon,
                    Dock = DockStyle.Top
                };

                buddy.Click += Buddy_Click;
                

                this.Controls.Add(buddy);
                
            }
        }

        private void Buddy_Click(object? sender, EventArgs e)
        {
            Trace.WriteLine(
                ((ucBuddy)sender).BuddyName
                );
        }

        public ucBuddies()
        {
            InitializeComponent();
            this.buddyList.Add(new vecBuddy()
            {
                BuddyName = "Christan Harten",
                BuddyStatus = "online",
                BuddyIcon = (Image)Netzwerkchat.Properties.Resources.buddyIconFoo,
            });
            this.buddyList.Add(new vecBuddy()
            {
                BuddyName = "Olga Machslochov",
                BuddyStatus = "online",
                BuddyIcon = (Image)Netzwerkchat.Properties.Resources.buddyIconFoo,
            });
            this.buddyList.Add(new vecBuddy()
            {
                BuddyName = "Christoph Smaul",
                BuddyStatus = "online",
                BuddyIcon = (Image)Netzwerkchat.Properties.Resources.buddyIconFoo,
            });




            this.generateBuddies();
        }
    }
}
