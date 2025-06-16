using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Monopoly
{
    public class Tile : UserControl
    {
        public string TileName { get; set; } = "Hà Nội";
        public int Price { get; set; } = 100;
        public Color TileColor { get; set; } = Color.Red;
        public int HouseCount { get; set; } // max 4
        public List<string> PlayersOnTile { get; set; } = new List<string>();

        // Màu sắc cho người chơi
        private readonly Color[] PlayerColors = {
            Color.Red, Color.Blue, Color.Green, Color.Orange
        };

        public Tile()
        {
            this.DoubleBuffered = true;
            this.Width = 90;  // Giảm từ 120 xuống 90
            this.Height = 65; // Giảm từ 85 xuống 65
            this.BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            var rect = this.ClientRectangle;

            // Vẽ viền tile
            using (var pen = new Pen(Color.Black, 2))
            {
                g.DrawRectangle(pen, 0, 0, rect.Width - 1, rect.Height - 1);
            }

            // Vẽ thanh màu tile (trên) - nhỏ hơn
            using (var brush = new SolidBrush(TileColor))
            {
                g.FillRectangle(brush, 3, 3, rect.Width - 6, 12); // Giảm padding và height
            }

            // Viền thanh màu
            using (var pen = new Pen(Color.Black, 1))
            {
                g.DrawRectangle(pen, 3, 3, rect.Width - 6, 12);
            }

            // Vẽ tên tile - font vừa phải
            using (var font = new Font("Segoe UI", 9f, FontStyle.Bold)) // Tăng lên 9 cho rõ ràng
            {
                var textRect = new Rectangle(5, 18, rect.Width - 10, 16); // Tăng height thêm một chút
                var format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(TileName, font, Brushes.Black, textRect, format);
            }

            // Vẽ giá - font vừa phải
            using (var font = new Font("Segoe UI", 8f)) // Tăng lên 8 cho rõ ràng
            {
                var priceRect = new Rectangle(5, 34, rect.Width - 10, 12); // Điều chỉnh vị trí cho vừa
                var format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString($"${Price}", font, Brushes.DarkBlue, priceRect, format);
            }

            // Vẽ khung chứa nhà (hình chữ nhật bo góc) - nhỏ hơn
            if (HouseCount > 0)
            {
                var houseFrameRect = new Rectangle(5, rect.Height - 18, rect.Width - 10, 14); // Giảm kích thước

                // Vẽ nền bo góc với radius nhỏ hơn
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    var radius = 4; // Giảm từ 6 xuống 4
                    path.StartFigure();
                    path.AddArc(houseFrameRect.X, houseFrameRect.Y, radius, radius, 180, 90);
                    path.AddArc(houseFrameRect.Right - radius, houseFrameRect.Y, radius, radius, 270, 90);
                    path.AddArc(houseFrameRect.Right - radius, houseFrameRect.Bottom - radius, radius, radius, 0, 90);
                    path.AddArc(houseFrameRect.X, houseFrameRect.Bottom - radius, radius, radius, 90, 90);
                    path.CloseFigure();

                    g.FillPath(Brushes.Silver, path);
                    g.DrawPath(Pens.Gray, path);
                }

                // Chia đều khung thành 4 phần để vẽ nhà tròn - kích thước nhỏ hơn
                var frameInnerWidth = houseFrameRect.Width - 6;
                var houseWidth = frameInnerWidth / 4;
                var houseSize = Math.Min(houseWidth - 2, 8); // Giảm kích thước nhà

                // Vẽ nhà tròn từ trái qua phải
                for (int i = 0; i < HouseCount && i < 4; i++)
                {
                    var houseX = houseFrameRect.X + 3 + (i * houseWidth) + (houseWidth - houseSize) / 2;
                    var houseY = rect.Height - 12 - houseSize / 2;
                    var houseRect = new Rectangle(houseX, houseY, houseSize, houseSize);

                    g.FillEllipse(Brushes.LimeGreen, houseRect);
                    g.DrawEllipse(Pens.DarkGreen, houseRect);
                }
            }

            // Vẽ người chơi ở 4 góc phần chữ (chỉ cục màu) - nhỏ hơn
            var textAreaTop = 18;
            var textAreaBottom = 44;
            var textAreaLeft = 5;
            var textAreaRight = rect.Width - 5;

            var playerPositions = new Point[]
            {
                new Point(textAreaLeft + 1, textAreaTop + 1),      // Góc trên trái
                new Point(textAreaRight - 7, textAreaTop + 1),     // Góc trên phải
                new Point(textAreaLeft + 1, textAreaBottom - 7),   // Góc dưới trái
                new Point(textAreaRight - 7, textAreaBottom - 7)   // Góc dưới phải
            };

            for (int i = 0; i < PlayersOnTile.Count && i < 4; i++)
            {
                var playerPos = playerPositions[i];
                var playerRect = new Rectangle(playerPos.X, playerPos.Y, 6, 6); // Giảm từ 8x8 xuống 6x6

                var playerColor = PlayerColors[i % PlayerColors.Length];
                using (var brush = new SolidBrush(playerColor))
                {
                    g.FillRectangle(brush, playerRect);
                }
                g.DrawRectangle(Pens.Black, playerRect);
            }
        }
    }
}