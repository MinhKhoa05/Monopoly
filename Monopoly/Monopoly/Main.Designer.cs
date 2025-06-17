namespace Monopoly
{
    partial class Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.boardPanel = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.dice2 = new System.Windows.Forms.PictureBox();
            this.dice1 = new System.Windows.Forms.PictureBox();
            this.panelTileInfo = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.tileInfo = new System.Windows.Forms.Label();
            this.tileColor = new System.Windows.Forms.Panel();
            this.tileName = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.boardPanel.SuspendLayout();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dice2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice1)).BeginInit();
            this.panelTileInfo.SuspendLayout();
            this.panel13.SuspendLayout();
            this.tileColor.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // boardPanel
            // 
            this.boardPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boardPanel.Controls.Add(this.panel14);
            this.boardPanel.Controls.Add(this.panelTileInfo);
            this.boardPanel.Controls.Add(this.panel15);
            this.boardPanel.Controls.Add(this.panel5);
            this.boardPanel.Controls.Add(this.rightPanel);
            this.boardPanel.Controls.Add(this.leftPanel);
            this.boardPanel.Controls.Add(this.bottomPanel);
            this.boardPanel.Controls.Add(this.topPanel);
            this.boardPanel.Location = new System.Drawing.Point(12, 11);
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.Size = new System.Drawing.Size(990, 715);
            this.boardPanel.TabIndex = 2;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.dice2);
            this.panel14.Controls.Add(this.dice1);
            this.panel14.Location = new System.Drawing.Point(96, 173);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(112, 64);
            this.panel14.TabIndex = 9;
            // 
            // dice2
            // 
            this.dice2.Location = new System.Drawing.Point(58, 14);
            this.dice2.Name = "dice2";
            this.dice2.Size = new System.Drawing.Size(40, 40);
            this.dice2.TabIndex = 1;
            this.dice2.TabStop = false;
            this.dice2.Click += new System.EventHandler(this.dice2_Click);
            // 
            // dice1
            // 
            this.dice1.Location = new System.Drawing.Point(12, 14);
            this.dice1.Name = "dice1";
            this.dice1.Size = new System.Drawing.Size(40, 40);
            this.dice1.TabIndex = 0;
            this.dice1.TabStop = false;
            this.dice1.Click += new System.EventHandler(this.dice1_Click);
            // 
            // panelTileInfo
            // 
            this.panelTileInfo.BackColor = System.Drawing.Color.Transparent;
            this.panelTileInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTileInfo.Controls.Add(this.panel13);
            this.panelTileInfo.Controls.Add(this.tileColor);
            this.panelTileInfo.Location = new System.Drawing.Point(587, 284);
            this.panelTileInfo.Name = "panelTileInfo";
            this.panelTileInfo.Size = new System.Drawing.Size(307, 360);
            this.panelTileInfo.TabIndex = 8;
            this.panelTileInfo.Visible = false;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.tileInfo);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(0, 40);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(305, 318);
            this.panel13.TabIndex = 2;
            // 
            // tileInfo
            // 
            this.tileInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileInfo.Location = new System.Drawing.Point(0, 0);
            this.tileInfo.Name = "tileInfo";
            this.tileInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tileInfo.Size = new System.Drawing.Size(305, 318);
            this.tileInfo.TabIndex = 0;
            this.tileInfo.Text = "Giá mua đất: 1000$\nGiá mua một căn nhà: 100$\nTiền trả khi người khác vào ô trống:" +
    " 1000$";
            // 
            // tileColor
            // 
            this.tileColor.Controls.Add(this.tileName);
            this.tileColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileColor.Location = new System.Drawing.Point(0, 0);
            this.tileColor.Name = "tileColor";
            this.tileColor.Size = new System.Drawing.Size(305, 40);
            this.tileColor.TabIndex = 1;
            // 
            // tileName
            // 
            this.tileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileName.Location = new System.Drawing.Point(0, 0);
            this.tileName.Name = "tileName";
            this.tileName.Size = new System.Drawing.Size(305, 40);
            this.tileName.TabIndex = 7;
            this.tileName.Text = "THÔNG TIN Ô \'HÀ NỘI\'";
            this.tileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.Cyan;
            this.panel15.Controls.Add(this.label6);
            this.panel15.Location = new System.Drawing.Point(96, 76);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(485, 91);
            this.panel15.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(485, 91);
            this.label6.TabIndex = 8;
            this.label6.Text = "CỜ TỶ PHÚ VIỆT NAM";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightYellow;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(587, 76);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(307, 202);
            this.panel5.TabIndex = 6;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.panel10);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 160);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(305, 40);
            this.panel7.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(267, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Hồ Nguyễn Minh Khoa - 1000000$";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Aqua;
            this.panel10.Location = new System.Drawing.Point(10, 10);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(20, 20);
            this.panel10.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 120);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(305, 40);
            this.panel3.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(267, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hồ Nguyễn Minh Khoa - 1000000$";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Lime;
            this.panel4.Location = new System.Drawing.Point(10, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(20, 20);
            this.panel4.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 40);
            this.panel1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(267, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hồ Nguyễn Minh Khoa - 1000000$";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Yellow;
            this.panel2.Location = new System.Drawing.Point(10, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 20);
            this.panel2.TabIndex = 6;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 40);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(305, 40);
            this.panel8.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hồ Nguyễn Minh Khoa - 1000000$";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Red;
            this.panel9.Location = new System.Drawing.Point(10, 10);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(20, 20);
            this.panel9.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(305, 40);
            this.panel6.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 40);
            this.label1.TabIndex = 7;
            this.label1.Text = "NGƯỜI CHƠI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightPanel
            // 
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Location = new System.Drawing.Point(900, 65);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(90, 585);
            this.rightPanel.TabIndex = 3;
            // 
            // leftPanel
            // 
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 65);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(90, 585);
            this.leftPanel.TabIndex = 2;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 650);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(990, 65);
            this.bottomPanel.TabIndex = 1;
            // 
            // topPanel
            // 
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(990, 65);
            this.topPanel.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1014, 736);
            this.Controls.Add(this.boardPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monopoly";
            this.Load += new System.EventHandler(this.Main_Load);
            this.boardPanel.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dice2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice1)).EndInit();
            this.panelTileInfo.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.tileColor.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel boardPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelTileInfo;
        private System.Windows.Forms.Panel tileColor;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label tileInfo;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.PictureBox dice1;
        private System.Windows.Forms.PictureBox dice2;
        private System.Windows.Forms.Label tileName;
    }
}