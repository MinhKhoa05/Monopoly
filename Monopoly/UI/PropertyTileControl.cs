//using Monopoly.Core.Tiles;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Monopoly.Events;
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

        public PropertyTileControl(BaseTile tile) : base(tile)
        {
            Tile.TileAction += Tile_TileAction;
        }

        private void Tile_TileAction(object sender, TileActionEventArgs e)
        {
            if (e.RequiresConfirm)
            {
                var result = MessageBox.Show(e.Message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                e.Confirmed = result == DialogResult.Yes;
            }
            else
            {
                MessageBox.Show(e.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            UpdateUI();
        }

        public override void UpdateUI()
        {
            base.UpdateUI();

            this.labelTop.Text = Tile.Name;
            this.labelMiddle.Text = $"${Tile.Price}";
            this.labelHouse.BackColor = Tile.Owner?.Color ?? Color.Silver;

            this.labelHouse.Text = Tile.HouseCount == 5
                ? "🏰"
                : string.Concat(Enumerable.Repeat("🏠 ", Tile.HouseCount));
        }

    }
}
