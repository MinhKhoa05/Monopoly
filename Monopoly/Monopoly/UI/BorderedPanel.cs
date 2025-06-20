using System.Drawing;
using System.Windows.Forms;

namespace Monopoly.UI
{
    // Custom Panel với border
    public class BorderedPanel : Panel
    {
        private Color _borderColor = Color.Black;
        private int _borderWidth = 1;

        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                this.Invalidate();
            }
        }

        public int BorderWidth
        {
            get { return _borderWidth; }
            set
            {
                _borderWidth = value;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_borderWidth > 0)
            {
                using (Pen pen = new Pen(_borderColor, _borderWidth))
                {
                    Rectangle rect = new Rectangle(
                        _borderWidth / 2,
                        _borderWidth / 2,
                        this.Width - _borderWidth,
                        this.Height - _borderWidth
                    );
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }
    }
}
