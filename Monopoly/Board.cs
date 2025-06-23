using System.Drawing;
using Monopoly.Tiles;

namespace Monopoly
{
    public class Board
    {
        public ITile[] Tiles { get; private set; }

        private readonly (string name, Color color, string symbol, int? price, int? rent, bool isSpecial)[] tileConfigs =
        {
            ("XUẤT PHÁT", Color.LightYellow, "⬅", null, null, true),
            ("CHÂU ĐỐC", Color.SaddleBrown, null, 600, 20, false),
            ("KHÍ VẬN", Color.LightBlue, "❓", null, null, true),
            ("CẦN THƠ", Color.SaddleBrown, null, 600, 40, false),
            ("THUẾ THU NHẬP", Color.LightGray, "💰", null, null, true),
            ("GA TÀU 1", Color.SlateBlue, null, 2000, 250, false),
            ("NHA TRANG", Color.LightSkyBlue, null, 1000, 60, false),
            ("CƠ HỘI", Color.Orange, "❗", null, null, true),
            ("ĐÀ LẠT", Color.LightSkyBlue, null, 1000, 60, false),
            ("HUẾ", Color.LightSkyBlue, null, 1200, 80, false),
            ("TRẠI GIAM", Color.Orange, "🔒", null, null, true),

            ("HÀ NỘI", Color.HotPink, null, 1400, 100, false),
            ("ĐIỆN LỰC", Color.White, "⚡", null, null, true),
            ("TP HCM", Color.HotPink, null, 1400, 100, false),
            ("VŨNG TÀU", Color.HotPink, null, 1600, 120, false),
            ("GA TÀU 2", Color.SlateBlue, null, 2000, 250, false),
            ("PHAN THIẾT", Color.Orange, null, 1800, 140, false),
            ("KHÍ VẬN", Color.LightBlue, "❓", null, null, true),
            ("SAPA", Color.Orange, null, 1800, 140, false),
            ("HẠ LONG", Color.Orange, null, 2000, 160, false),
            ("SÂN BAY", Color.IndianRed, "🛫", null, null, true),

            ("PHÚ QUỐC", Color.IndianRed, null, 2200, 180, false),
            ("CƠ HỘI", Color.Orange, "❗", null, null, true),
            ("HẢI PHÒNG", Color.IndianRed, null, 2200, 180, false),
            ("HỘI AN", Color.IndianRed, null, 2400, 200, false),
            ("GA TÀU 3", Color.SlateBlue, null, 2000, 250, false),
            ("BÌNH DƯƠNG", Color.Yellow, null, 2600, 220, false),
            ("BÌNH THUẬN", Color.Yellow, null, 2600, 220, false),
            ("NƯỚC SẠCH", Color.White, "💧", null, null, true),
            ("LONG AN", Color.Yellow, null, 2800, 240, false),
            ("VÀO TÙ", Color.IndianRed, "👮", null, null, true),

            ("NAM ĐỊNH", Color.Green, null, 3000, 260, false),
            ("QUẢNG NINH", Color.Green, null, 3000, 260, false),
            ("KHÍ VẬN", Color.LightBlue, "❓", null, null, true),
            ("BẮC NINH", Color.Green, null, 3200, 280, false),
            ("GA TÀU 4", Color.SlateBlue, null, 2000, 250, false),
            ("CƠ HỘI", Color.Orange, "❗", null, null, true),
            ("THANH HÓA", Color.LightGreen, null, 3500, 350, false),
            ("THUẾ CAO CẤP", Color.LightGray, "💎", null, null, true),
            ("HƯNG YÊN", Color.LightGreen, null, 4000, 500, false)
        };

        public Board()
        {
            CreateBoard();
        }

        private void CreateBoard()
        {
            Tiles = new ITile[tileConfigs.Length];

            for (int i = 0; i < tileConfigs.Length; i++)
            {
                var (name, color, symbol, price, rent, isSpecial) = tileConfigs[i];

                Tiles[i] = isSpecial
                    ? TileFactory.CreateSpecialTile(name, color, symbol)
                    : TileFactory.CreatePropertyTile(name, color, price ?? 0, rent ?? 0);
            }
        }
    }
}
