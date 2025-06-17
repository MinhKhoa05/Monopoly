using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Monopoly.Tiles;

namespace Monopoly
{
    public partial class Form1 : Form
    {
        private TileControl[] tiles = new TileControl[40];
        private List<Player> players = new List<Player>();
        private int currentPlayerIndex = 0;
        private Random dice = new Random();
        private bool gameStarted = false;

        // Game state
        private int freeParkingMoney = 0;
        private Dictionary<Color, List<int>> propertyGroups;

        public Form1()
        {
            InitializeComponent();
            InitializePropertyGroups();
            InitializePlayers();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitBoard();
            UpdatePlayerDisplay();
            SetupGameControls();
        }

        #region Initialization Methods

        private void InitializePropertyGroups()
        {
            propertyGroups = new Dictionary<Color, List<int>>
            {
                { Color.SaddleBrown, new List<int> { 1, 3 } },
                { Color.LightSkyBlue, new List<int> { 6, 8, 9 } },
                { Color.HotPink, new List<int> { 11, 13, 14 } },
                { Color.Orange, new List<int> { 16, 18, 19 } },
                { Color.Red, new List<int> { 21, 23, 24 } },
                { Color.Yellow, new List<int> { 26, 27, 29 } },
                { Color.Green, new List<int> { 31, 32, 34 } },
                { Color.DarkBlue, new List<int> { 37, 39 } }
            };
        }

        private void InitializePlayers()
        {
            // Initialize 4 players with different colors
            players.Add(new Player("Người chơi 1", Color.Red, 15000));
            players.Add(new Player("Người chơi 2", Color.Yellow, 15000));
            players.Add(new Player("Người chơi 3", Color.Lime, 15000));
            players.Add(new Player("Người chơi 4", Color.Aqua, 15000));

            // Place all players at GO position
            foreach (var player in players)
            {
                player.Position = 0;
            }
        }

        private void SetupGameControls()
        {
            // Add game control buttons to panel11
            panel11.Controls.Clear();

            var rollDiceBtn = new Button
            {
                Text = "🎲 Tung Xúc Xắc",
                Size = new Size(150, 40),
                Location = new Point(10, 10),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                BackColor = Color.LightGreen,
                FlatStyle = FlatStyle.Flat
            };
            rollDiceBtn.Click += RollDice_Click;
            panel11.Controls.Add(rollDiceBtn);

            var buyPropertyBtn = new Button
            {
                Text = "💰 Mua Tài Sản",
                Size = new Size(150, 40),
                Location = new Point(170, 10),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                BackColor = Color.LightBlue,
                FlatStyle = FlatStyle.Flat,
                Enabled = false
            };
            buyPropertyBtn.Click += BuyProperty_Click;
            panel11.Controls.Add(buyPropertyBtn);

            var endTurnBtn = new Button
            {
                Text = "⏭️ Kết Thúc Lượt",
                Size = new Size(150, 40),
                Location = new Point(330, 10),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                BackColor = Color.LightCoral,
                FlatStyle = FlatStyle.Flat
            };
            endTurnBtn.Click += EndTurn_Click;
            panel11.Controls.Add(endTurnBtn);

            // Game info display
            var gameInfoLabel = new Label
            {
                Text = "Lượt của: " + players[currentPlayerIndex].Name,
                Size = new Size(400, 30),
                Location = new Point(10, 60),
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = players[currentPlayerIndex].Color
            };
            gameInfoLabel.Name = "gameInfoLabel";
            panel11.Controls.Add(gameInfoLabel);

            // Dice result display
            var diceLabel = new Label
            {
                Text = "Kết quả xúc xắc: --",
                Size = new Size(200, 25),
                Location = new Point(10, 95),
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.DarkBlue
            };
            diceLabel.Name = "diceLabel";
            panel11.Controls.Add(diceLabel);

            // Property info display
            var propInfoLabel = new Label
            {
                Text = "Chọn một ô để xem thông tin",
                Size = new Size(400, 80),
                Location = new Point(10, 125),
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.Black
            };
            propInfoLabel.Name = "propInfoLabel";
            panel11.Controls.Add(propInfoLabel);
        }

        #endregion

        #region Board Creation Methods

        private void InitBoard()
        {
            // Clear existing controls
            bottomPanel.Controls.Clear();
            leftPanel.Controls.Clear();
            topPanel.Controls.Clear();
            rightPanel.Controls.Clear();

            CreateBottomTiles();
            CreateLeftTiles();
            CreateTopTiles();
            CreateRightTiles();

            // Add click events to all tiles
            for (int i = 0; i < 40; i++)
            {
                if (tiles[i] != null)
                {
                    tiles[i].Click += Tile_Click;
                    tiles[i].Tag = i; // Store tile index
                }
            }
        }

