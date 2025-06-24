using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monopoly.Tiles;
using Monopoly.UI;

namespace Monopoly
{
    public partial class MainForm : Form
    {
        private readonly GameManager _gameManager = new GameManager();
        private readonly PlayerInfoControl[] _playerInfoControls = new PlayerInfoControl[4];

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeBoardUI();
            InitializePlayerPanels();
            UpdateDiceImages();
            HighlightActivePlayer();

            // Sự kiện xúc xắc thay đổi ảnh tự động
            _gameManager.Dices[0].Rolled += (s, _) => dice1Image.Image = _gameManager.Dices[0].Image;
            _gameManager.Dices[1].Rolled += (s, _) => dice2Image.Image = _gameManager.Dices[1].Image;
        }

        private void InitializeBoardUI()
        {
            bottomPanel.Controls.Clear();
            leftPanel.Controls.Clear();
            topPanel.Controls.Clear();
            rightPanel.Controls.Clear();

            AddTilesToPanel(0, 11, DockStyle.Left, bottomPanel);
            AddTilesToPanel(11, 20, DockStyle.Top, leftPanel);
            AddTilesToPanel(20, 31, DockStyle.Right, topPanel);
            AddTilesToPanel(31, 40, DockStyle.Bottom, rightPanel);
        }

        private void InitializePlayerPanels()
        {
            panelPlayer.Controls.Clear();

            for (int i = _gameManager.Players.Length - 1; i >= 0; i--)
            {
                _playerInfoControls[i] = new PlayerInfoControl(_gameManager.Players[i]);
                panelPlayer.Controls.Add(_playerInfoControls[i]);
            }
        }

        private void UpdateDiceImages()
        {
            dice1Image.Image = _gameManager.Dices[0].Image;
            dice2Image.Image = _gameManager.Dices[1].Image;
        }

        private void AddTilesToPanel(int startIndex, int endIndex, DockStyle dockStyle, Panel targetPanel)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                var tileControl = _gameManager.Board.TileControls[i];
                tileControl.Dock = dockStyle;
                tileControl.TileClicked += TileControl_TileClicked;
                targetPanel.Controls.Add(tileControl);
            }
        }

        private void TileControl_TileClicked(object sender, TileClickedEventArgs e)
        {
            ShowTileInfo(e.Tile);
        }

        private void ShowTileInfo(BaseTile tile)
        {
            tileInfoControl1.Tile = tile;
        }

        private async void RollDiceWithAnimation()
        {
            panelDice.Enabled = false;

            const int totalRolls = 10;
            const int rollDelay = 50;

            await Task.WhenAll(
                _gameManager.Dices[0].RollWithEffect(totalRolls, rollDelay),
                _gameManager.Dices[1].RollWithEffect(totalRolls, rollDelay)
            );

            _gameManager.ExecutePlayerTurn();
            HighlightActivePlayer();

            _gameManager.NextPlayerTurn();
            HighlightActivePlayer();

            panelDice.Enabled = true;
        }

        private void HighlightActivePlayer()
        {
            for (int i = 0; i < _playerInfoControls.Length; i++)
            {
                if (_playerInfoControls[i] == null) continue;

                _playerInfoControls[i].IsCurrentPlayer = (i == _gameManager.CurrentPlayerIndex);
                _playerInfoControls[i].UpdatePlayerUI();
            }
        }

        private void panelDice_Click(object sender, EventArgs e) => RollDiceWithAnimation();
    }
}
