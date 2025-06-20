using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Monopoly.Tiles;

namespace Monopoly.UI
{
    public class PropertyTilePanel : Panel
    {
        private PropertyTile _property;
        private bool _isSelected;

        public PropertyTile Property
        {
            get => _property;
            set
            {
                _property = value;
                this.Invalidate(); // Trigger repaint
            }
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                this.Invalidate(); // Trigger repaint
            }
        }

        public PropertyTilePanel()
        {
            InitializeComponent(new PropertyTile("QUẢNG NINH", Color.Red, 1000, 1));
        }

        public PropertyTilePanel(PropertyTile property)
        {
            InitializeComponent(property);
        }

        private void InitializeComponent(PropertyTile property)
        {
            this.Size = new Size(90, 65);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint |
                         ControlStyles.DoubleBuffer |
                         ControlStyles.ResizeRedraw, true);

            _property = property;
            _isSelected = false;

            // Enable mouse events for selection
            this.Click += OnClick;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_property == null) return;

            var g = e.Graphics;
            var bounds = this.ClientRectangle;

            // Vẽ border
            DrawBorder(g, bounds);

            // Vẽ màu nền tile
            DrawTileColor(g, bounds, _property.TileColor);

            // Vẽ nội dung tile
            DrawTileContent(g, bounds, _property);

            // Vẽ player markers
            DrawPlayerMarkers(g, bounds, _property);
        }

        private void DrawBorder(Graphics g, Rectangle bounds)
        {
            using (var pen = new Pen(_isSelected ? Color.Blue : Color.Black, _isSelected ? 2 : 1))
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

        private void DrawTileContent(Graphics g, Rectangle bounds, PropertyTile property)
        {
            // Tên ô
            using (var font = new Font("Segoe UI", 9f, FontStyle.Bold))
            {
                var textRect = new Rectangle(2, 10, bounds.Width - 4, 16);
                var format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString(property.TileName, font, Brushes.Black, textRect, format);
            }

            // Giá
            using (var font = new Font("Segoe UI", 8f))
            {
                var priceRect = new Rectangle(2, 28, bounds.Width - 4, 12);
                var format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString("$" + property.Price, font, Brushes.Black, priceRect, format);
            }

            DrawHouses(g, bounds, property);
        }

        private void DrawHouses(Graphics g, Rectangle bounds, PropertyTile property)
        {
            // Khung owner strip ở dưới, bo tròn nhẹ
            var frameRect = new Rectangle(1, bounds.Height - 20, bounds.Width - 2, 20);
            var radius = 4;

            using (var path = new GraphicsPath())
            {
                path.StartFigure();
                path.AddArc(frameRect.X, frameRect.Y, radius, radius, 180, 90);
                path.AddArc(frameRect.Right - radius, frameRect.Y, radius, radius, 270, 90);
                path.AddArc(frameRect.Right - radius, frameRect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(frameRect.X, frameRect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                // Nếu có chủ, dùng màu chủ sở hữu
                Brush fillBrush = Brushes.Silver;
                if (property.Owner != null)
                {
                    fillBrush = new SolidBrush(property.Owner.Color);
                }

                g.FillPath(fillBrush, path);
                g.DrawPath(Pens.Gray, path);

                if (fillBrush != Brushes.Silver)
                    fillBrush.Dispose();
            }

            // Vẽ nhà
            int frameWidth = frameRect.Width;
            int houseWidth = frameWidth / 4;
            int houseSize = Math.Min(houseWidth - 4, 12);

            for (int i = 0; i < property.HouseCount && i < 4; i++)
            {
                int houseX = frameRect.X + (i * houseWidth) + (houseWidth - houseSize) / 2;
                int houseY = frameRect.Y + (frameRect.Height - houseSize) / 2;
                var houseRect = new Rectangle(houseX, houseY, houseSize, houseSize);

                g.FillRectangle(Brushes.LimeGreen, houseRect);
                g.DrawRectangle(Pens.DarkGreen, houseRect);
            }
        }

        private void DrawPlayerMarkers(Graphics g, Rectangle bounds, PropertyTile tile)
        {
            if (tile.PlayersOnTile == null) return;

            int textAreaTop = 18;
            int textAreaBottom = 44;
            int textAreaLeft = 5;
            int textAreaRight = bounds.Width - 5;

            Point[] positions = new Point[]
            {
                new Point(textAreaLeft + 1, textAreaTop - 4),
                new Point(textAreaRight - 11, textAreaTop - 4),
                new Point(textAreaLeft + 1, textAreaBottom - 12),
                new Point(textAreaRight - 11, textAreaBottom - 12)
            };

            for (int i = 0; i < tile.PlayersOnTile.Count; i++)
            {
                var player = tile.PlayersOnTile[i];
                int idx = player.Index;
                if (idx < 0 || idx >= positions.Length) continue;

                var pos = positions[idx];
                var playerRect = new Rectangle(pos.X, pos.Y, 10, 10);

                using (var brush = new SolidBrush(player.Color))
                {
                    g.FillRectangle(brush, playerRect);
                }
                g.DrawRectangle(Pens.Black, playerRect);
            }
        }

        private void OnClick(object sender, EventArgs e)
        {
            IsSelected = !IsSelected;
            // Có thể thêm event để thông báo selection changed
            OnPropertySelected();
        }

        protected virtual void OnPropertySelected()
        {
            // Override này để handle selection event
        }

        public void UpdateProperty()
        {
            this.Invalidate(); // Trigger repaint
        }
    }
}