using System.Collections.Generic;
using System.Drawing;

namespace Monopoly.Tiles
{
    public abstract class BaseTile : ITile
    {
        public string TileName { get; set; }
        public Color TileColor { get; set; }
        public List<Player> PlayersOnTile { get; set; } = new List<Player>(); // Danh sách người chơi trên ô này

        public BaseTile(string tileName, Color tileColor)
        {
            this.TileName = tileName;
            this.TileColor = tileColor;
        }

        public void OnEnter(Player player)
        {
            if (!PlayersOnTile.Contains(player))
            {
                PlayersOnTile.Add(player);
            }
        }

        public void OnLeave(Player player)
        {
            // Xóa người chơi khỏi danh sách nếu họ rời khỏi ô
            PlayersOnTile.Remove(player);
        }

        public void OnRender(Graphics g, Rectangle bounds)
        {
            DrawBorder(g, bounds);
            DrawTileColor(g, bounds);
            DrawTileContent(g, bounds);
            DrawPlayerMarker(g, bounds);
        }

        public virtual string GetInfo()
        {
            return $"Thông tin ô {TileName}";
            // Logic for when the tile is clicked, if needed
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

            for (int i = 0; i < PlayersOnTile.Count; i++)
            {
                var playerPos = playerPositions[PlayersOnTile[i].PlayerIndex];
                var playerRect = new Rectangle(playerPos.X, playerPos.Y, 10, 10);
                var playerColor = PlayersOnTile[i].Color;

                using (var brush = new SolidBrush(playerColor))
                {
                    g.FillRectangle(brush, playerRect);
                }
                g.DrawRectangle(Pens.Black, playerRect);
            }
        }
    }
}