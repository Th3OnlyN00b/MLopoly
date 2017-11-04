using System;

namespace Monopoly {
    public class WaterworksSpace : Buyable {

        public int price = 150;
        public int mortgage = 75;
        public bool isMortgaged = false;

        public WaterworksSpace(string name, int ID) : base(name, ID) {
        }

        override public int Buy(Player player) {
            Owner = player;
            Owner.utilsOwned++;
            Owner.money = Owner.money - price;
            return price;
        }

        override public int Mortgage() {
            isMortgaged = true;
            Owner.money = Owner.money + mortgage;
            return mortgage;
        }

        override public int BuyBack() {
            isMortgaged = false;
            int BuyCost = (int)(mortgage * 1.1);
            Owner.money = Owner.money - BuyCost;
            return BuyCost;
        }

        override public int ChargeRent(Player player, int roll) {
            int rentCost;
            if (Owner.utilsOwned == 1) {
                rentCost = 4 * roll;
            }
            else {
                rentCost = 10 * roll;
            }
            player.money = player.money - rentCost;
            Owner.money = Owner.money + rentCost;
            return rentCost;
        }
        
        override public int Handle(Player player, int roll) {
            //if unowned
            if(Owner == null) {
                bool purchase = false;
                //TODO offer to buy
                //Player buys it
                if (purchase) {
                    Buy(player);
                    return 0;
                }
                //Auction needs to happen
                else {
                    return 1;
                }
            }
            //if owned
            else {
                //if not owned by player
                if(Owner != player) {
                    ChargeRent(player, roll);
                    return 0;
                }
                //if owned by player
                else {
                    return 0;
                }
            }
        }

        override public void Trade(Player player) {
            Owner = player;
        }

        public override int GetPrice() {
            return price;
        }
    }
}
