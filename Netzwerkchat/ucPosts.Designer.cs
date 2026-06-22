namespace Netzwerkchat
{
    partial class ucPosts
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel2 = new Panel();
            btnPost = new Button();
            txtPost = new TextBox();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(627, 61);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnPost);
            panel2.Controls.Add(txtPost);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 61);
            panel2.Name = "panel2";
            panel2.Size = new Size(627, 89);
            panel2.TabIndex = 1;
            // 
            // btnPost
            // 
            btnPost.Dock = DockStyle.Right;
            btnPost.Location = new Point(554, 0);
            btnPost.Name = "btnPost";
            btnPost.Size = new Size(73, 89);
            btnPost.TabIndex = 1;
            btnPost.Text = "button1";
            btnPost.UseVisualStyleBackColor = true;
            // 
            // txtPost
            // 
            txtPost.BorderStyle = BorderStyle.None;
            txtPost.Dock = DockStyle.Left;
            txtPost.Location = new Point(0, 0);
            txtPost.Name = "txtPost";
            txtPost.Size = new Size(531, 16);
            txtPost.TabIndex = 0;
            // 
            // ucPosts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ucPosts";
            Size = new Size(627, 150);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private TextBox txtPost;
        private Button btnPost;
    }
}
