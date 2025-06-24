namespace Monopoly.UI
{
    partial class TileInfoControl
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
            this.labelTileName = new System.Windows.Forms.Label();
            this.labelTileInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTileName
            // 
            this.labelTileName.BackColor = System.Drawing.Color.Transparent;
            this.labelTileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTileName.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTileName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTileName.Location = new System.Drawing.Point(0, 0);
            this.labelTileName.Name = "labelTileName";
            this.labelTileName.Size = new System.Drawing.Size(300, 40);
            this.labelTileName.TabIndex = 0;
            this.labelTileName.Text = "THÔNG TIN Ô: LONG AN";
            this.labelTileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTileInfo
            // 
            this.labelTileInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.labelTileInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTileInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelTileInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTileInfo.Location = new System.Drawing.Point(0, 40);
            this.labelTileInfo.Name = "labelTileInfo";
            this.labelTileInfo.Size = new System.Drawing.Size(300, 320);
            this.labelTileInfo.TabIndex = 1;
            this.labelTileInfo.Text = "Giá mua đất: 1000$\nGiá mua một căn nhà: 100$\nTiền trả khi người khác vào ô trống:" +
    " 1000$";
            // 
            // TileInfoControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labelTileInfo);
            this.Controls.Add(this.labelTileName);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "TileInfoControl";
            this.Size = new System.Drawing.Size(300, 360);
            this.Visible = false;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTileName;
        private System.Windows.Forms.Label labelTileInfo;
    }
}
