using System.Drawing;
using Monopoly.Tiles;
using Monopoly.UI;

namespace Monopoly
{
    public static class TileFactory
    {
        public static BaseTileControl CreatePropertyTile(string name, Color color, int rent, int lvl)
        {
            return new PropertyTileControl(new PropertyTile(name, color, rent, lvl));
        }

        public static BaseTileControl CreateSpecialTile(string name, Color color, string symbol)
        {
            return new SpecialTileControl(new SpecialTile(name, color, symbol));
        }
    }
}