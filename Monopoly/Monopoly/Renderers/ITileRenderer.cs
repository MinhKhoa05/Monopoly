using System.Drawing;
using Monopoly.Tiles;

namespace Monopoly.Renderers
{
    public interface ITileRenderer
    {
        void Render(ITile tile, Graphics g, Rectangle bounds);
    }
}
