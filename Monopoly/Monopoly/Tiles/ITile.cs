using System.Drawing;

namespace Monopoly.Tiles
{
    public interface ITile
    {
        string TileName { get; }
        Color TileColor { get; }
        void OnEnter(Player player);
        void OnRender(Graphics g, Rectangle bounds);
        void OnLeave(Player player);
        string GetInfo();
    }
}
