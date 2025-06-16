using System.Drawing;

namespace Monopoly.Tiles
{
    public class PropertyTile : BaseTile
    {
        public int Price { get; set; }

        public PropertyTile(string tileName, Color tileColor, int price)
            : base(tileName, tileColor)
        {
            this.Price = price;
        }

        public override void OnEnter(Player player)
        {
            // Logic for when a player enters this tile
            // For example, check if the player can buy it or pay rent
        }

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

            // Vẽ khung chứa nhà (hình chữ nhật bo góc)
            var houseFrameRect = new Rectangle(5, bounds.Height - 18, bounds.Width - 10, 14);

            // Vẽ nền bo góc
            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                var radius = 4;
                path.StartFigure();
                path.AddArc(houseFrameRect.X, houseFrameRect.Y, radius, radius, 180, 90);
                path.AddArc(houseFrameRect.Right - radius, houseFrameRect.Y, radius, radius, 270, 90);
                path.AddArc(houseFrameRect.Right - radius, houseFrameRect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(houseFrameRect.X, houseFrameRect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                g.FillPath(Brushes.Silver, path);
                g.DrawPath(Pens.Gray, path);
            }
        }
    }
}