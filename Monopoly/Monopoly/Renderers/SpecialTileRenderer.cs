using System.Drawing;
using Monopoly.Tiles;

namespace Monopoly.Renderers
{
    public class SpecialTileRenderer : BaseTileRenderer
    {
        protected override void RenderTileDetails(Graphics g, Rectangle bounds, ITile tile)
        {
            var specialTile = tile as SpecialTile;
            if (specialTile == null) return;

            // Icon ở giữa
            using (var font = new Font("Segoe UI Emoji", 16))
            {
                var iconRect = new Rectangle(0, 5, bounds.Width, 25);
                var format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(specialTile.Symbol, font, Brushes.Black, iconRect, format);
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
                g.DrawString(specialTile.TileName, font, Brushes.Black, textRect, format);
            }
        }
    }
}