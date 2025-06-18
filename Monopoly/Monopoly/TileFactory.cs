using System.Drawing;
using Monopoly.Tiles;

namespace Monopoly
{
    public static class TileFactory
    {
        public static ITile CreatePropertyTile(string name, Color color, int rent, int lvl)
        {
            return new PropertyTile(name, color, rent, lvl);
        }

        public static ITile CreateSpecialTile(string name, Color color, string symbol)
        {
            return new SpecialTile(name, color, symbol);
        }
    }
}