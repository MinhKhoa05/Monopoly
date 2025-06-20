using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Monopoly.Tiles;

namespace Monopoly.Renderers
{
    public class PropertyTileRenderer : ITileRenderer
    {
        public void Render(ITile tile, Graphics g, Rectangle bounds)
        {
            var property = tile as PropertyTile;
            if (property == null) return;

            DrawBorder(g, bounds);
            DrawTileColor(g, bounds, property.TileColor);
            DrawTileContent(g, bounds, property);
            DrawPlayerMarkers(g, bounds, property);
        }

        private void DrawBorder(Graphics g, Rectangle bounds)
        {
            using (var pen = new Pen(Color.Black, 1))
            {
                g.DrawRectangle(pen, bounds.X, bounds.Y, bounds.Width - 1, bounds.Height - 1);
            }
        }

        private void DrawTileColor(Graphics g, Rectangle bounds, Color tileColor)
        {
            //// Làm sáng màu tile lên
            //var lightColor = Color.FromArgb(
            //    Math.Min(255, tileColor.R + 60),
            //    Math.Min(255, tileColor.G + 60),
            //    Math.Min(255, tileColor.B + 60)
            //);

            using (var brush = new SolidBrush(tileColor))
            {
                g.FillRectangle(brush, 1, 1, bounds.Width - 2, bounds.Height - 2);
            }
        }

        private void DrawTileContent(Graphics g, Rectangle bounds, PropertyTile property)
        {
            // Tên ô
            using (var font = new Font("Segoe UI", 9f, FontStyle.Bold))
            {
                var textRect = new Rectangle(5, 10, bounds.Width - 10, 16);
                var format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString(property.TileName, font, Brushes.Black, textRect, format);
            }

            // Giá
            using (var font = new Font("Segoe UI", 8f))
            {
                var priceRect = new Rectangle(5, 30, bounds.Width - 10, 12);
                var format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString("$" + property.Price, font, Brushes.Black, priceRect, format);
            }

            DrawHouses(g, bounds, property);
        }

        private void DrawHouses(Graphics g, Rectangle bounds, PropertyTile property)
        {
            // Khung to hơn giống như color strip, bo tròn nhẹ
            var frameRect = new Rectangle(1, bounds.Height - 20, bounds.Width - 2, 20);
            var radius = 4;

            using (var path = new GraphicsPath())
            {
                path.StartFigure();
                path.AddArc(frameRect.X, frameRect.Y, radius, radius, 180, 90);
                path.AddArc(frameRect.Right - radius, frameRect.Y, radius, radius, 270, 90);
                path.AddArc(frameRect.Right - radius, frameRect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(frameRect.X, frameRect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                // 🟢 Nếu có chủ, dùng màu chủ sở hữu
                Brush fillBrush = Brushes.Silver;
                if (property.Owner != null)
                {
                    fillBrush = new SolidBrush(property.Owner.Color);
                }

                g.FillPath(fillBrush, path);
                g.DrawPath(Pens.Gray, path);
            }

            // Nhà to hơn và chia đều 4 chỗ
            int frameWidth = frameRect.Width;
            int houseWidth = frameWidth / 4;
            int houseSize = Math.Min(houseWidth - 4, 12); // To hơn, tối đa 12px

            for (int i = 0; i < property.HouseCount && i < 4; i++)
            {
                int houseX = frameRect.X + (i * houseWidth) + (houseWidth - houseSize) / 2;
                int houseY = frameRect.Y + (frameRect.Height - houseSize) / 2;
                var houseRect = new Rectangle(houseX, houseY, houseSize, houseSize);

                g.FillRectangle(Brushes.LimeGreen, houseRect);
                g.DrawRectangle(Pens.DarkGreen, houseRect);
            }
        }

        private void DrawPlayerMarkers(Graphics g, Rectangle bounds, PropertyTile tile)
        {
            int textAreaTop = 18;
            int textAreaBottom = 44;
            int textAreaLeft = 5;
            int textAreaRight = bounds.Width - 5;

            Point[] positions = new Point[]
            {
                new Point(textAreaLeft + 1, textAreaTop + 1),
                new Point(textAreaRight - 11, textAreaTop + 1),
                new Point(textAreaLeft + 1, textAreaBottom - 7),
                new Point(textAreaRight - 11, textAreaBottom - 7)
            };

            for (int i = 0; i < tile.PlayersOnTile.Count; i++)
            {
                var player = tile.PlayersOnTile[i];
                int idx = player.Index;
                if (idx < 0 || idx >= positions.Length) continue;

                var pos = positions[idx];
                var playerRect = new Rectangle(pos.X, pos.Y, 10, 10);

                using (var brush = new SolidBrush(player.Color))
                {
                    g.FillRectangle(brush, playerRect);
                }
                g.DrawRectangle(Pens.Black, playerRect);
            }
        }
    }
}