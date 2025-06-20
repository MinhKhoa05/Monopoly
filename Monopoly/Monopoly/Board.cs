using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monopoly.Tiles;
using Monopoly.UI;

namespace Monopoly
{
    public partial class Board : Form
    {
        private GameManager game;
        public PlayerPanel[] playerPanels = new PlayerPanel[4];
        public TileControl[] tileControls = new TileControl[40];

        public Board()
        {
            InitializeComponent();
            game = new GameManager();

            // Sự kiện khi clik vào vùng không phải ô thì ẩn PanelTileInfo
            this.boardPanel.Click += (s, e) => 
            {
                if (panelTileInfo.Visible)
                {
                    panelTileInfo.Visible = false;
                }
            };

            game.PlayerMoved += OnPlayerMoved; // Đăng ký sự kiện PlayerMoved
        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitBoard();
            InitPlayerPanels();

            dice1.Image = game.Dices[0].Image;
            dice2.Image = game.Dices[1].Image;

            foreach (var player in game.Players)
            {
                int pos = player.Position; // Đặt vị trí ban đầu cho người chơi
                tileControls[pos].OnEnter(player); // Đặt người chơi vào ô ban đầu
            }

            HighlightCurrentPlayer(); // Nổi bật người chơi hiện tại
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
                playerPanels[i] = new PlayerPanel(game.Players[i]);
            }

            for (int i = game.Players.Length - 1; i >= 0; i--)
            {
                panelPlayer.Controls.Add(playerPanels[i]);
            }
        }

        private void AddTilesToPanel(int start, int end, DockStyle dock, Panel panel)
        {
            TileControl tileControl;
            for (int i = start; i < end; i++)
            {
                tileControl = new TileControl(game.Tiles[i]);
                tileControl.TileClicked += OnTileClicked;
                tileControl.Dock = dock;
                panel.Controls.Add(tileControl);
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
            if (!panelTileInfo.Visible)
            {
                panelTileInfo.Visible = true;
            }

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
            HighlightCurrentPlayer();

            panelDice.Enabled = true;
        }

        private void HighlightCurrentPlayer()
        {
            for (int i = 0; i < playerPanels.Length; i++)
            {
                playerPanels[i].UpdateUI();
                if (i == game.CurrentPlayerIndex)
                {
                    playerPanels[i].PlayerTurned(); // Nổi bật người chơi hiện tại
                } else
                {
                    playerPanels[i].PlayerFinishedTurn();
                }
            }
        }

        private void dice1_Click(object sender, EventArgs e)
        {
            DiceRoll();
        }

        private void OnPlayerMoved(object sender, PlayerMovedEventArgs e)
        {
            tileControls[e.From].OnLeave(e.Player);    // Rời tile cũ
            tileControls[e.To].OnEnter(e.Player);      // Vào tile mới

            playerPanels[e.Player.Index].UpdateUI();   // Cập nhật tiền, vị trí v.v...
        }

        private void dice2_Click(object sender, EventArgs e)
        {
            DiceRoll();
        }
    }
}