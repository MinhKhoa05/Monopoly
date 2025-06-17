using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.Tiles;

namespace Monopoly
{
    public sealed class GameManger
    {
        private static readonly Lazy<GameManger> lazy = new Lazy<GameManger>(() => new GameManger());

        private Main main;
        public static GameManger Instance { get { return lazy.Value; } }
        private GameManger()
        {
            // Initialize game manager
            main = new Main();
        }

        public void UpdateTileInfo(ITileComponent tile)
        {
            
            // Logic to update tile information in the game manager
            // This could include updating the UI, player stats, etc.
            Console.WriteLine($"Updating tile info for: {tile.TileName}");
        }
    }
}
