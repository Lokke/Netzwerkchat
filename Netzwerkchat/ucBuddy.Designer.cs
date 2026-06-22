namespace Netzwerkchat
{
    partial class ucBuddy
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
            tableLayoutPanel1 = new TableLayoutPanel();
            pbxIcon = new PictureBox();
            lblName = new Label();
            lblStatus = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxIcon).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.68421F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.31579F));
            tableLayoutPanel1.Controls.Add(pbxIcon, 0, 0);
            tableLayoutPanel1.Controls.Add(lblName, 1, 0);
            tableLayoutPanel1.Controls.Add(lblStatus, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(380, 126);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Click += Buddy_Click;
            // 
            // pbxIcon
            // 
            pbxIcon.Dock = DockStyle.Fill;
            pbxIcon.Location = new Point(3, 3);
            pbxIcon.Name = "pbxIcon";
            tableLayoutPanel1.SetRowSpan(pbxIcon, 2);
            pbxIcon.Size = new Size(122, 120);
            pbxIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pbxIcon.TabIndex = 0;
            pbxIcon.TabStop = false;
            pbxIcon.Click += Buddy_Click;
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblName.AutoSize = true;
            lblName.Location = new Point(131, 48);
            lblName.Name = "lblName";
            lblName.Size = new Size(38, 15);
            lblName.TabIndex = 1;
            lblName.Text = "label1";
            lblName.Click += Buddy_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(131, 63);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(38, 15);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "label2";
            lblStatus.Click += Buddy_Click;
            // 
            // ucBuddy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ucBuddy";
            Size = new Size(380, 126);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pbxIcon;
        private Label lblName;
        private Label lblStatus;
    }
}
