using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monopoly.Tiles;

namespace Monopoly
{
    public partial class Main : Form
    {
        private TileControl[] tiles = new TileControl[40];
        private Dice[] dices = new Dice[2];

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitBoard();

            dices[0] = new Dice();
            dices[1] = new Dice();

            dice1.Image = dices[0].Image;
            dice2.Image = dices[1].Image;     
        }

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
        }

        private void OnTileClicked(object sender, TileClickedEventArgs e)
        {
            UpdateTileInfoUI(e.Tile);
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

        private void CreateBottomTiles()
        {
            // Bottom row (tiles 0-10) - from right to left
            var bottomTiles = new List<TileControl>
            {
                // Tile 0 - GO
                new TileControl(new SpecialTile("BẮT ĐẦU", Color.LightYellow, "⛳")),
                
                // Tile 1 - Brown properties
                new TileControl(new PropertyTile("CHÂU ĐỐC", Color.SaddleBrown, 600, 20)),
                
                // Tile 2 - Community Chest
                new TileControl(new SpecialTile("KHÍ VẬN", Color.LightBlue, "❓")),
                
                // Tile 3 - Brown property
                new TileControl(new PropertyTile("CẦN THƠ", Color.SaddleBrown, 600, 40)),
                
                // Tile 4 - Income Tax
                new TileControl(new SpecialTile("THUẾ THU NHẬP", Color.LightGray, "💰")),
                
                // Tile 5 - Railroad
                new TileControl(new PropertyTile("GA TÀU 1", Color.SlateBlue, 2000, 250)),
                
                // Tile 6 - Light Blue properties
                new TileControl(new PropertyTile("NHA TRANG", Color.LightSkyBlue, 1000, 60)),
                
                // Tile 7 - Chance
                new TileControl(new SpecialTile("CƠ HỘI", Color.Orange, "❗")),
                
                // Tile 8 - Light Blue property
                new TileControl(new PropertyTile("ĐÀ LẠT", Color.LightSkyBlue, 1000, 60)),
                
                // Tile 9 - Light Blue property
                new TileControl(new PropertyTile("HUẾ", Color.LightSkyBlue, 1200, 80)),
                
                // Tile 10 - Jail
                new TileControl(new SpecialTile("TÙ", Color.Orange, "🚓"))
            };

            for (int i = 0; i < bottomTiles.Count; i++)
            {
                bottomTiles[i].TileClicked += OnTileClicked; // Subscribe to tile click event
                tiles[i] = bottomTiles[i];
                tiles[i].Dock = DockStyle.Right;
                bottomPanel.Controls.Add(tiles[i]);
            }
        }

        private void CreateLeftTiles()
        {
            // Left side (tiles 11-19) - from bottom to top
            var leftTiles = new List<TileControl>
            {
                // Tile 11 - Pink properties
                new TileControl(new PropertyTile("HÀ NỘI", Color.HotPink, 1400, 100)),
                
                // Tile 12 - Utility
                new TileControl(new SpecialTile("ĐIỆN LỰC", Color.White, "⚡")),
                
                // Tile 13 - Pink property
                new TileControl(new PropertyTile("TP HCM", Color.HotPink, 1400, 100)),
                
                // Tile 14 - Pink property
                new TileControl(new PropertyTile("VŨNG TÀU", Color.HotPink, 1600, 120)),
                
                // Tile 15 - Railroad
                new TileControl(new PropertyTile("GA TÀU 2", Color.SlateBlue, 2000, 250)),
                
                // Tile 16 - Orange properties
                new TileControl(new PropertyTile("PHAN THIẾT", Color.Orange, 1800, 140)),
                
                // Tile 17 - Community Chest
                new TileControl(new SpecialTile("KHÍ VẬN", Color.LightBlue, "❓")),
                
                // Tile 18 - Orange property
                new TileControl(new PropertyTile("SAPA", Color.Orange, 1800, 140)),
                
                // Tile 19 - Orange property
                new TileControl(new PropertyTile("HẠ LONG", Color.Orange, 2000, 160))
            };

            for (int i = 0; i < leftTiles.Count; i++)
            {
                leftTiles[i].TileClicked += OnTileClicked; // Subscribe to tile click event
                tiles[11 + i] = leftTiles[i];
                tiles[11 + i].Dock = DockStyle.Bottom;
                leftPanel.Controls.Add(tiles[11 + i]);
            }
        }

        private void CreateTopTiles()
        {
            // Top row (tiles 20-30) - from left to right
            var topTiles = new List<TileControl>
            {
                // Tile 20 - Free Parking
                new TileControl(new SpecialTile("ĐỖ XE", Color.Red, "🅿")),
                
                // Tile 21 - Red properties
                new TileControl(new PropertyTile("PHÚ QUỐC", Color.Red, 2200, 180)),
                
                // Tile 22 - Chance
                new TileControl(new SpecialTile("CƠ HỘI", Color.Orange, "❗")),
                
                // Tile 23 - Red property
                new TileControl(new PropertyTile("HẢI PHÒNG", Color.Red, 2200, 180)),
                
                // Tile 24 - Red property
                new TileControl(new PropertyTile("HỘI AN", Color.Red, 2400, 200)),
                
                // Tile 25 - Railroad
                new TileControl(new PropertyTile("GA TÀU 3", Color.SlateBlue, 2000, 250)),
                
                // Tile 26 - Yellow properties
                new TileControl(new PropertyTile("BÌNH DƯƠNG", Color.Yellow, 2600, 220)),
                
                // Tile 27 - Yellow property
                new TileControl(new PropertyTile("BÌNH THUẬN", Color.Yellow, 2600, 220)),
                
                // Tile 28 - Utility
                new TileControl(new SpecialTile("NƯỚC SẠCH", Color.White, "💧")),
                
                // Tile 29 - Yellow property
                new TileControl(new PropertyTile("LONG AN", Color.Yellow, 2800, 240)),
                
                // Tile 30 - Go to Jail
                new TileControl(new SpecialTile("VÀO TÙ", Color.Red, "👮"))
            };

            for (int i = 0; i < topTiles.Count; i++)
            {
                topTiles[i].TileClicked += OnTileClicked; // Subscribe to tile click event
                tiles[20 + i] = topTiles[i];
                tiles[20 + i].Dock = DockStyle.Left;
                topPanel.Controls.Add(tiles[20 + i]);
            }
        }

        private void CreateRightTiles()
        {
            // Right side (tiles 31-39) - from top to bottom
            var rightTiles = new List<TileControl>
            {
                // Tile 31 - Green properties
                new TileControl(new PropertyTile("NAM ĐỊNH", Color.Green, 3000, 260)),
                
                // Tile 32 - Green property
                new TileControl(new PropertyTile("QUẢNG NINH", Color.Green, 3000, 260)),
                
                // Tile 33 - Community Chest
                new TileControl(new SpecialTile("KHÍ VẬN", Color.LightBlue, "❓")),
                
                // Tile 34 - Green property
                new TileControl(new PropertyTile("BẮC NINH", Color.Green, 3200, 280)),
                
                // Tile 35 - Railroad
                new TileControl(new PropertyTile("GA TÀU 4", Color.SlateBlue, 2000, 250)),
                
                // Tile 36 - Chance
                new TileControl(new SpecialTile("CƠ HỘI", Color.Orange, "❗")),
                
                // Tile 37 - Dark Blue property
                new TileControl(new PropertyTile("THANH HÓA", Color.LightGreen, 3500, 350)),
                
                // Tile 38 - Luxury Tax
                new TileControl(new SpecialTile("THUẾ CAO CẤP", Color.LightGray, "💎")),
                
                // Tile 39 - Dark Blue property
                new TileControl(new PropertyTile("HƯNG YÊN", Color.LightGreen, 4000, 500))
            };

            for (int i = 0; i < rightTiles.Count; i++)
            {
                rightTiles[i].TileClicked += OnTileClicked;
                tiles[31 + i] = rightTiles[i];
                tiles[31 + i].Dock = DockStyle.Top;
                rightPanel.Controls.Add(tiles[31 + i]);
            }
        }

        // Helper method to get all property tiles
        public List<PropertyTile> GetAllProperties()
        {
            var properties = new List<PropertyTile>();
            foreach (var tile in tiles)
            {
                if (tile?.Tile is PropertyTile property)
                {
                    properties.Add(property);
                }
            }
            return properties;
        }

        // Helper method to get properties by color group
        public List<PropertyTile> GetPropertiesByColor(Color color)
        {
            return GetAllProperties().Where(p => p.TileColor == color).ToList();
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
                dices[0].Roll();
                dices[1].Roll();

                // Đảm bảo 2 viên ra số khác nhau (nếu bạn muốn)
                while (dices[0].Value == dices[1].Value)
                {
                    dices[1].Roll();
                }

                dice1.Image = dices[0].Image;
                dice2.Image = dices[1].Image;

                await Task.Delay(delay); // Đợi một chút để tạo hiệu ứng
            }

            // Sau khi dừng, giữ kết quả cuối cùng (hoặc xử lý gì đó nếu cần)
        }
    }
}