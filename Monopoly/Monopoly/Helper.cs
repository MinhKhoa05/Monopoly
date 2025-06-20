using System;
using System.Drawing;

namespace Monopoly
{
    public static class Helper
    {
        public static Color LightenColor(Color color, int amount = 70)
        {
            return Color.FromArgb(
                color.A,
                Math.Min(255, color.R + amount),
                Math.Min(255, color.G + amount),
                Math.Min(255, color.B + amount)
            );
        }
    }
}
