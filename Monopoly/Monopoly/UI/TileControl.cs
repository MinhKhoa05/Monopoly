using System;
using System.Drawing;
using System.Windows.Forms;
using Monopoly.Tiles;

namespace Monopoly.UI
{
    public class TileControl : UserControl
    {
        private ITile tile;
        public event EventHandler<TileClickedEventArgs> TileClicked;

        public ITile Tile
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

        public TileControl(ITile tile) : this()
        {
            this.Tile = tile;
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

        public void OnEnter(Player player)
        {
            tile.OnEnter(player);
            Invalidate(); // Cập nhật giao diện khi có người chơi vào
        }

        public void OnLeave(Player player)
        {
            tile.OnLeave(player);
            Invalidate(); // Cập nhật giao diện khi có người chơi rời
        }
    }

    public class TileClickedEventArgs : EventArgs
    {
        public ITile Tile { get; }

        public TileClickedEventArgs(ITile tile)
        {
            Tile = tile;
        }
    }
}