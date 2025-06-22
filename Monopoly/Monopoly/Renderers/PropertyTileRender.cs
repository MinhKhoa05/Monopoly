using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Monopoly.Tiles;

namespace Monopoly.Renderers
{
    /// <summary>
    /// Renderer cho các ô bất động sản (PropertyTile).
    /// </summary>
    public class PropertyTileRenderer : BaseTileRenderer
    {
        protected override void RenderTileDetails(Graphics g, Rectangle bounds, ITile tile)
        {
            if (!(tile is PropertyTile property)) return;

            // Tên ô
            using (var font = new Font("Segoe UI", 9f, FontStyle.Bold))
            {
                using (var format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    var nameRect = new Rectangle(2, 10, bounds.Width - 4, 16);
                    g.DrawString(property.TileName, font, Brushes.Black, nameRect, format);
                }
            }

            // Giá
            using (var font = new Font("Segoe UI", 8f))
            {
                using (var format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    var priceRect = new Rectangle(2, 30, bounds.Width - 4, 12);
                    g.DrawString($"${property.Price}", font, Brushes.Black, priceRect, format);
                }
            }
        }

        /// <summary>
        /// Vẽ khung bo tròn phía dưới và nhà (nếu có).
        /// </summary>
        protected override void DrawHouses(Graphics g, Rectangle bounds, ITile tile)
        {
            if (!(tile is PropertyTile property)) return;

            var frameRect = new Rectangle(1, bounds.Height - 15, bounds.Width - 2, 15);
            int cornerRadius = 4;

            using (var path = new GraphicsPath())
            {
                path.AddArc(frameRect.X, frameRect.Y, cornerRadius, cornerRadius, 180, 90);
                path.AddArc(frameRect.Right - cornerRadius, frameRect.Y, cornerRadius, cornerRadius, 270, 90);
                path.AddArc(frameRect.Right - cornerRadius, frameRect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90);
                path.AddArc(frameRect.X, frameRect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90);
                path.CloseFigure();

                // Vẽ khung bo tròn
                var color = property.Owner != null ? property.Owner.Color : Color.LightGray;
                using (var brush = new SolidBrush(color))
                {
                    g.FillPath(brush, path);
                }

                g.DrawPath(Pens.Gray, path);
            }

            // Vẽ các ngôi nhà (tối đa 4)
            int houseSlotWidth = frameRect.Width / 4;
            int houseSize = Math.Min(houseSlotWidth - 4, 12);

            for (int i = 0; i < Math.Min(property.HouseCount, 4); i++)
            {
                int x = frameRect.X + i * houseSlotWidth + (houseSlotWidth - houseSize) / 2;
                int y = frameRect.Y + (frameRect.Height - houseSize) / 2;
                var houseRect = new Rectangle(x, y, houseSize, houseSize);

                g.FillRectangle(Brushes.LimeGreen, houseRect);
                g.DrawRectangle(Pens.DarkGreen, houseRect);
            }
        }
    }
}
