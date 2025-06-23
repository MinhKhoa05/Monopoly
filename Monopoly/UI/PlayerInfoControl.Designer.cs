namespace Monopoly.UI
{
    partial class PlayerInfoControl
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
            this.labelToken = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelToken
            // 
            this.labelToken.BackColor = System.Drawing.Color.Transparent;
            this.labelToken.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelToken.ForeColor = System.Drawing.Color.LightGreen;
            this.labelToken.Location = new System.Drawing.Point(10, 10);
            this.labelToken.Name = "labelToken";
            this.labelToken.Size = new System.Drawing.Size(20, 20);
            this.labelToken.TabIndex = 0;
            this.labelToken.Text = "⭐";
            this.labelToken.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelInfo
            // 
            this.labelInfo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelInfo.Location = new System.Drawing.Point(35, 10);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(267, 20);
            this.labelInfo.TabIndex = 1;
            this.labelInfo.Text = "(0) Hồ Nguyễn Minh Khoa - 20000$";
            // 
            // PlayerInfoControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelToken);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "PlayerInfoControl";
            this.Size = new System.Drawing.Size(305, 40);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelToken;
        private System.Windows.Forms.Label labelInfo;
    }
}
