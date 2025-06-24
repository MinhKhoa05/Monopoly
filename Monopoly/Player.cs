using System;
using System.Collections.Generic;
using System.Drawing;
using Monopoly.Tiles;

namespace Monopoly
{
    public class Player
    {
        public int Id { get; }
        public string Name { get; }
        public Color Color { get; }
        public string Token { get; }
        public int Money { get; private set; }
        public int Position { get; private set; }
        public List<PropertyTile> Properties { get; } = new List<PropertyTile>();

        public event EventHandler<PlayerMovedEventArgs> PlayerMoved;
        public event EventHandler<PlayerMoneyChangedEventArgs> MoneyChanged;

        public Player(int id, string name, Color color, string token = "⭐", int startingMoney = 20000)
        {
            Id = id;
            Name = name;
            Color = color;
            Token = token;
            Money = startingMoney;
        }

        public void Move(int steps)
        {
            if (steps < 0) throw new ArgumentException("Steps must be non-negative.");

            int oldPosition = Position;
            Position += steps;

            bool passedGo = false;
            if (Position >= GameConfig.BoardSize)
            {
                Money += GameConfig.PassGoBonus;
                MoneyChanged?.Invoke(this, new PlayerMoneyChangedEventArgs(Money));
                Position %= GameConfig.BoardSize;
                passedGo = true;
            }

            PlayerMoved?.Invoke(this, new PlayerMovedEventArgs(oldPosition, Position, passedGo));
        }

        public void PayRent(Player recipient, int amount)
        {
            if (Money < amount)
                throw new InvalidOperationException($"{Name} does not have enough money to pay rent.");

            Money -= amount;
            MoneyChanged?.Invoke(this, new PlayerMoneyChangedEventArgs(Money));

            recipient.ReceiveMoney(amount);
        }

        public void Buy(PropertyTile property)
        {
            if (Money < property.Price)
                throw new InvalidOperationException($"{Name} does not have enough money to buy {property.Name}.");

            Money -= property.Price;
            MoneyChanged?.Invoke(this, new PlayerMoneyChangedEventArgs(Money));

            Properties.Add(property);
            property.Owner = this;
        }

        public void ReceiveMoney(int amount)
        {
            if (amount < 0) throw new ArgumentException("Amount must be non-negative.");

            Money += amount;
            MoneyChanged?.Invoke(this, new PlayerMoneyChangedEventArgs(Money));
        }

        public string GetInfo()
        {
            return $"({Position}) {Name} - {Money}$";
        }
    }

    public class PlayerMovedEventArgs : EventArgs
    {
        public int OldPosition { get; }
        public int NewPosition { get; }
        public bool PassedGo { get; }

        public PlayerMovedEventArgs(int oldPos, int newPos, bool passedGo)
        {
            OldPosition = oldPos;
            NewPosition = newPos;
            PassedGo = passedGo;
        }
    }

    public class PlayerMoneyChangedEventArgs : EventArgs
    {
        public int NewMoney { get; }

        public PlayerMoneyChangedEventArgs(int newMoney)
        {
            NewMoney = newMoney;
        }
    }
}
