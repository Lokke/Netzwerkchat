namespace Netzwerkchat
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            splitContainer1 = new SplitContainer();
            ucBuddies1 = new ucBuddies();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            ucBuddy1 = new ucBuddy();
            panel2 = new Panel();
            label1 = new Label();
            ucPosts1 = new ucPosts();
            contextMenuStrip1 = new ContextMenuStrip(components);
            ucMessages1 = new ucMessages();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(ucBuddies1);
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(ucMessages1);
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Panel2.Controls.Add(ucPosts1);
            splitContainer1.Size = new Size(926, 450);
            splitContainer1.SplitterDistance = 307;
            splitContainer1.TabIndex = 0;
            // 
            // ucBuddies1
            // 
            ucBuddies1.Dock = DockStyle.Fill;
            ucBuddies1.Location = new Point(0, 97);
            ucBuddies1.Name = "ucBuddies1";
            ucBuddies1.Size = new Size(307, 353);
            ucBuddies1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(ucBuddy1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(307, 97);
            panel1.TabIndex = 1;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1, 68);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(35, 29);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // ucBuddy1
            // 
            ucBuddy1.BuddyIcon = null;
            ucBuddy1.BuddyName = "label1";
            ucBuddy1.BuddyStatus = "label2";
            ucBuddy1.Dock = DockStyle.Top;
            ucBuddy1.Location = new Point(0, 0);
            ucBuddy1.Name = "ucBuddy1";
            ucBuddy1.Size = new Size(307, 73);
            ucBuddy1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(615, 71);
            panel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 25);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // ucPosts1
            // 
            ucPosts1.Dock = DockStyle.Bottom;
            ucPosts1.Location = new Point(0, 347);
            ucPosts1.Name = "ucPosts1";
            ucPosts1.Size = new Size(615, 64);
            ucPosts1.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // ucMessages1
            // 
            ucMessages1.Dock = DockStyle.Fill;
            ucMessages1.Location = new Point(0, 71);
            ucMessages1.Name = "ucMessages1";
            ucMessages1.Size = new Size(615, 276);
            ucMessages1.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(926, 450);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private ucBuddies ucBuddies1;
        private Panel panel1;
        private PictureBox pictureBox2;
        private ucBuddy ucBuddy1;
        private ContextMenuStrip contextMenuStrip1;
        private ucPosts ucPosts1;
        private Panel panel2;
        private Label label1;
        private ucMessages ucMessages1;
    }
}
