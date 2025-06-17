using System.Collections.Generic;
using System.Drawing;

namespace Monopoly.Tiles
{
    public abstract class BaseTile : ITileComponent
    {
        public string TileName { get; set; }
        public Color TileColor { get; set; }

        private List<string> playersOnTile = new List<string>();
        private readonly Color[] playerColors = { Color.Red, Color.Blue, Color.Green, Color.Orange };

        public List<string> PlayersOnTile
        {
            get { return playersOnTile; }
            set { playersOnTile = value; }
        }

        public BaseTile(string tileName, Color tileColor)
        {
            this.TileName = tileName;
            this.TileColor = tileColor;
        }

        public abstract void OnEnter(Player player);

        public void OnRender(Graphics g, Rectangle bounds)
        {
            DrawBorder(g, bounds);
            DrawTileColor(g, bounds);
            DrawTileContent(g, bounds);
            DrawPlayerMarker(g, bounds);
        }

        protected virtual void DrawBorder(Graphics g, Rectangle bounds)
        {
            // Vẽ viền tile
            using (var pen = new Pen(Color.Black, 1))
            {
                g.DrawRectangle(pen, bounds.X, bounds.Y, bounds.Width - 1, bounds.Height - 1);
            }
        }

        protected abstract void DrawTileColor(Graphics g, Rectangle bounds);
        protected abstract void DrawTileContent(Graphics g, Rectangle bounds);

        protected virtual void DrawPlayerMarker(Graphics g, Rectangle bounds)
        {
            // Vẽ người chơi ở 4 góc phần chữ (chỉ cục màu) - nhỏ hơn
            var textAreaTop = 18;
            var textAreaBottom = 44;
            var textAreaLeft = 5;
            var textAreaRight = bounds.Width - 5;

            var playerPositions = new Point[]
            {
                new Point(textAreaLeft + 1, textAreaTop + 1),      // Góc trên trái
                new Point(textAreaRight - 11, textAreaTop + 1),     // Góc trên phải
                new Point(textAreaLeft + 1, textAreaBottom - 7),   // Góc dưới trái
                new Point(textAreaRight - 11, textAreaBottom - 7)   // Góc dưới phải
            };

            for (int i = 0; i < playersOnTile.Count && i < 4; i++)
            {
                var playerPos = playerPositions[i];
                var playerRect = new Rectangle(playerPos.X, playerPos.Y, 10, 10);

                var playerColor = playerColors[i % playersOnTile.Count];
                using (var brush = new SolidBrush(playerColor))
                {
                    g.FillRectangle(brush, playerRect);
                }
                g.DrawRectangle(Pens.Black, playerRect);
            }
        }
    }
}