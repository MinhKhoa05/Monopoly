using System.Drawing;
using System;
using System.Collections.Generic;
using Monopoly.Tiles;

namespace Monopoly
{
    public class Player
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public int Money { get; private set; }
        public int Position { get; private set; }
        public List<PropertyTile> properties { get; set; } = new List<PropertyTile>(); // Danh sách tài sản của người chơi

        public int Index { get; set; } // <= đây là chỉ số cố định, từ 0 đến 3

        public Player(string name, Color color, int money = 20000, int index = 0)
        {
            Name = name;
            Color = color;
            Money = money;
            Index = index;
        }

        public int Move(int steps)
        {
            if (steps < 0) throw new ArgumentException("Steps must be non-negative.");
            Position += steps;

            return Position;
        }

        public void PayRent(Player player, int amount)
        {
            if (Money >= amount)
            {
                Money -= amount;
                player.ReceiveMoney(amount); // Transfer money to the owner
            }
            else
            {
                throw new InvalidOperationException($"{Name} does not have enough money to pay rent.");
            }
        }

        public void Buy(PropertyTile property)
        {
            if (Money >= property.Price)
            {
                properties.Add(property);
                Money -= property.Price;
                property.Owner = this; // Set the owner of the property
            }
            else
            {
                throw new InvalidOperationException($"{Name} does not have enough money to buy {property.TileName}.");
            }
        }

        public void ReceiveMoney(int amount)
        {
            if (amount < 0) throw new ArgumentException("Amount must be non-negative.");
            Money += amount;
        }
    }
}
