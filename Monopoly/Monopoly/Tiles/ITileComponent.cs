using System.Collections.Generic;
using System.Drawing;

namespace Monopoly.Tiles
{
    public interface ITileComponent
    {
        void OnEnter(Player player);
        void OnRender(Graphics g, Rectangle bounds);
        List<string> PlayersOnTile { get; set; }
    }
}
