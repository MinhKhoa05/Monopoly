namespace Monopoly
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.boardPanel = new System.Windows.Forms.Panel();
            this.panelDice = new System.Windows.Forms.Panel();
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
            this.dice2Image = new System.Windows.Forms.PictureBox();
            this.dice1Image = new System.Windows.Forms.PictureBox();
            this.tileInfoControl1 = new Monopoly.UI.TileInfoControl();
            this.boardPanel.SuspendLayout();
            this.panelDice.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dice2Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice1Image)).BeginInit();
            this.SuspendLayout();
            // 
            // boardPanel
            // 
            this.boardPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boardPanel.Controls.Add(this.tileInfoControl1);
            this.boardPanel.Controls.Add(this.panelDice);
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
            this.panelDice.Controls.Add(this.dice2Image);
            this.panelDice.Controls.Add(this.dice1Image);
            this.panelDice.Location = new System.Drawing.Point(278, 173);
            this.panelDice.Name = "panelDice";
            this.panelDice.Size = new System.Drawing.Size(112, 64);
            this.panelDice.TabIndex = 9;
            this.panelDice.Click += new System.EventHandler(this.panelDice_Click);
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
            this.panel2.Location = new System.Drawing.Point(594, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 202);
            this.panel2.TabIndex = 6;
            // 
            // panelPlayer
            // 
            this.panelPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPlayer.Location = new System.Drawing.Point(0, 40);
            this.panelPlayer.Name = "panelPlayer";
            this.panelPlayer.Size = new System.Drawing.Size(298, 160);
            this.panelPlayer.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(298, 40);
            this.panel6.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 40);
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
            // dice2Image
            // 
            this.dice2Image.Enabled = false;
            this.dice2Image.Location = new System.Drawing.Point(58, 14);
            this.dice2Image.Name = "dice2Image";
            this.dice2Image.Size = new System.Drawing.Size(40, 40);
            this.dice2Image.TabIndex = 1;
            this.dice2Image.TabStop = false;
            // 
            // dice1Image
            // 
            this.dice1Image.Enabled = false;
            this.dice1Image.Location = new System.Drawing.Point(12, 14);
            this.dice1Image.Name = "dice1Image";
            this.dice1Image.Size = new System.Drawing.Size(40, 40);
            this.dice1Image.TabIndex = 0;
            this.dice1Image.TabStop = false;
            // 
            // tileInfoControl1
            // 
            this.tileInfoControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.tileInfoControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tileInfoControl1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileInfoControl1.ForeColor = System.Drawing.Color.Black;
            this.tileInfoControl1.Location = new System.Drawing.Point(594, 284);
            this.tileInfoControl1.Name = "tileInfoControl1";
            this.tileInfoControl1.Size = new System.Drawing.Size(300, 360);
            this.tileInfoControl1.TabIndex = 10;
            // 
            // MainForm
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
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monopoly";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.boardPanel.ResumeLayout(false);
            this.panelDice.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dice2Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice1Image)).EndInit();
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
        private System.Windows.Forms.Panel panelDice;
        private System.Windows.Forms.PictureBox dice1Image;
        private System.Windows.Forms.PictureBox dice2Image;
        private System.Windows.Forms.Panel panelPlayer;
        private UI.TileInfoControl tileInfoControl1;
    }
}