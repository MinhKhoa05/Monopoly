using System;
using System.Drawing;

namespace Monopoly.Tiles
{
    public class PropertyTile : BaseTile
    {
        public int Price { get; set; }
        public Player Owner { get; set; } // Optional: to track the owner of the property
        public int PriceLevel { get; set; }
        public int HouseCount { get; set; } // Number of houses on the property

        public PropertyTile(string tileName, Color tileColor, int price, int priceLevel)
            : base(tileName, tileColor)
        {
            this.Price = price;
            this.PriceLevel = priceLevel;
        }

        public override void OnEnter(Player player)
        {
            // Logic for when a player enters this tile
            // For example, check if the player can buy it or pay rent
        }

        #region Rendering Overrides
        protected override void DrawTileColor(Graphics g, Rectangle bounds)
        {
            // Vẽ thanh màu tile (trên)
            using (var brush = new SolidBrush(TileColor))
            {
                g.FillRectangle(brush, 3, 3, bounds.Width - 6, 12);
            }

            // Viền thanh màu
            using (var pen = new Pen(Color.Black, 1))
            {
                g.DrawRectangle(pen, 3, 3, bounds.Width - 6, 12);
            }
        }

        protected override void DrawTileContent(Graphics g, Rectangle bounds)
        {
            // Vẽ tên tile
            using (var font = new Font("Segoe UI", 9f, FontStyle.Bold))
            {
                var textRect = new Rectangle(5, 18, bounds.Width - 10, 16);
                var format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(TileName, font, Brushes.Black, textRect, format);
            }

            // Vẽ giá
            using (var font = new Font("Segoe UI", 8f))
            {
                var priceRect = new Rectangle(5, 34, bounds.Width - 10, 12);
                var format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString($"${Price}", font, Brushes.DarkBlue, priceRect, format);
            }

            DrawHouses(g, bounds);
        }

        protected virtual void DrawHouses(Graphics g, Rectangle bounds)
        {
            var houseFrameRect = new Rectangle(5, bounds.Height - 18, bounds.Width - 10, 14);

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

            if (HouseCount <= 0) return; // Không vẽ nhà nếu không có nhà nào

            // Chia đều khung thành 4 phần để vẽ nhà tròn - kích thước nhỏ hơn
            var frameInnerWidth = houseFrameRect.Width - 6;
            var houseWidth = frameInnerWidth / 4;
            var houseSize = Math.Min(houseWidth - 2, 8); // Giảm kích thước nhà

            // Vẽ nhà tròn từ trái qua phải
            for (int i = 0; i < HouseCount && i < 4; i++)
            {
                var houseX = houseFrameRect.X + 3 + (i * houseWidth) + (houseWidth - houseSize) / 2;
                var houseY = bounds.Height - 12 - houseSize / 2;
                var houseRect = new Rectangle(houseX, houseY, houseSize, houseSize);

                g.FillEllipse(Brushes.LimeGreen, houseRect);
                g.DrawEllipse(Pens.DarkGreen, houseRect);
            }
        }

        #endregion
    }
}