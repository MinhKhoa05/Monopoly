using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class a
    {
        public static void Ve()
        {
            using (var bmp = new Bitmap(60, 60))
            using (var g = Graphics.FromImage(bmp))
            {
                // Vẽ nền tile
                g.Clear(Color.White);

                // Vẽ viền
                using (var pen = new Pen(Color.Black, 1))
                    g.DrawRectangle(pen, 0, 0, 59, 59);

                // Vẽ thanh chờ màu
                g.FillRectangle(Brushes.White, 3, 3, 54, 12);
                g.DrawRectangle(Pens.Gray, 3, 3, 54, 12);

                bmp.Save("tile_base.png", System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}
