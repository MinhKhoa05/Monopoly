using System;
using System.Drawing;
using System.Windows.Forms;
using Monopoly.Tiles;

namespace Monopoly.UI
{
    public partial class BaseTileControl : UserControl
    {
        private BaseTile _tile;
        private readonly Label[] _playerTokens = new Label[4];
        private const int TokenSize = 25;

        public BaseTile Tile
        {
            get => _tile;
            set {
                _tile = value;
                UpdateUI();
            }
        }

        public event EventHandler<TileClickedEventArgs> TileClicked;

        public BaseTileControl()
        {
            InitializeComponent();
            InitializePlayerTokens();
        }

        public BaseTileControl(BaseTile tile) : this()
        {
            Tile = tile;
        }

        private void InitializePlayerTokens()
        {
            Point[] positions =
            {
                new Point(0, 0),                               // Trái trên
                new Point(this.Width - TokenSize, 0),         // Phải trên
                new Point(0, this.Height - TokenSize - 18),   // Trái dưới
                new Point(this.Width - TokenSize, this.Height - TokenSize - 18) // Phải dưới
            };

            for (int i = 0; i < _playerTokens.Length; i++)
            {
                var token = new Label
                {
                    Font = new Font("Segoe UI Emoji", 10F, FontStyle.Regular),
                    Size = new Size(TokenSize, TokenSize),
                    Location = positions[i],
                    BackColor = Color.Transparent,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Visible = false
                };

                _playerTokens[i] = token;
                Controls.Add(token);
                token.BringToFront();
            }
        }

        public virtual void UpdateUI()
        {
            BackColor = Tile != null ? Tile.Color : Color.Transparent;
        }

        public void OnEnter(Player player)
        {
            Tile?.OnEnter(player);
            ShowToken(player);
        }

        public void ShowToken(Player player)
        {
            int index = player.Id;
            if (index >= 0 && index < 4)
            {
                var token = _playerTokens[index];
                token.Text = player.Token;
                token.ForeColor = player.Color;
                token.Visible = true;
            }
        }

        public void HideToken(Player player)
        {
            int index = player.Id;
            if (index >= 0 && index < 4)
            {
                _playerTokens[index].Visible = false;
            }
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            TileClicked?.Invoke(this, new TileClickedEventArgs(Tile));
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            e.Control.Click += Tile_Click;
        }
    }

    public class TileClickedEventArgs : EventArgs
    {
        public BaseTile Tile { get; }

        public TileClickedEventArgs(BaseTile tile) => Tile = tile;
    }
}
