//using Monopoly.Core.Tiles;
using Monopoly.Tiles;

namespace Monopoly.UI
{
    public class PropertyTileControl : BaseTileControl
    {
        public new PropertyTile Tile
        {
            get => base.Tile as PropertyTile;
            private set => base.Tile = value;
        }

        public PropertyTileControl()
        {
            this.labelTop.Text = "QUẢNG NINH";
            this.labelMiddle.Text = "$200";
            this.labelHouse.Text = "🏰 🏠";
        }

        public PropertyTileControl(ITile tile) : base(tile)
        {
            UpdateUI();
        }

        public void UpdateUI()
        {

            this.BackColor = Tile.TileColor;
            this.labelTop.Text = Tile.TileName;
            this.labelMiddle.Text = $"${Tile.Price}";
            //this.labelHouse.BackColor = Color.Orange;
            //this.labelHouse.Text = $"{Tile.HouseCount} 🏠 {Tile.HotelCount} 🏰";
        }
    }
}
