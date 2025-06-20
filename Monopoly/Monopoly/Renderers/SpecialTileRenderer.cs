using System.Drawing;
using Monopoly.Tiles;

namespace Monopoly.Renderers
{
    public class SpecialTileRenderer : ITileRenderer
    {
        public void Render(ITile tile, Graphics g, Rectangle bounds)
        {
            var special = tile as SpecialTile;
            if (special == null) return;

            DrawBorder(g, bounds);
            DrawTileColor(g, bounds, special.TileColor);
            DrawTileContent(g, bounds, special);
            DrawPlayerMarkers(g, bounds, special);
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
            using (var brush = new SolidBrush(tileColor))
            {
                g.FillRectangle(brush, 1, 1, bounds.Width - 2, bounds.Height - 2);
            }
        }

        private void DrawTileContent(Graphics g, Rectangle bounds, SpecialTile tile)
        {
            // Icon ở giữa
            using (var font = new Font("Segoe UI Emoji", 16))
            {
                var iconRect = new Rectangle(0, 5, bounds.Width, 25);
                var format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(tile.Symbol, font, Brushes.Black, iconRect, format);
            }

            // Tên tile bên dưới
            using (var font = new Font("Segoe UI", 9, FontStyle.Bold))
            {
                var textRect = new Rectangle(5, 34, bounds.Width - 10, 24);
                var format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(tile.TileName, font, Brushes.Black, textRect, format);
            }
        }

        private void DrawPlayerMarkers(Graphics g, Rectangle bounds, BaseTile tile)
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
                var rect = new Rectangle(pos.X, pos.Y, 10, 10);

                using (var brush = new SolidBrush(player.Color))
                {
                    g.FillRectangle(brush, rect);
                }
                g.DrawRectangle(Pens.Black, rect);
            }
        }
    }
}
