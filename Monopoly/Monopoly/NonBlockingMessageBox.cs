using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Monopoly
{
    public sealed class NonBlockingMessageBox
    {
        public static void Show(string propertyName, string propertyInfo, Color themeColor, string price = "", int duration = 3000)
        {
            Form msg = new Form()
            {
                Width = 380,
                Height = 180,
                Text = "",
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.None,
                MaximizeBox = false,
                MinimizeBox = false,
                TopMost = true,
                BackColor = Color.FromArgb(240, 240, 240),
                ShowInTaskbar = false
            };

            // Custom paint để vẽ viền đẹp
            msg.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Vẽ viền ngoài
                using (Pen borderPen = new Pen(Color.FromArgb(180, 180, 180), 2))
                {
                    g.DrawRectangle(borderPen, 1, 1, msg.Width - 3, msg.Height - 3);
                }

                // Vẽ viền trong
                using (Pen innerBorderPen = new Pen(Color.White, 1))
                {
                    g.DrawRectangle(innerBorderPen, 3, 3, msg.Width - 7, msg.Height - 7);
                }
            };

            // Header panel
            Panel headerPanel = new Panel()
            {
                Height = 45,
                Dock = DockStyle.Top,
                BackColor = themeColor
            };

            // Custom paint cho header để có gradient
            headerPanel.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                Rectangle rect = headerPanel.ClientRectangle;

                using (LinearGradientBrush brush = new LinearGradientBrush(
                    rect, themeColor, Color.FromArgb(Math.Max(0, themeColor.R - 30),
                    Math.Max(0, themeColor.G - 30), Math.Max(0, themeColor.B - 30)),
                    LinearGradientMode.Vertical))
                {
                    g.FillRectangle(brush, rect);
                }

                // Vẽ viền dưới header
                using (Pen pen = new Pen(Color.FromArgb(200, 200, 200), 1))
                {
                    g.DrawLine(pen, 0, rect.Height - 1, rect.Width, rect.Height - 1);
                }
            };

            // Title label
            Label titleLabel = new Label()
            {
                Text = propertyName,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };
            headerPanel.Controls.Add(titleLabel);

            // Content panel
            Panel contentPanel = new Panel()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20, 15, 20, 15)
            };

            // Info label
            Label infoLabel = new Label()
            {
                Text = propertyInfo,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(60, 60, 60),
                Location = new Point(0, 0),
                Size = new Size(340, 60),
                BackColor = Color.Transparent
            };

            // Price label
            if (!string.IsNullOrEmpty(price))
            {
                Label priceLabel = new Label()
                {
                    Text = $"💰 {price}",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = themeColor,
                    Location = new Point(0, 70),
                    Size = new Size(200, 25),
                    BackColor = Color.Transparent
                };
                contentPanel.Controls.Add(priceLabel);
            }

            contentPanel.Controls.Add(infoLabel);

            // Close button
            Button closeBtn = new Button()
            {
                Text = "×",
                Size = new Size(30, 30),
                Location = new Point(msg.Width - 35, 8),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(50, 255, 255, 255),
                ForeColor = Color.White,
                Font = new Font("Arial", 14, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 255, 255, 255);
            closeBtn.Click += (s, e) => msg.Close();

            // Add controls
            msg.Controls.Add(contentPanel);
            msg.Controls.Add(headerPanel);
            msg.Controls.Add(closeBtn);

            // Auto close timer
            Timer autoCloseTimer = new Timer();
            autoCloseTimer.Interval = duration;
            autoCloseTimer.Tick += (s, e) =>
            {
                autoCloseTimer.Stop();
                msg.Close();
            };

            msg.Show();
            autoCloseTimer.Start();
        }

        // Utility methods
        public static void ShowPropertyInfo(string propertyName, string rent, string price, Color color)
        {
            string info = $"🏠 Tiền thuê: {rent}\n💵 Giá mua: {price}\n\n➤ Nhấn để mua hoặc trả tiền thuê";
            Show(propertyName, info, color, price, 4000);
        }

        public static void ShowStationInfo(string stationName, string rent)
        {
            string info = $"🚂 Ga tàu hỏa\n💵 Tiền thuê: {rent}\n\n➤ Tiền thuê tăng theo số ga bạn sở hữu";
            Show(stationName, info, Color.FromArgb(70, 70, 70), rent, 3000);
        }

        public static void ShowUtilityInfo(string utilityName, string multiplier)
        {
            string info = $"⚡ Công ty tiện ích\n🎲 Thuê = Xúc xắc × {multiplier}\n\n➤ Tiền thuê phụ thuộc vào kết quả xúc xắc";
            Show(utilityName, info, Color.FromArgb(65, 105, 225), "", 3000);
        }

        public static void ShowSpecialSquare(string title, string description, Color color)
        {
            Show(title, $"🎯 {description}", color, "", 2500);
        }

        public static void ShowSimpleMessage(string title, string message)
        {
            Show(title, message, Color.FromArgb(52, 152, 219), "", 2000);
        }
    }
}