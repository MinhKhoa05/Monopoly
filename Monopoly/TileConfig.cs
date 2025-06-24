using System.Drawing;

namespace Monopoly
{
    public class TileConfig
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public bool IsSpecial { get; set; }
        public int Price { get; set; }
        public int Rent { get; set; }
        public string Symbol { get; set; }

        public static TileConfig Property(string name, Color color, int price, int rent)
        {
            return new TileConfig { Name = name, Color = color, Price = price, Rent = rent, IsSpecial = false };
        }

        public static TileConfig Special(string name, Color color, string symbol)
        {
            return new TileConfig { Name = name, Color = color, Symbol = symbol, IsSpecial = true };
        }
    }

    public static class TileData
    {
        public static TileConfig[] GetTiles()
        {
            return new TileConfig[]
            {
                TileConfig.Special("XUẤT PHÁT", Color.LightYellow, "⬅"),
                TileConfig.Property("CHÂU ĐỐC", Color.SaddleBrown, 600, 20),
                TileConfig.Special("KHÍ VẬN", Color.LightBlue, "❓"),
                TileConfig.Property("CẦN THƠ", Color.SaddleBrown, 600, 40),
                TileConfig.Special("THUẾ THU NHẬP", Color.LightGray, "💰"),
                TileConfig.Property("GA TÀU 1", Color.SlateBlue, 2000, 250),
                TileConfig.Property("NHA TRANG", Color.LightSkyBlue, 1000, 60),
                TileConfig.Special("CƠ HỘI", Color.Orange, "❗"),
                TileConfig.Property("ĐÀ LẠT", Color.LightSkyBlue, 1000, 60),
                TileConfig.Property("HUẾ", Color.LightSkyBlue, 1200, 80),
                TileConfig.Special("TRẠI GIAM", Color.Orange, "🔒"),

                TileConfig.Property("HÀ NỘI", Color.HotPink, 1400, 100),
                TileConfig.Special("ĐIỆN LỰC", Color.White, "⚡"),
                TileConfig.Property("TP HCM", Color.HotPink, 1400, 100),
                TileConfig.Property("VŨNG TÀU", Color.HotPink, 1600, 120),
                TileConfig.Property("GA TÀU 2", Color.SlateBlue, 2000, 250),
                TileConfig.Property("PHAN THIẾT", Color.Orange, 1800, 140),
                TileConfig.Special("KHÍ VẬN", Color.LightBlue, "❓"),
                TileConfig.Property("SAPA", Color.Orange, 1800, 140),
                TileConfig.Property("HẠ LONG", Color.Orange, 2000, 160),
                TileConfig.Special("SÂN BAY", Color.MediumPurple, "🛫"),

                TileConfig.Property("PHÚ QUỐC", Color.IndianRed, 2200, 180),
                TileConfig.Special("CƠ HỘI", Color.Orange, "❗"),
                TileConfig.Property("HẢI PHÒNG", Color.IndianRed, 2200, 180),
                TileConfig.Property("HỘI AN", Color.IndianRed, 2400, 200),
                TileConfig.Property("GA TÀU 3", Color.SlateBlue, 2000, 250),
                TileConfig.Property("BÌNH DƯƠNG", Color.Yellow, 2600, 220),
                TileConfig.Property("BÌNH THUẬN", Color.Yellow, 2600, 220),
                TileConfig.Special("NƯỚC SẠCH", Color.White, "💧"),
                TileConfig.Property("LONG AN", Color.Yellow, 2800, 240),
                TileConfig.Special("VÀO TÙ", Color.Firebrick, "👮"),

                TileConfig.Property("NAM ĐỊNH", Color.Green, 3000, 260),
                TileConfig.Property("QUẢNG NINH", Color.Green, 3000, 260),
                TileConfig.Special("KHÍ VẬN", Color.LightBlue, "❓"),
                TileConfig.Property("BẮC NINH", Color.Green, 3200, 280),
                TileConfig.Property("GA TÀU 4", Color.SlateBlue, 2000, 250),
                TileConfig.Special("CƠ HỘI", Color.Orange, "❗"),
                TileConfig.Property("THANH HÓA", Color.LightGreen, 3500, 350),
                TileConfig.Special("THUẾ CAO CẤP", Color.LightGray, "💎"),
                TileConfig.Property("HƯNG YÊN", Color.LightGreen, 4000, 500)
            };
        }
    }
}
