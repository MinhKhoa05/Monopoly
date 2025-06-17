using System;
using System.Drawing;

namespace Monopoly
{
    public class Dice
    {
        private static readonly Random _random = new Random();
        public int Value { get; private set; }

        public Bitmap Image
        {
            get {
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
            Roll(); // Initialize with a random value
        }

        public void Roll()
        {
            Value = _random.Next(1, 7); // Generates a number between 1 and 6
        }
    }
}