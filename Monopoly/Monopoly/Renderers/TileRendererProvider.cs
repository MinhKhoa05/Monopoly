using System;
using System.Collections.Generic;
using Monopoly.Tiles;

namespace Monopoly.Renderers
{
    public static class TileRendererProvider
    {
        private static Dictionary<Type, BaseTileRenderer> _renderers = new Dictionary<Type, BaseTileRenderer>
        {
            { typeof(PropertyTile), new PropertyTileRenderer() }
            , { typeof(SpecialTile), new SpecialTileRenderer() }
            // Thêm các renderer khác tại đây nếu có
        };

        public static BaseTileRenderer GetRenderer(ITile tile)
        {
            BaseTileRenderer renderer;
            if (_renderers.TryGetValue(tile.GetType(), out renderer))
            {
                return renderer;
            }

            return null; // hoặc trả về default renderer nếu có
        }
    }
}
