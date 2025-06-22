using System.Collections.Generic;
using System.Drawing;

namespace Monopoly.Tiles
{
    public abstract class BaseTile : ITile
    {
        public string TileName { get; set; }
        public Color TileColor { get; set; }

        protected BaseTile(string tileName, Color tileColor)
        {
            TileName = tileName;
            TileColor = Helper.LightenColor(tileColor);
        }

        public virtual void OnEnter(Player player)
        {
        }

        public virtual void OnLeave(Player player)
        {
        }

        public virtual string GetInfo()
        {
            return $"Thông tin ô {TileName}";
        }
    }
}
