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
            tableLayoutPanel1 = new TableLayoutPanel();
            btnPost = new Button();
            txtPost = new TextBox();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(627, 1);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 1);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(12, 10, 12, 10);
            panel2.Size = new Size(627, 63);
            panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel1.Controls.Add(btnPost, 1, 0);
            tableLayoutPanel1.Controls.Add(txtPost, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(12, 10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(603, 43);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnPost
            // 
            btnPost.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnPost.FlatAppearance.BorderSize = 0;
            btnPost.FlatStyle = FlatStyle.Flat;
            btnPost.Font = new Font("Microsoft Sans Serif", 9F);
            btnPost.Location = new Point(525, 0);
            btnPost.Margin = new Padding(0);
            btnPost.Name = "btnPost";
            btnPost.Size = new Size(78, 43);
            btnPost.TabIndex = 1;
            btnPost.Text = "Senden";
            btnPost.UseVisualStyleBackColor = false;
            // 
            // txtPost
            // 
            txtPost.BorderStyle = BorderStyle.None;
            txtPost.Dock = DockStyle.Fill;
            txtPost.Margin = new Padding(0, 0, 10, 0);
            txtPost.Multiline = true;
            txtPost.Name = "txtPost";
            txtPost.ScrollBars = ScrollBars.Vertical;
            txtPost.Size = new Size(515, 43);
            txtPost.TabIndex = 0;
            // 
            // ucPosts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ucPosts";
            Size = new Size(627, 64);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txtPost;
        private Button btnPost;
    }
}
