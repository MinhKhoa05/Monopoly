using System;
using System.Drawing;
using System.Windows.Forms;
using Monopoly.Tiles;

namespace Monopoly.UI
{
    public class SpecialTilePanel : Panel
    {
        private SpecialTile _specialTile;
        private bool _isSelected;

        public SpecialTile SpecialTile
        {
            get => _specialTile;
            set
            {
                _specialTile = value;
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

        public SpecialTilePanel()
        {
            InitializeComponent(new SpecialTile("GO", Color.LightGreen, "🏁"));
        }

        public SpecialTilePanel(SpecialTile specialTile)
        {
            InitializeComponent(specialTile);
        }

        private void InitializeComponent(SpecialTile specialTile)
        {
            this.Size = new Size(90, 65);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint |
                         ControlStyles.DoubleBuffer |
                         ControlStyles.ResizeRedraw, true);

            _specialTile = specialTile;
            _isSelected = false;

            // Enable mouse events for selection
            this.Click += OnClick;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_specialTile == null) return;

            var g = e.Graphics;
            var bounds = this.ClientRectangle;

            // Vẽ border
            DrawBorder(g, bounds);

            // Vẽ màu nền tile
            DrawTileColor(g, bounds, _specialTile.TileColor);

            // Vẽ nội dung tile
            DrawTileContent(g, bounds, _specialTile);

            // Vẽ player markers
            DrawPlayerMarkers(g, bounds, _specialTile);
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

        private void DrawTileContent(Graphics g, Rectangle bounds, SpecialTile tile)
        {
            // Icon ở giữa
            using (var font = new Font("Segoe UI Emoji", 16))
            {
                var iconRect = new Rectangle(0, 5, bounds.Width, 25);
                var format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(tile.Symbol, font, Brushes.Black, iconRect, format);
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
                g.DrawString(tile.TileName, font, Brushes.Black, textRect, format);
            }
        }

        private void DrawPlayerMarkers(Graphics g, Rectangle bounds, BaseTile tile)
        {
            if (tile.PlayersOnTile == null) return;

            int textAreaTop = 18;
            int textAreaBottom = 44;
            int textAreaLeft = 5;
            int textAreaRight = bounds.Width - 5;

            Point[] positions = new Point[]
            {
                new Point(textAreaLeft + 1, textAreaTop + 1),
                new Point(textAreaRight - 11, textAreaTop + 1),
                new Point(textAreaLeft + 1, textAreaBottom - 7),
                new Point(textAreaRight - 11, textAreaBottom - 7)
            };

            for (int i = 0; i < tile.PlayersOnTile.Count; i++)
            {
                var player = tile.PlayersOnTile[i];
                int idx = player.Index;
                if (idx < 0 || idx >= positions.Length) continue;

                var pos = positions[idx];
                var rect = new Rectangle(pos.X, pos.Y, 10, 10);

                using (var brush = new SolidBrush(player.Color))
                {
                    g.FillRectangle(brush, rect);
                }
                g.DrawRectangle(Pens.Black, rect);
            }
        }

        private void OnClick(object sender, EventArgs e)
        {
            IsSelected = !IsSelected;
            // Có thể thêm event để thông báo selection changed
            OnSpecialTileSelected();
        }

        protected virtual void OnSpecialTileSelected()
        {
            // Override này để handle selection event
        }

        public void UpdateSpecialTile()
        {
            this.Invalidate(); // Trigger repaint
        }
    }
}