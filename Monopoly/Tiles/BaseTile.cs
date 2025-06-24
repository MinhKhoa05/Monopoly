using System;
using System.Drawing;

namespace Monopoly.Tiles
{
    public abstract class BaseTile
    {
        public string Name { get; }
        public Color Color { get; }

        protected BaseTile(string name, Color color)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Color = Helper.LightenColor(color);
        }

        /// <summary>
        /// Hành động khi người chơi đi vào ô này.
        /// </summary>
        public abstract void OnEnter(Player player);

        /// <summary>
        /// Lấy thông tin mô tả của ô.
        /// </summary>
        public virtual string GetInfo()
        {
            return $"Thông tin ô {Name}";
        }
    }
}
