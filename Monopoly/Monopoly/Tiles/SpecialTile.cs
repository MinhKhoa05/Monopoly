using System.Drawing;

namespace Monopoly.Tiles
{
    internal class SpecialTile : BaseTile
    { 
        public string Icon { get; set; } = "⛳"; // Hoặc "🚓", "🛑", "🏛️"

        public SpecialTile(string tileName, Color tileColor, string icon) : base(tileName, tileColor)
        {
            this.Icon = icon;
        }

        public override void OnEnter(Player player) { }

        protected override void DrawTileColor(Graphics g, Rectangle bounds)
        {
            // Nền toàn tile
            using (var brush = new SolidBrush(TileColor))
            {
                g.FillRectangle(brush, 1, 1, bounds.Width - 2, bounds.Height - 2);
            }
        }

        protected override void DrawTileContent(Graphics g, Rectangle bounds)
        {
            // Vẽ tên tile
            using (var font = new Font("Segoe UI", 9, FontStyle.Bold))
            {
                var textRect = new Rectangle(5, 34, bounds.Width - 10, 24);
                var format = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(TileName, font, Brushes.Black, textRect, format);
            }

            // Vẽ icon giữa tile
            using (var font = new Font("Segoe UI Emoji", 16))
            {
                var iconRect = new Rectangle(0, 5, bounds.Width, 25);
                var format = new StringFormat() { Alignment = StringAlignment.Center };
                g.DrawString(Icon, font, Brushes.Black, iconRect, format);
            }
        }
    }
}
