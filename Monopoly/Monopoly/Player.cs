using System;
using System.Collections.Generic;
using System.Drawing;
using Monopoly.Tiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    #region Player Class

    public class Player
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public int Money { get; set; }
        public int Position { get; set; }
        public List<PropertyTile> Properties { get; set; }
        public bool InJail { get; set; }
        public int JailTurns { get; set; }

        public Player(string name, Color color, int startingMoney)
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

    #endregion
}
