using System;
using System.Drawing;
using System.Windows.Forms;
using Monopoly.Tiles;

namespace Monopoly.UI
{
    public class SpecialTileControl : BaseTileControl
    {
        public new SpecialTile Tile
        {
            get => base.Tile as SpecialTile;
            private set => base.Tile = value;
        }

        public SpecialTileControl()
        {
            this.SetUp();
            this.labelTop.Text = "❓";
            this.labelMiddle.Text = "CƠ HỘI";
        }

        public SpecialTileControl(ITile tile) : base(tile)
        {
            this.SetUp();
            UpdateUI();
        }

        public void UpdateUI()
        {
            this.BackColor = Tile.TileColor;

            this.labelTop.Text = Tile.Symbol;
            this.labelMiddle.Text = Tile.TileName;
        }

        private void SetUp()
        {
            this.labelTop.Font = new Font("Segoe UI Emoji", 14.25F, FontStyle.Regular);
            this.labelTop.Size = new Size(90, 25);

            this.labelMiddle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.labelMiddle.Size = new Size(90, 24);

            this.labelHouse.Visible = false;
        }
    }
}
