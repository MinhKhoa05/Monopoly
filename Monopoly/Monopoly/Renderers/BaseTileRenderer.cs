using System.Collections.Generic;
using System.Drawing;
using Monopoly.Tiles;

namespace Monopoly.Renderers
{
    /// <summary>
    /// Lớp cơ sở để vẽ một ô trên bàn cờ Monopoly.
    /// </summary>
    public abstract class BaseTileRenderer
    {
        /// <summary>
        /// Vẽ ô: nền, nội dung cụ thể, và người chơi trên ô.
        /// </summary>
        public void RenderTile(Graphics g, Rectangle bounds, ITile tile, List<Player> playersOn = null)
        {
            RenderTileBackground(g, bounds, tile.TileColor);
            RenderTileDetails(g, bounds, tile);
            DrawHouses(g, bounds, tile);

            if (playersOn != null && playersOn.Count > 0)
            {
                DrawPlayersOnTile(g, bounds, playersOn);
            }
        }

        private void RenderTileBackground(Graphics g, Rectangle bounds, Color tileColor)
        {
            using (var pen = new Pen(Color.Black, 1))
            {
                g.DrawRectangle(pen, bounds.X, bounds.Y, bounds.Width - 1, bounds.Height - 1);
            }

            using (var brush = new SolidBrush(tileColor))
            {
                g.FillRectangle(brush, 1, 1, bounds.Width - 2, bounds.Height - 2);
            }
        }

        /// <summary>
        /// Vẽ nội dung riêng của từng loại ô (do lớp con định nghĩa).
        /// </summary>
        protected abstract void RenderTileDetails(Graphics g, Rectangle bounds, ITile tile);

        protected virtual void DrawHouses(Graphics g, Rectangle bounds, ITile tile) { }

        /// <summary>
        /// Vẽ tối đa 4 quân cờ người chơi lên ô.
        /// </summary>
        private void DrawPlayersOnTile(Graphics g, Rectangle bounds, List<Player> players)
        {
            int top = 14, bottom = 32, left = 6, right = bounds.Width - 16;

            Point[] positions = new Point[]
            {
                new Point(left, top),
                new Point(right, top),
                new Point(left, bottom),
                new Point(right, bottom)
            };

            for (int i = 0; i < players.Count && i < positions.Length; i++)
            {
                var rect = new Rectangle(positions[i].X, positions[i].Y, 10, 10);

                using (var brush = new SolidBrush(players[i].Color))
                {
                    g.FillRectangle(brush, rect);
                }

                g.DrawRectangle(Pens.Black, rect);
            }
        }
    }
}
