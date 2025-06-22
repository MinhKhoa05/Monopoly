namespace Monopoly
{
    public static class GameConfig
    {
        // Tiền ban đầu của mỗi người chơi
        public const int InitialMoney = 20000;

        // Số lượng người chơi tối đa
        public const int MaxPlayers = 4;

        // Kích thước bàn cờ (số ô)
        public const int BoardSize = 40;

        // Các vị trí đặc biệt trên bàn cờ
        public const int GoPosition = 0;
        public const int JailPosition = 10;
        public const int FreeParkingPosition = 20;
        public const int GoToJailPosition = 30;

        // Số lượng thẻ bài trong mỗi bộ
        public const int ChanceDeckSize = 16;
        public const int CommunityChestDeckSize = 16;

        // Số tiền nhận được khi đi qua ô "Go"
        public const int PassGoBonus = 2000;
        
        // Thời gian ở tù tối đa nếu không trả tiền/phá ngục
        public const int MaxTurnsInJail = 3;

        // Phí ra tù nếu không rút được thẻ hoặc đổ xúc xắc
        public const int JailFee = 500;

        // Giá trị mặc định của một số tài sản (có thể thay đổi tùy từng loại)
        public const int DefaultPropertyPrice = 1000;

        // Tiền thuê mặc định khi dừng ở một tài sản (có thể tuỳ chỉnh theo loại)
        public const int DefaultRent = 200;

        // Phí xây nhà hoặc khách sạn
        public const int HousePrice = 500;
        public const int HotelPrice = 2000;

        // Số nhà tối đa trước khi xây khách sạn
        public const int MaxHousesPerProperty = 4;
    }
}
