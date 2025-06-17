using System;
using System.Drawing;
using Monopoly.Tiles;

namespace Monopoly {
    public class GameManager
    {
        public Player[] Players { get; private set; }
        public int CurrentPlayerIndex { get; private set; }
        public ITileComponent[] Tiles { get; private set; }
        public Dice[] Dices { get; private set; }

        public event Action<int, int> DiceRolled;
        public event Action<Player> PlayerMoved;

        public GameManager()
        {
            CreateBoard();

            Players = new Player[]
            {
                new Player("Player 1", Color.Red),
                new Player("Player 2", Color.Blue),
                new Player("Player 3", Color.Green),
                new Player("Player 4", Color.Yellow)
            };

            for (int i = 0; i < Players.Length; i++)
            {
                Tiles[0].PlayersOnTile.Add(Players[i]);
            }

            Dices = new Dice[2] { new Dice(), new Dice() };
        }

        public void Update()
        {
            Players[1].Money += 100; // Example of updating player money
        }

        private void CreateBoard()
        {
            Tiles = new ITileComponent[]
            {
                TileFactory.CreateSpecialTile("XUẤT PHÁT", Color.LightYellow, "⬅"), // 0
                TileFactory.CreatePropertyTile("CHÂU ĐỐC", Color.SaddleBrown, 600, 20), // 1
                TileFactory.CreateSpecialTile("KHÍ VẬN", Color.LightBlue, "❓"), // 2
                TileFactory.CreatePropertyTile("CẦN THƠ", Color.SaddleBrown, 600, 40), // 3
                TileFactory.CreateSpecialTile("THUẾ THU NHẬP", Color.LightGray, "💰"), // 4
                TileFactory.CreatePropertyTile("GA TÀU 1", Color.SlateBlue, 2000, 250), // 5
                TileFactory.CreatePropertyTile("NHA TRANG", Color.LightSkyBlue, 1000, 60), // 6
                TileFactory.CreateSpecialTile("CƠ HỘI", Color.Orange, "❗"), // 7
                TileFactory.CreatePropertyTile("ĐÀ LẠT", Color.LightSkyBlue, 1000, 60), // 8
                TileFactory.CreatePropertyTile("HUẾ", Color.LightSkyBlue, 1200, 80), // 9
                TileFactory.CreateSpecialTile("TÙ", Color.Orange, "🚓"), // 10

                TileFactory.CreatePropertyTile("HÀ NỘI", Color.HotPink, 1400, 100), // 11
                TileFactory.CreateSpecialTile("ĐIỆN LỰC", Color.White, "⚡"), // 12
                TileFactory.CreatePropertyTile("TP HCM", Color.HotPink, 1400, 100), // 13
                TileFactory.CreatePropertyTile("VŨNG TÀU", Color.HotPink, 1600, 120), // 14
                TileFactory.CreatePropertyTile("GA TÀU 2", Color.SlateBlue, 2000, 250), // 15
                TileFactory.CreatePropertyTile("PHAN THIẾT", Color.Orange, 1800, 140), // 16
                TileFactory.CreateSpecialTile("KHÍ VẬN", Color.LightBlue, "❓"), // 17
                TileFactory.CreatePropertyTile("SAPA", Color.Orange, 1800, 140), // 18
                TileFactory.CreatePropertyTile("HẠ LONG", Color.Orange, 2000, 160), // 19
                TileFactory.CreateSpecialTile("ĐỖ XE", Color.Red, "🅿"), // 20

                TileFactory.CreatePropertyTile("PHÚ QUỐC", Color.Red, 2200, 180), // 21
                TileFactory.CreateSpecialTile("CƠ HỘI", Color.Orange, "❗"), // 22
                TileFactory.CreatePropertyTile("HẢI PHÒNG", Color.Red, 2200, 180), // 23
                TileFactory.CreatePropertyTile("HỘI AN", Color.Red, 2400, 200), // 24
                TileFactory.CreatePropertyTile("GA TÀU 3", Color.SlateBlue, 2000, 250), // 25
                TileFactory.CreatePropertyTile("BÌNH DƯƠNG", Color.Yellow, 2600, 220), // 26
                TileFactory.CreatePropertyTile("BÌNH THUẬN", Color.Yellow, 2600, 220), // 27
                TileFactory.CreateSpecialTile("NƯỚC SẠCH", Color.White, "💧"), // 28
                TileFactory.CreatePropertyTile("LONG AN", Color.Yellow, 2800, 240), // 29
                TileFactory.CreateSpecialTile("VÀO TÙ", Color.Red, "👮"), // 30

                TileFactory.CreatePropertyTile("NAM ĐỊNH", Color.Green, 3000, 260), // 31
                TileFactory.CreatePropertyTile("QUẢNG NINH", Color.Green, 3000, 260), // 32
                TileFactory.CreateSpecialTile("KHÍ VẬN", Color.LightBlue, "❓"), // 33
                TileFactory.CreatePropertyTile("BẮC NINH", Color.Green, 3200, 280), // 34
                TileFactory.CreatePropertyTile("GA TÀU 4", Color.SlateBlue, 2000, 250), // 35
                TileFactory.CreateSpecialTile("CƠ HỘI", Color.Orange, "❗"), // 36
                TileFactory.CreatePropertyTile("THANH HÓA", Color.LightGreen, 3500, 350), // 37
                TileFactory.CreateSpecialTile("THUẾ CAO CẤP", Color.LightGray, "💎"), // 38
                TileFactory.CreatePropertyTile("HƯNG YÊN", Color.LightGreen, 4000, 500) // 39
            };
        }

