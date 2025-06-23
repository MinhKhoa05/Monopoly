namespace Monopoly.UI
{
    partial class BaseTileControl
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
            this.labelTop = new System.Windows.Forms.Label();
            this.labelMiddle = new System.Windows.Forms.Label();
            this.labelHouse = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTop
            // 
            this.labelTop.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTop.ForeColor = System.Drawing.Color.Black;
            this.labelTop.Location = new System.Drawing.Point(0, 8);
            this.labelTop.Name = "labelTop";
            this.labelTop.Size = new System.Drawing.Size(90, 20);
            this.labelTop.TabIndex = 0;
            this.labelTop.Text = "labelTop";
            this.labelTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMiddle
            // 
            this.labelMiddle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMiddle.ForeColor = System.Drawing.Color.Black;
            this.labelMiddle.Location = new System.Drawing.Point(0, 30);
            this.labelMiddle.Name = "labelMiddle";
            this.labelMiddle.Size = new System.Drawing.Size(90, 12);
            this.labelMiddle.TabIndex = 2;
            this.labelMiddle.Text = "labelMiddle";
            this.labelMiddle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHouse
            // 
            this.labelHouse.BackColor = System.Drawing.Color.Silver;
            this.labelHouse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelHouse.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHouse.ForeColor = System.Drawing.Color.Black;
            this.labelHouse.Location = new System.Drawing.Point(0, 47);
            this.labelHouse.Margin = new System.Windows.Forms.Padding(0);
            this.labelHouse.Name = "labelHouse";
            this.labelHouse.Size = new System.Drawing.Size(90, 18);
            this.labelHouse.TabIndex = 6;
            this.labelHouse.Text = "🏰 🏠";
            this.labelHouse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BaseTileControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labelHouse);
            this.Controls.Add(this.labelMiddle);
            this.Controls.Add(this.labelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "BaseTileControl";
            this.Size = new System.Drawing.Size(90, 65);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label labelTop;
        protected System.Windows.Forms.Label labelMiddle;
        protected System.Windows.Forms.Label labelHouse;
    }
}
