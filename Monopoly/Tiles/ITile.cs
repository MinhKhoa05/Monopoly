using System.Drawing;

namespace Monopoly.Tiles
{
    public interface ITile
    {
        string TileName { get; }
        Color TileColor { get; }
        void OnEnter(Player player);
        void OnLeave(Player player);
        string GetInfo();
    }
}
