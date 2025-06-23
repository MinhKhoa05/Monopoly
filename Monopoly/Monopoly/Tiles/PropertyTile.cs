using System;
using System.Drawing;

namespace Monopoly.Tiles
{
    public class PropertyTile : BaseTile
    {
        public int Price { get; set; }
        public Player Owner { get; set; }
        public int PriceLevel { get; set; }
        public int HouseCount { get; set; } = 4;
        public Action<Player, PropertyTile> OnOfferToBuy;

        public PropertyTile(string tileName, Color tileColor, int price, int priceLevel)
            : base(tileName, tileColor)
        {
            Price = price;
            PriceLevel = priceLevel;
        }

        public override void OnEnter(Player player)
        {
            base.OnEnter(player);

            if (Owner == null)
                OnOfferToBuy?.Invoke(player, this);
            else if (Owner != player)
                player.PayRent(Owner, PriceLevel);
        }

        public override string GetInfo()
        {
            string ownerInfo = Owner != null ? $"Chủ sở hữu: {Owner.Name}" : "Chưa có chủ sở hữu";
            return base.GetInfo() +
                   $"\nGiá: ${Price}\nCấp độ giá: {PriceLevel}\nSố nhà: {HouseCount}\n" + ownerInfo;
        }
    }
}