    //        // Helper method to get all property tiles
    //        public List<PropertyTile> GetAllProperties()
    //        {
    //            var properties = new List<PropertyTile>();
    //            foreach (var tile in tiles)
    //            {
    //                if (tile?.Tile is PropertyTile property)
    //                {
    //                    properties.Add(property);
    //                }
    //            }
    //            return properties;
    //        }

    //        // Helper method to get properties by color group
    //        public List<PropertyTile> GetPropertiesByColor(Color color)
    //        {
    //            return GetAllProperties().Where(p => p.TileColor == color).ToList();
    //        }

    //        private void dice1_Click(object sender, EventArgs e)
    //        {
    //            DiceRoll();
    //        }

    //        private void dice2_Click(object sender, EventArgs e)
    //        {
    //            DiceRoll();
    //        }

    //        private async void DiceRoll()
    //        {
    //            int rollCount = 10; // Số lần tung
    //            int delay = 50;     // Thời gian giữa mỗi lần tung (ms)

    //            for (int i = 0; i < rollCount; i++)
    //            {
    //                dices[0].Roll();
    //                dices[1].Roll();

    //                // Đảm bảo 2 viên ra số khác nhau (nếu bạn muốn)
    //                while (dices[0].Value == dices[1].Value)
    //                {
    //                    dices[1].Roll();
    //                }

    //                dice1.Image = dices[0].Image;
    //                dice2.Image = dices[1].Image;

    //                await Task.Delay(delay); // Đợi một chút để tạo hiệu ứng
    //            }

    //            // Sau khi dừng, giữ kết quả cuối cùng (hoặc xử lý gì đó nếu cần)
    //        }
    //    }
    //}


    //public void RollDiceAndMove()
    //{
    //    Dices[0].Roll();
    //    Dices[1].Roll();
    //    int total = Dices[0].Value + Dices[1].Value;

    //    DiceRolled?.Invoke(Dices[0].Value, Dices[1].Value);

    //    Player current = Players[CurrentPlayerIndex];
    //    current.Move(total, Tiles.Length);

    //    PlayerMoved?.Invoke(current);

    //    // Chuyển lượt nếu không được đi tiếp
    //    if (Dices[0].Value != Dices[1].Value)
    //        CurrentPlayerIndex = (CurrentPlayerIndex + 1) % Players.Length;
    //}
    }
}