//using Monopoly.Core.Tiles;
using System.Drawing;
using Monopoly.Tiles;

namespace Monopoly.UI
{
    public class PropertyTileControl : BaseTileControl
    {
        public new PropertyTile Tile
        {
            get => base.Tile as PropertyTile;
            protected set => base.Tile = value;
        }

        public PropertyTileControl() : this(new PropertyTile("LONG AN", Color.Orange, 200, 1)) { }

        public PropertyTileControl(BaseTile tile) : base(tile) { }

        public override void UpdateUI()
        {
            base.UpdateUI();

            this.labelTop.Text = Tile.Name;
            this.labelMiddle.Text = $"${Tile.Price}";
            this.labelHouse.BackColor = Tile.Owner?.Color ?? Color.Silver;
            //this.labelHouse.Text = $"{Tile.HouseCount} 🏠 {Tile.HotelCount} 🏰";
        }
    }
}
