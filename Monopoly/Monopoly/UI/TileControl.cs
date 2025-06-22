using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Monopoly.Renderers;
using Monopoly.Tiles;

namespace Monopoly.UI
{
    /// <summary>
    /// Điều khiển UI đại diện cho một ô trong game Monopoly.
    /// </summary>
    public class TileControl : UserControl
    {
        private ITile tile;
        private readonly List<Player> playersOnTile = new List<Player>();

        public event EventHandler<TileClickedEventArgs> TileClicked;

        public ITile Tile
        {
            get => tile;
            set
            {
                tile = value;
                Invalidate();
            }
        }

        public TileControl()
        {
            DoubleBuffered = true;
            Width = 90;
            Height = 65;
            BackColor = Color.White;
        }

        public TileControl(ITile tile) : this()
        {
            Tile = tile;

            if (tile is PropertyTile propertyTile)
            {
                propertyTile.OnOfferToBuy += HandleOfferToBuy;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (Tile == null) return;

            var renderer = TileRendererProvider.GetRenderer(Tile);
            renderer?.RenderTile(e.Graphics, ClientRectangle, Tile, playersOnTile);
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
            if (!playersOnTile.Contains(player))
                playersOnTile.Add(player);

            Invalidate();
            Tile?.OnEnter(player);
            Invalidate();
        }

        public void OnLeave(Player player)
        {
            playersOnTile.Remove(player);

            Tile?.OnLeave(player);
            Invalidate();
        }

        private void HandleOfferToBuy(Player player, PropertyTile property)
        {
            var result = MessageBox.Show(
                $"{player.Name} có muốn mua {property.TileName} với giá ${property.Price} không?",
                "Cơ hội đầu tư",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes) return;

            try
            {
                player.Buy(property);
                property.HouseCount++;
                MessageBox.Show(
                    $"{player.Name} đã mua {property.TileName}!",
                    "Giao dịch thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Lỗi giao dịch",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }

    /// <summary>
    /// Event args cho sự kiện click vào ô.
    /// </summary>
    public class TileClickedEventArgs : EventArgs
    {
        public ITile Tile { get; }

        public TileClickedEventArgs(ITile tile)
        {
            Tile = tile;
        }
    }
}
