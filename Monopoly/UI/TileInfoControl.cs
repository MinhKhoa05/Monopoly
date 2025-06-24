using System.Windows.Forms;
using Monopoly.Tiles;

namespace Monopoly.UI
{
    public partial class TileInfoControl : UserControl
    {
        private BaseTile _tile;

        public BaseTile Tile
        {
            get { return _tile; }
            set
            {
                _tile = value;
                UpdateUI();
            }
        }

        public TileInfoControl()
        {
            InitializeComponent();
        }

        public void UpdateUI()
        {
            if (_tile == null) return;

            labelTileName.Text = $"THÔNG TIN Ô: {_tile.Name}";
            labelTileName.BackColor = _tile.Color;
            labelTileInfo.Text = _tile.GetInfo();
            this.Visible = true;
        }
    }
}
