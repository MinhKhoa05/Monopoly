using System.Drawing;
using System.Windows.Forms;
using Monopoly.Tiles;

namespace Monopoly
{
    public class TileControl : UserControl
    {
        private ITileComponent tile;

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
    }
}