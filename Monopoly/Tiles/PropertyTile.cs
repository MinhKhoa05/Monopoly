using System;
using System.Drawing;
using Monopoly.Events;

namespace Monopoly.Tiles
{
    public class PropertyTile : BaseTile
    {
        public int Price { get; }
        public Player Owner { get; private set; }
        public int PriceLevel { get; }
        public int HouseCount { get; private set; }

        public event EventHandler<TileActionEventArgs> TileAction;

        public PropertyTile(string tileName, Color tileColor, int price, int priceLevel)
            : base(tileName, tileColor)
        {
            Price = price;
            PriceLevel = priceLevel;
        }

        public override void OnEnter(Player player)
        {
            if (Owner == null)
            {
                var args = new TileActionEventArgs($"{player.Name} có muốn mua '{Name}' với giá {Price}$ không?", true);
                TileAction?.Invoke(this, args);

                if (args.Confirmed)
                {
                    try
                    {
                        player.Buy(this);
                        TileAction?.Invoke(this, new TileActionEventArgs($"{player.Name} đã mua {Name} với giá {Price}$"));
                    } catch (Exception ex)
                    {
                        TileAction.Invoke(this, new TileActionEventArgs(ex.Message));
                    }
                }
            }
            else if (Owner.Equals(player))
            {
                var args = new TileActionEventArgs($"{player.Name} có muốn xây nhà ở ô '{Name}' với giá {PriceLevel}$ không?", true);
                TileAction?.Invoke(this, args);

                if (args.Confirmed)
                {
                    try
                    {
                        player.Build(this);
                        TileAction?.Invoke(this, new TileActionEventArgs($"{player.Name} đã xây thêm nhà ở ô {Name}"));
                    }
                    catch (Exception ex)
                    {
                        TileAction.Invoke(this, new TileActionEventArgs(ex.Message));
                    }
                }
            }
            else if (Owner != player)
            {
                player.PayRent(Owner, PriceLevel);
                TileAction?.Invoke(this, new TileActionEventArgs($"{player.Name} vừa trả tiền thuê cho {Owner.Name}"));
            }
        }

        public override string GetInfo()
        {
            string ownerInfo = Owner != null ? $"Chủ sở hữu: {Owner.Name}" : "Chưa có chủ sở hữu";
            return base.GetInfo() +
                   $"\nGiá: ${Price}\nCấp độ giá: {PriceLevel}\nSố nhà: {HouseCount}\n" + ownerInfo;
        }

        public void BuildHouse()
        {
            HouseCount++;
        }

        public void SetOwner(Player owner)
        {
            Owner = owner;
        }
    }
}
