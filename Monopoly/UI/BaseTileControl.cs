using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Monopoly.Tiles;

namespace Monopoly.UI
{
    public partial class BaseTileControl : UserControl
    {
        public ITile Tile { get; set; }
        public event EventHandler<TileClickedEventArgs> TileClicked;
        public List<Player> PlayerOnTile = new List<Player>();

        private Label[] playerTokens = new Label[4];

        public BaseTileControl()
        {
            InitializeComponent();
            InitializePlayerTokens();
        }

        public BaseTileControl(ITile tile) : this()
        {
            Tile = tile;
            UpdateUI();
        }

        private void InitializePlayerTokens()
        {
            for (int i = 0; i < 4; i++)
            {
                Label tokenLabel = new Label
                {
                    Font = new Font("Segoe UI Emoji", 10F, FontStyle.Regular),
                    Size = new Size(25, 25),
                    BackColor = Color.Transparent,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Visible = false // Ẩn ban đầu
                };

                // Đặt vị trí theo từng góc
                switch (i)
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
                }

                playerTokens[i] = tokenLabel;
                this.Controls.Add(tokenLabel);
                tokenLabel.BringToFront();
            }
        }

        public virtual void UpdateUI()
        {
            Color color = Color.Transparent;

            if (Tile != null)
            {
                color = Helper.LightenColor(Tile.TileColor);
            }

            this.BackColor = color;
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

        public void AddPlayerToken()
        {
            for (int i = 0; i < playerTokens.Length; i++)
            {
                if (i < PlayerOnTile.Count)
                {
                    var player = PlayerOnTile[i];
                    playerTokens[i].Text = player.Token;
                    playerTokens[i].ForeColor = player.Color;
                    playerTokens[i].Visible = true;
                }
                else
                {
                    playerTokens[i].Visible = false;
                }
            }
        }

        public void Add(Player player)
        {
            if (!PlayerOnTile.Contains(player))
                PlayerOnTile.Add(player);

            AddPlayerToken();
        }

        public void Remove(Player player)
        {
            PlayerOnTile.Remove(player);
            AddPlayerToken();
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
