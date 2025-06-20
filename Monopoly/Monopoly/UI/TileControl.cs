using System;
using System.Drawing;
using System.Windows.Forms;
using Monopoly.Renderers;
using Monopoly.Tiles;

namespace Monopoly.UI
{
    public class TileControl : UserControl
    {
        private ITile tile;
        public event EventHandler<TileClickedEventArgs> TileClicked;

        public ITile Tile
        {
            get => tile;
            set
            {
                tile = value;
                Invalidate(); // Vẽ lại nếu đổi tile
            }
        }

        public TileControl()
        {
            this.DoubleBuffered = true;
            this.Width = 90;
            this.Height = 65;
            this.BackColor = Color.White;
        }

        public TileControl(ITile tile) : this()
        {
            this.Tile = tile;

            if (tile is PropertyTile propertyTile)
            {
                propertyTile.OnOfferToBuy += HandleOfferToBuy; // Đăng ký sự kiện mua bán
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var renderer = TileRendererFactory.GetRenderer(Tile);
            if (renderer != null)
            {
                renderer.Render(Tile, e.Graphics, this.ClientRectangle);
            }        
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if (Tile != null)
            {
                TileClicked?.Invoke(this, new TileClickedEventArgs(Tile));
            }
        }

        public void OnEnter(Player player)
        {
            Invalidate(); // Cập nhật giao diện khi có người chơi vào
            tile.OnEnter(player);
            Invalidate(); // Cập nhật giao diện khi có người chơi vào
        }

        public void OnLeave(Player player)
        {
            tile.OnLeave(player);
            Invalidate(); // Cập nhật giao diện khi có người chơi rời
        }

        private void HandleOfferToBuy(Player player, PropertyTile property)
        {
            var result = MessageBox.Show(
                $"{player.Name} có muốn mua {property.TileName} với giá ${property.Price} không?",
                "Cơ hội đầu tư",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    player.Buy(property);
                    property.HouseCount++;
                    MessageBox.Show($"{player.Name} đã mua {property.TileName}!", "Giao dịch thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi giao dịch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }


    public class TileClickedEventArgs : EventArgs
    {
        public ITile Tile { get; }

        public TileClickedEventArgs(ITile tile)
        {
            Tile = tile;
        }
    }
}