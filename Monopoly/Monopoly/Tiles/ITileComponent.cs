using System.Collections.Generic;
using System.Drawing;

namespace Monopoly.Tiles
{
    public interface ITileComponent
    {
        string TileName { get; }
        Color TileColor { get; }
        void OnEnter(Player player);
        void OnRender(Graphics g, Rectangle bounds);
        string GetInfo();
        List<string> PlayersOnTile { get; set; }
    }
}
