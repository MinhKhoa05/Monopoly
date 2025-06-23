using System.Drawing;

namespace Monopoly.Tiles
{
    public class SpecialTile : BaseTile
    { 
        public string Symbol { get; set; } = "⛳"; // Hoặc "🚓", "🛑", "🏛️"

        public SpecialTile(string tileName, Color tileColor, string symbol) : base(tileName, tileColor)
        {
            this.Symbol = symbol;
        }
    }
}