        private void CreateBottomTiles()
        {
            var bottomTileData = new[]
            {
                new { Type = "Special", Name = "BẮT ĐẦU", Color = Color.LightYellow, Icon = "⛳", Price = 0, Rent = 0 },
                new { Type = "Property", Name = "CHÂU ĐỐC", Color = Color.SaddleBrown, Icon = "", Price = 600, Rent = 20 },
                new { Type = "Special", Name = "KHÍ VẬN", Color = Color.LightBlue, Icon = "❓", Price = 0, Rent = 0 },
                new { Type = "Property", Name = "CẦN THƠ", Color = Color.SaddleBrown, Icon = "", Price = 600, Rent = 40 },
                new { Type = "Special", Name = "THUẾ THU NHẬP", Color = Color.LightGray, Icon = "💰", Price = 2000, Rent = 0 },
                new { Type = "Railroad", Name = "GA TÀU 1", Color = Color.Black, Icon = "🚂", Price = 2000, Rent = 250 },
                new { Type = "Property", Name = "NHA TRANG", Color = Color.LightSkyBlue, Icon = "", Price = 1000, Rent = 60 },
                new { Type = "Special", Name = "CƠ HỘI", Color = Color.Orange, Icon = "❗", Price = 0, Rent = 0 },
                new { Type = "Property", Name = "ĐÀ LẠT", Color = Color.LightSkyBlue, Icon = "", Price = 1000, Rent = 60 },
                new { Type = "Property", Name = "HUẾ", Color = Color.LightSkyBlue, Icon = "", Price = 1200, Rent = 80 },
                new { Type = "Special", Name = "TÙ", Color = Color.Orange, Icon = "🚓", Price = 0, Rent = 0 }
            };

            CreateTilesFromData(bottomTileData, bottomPanel, DockStyle.Right, 0);
        }

        private void CreateLeftTiles()
        {
            var leftTileData = new[]
            {
                new { Type = "Property", Name = "HÀ NỘI", Color = Color.HotPink, Icon = "", Price = 1400, Rent = 100 },
                new { Type = "Utility", Name = "ĐIỆN LỰC", Color = Color.White, Icon = "⚡", Price = 1500, Rent = 0 },
                new { Type = "Property", Name = "TP HCM", Color = Color.HotPink, Icon = "", Price = 1400, Rent = 100 },
                new { Type = "Property", Name = "VŨNG TÀU", Color = Color.HotPink, Icon = "", Price = 1600, Rent = 120 },
                new { Type = "Railroad", Name = "GA TÀU 2", Color = Color.Black, Icon = "🚂", Price = 2000, Rent = 250 },
                new { Type = "Property", Name = "PHAN THIẾT", Color = Color.Orange, Icon = "", Price = 1800, Rent = 140 },
                new { Type = "Special", Name = "KHÍ VẬN", Color = Color.LightBlue, Icon = "❓", Price = 0, Rent = 0 },
                new { Type = "Property", Name = "SAPA", Color = Color.Orange, Icon = "", Price = 1800, Rent = 140 },
                new { Type = "Property", Name = "HẠ LONG", Color = Color.Orange, Icon = "", Price = 2000, Rent = 160 }
            };

            CreateTilesFromData(leftTileData, leftPanel, DockStyle.Bottom, 11);
        }

        private void CreateTopTiles()
        {
            var topTileData = new[]
            {
                new { Type = "Special", Name = "ĐỖ XE MIỄN PHÍ", Color = Color.Red, Icon = "🅿️", Price = 0, Rent = 0 },
                new { Type = "Property", Name = "PHÚ QUỐC", Color = Color.Red, Icon = "", Price = 2200, Rent = 180 },
                new { Type = "Special", Name = "CƠ HỘI", Color = Color.Orange, Icon = "❗", Price = 0, Rent = 0 },
                new { Type = "Property", Name = "HẢI PHÒNG", Color = Color.Red, Icon = "", Price = 2200, Rent = 180 },
                new { Type = "Property", Name = "HỘI AN", Color = Color.Red, Icon = "", Price = 2400, Rent = 200 },
                new { Type = "Railroad", Name = "GA TÀU 3", Color = Color.Black, Icon = "🚂", Price = 2000, Rent = 250 },
                new { Type = "Property", Name = "BÌNH DƯƠNG", Color = Color.Yellow, Icon = "", Price = 2600, Rent = 220 },
                new { Type = "Property", Name = "BÌNH THUẬN", Color = Color.Yellow, Icon = "", Price = 2600, Rent = 220 },
                new { Type = "Utility", Name = "NƯỚC SẠCH", Color = Color.White, Icon = "💧", Price = 1500, Rent = 0 },
                new { Type = "Property", Name = "LONG AN", Color = Color.Yellow, Icon = "", Price = 2800, Rent = 240 },
                new { Type = "Special", Name = "VÀO TÙ", Color = Color.Red, Icon = "👮", Price = 0, Rent = 0 }
            };

            CreateTilesFromData(topTileData, topPanel, DockStyle.Left, 20);
        }

