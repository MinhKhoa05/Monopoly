namespace Monopoly
{
    partial class Board
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Board));
            this.boardPanel = new System.Windows.Forms.Panel();
            this.panelDice = new System.Windows.Forms.Panel();
            this.dice2 = new System.Windows.Forms.PictureBox();
            this.dice1 = new System.Windows.Forms.PictureBox();
            this.panelTileInfo = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.tileInfo = new System.Windows.Forms.Label();
            this.tileColor = new System.Windows.Forms.Panel();
            this.tileName = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelPlayer = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.specialTilePanel1 = new Monopoly.UI.SpecialTilePanel();
            this.propertyTilePanel1 = new Monopoly.UI.PropertyTilePanel();
            this.boardPanel.SuspendLayout();
            this.panelDice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dice2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice1)).BeginInit();
            this.panelTileInfo.SuspendLayout();
            this.panel13.SuspendLayout();
            this.tileColor.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // boardPanel
            // 
            this.boardPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boardPanel.Controls.Add(this.propertyTilePanel1);
            this.boardPanel.Controls.Add(this.specialTilePanel1);
            this.boardPanel.Controls.Add(this.panelDice);
            this.boardPanel.Controls.Add(this.panelTileInfo);
            this.boardPanel.Controls.Add(this.panel15);
            this.boardPanel.Controls.Add(this.panel2);
            this.boardPanel.Controls.Add(this.rightPanel);
            this.boardPanel.Controls.Add(this.leftPanel);
            this.boardPanel.Controls.Add(this.bottomPanel);
            this.boardPanel.Controls.Add(this.topPanel);
            this.boardPanel.Location = new System.Drawing.Point(12, 11);
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.Size = new System.Drawing.Size(990, 715);
            this.boardPanel.TabIndex = 2;
            // 
            // panelDice
            // 
            this.panelDice.Controls.Add(this.dice2);
            this.panelDice.Controls.Add(this.dice1);
            this.panelDice.Location = new System.Drawing.Point(278, 173);
            this.panelDice.Name = "panelDice";
            this.panelDice.Size = new System.Drawing.Size(112, 64);
            this.panelDice.TabIndex = 9;
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
            this.tileInfo.BackColor = System.Drawing.Color.WhiteSmoke;
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightYellow;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panelPlayer);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Location = new System.Drawing.Point(587, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(307, 202);
            this.panel2.TabIndex = 6;
            // 
            // panelPlayer
            // 
            this.panelPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPlayer.Location = new System.Drawing.Point(0, 40);
            this.panelPlayer.Name = "panelPlayer";
            this.panelPlayer.Size = new System.Drawing.Size(305, 160);
            this.panelPlayer.TabIndex = 1;
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
            // specialTilePanel1
            // 
            this.specialTilePanel1.IsSelected = false;
            this.specialTilePanel1.Location = new System.Drawing.Point(311, 334);
            this.specialTilePanel1.Name = "specialTilePanel1";
            this.specialTilePanel1.Size = new System.Drawing.Size(90, 65);
            this.specialTilePanel1.TabIndex = 10;
            // 
            // propertyTilePanel1
            // 
            this.propertyTilePanel1.IsSelected = false;
            this.propertyTilePanel1.Location = new System.Drawing.Point(399, 441);
            this.propertyTilePanel1.Name = "propertyTilePanel1";
            this.propertyTilePanel1.Size = new System.Drawing.Size(90, 65);
            this.propertyTilePanel1.TabIndex = 11;
            // 
            // Board
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1014, 736);
            this.Controls.Add(this.boardPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Board";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monopoly";
            this.Load += new System.EventHandler(this.Main_Load);
            this.boardPanel.ResumeLayout(false);
            this.panelDice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dice2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice1)).EndInit();
            this.panelTileInfo.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.tileColor.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel boardPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelTileInfo;
        private System.Windows.Forms.Panel tileColor;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label tileInfo;
        private System.Windows.Forms.Panel panelDice;
        private System.Windows.Forms.PictureBox dice1;
        private System.Windows.Forms.PictureBox dice2;
        private System.Windows.Forms.Label tileName;
        private System.Windows.Forms.Panel panelPlayer;
        private UI.PropertyTilePanel propertyTilePanel1;
        private UI.SpecialTilePanel specialTilePanel1;
    }
}