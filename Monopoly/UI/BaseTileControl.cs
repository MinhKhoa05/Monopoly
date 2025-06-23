using System;
using System.Drawing;
using System.Windows.Forms;
using Monopoly.Tiles;

namespace Monopoly.UI
{
    public partial class BaseTileControl : UserControl
    {
        public ITile Tile { get; set; }
        public event EventHandler<TileClickedEventArgs> TileClicked;

        public BaseTileControl()
        {
            InitializeComponent();
        }

        public BaseTileControl(ITile tile) : this()
        {
            Tile = tile;
            //UpdateUI();
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            if (Tile != null)
            {
                TileClicked?.Invoke(this, new TileClickedEventArgs(Tile));
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            e.Control.Click += Tile_Click;
        }

        public void AddPlayerToken(string tokenSymbol, Color color)
        {
            Label tokenLabel = new Label();
            tokenLabel.Text = tokenSymbol;
            tokenLabel.Font = new Font("Segoe UI Emoji", 10F, FontStyle.Regular);
            tokenLabel.Size = new Size(25, 25);
            tokenLabel.ForeColor = color;
            tokenLabel.BackColor = Color.Transparent;
            tokenLabel.TextAlign = ContentAlignment.MiddleCenter;

            // Vị trí chia đều 4 góc
            int count = this.Controls.Count - 3;
            switch (count)
            {
                case 0:
                    tokenLabel.Location = new Point(0, 0); // Góc trái trên
                    break;
                case 1:
                    tokenLabel.Location = new Point(this.Width - tokenLabel.Width, 0); // Góc phải trên
                    break;
                case 2:
                    tokenLabel.Location = new Point(0, this.Height - tokenLabel.Height - 18); // Góc trái dưới
                    break;
                case 3:
                    tokenLabel.Location = new Point(this.Width - tokenLabel.Width, this.Height - tokenLabel.Height - 18); // Góc phải dưới
                    break;
                default:
                    tokenLabel.Location = new Point(10 * count, 10); // Tạm tính nếu trên 4 người
                    break;
            }

            this.Controls.Add(tokenLabel);
            tokenLabel.BringToFront(); // Đảm bảo token luôn hiển thị trên cùng

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