        private void CreateRightTiles()
        {
            var rightTileData = new[]
            {
                new { Type = "Property", Name = "NAM ĐỊNH", Color = Color.Green, Icon = "", Price = 3000, Rent = 260 },
                new { Type = "Property", Name = "QUẢNG NINH", Color = Color.Green, Icon = "", Price = 3000, Rent = 260 },
                new { Type = "Special", Name = "KHÍ VẬN", Color = Color.LightBlue, Icon = "❓", Price = 0, Rent = 0 },
                new { Type = "Property", Name = "BẮC NINH", Color = Color.Green, Icon = "", Price = 3200, Rent = 280 },
                new { Type = "Railroad", Name = "GA TÀU 4", Color = Color.Black, Icon = "🚂", Price = 2000, Rent = 250 },
                new { Type = "Special", Name = "CƠ HỘI", Color = Color.Orange, Icon = "❗", Price = 0, Rent = 0 },
                new { Type = "Property", Name = "THANH HÓA", Color = Color.DarkBlue, Icon = "", Price = 3500, Rent = 350 },
                new { Type = "Special", Name = "THUẾ CAO CẤP", Color = Color.LightGray, Icon = "💎", Price = 1000, Rent = 0 },
                new { Type = "Property", Name = "HƯNG YÊN", Color = Color.DarkBlue, Icon = "", Price = 4000, Rent = 500 }
            };

            CreateTilesFromData(rightTileData, rightPanel, DockStyle.Top, 31);
        }

        private void CreateTilesFromData(dynamic[] tileData, Panel panel, DockStyle dock, int startIndex)
        {
            for (int i = 0; i < tileData.Length; i++)
            {
                var data = tileData[i];
                TileControl tileControl;

                if (data.Type == "Property" || data.Type == "Railroad" || data.Type == "Utility")
                {
                    tileControl = new TileControl(new PropertyTile(data.Name, data.Color, data.Price, data.Rent));
                }
                else
                {
                    tileControl = new TileControl(new SpecialTile(data.Name, data.Color, data.Icon));
                }

                tiles[startIndex + i] = tileControl;
                tileControl.Dock = dock;
                panel.Controls.Add(tileControl);
            }
        }

        #endregion

        #region Game Logic Methods

        private void RollDice_Click(object sender, EventArgs e)
        {
            if (gameStarted)
            {
                int diceResult = dice.Next(1, 7) + dice.Next(1, 7);
                UpdateDiceDisplay(diceResult);

                Player currentPlayer = players[currentPlayerIndex];
                MovePlayer(currentPlayer, diceResult);

                CheckCurrentTile();
                UpdatePlayerDisplay();
            }
            else
            {
                gameStarted = true;
                ((Button)sender).Text = "🎲 Tung Xúc Xắc";
                RollDice_Click(sender, e);
            }
        }

        private void BuyProperty_Click(object sender, EventArgs e)
        {
            Player currentPlayer = players[currentPlayerIndex];
            var currentTile = tiles[currentPlayer.Position];

            if (currentTile.Tile is PropertyTile property && property.Owner == null)
            {
                if (currentPlayer.Money >= property.Price)
                {
                    currentPlayer.Money -= property.Price;
                    property.Owner = currentPlayer;
                    currentPlayer.Properties.Add(property);

                    MessageBox.Show($"{currentPlayer.Name} đã mua {property.TileName} với giá ${property.Price}!");
                    UpdatePropertyInfo(currentPlayer.Position);
                    UpdatePlayerDisplay();
                }
                else
                {
                    MessageBox.Show("Không đủ tiền để mua tài sản này!");
                }
            }
        }

        private void EndTurn_Click(object sender, EventArgs e)
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
            UpdateGameInfo();
            UpdatePlayerDisplay();

            // Enable/disable buy button based on current tile
            CheckCurrentTile();
        }

        private void MovePlayer(Player player, int steps)
        {
            int oldPosition = player.Position;
            player.Position = (player.Position + steps) % 40;

            // Check if player passed GO
            if (player.Position < oldPosition)
            {
                player.Money += 2000; // Collect $200 for passing GO
                MessageBox.Show($"{player.Name} đã qua ô BẮT ĐẦU và nhận được $2000!");
            }
        }

