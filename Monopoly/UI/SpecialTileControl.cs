using System.Drawing;
using Monopoly.Tiles;

namespace Monopoly.UI
{
    public class SpecialTileControl : BaseTileControl
    {
        public new SpecialTile Tile
        {
            get => base.Tile as SpecialTile;
            protected set => base.Tile = value;
        }

        public SpecialTileControl() : this(new SpecialTile("CƠ HỘI", Color.LightBlue, "❓")) { }

        public SpecialTileControl(BaseTile tile) : base(tile)
        {
            Initialize();
        }

        public override void UpdateUI()
        {
            base.UpdateUI();
            labelTop.Text = Tile?.Symbol ?? string.Empty;
            labelMiddle.Text = Tile?.Name ?? string.Empty;
        }

        private void Initialize()
        {
            labelTop.Font = new Font("Segoe UI Emoji", 14.25F);
            labelTop.Size = new Size(90, 25);

            labelMiddle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelMiddle.Size = new Size(90, 24);

            labelHouse.Visible = false;
        }
    }
}
