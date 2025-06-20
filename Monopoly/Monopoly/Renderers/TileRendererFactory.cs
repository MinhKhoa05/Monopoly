using System;
using System.Collections.Generic;
using Monopoly.Tiles;

namespace Monopoly.Renderers
{
    public static class TileRendererFactory
    {
        private static Dictionary<Type, ITileRenderer> _renderers = new Dictionary<Type, ITileRenderer>
        {
            { typeof(PropertyTile), new PropertyTileRenderer() }
            , { typeof(SpecialTile), new SpecialTileRenderer() }
            // Thêm các renderer khác tại đây nếu có
        };

        public static ITileRenderer GetRenderer(ITile tile)
        {
            ITileRenderer renderer;
            if (_renderers.TryGetValue(tile.GetType(), out renderer))
                return renderer;

            return null; // hoặc trả về default renderer nếu có
        }
    }
}