        private void CheckCurrentTile()
        {
            Player currentPlayer = players[currentPlayerIndex];
            var currentTile = tiles[currentPlayer.Position];

            if (currentTile.Tile is PropertyTile property)
            {
                var buyBtn = panel11.Controls.OfType<Button>().FirstOrDefault(b => b.Text.Contains("Mua"));
                if (buyBtn != null)
                {
                    buyBtn.Enabled = (property.Owner == null && currentPlayer.Money >= property.Price);
                }

                if (property.Owner != null && property.Owner != currentPlayer)
                {
                    // Pay rent
                    int rent = CalculateRent(property);
                    currentPlayer.Money -= rent;
                    property.Owner.Money += rent;
                    MessageBox.Show($"{currentPlayer.Name} phải trả ${rent} tiền thuê cho {property.Owner.Name}!");
                }
            }
            else
            {
                var buyBtn = panel11.Controls.OfType<Button>().FirstOrDefault(b => b.Text.Contains("Mua"));
                if (buyBtn != null)
                {
                    buyBtn.Enabled = false;
                }
            }

            UpdatePropertyInfo(currentPlayer.Position);
        }

        private int CalculateRent(PropertyTile property)
        {
            // Basic rent calculation - can be enhanced with monopoly bonuses, houses, etc.
            return property.PriceLevel;
        }

        #endregion

        #region Display Update Methods

        private void UpdatePlayerDisplay()
        {
            // Update player panels
            var playerPanels = new[] { panel8, panel1, panel3, panel7 };
            var playerLabels = new[] { label2, label3, label4, label5 };
            var colorPanels = new[] { panel9, panel2, panel4, panel10 };

            for (int i = 0; i < Math.Min(players.Count, 4); i++)
            {
                var player = players[i];
                playerLabels[i].Text = $"{player.Name} - ${player.Money:N0}";
                colorPanels[i].BackColor = player.Color;

                // Highlight current player
                if (i == currentPlayerIndex)
                {
                    playerPanels[i].BackColor = Color.LightGoldenrodYellow;
                    playerLabels[i].Font = new Font(playerLabels[i].Font, FontStyle.Bold);
                }
                else
                {
                    playerPanels[i].BackColor = Color.Transparent;
                    playerLabels[i].Font = new Font(playerLabels[i].Font, FontStyle.Regular);
                }
            }
        }

        private void UpdateGameInfo()
        {
            var gameInfoLabel = panel11.Controls.Find("gameInfoLabel", false).FirstOrDefault() as Label;
            if (gameInfoLabel != null)
            {
                gameInfoLabel.Text = "Lượt của: " + players[currentPlayerIndex].Name;
                gameInfoLabel.ForeColor = players[currentPlayerIndex].Color;
            }
        }

        private void UpdateDiceDisplay(int result)
        {
            var diceLabel = panel11.Controls.Find("diceLabel", false).FirstOrDefault() as Label;
            if (diceLabel != null)
            {
                diceLabel.Text = $"Kết quả xúc xắc: {result}";
            }
        }

        private void UpdatePropertyInfo(int tileIndex)
        {
            var propInfoLabel = panel11.Controls.Find("propInfoLabel", false).FirstOrDefault() as Label;
            if (propInfoLabel != null)
            {
                var tile = tiles[tileIndex];
                if (tile.Tile is PropertyTile property)
                {
                    string ownerInfo = property.Owner != null ? $"\nChủ sở hữu: {property.Owner.Name}" : "\nChưa có chủ";
                    propInfoLabel.Text = $"Tài sản: {property.TileName}\nGiá: ${property.Price:N0}\nTiền thuê: ${property.PriceLevel}{ownerInfo}";
                }
                else if (tile.Tile is SpecialTile special)
                {
                    propInfoLabel.Text = $"Ô đặc biệt: {special.TileName}\n{special.Icon}";
                }
            }
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            if (sender is TileControl tileControl && tileControl.Tag is int tileIndex)
            {
                UpdatePropertyInfo(tileIndex);
            }
        }

        #endregion

        #region Helper Methods

        public TileControl GetTile(int index)
        {
            return (index >= 0 && index < 40) ? tiles[index] : null;
        }

        public List<PropertyTile> GetAllProperties()
        {
            return tiles.Where(t => t?.Tile is PropertyTile)
                        .Select(t => t.Tile as PropertyTile)
                        .ToList();
        }

        public List<PropertyTile> GetPropertiesByColor(Color color)
        {
            return GetAllProperties().Where(p => p.TileColor == color).ToList();
        }

        public bool HasMonopoly(Player player, Color color)
        {
            if (!propertyGroups.ContainsKey(color)) return false;

            var groupTiles = propertyGroups[color];
            return groupTiles.All(tileIndex =>
                tiles[tileIndex].Tile is PropertyTile prop && prop.Owner == player);
        }

        #endregion
    }
}