using System.Collections.Generic;
using System.Drawing;
using Monopoly.Tiles;

namespace Monopoly
{
    public class Player
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public int Money { get; set; }
        public int Position { get; set; }
        public List<PropertyTile> Properties { get; set; }
        public bool InJail { get; set; }
        public int JailTurns { get; set; }

        public Player(string name, Color color, int startingMoney = 20000)
        {
            Name = name;
            Color = color;
            Money = startingMoney;
            Position = 0;
            Properties = new List<PropertyTile>();
            InJail = false;
            JailTurns = 0;
        }
    }
}
