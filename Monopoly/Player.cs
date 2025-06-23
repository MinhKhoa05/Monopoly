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
        public string Token { get; set; }
        public List<PropertyTile> properties { get; set; } = new List<PropertyTile>();

        public Player(string name, Color color, string token = "⭐", int money = 20000)
        {
            Name = name;
            Color = color;
            Token = token;
            Money = money;
        }

        public void Move(int steps)
        {
            if (steps < 0) throw new ArgumentException("Steps must be non-negative.");

            Position += steps;
            if (Position >= GameConfig.BoardSize)
            {
                Money += GameConfig.PassGoBonus; // Nhận tiền thưởng khi đi qua ô "Go"
                Position %= GameConfig.BoardSize; // Quay về vị trí hợp lệ trên bàn cờ
            }
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

        public string GetInfo()
        {
            return $"({Position}) {Name} - {Money}$";
        }
    }
}
