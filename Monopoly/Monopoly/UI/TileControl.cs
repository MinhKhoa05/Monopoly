using System;
using System.Drawing;
using System.Windows.Forms;
using Monopoly.Tiles;

namespace Monopoly.UI
{
    public class TileControl : UserControl
    {
        private ITileComponent tile;
        public event EventHandler<TileClickedEventArgs> TileClicked;

        public ITileComponent Tile
        {
            get => tile;
            set
            {
                tile = value;
                Invalidate(); // Vẽ lại nếu đổi tile
            }
        }

        public TileControl()
        {
            this.DoubleBuffered = true;
            this.Width = 90;
            this.Height = 65;
            this.BackColor = Color.White;
        }

        public TileControl(ITileComponent tile) : this()
        {
            this.Tile = tile;
        }

        public void AddPlayerOnTile(Player player)
        {
            if (!tile.PlayersOnTile.Contains(player))
            {
                tile.PlayersOnTile.Add(player);
            }

            Invalidate(); // Vẽ lại để cập nhật người chơi trên tile
        }

        public void RemovePlayerOnTile(Player player)
        {
            if (tile.PlayersOnTile.Contains(player))
            {
                tile.PlayersOnTile.Remove(player);
                Invalidate(); // Vẽ lại để cập nhật người chơi trên tile
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (tile == null)
            {
                // Vẽ placeholder nếu chưa có tile
                using (var font = new Font("Segoe UI", 8f))
                {
                    e.Graphics.DrawString("Empty Tile", font, Brushes.Gray, new PointF(10, 10));
                }
                return;
            }

            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
            tile.OnRender(e.Graphics, bounds);
        }


        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if (Tile != null)
            {
                TileClicked?.Invoke(this, new TileClickedEventArgs(Tile));
            }
        }
    }

    public class TileClickedEventArgs : EventArgs
    {
        public ITileComponent Tile { get; }

        public TileClickedEventArgs(ITileComponent tile)
        {
            Tile = tile;
        }
    }
}