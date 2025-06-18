using System.Drawing;

namespace Monopoly
{
    public class Player
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public int Money { get; set; }
        public int Position { get; set; }

        public int PlayerIndex { get; set; } // <= đây là chỉ số cố định, từ 0 đến 3

        public Player(string name, Color color, int money = 20000, int playerIndex = 0)
        {
            Name = name;
            Color = color;
            Money = money;
            PlayerIndex = playerIndex;
        }
    }
}
