using System.Drawing;
using Monopoly.Tiles;

namespace Monopoly
{
    public static class TileFactory
    {
        public static ITileComponent CreatePropertyTile(string name, Color color, int rent, int lvl)
        {
            return new PropertyTile(name, color, rent, lvl);
        }

        public static ITileComponent CreateSpecialTile(string name, Color color, string symbol)
        {
            return new SpecialTile(name, color, symbol);
        }
    }
}