using System;
using System.Drawing;
using Monopoly.Tiles;

namespace Monopoly {
    public class GameManager
    {
        public Player[] Players { get; private set; }
        public ITile[] Tiles { get; private set; }
        public int CurrentPlayerIndex { get; set; } = 0; // Index of the current player
        public Dice[] Dices { get; private set; }

        public event EventHandler<PlayerMovedEventArgs> PlayerMoved;
        public event EventHandler<Player> PlayerPassedStart;

        public GameManager()
        {
            CreateBoard();

            Players = new Player[]
            {
                new Player("Hồ Nguyễn Minh Khoa", Color.Red, index: 0),
                new Player("Hồ Nguyễn Minh Tiến", Color.Blue, index: 1),
                new Player("Hồ Nguyễn Mai Phương", Color.LightGreen, index: 2),
                new Player("Nguyễn Ngọc Chấn Đông", Color.Yellow, index: 3)
            };

            Dices = new Dice[2] { new Dice(), new Dice() };
        }

        public void RollDices()
        {
            foreach (var dice in Dices)
            {
                dice.Roll();
            }
        }

        public void NextPlayer()
        {
            CurrentPlayerIndex = (CurrentPlayerIndex + 1) % Players.Length;
        }

        public event EventHandler<PropertyTileOfferedEventArgs> PropertyOffered;

        public void PlayerTurn()
        {
            Player player = Players[CurrentPlayerIndex];
            int from = player.Position;
            int value = Dices[0].Value + Dices[1].Value;
            int to = player.Move(value);

            if (to >= 40)
            {
                player.ReceiveMoney(2000);
                PlayerPassedStart?.Invoke(this, player);
            }

            PlayerMoved?.Invoke(this, new PlayerMovedEventArgs(player, from, to));
        }

        private void CreateBoard()
        {
            Tiles = new ITile[]
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
                TileFactory.CreateSpecialTile("TRẠI GIAM", Color.Orange, "🔒"), // 10

                TileFactory.CreatePropertyTile("HÀ NỘI", Color.HotPink, 1400, 100), // 11
                TileFactory.CreateSpecialTile("ĐIỆN LỰC", Color.White, "⚡"), // 12
                TileFactory.CreatePropertyTile("TP HCM", Color.HotPink, 1400, 100), // 13
                TileFactory.CreatePropertyTile("VŨNG TÀU", Color.HotPink, 1600, 120), // 14
                TileFactory.CreatePropertyTile("GA TÀU 2", Color.SlateBlue, 2000, 250), // 15
                TileFactory.CreatePropertyTile("PHAN THIẾT", Color.Orange, 1800, 140), // 16
                TileFactory.CreateSpecialTile("KHÍ VẬN", Color.LightBlue, "❓"), // 17
                TileFactory.CreatePropertyTile("SAPA", Color.Orange, 1800, 140), // 18
                TileFactory.CreatePropertyTile("HẠ LONG", Color.Orange, 2000, 160), // 19
                TileFactory.CreateSpecialTile("SÂN BAY", Color.Red, "🛫"), // 20

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
    }

    public class PlayerMovedEventArgs : EventArgs
    {
        public Player Player { get; }
        public int From { get; }
        public int To { get; }

        public PlayerMovedEventArgs(Player player, int from, int to)
        {
            Player = player;
            From = from;
            To = to;
        }
    }

    public class PropertyTileOfferedEventArgs : EventArgs
    {
        public Player Player { get; }
        public PropertyTile Property { get; }

        public PropertyTileOfferedEventArgs(Player player, PropertyTile property)
        {
            Player = player;
            Property = property;
        }
    }

}