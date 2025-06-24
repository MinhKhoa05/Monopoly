using System;
using System.Drawing;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Dice
    {
        private static readonly Random _random = new Random();
        public int Value { get; private set; }

        public event EventHandler Rolled; // Sự kiện mỗi lần hiện số mới

        public Bitmap Image
        {
            get
            {
                switch (Value)
                {
                    case 1: return Properties.Resources.dice_1;
                    case 2: return Properties.Resources.dice_2;
                    case 3: return Properties.Resources.dice_3;
                    case 4: return Properties.Resources.dice_4;
                    case 5: return Properties.Resources.dice_5;
                    case 6: return Properties.Resources.dice_6;
                    default: return null;
                }
            }
        }

        public Dice()
        {
            Value = _random.Next(1, 7);
        }

        /// <summary>
        /// Roll có hiệu ứng nhảy số liên tục, sau đó dừng lại.
        /// </summary>
        public async Task RollWithEffect(int rollTimes = 10, int delayMs = 100)
        {
            for (int i = 0; i < rollTimes; i++)
            {
                Value = _random.Next(1, 7);
                Rolled?.Invoke(this, EventArgs.Empty); // Gọi sự kiện sau mỗi lần random
                await Task.Delay(delayMs);
            }
        }
    }
}
