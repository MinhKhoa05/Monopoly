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

        public Board()
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
            }
        }

        private void OnTileClicked(object sender, TileClickedEventArgs e)
        {
            UpdateTileInfoUI(e.Tile);
            game.Update();
        }

        private void UpdateTileInfoUI(ITileComponent tile)
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

            // Sau khi dừng, giữ kết quả cuối cùng (hoặc xử lý gì đó nếu cần)
            playerPanels[1].UpdatePlayer(100);
        }
    }
}