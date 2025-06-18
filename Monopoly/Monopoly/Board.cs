using System;
using System.Drawing;
using System.Linq;
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

        private void dice1_Click(object sender, EventArgs e)
        {
            DiceRoll();
        }

        private void dice2_Click(object sender, EventArgs e)
        {
            DiceRoll();
        }

        private async void DiceRoll()
        {
            int rollCount = 10; // Số lần tung
            int delay = 50;     // Thời gian giữa mỗi lần tung (ms)

            for (int i = 0; i < rollCount; i++)
            {
                game.Dices[0].Roll();
                game.Dices[1].Roll();

                dice1.Image = game.Dices[0].Image;
                dice2.Image = game.Dices[1].Image;

                await Task.Delay(delay); // Đợi một chút để tạo hiệu ứng
            }

            UpdateTile();
        }

        public void UpdateTile()
        {
            Player currentPlayer = game.Players[game.CurrentPlayerIndex];
            int lastPosition = currentPlayer.Position;
            tileControls[lastPosition].OnLeave(currentPlayer); // Loại bỏ người chơi khỏi ô cũ

            // Cập nhật vị trí người chơi
            int value = game.Dices[0].Value + game.Dices[1].Value;
            currentPlayer.Position = (currentPlayer.Position + value); // Cập nhật vị trí người chơi

            if (currentPlayer.Position >= 40)
            {
                currentPlayer.Money += 200; // Nhận tiền khi qua ô bắt đầu
                currentPlayer.Position %= game.Tiles.Length; // Quay vòng nếu vượt quá
                MessageBox.Show($"{currentPlayer.Name} đã qua ô XUẤT PHÁT và nhận được 200 tiền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            tileControls[currentPlayer.Position].OnEnter(currentPlayer); // Cập nhật ô mới với người chơi
            playerPanels[game.CurrentPlayerIndex].UpdateUI(); // Cập nhật giao diện người chơi hiện tại

            game.CurrentPlayerIndex = (game.CurrentPlayerIndex + 1) % 4;
            HighlightCurrentPlayer(); // Nổi bật người chơi hiện tại
        }

        private void HighlightCurrentPlayer()
        {
            for (int i = 0; i < playerPanels.Length; i++)
            {
                if (i == game.CurrentPlayerIndex)
                {
                    playerPanels[i].PlayerTurned(); // Nổi bật người chơi hiện tại
                } else
                {
                    playerPanels[i].PlayerFinishedTurn();
                }
            }
        }

    }
}