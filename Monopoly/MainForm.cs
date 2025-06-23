using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monopoly.Tiles;
using Monopoly.UI;

namespace Monopoly
{
    public partial class MainForm : Form
    {
        private GameManager game;
        public PlayerInfoControl[] playerPanels = new PlayerInfoControl[4];
        public BaseTileControl[] tileControls = new BaseTileControl[40];
        
        public MainForm()
        {
            InitializeComponent();
            game = new GameManager();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitBoard();
            InitPlayerPanels();

            dice1.Image = game.Dices[0].Image;
            dice2.Image = game.Dices[1].Image;

            foreach (var player in game.Players)
            {
                tileControls[0].AddPlayerToken(player.Token, player.Color); // Thêm token cho người chơi đầu tiên 
            }

            //HighlightCurrentPlayer(); // Nổi bật người chơi hiện tại
        }

        private void InitBoard()
        {
            // Clear existing controls
            bottomPanel.Controls.Clear();
            leftPanel.Controls.Clear();
            topPanel.Controls.Clear();
            rightPanel.Controls.Clear();

            AddTilesToPanel(0, 11, DockStyle.Left, bottomPanel);
            AddTilesToPanel(11, 20, DockStyle.Top, leftPanel);
            AddTilesToPanel(20, 31, DockStyle.Right, topPanel);
            AddTilesToPanel(31, 40, DockStyle.Bottom, rightPanel);
        }

        private void InitPlayerPanels()
        {
            panelPlayer.Controls.Clear();

            for (int i = 0; i < game.Players.Length; i++)
            {
                playerPanels[i] = new PlayerInfoControl(game.Players[i]);
                playerPanels[i].Dock = DockStyle.Top;
            }

            for (int i = game.Players.Length - 1; i >= 0; i--)
            {
                panelPlayer.Controls.Add(playerPanels[i]);
            }
        }

        private void AddTilesToPanel(int start, int end, DockStyle dock, Panel panel)
        {
            BaseTileControl tileControl;
            for (int i = start; i < end; i++)
            {
                ITile tile = game.Board.Tiles[i];

                if (tile is PropertyTile)
                {
                    tileControl = new PropertyTileControl(tile);
                } else
                {
                    tileControl = new SpecialTileControl(tile);
                }

                tileControl.Dock = dock;
                panel.Controls.Add(tileControl);
                tileControl.TileClicked += OnTileClicked; // Đăng ký sự kiện khi người dùng click vào ô
                tileControls[i] = tileControl; // Lưu trữ TileControl để có thể truy cập sau này
            }
        }

        private void OnTileClicked(object sender, TileClickedEventArgs e)
        {
            UpdateTileInfoUI(e.Tile);
        }

        private void UpdateTileInfoUI(ITile tile)
        {
            if (tile == null) return;
            panelTileInfo.Visible = true;
            tileColor.BackColor = tile.TileColor; // Assuming ITileComponent has a TileColor property
            tileName.Text = "Ô: " + tile.TileName; // Assuming ITileComponent has a TileName property
            tileInfo.Text = tile.GetInfo();
        }

        private async void DiceRoll()
        {
            panelDice.Enabled = false;

            int rollCount = 10;
            int delay = 50;

            for (int i = 0; i < rollCount; i++)
            {
                // Hiệu ứng tung xúc xắc
                game.RollDices();
                dice1.Image = game.Dices[0].Image;
                dice2.Image = game.Dices[1].Image;
                await Task.Delay(delay);
            }

            game.PlayerTurn(); // Gọi hàm sẽ kích hoạt sự kiện PlayerMoved

            game.NextPlayer();
            //HighlightCurrentPlayer();

            panelDice.Enabled = true;
        }

        //private void HighlightCurrentPlayer()
        //{
        //    for (int i = 0; i < playerPanels.Length; i++)
        //    {
        //        playerPanels[i].UpdateUI();
        //        if (i == game.CurrentPlayerIndex)
        //        {
        //            playerPanels[i].PlayerTurned(); // Nổi bật người chơi hiện tại
        //        } else
        //        {
        //            playerPanels[i].PlayerFinishedTurn();
        //        }
        //    }
        //}

        private void dice1_Click(object sender, EventArgs e)
        {
            DiceRoll();
        }

        private void dice2_Click(object sender, EventArgs e)
        {
            DiceRoll();
        }
    }
}