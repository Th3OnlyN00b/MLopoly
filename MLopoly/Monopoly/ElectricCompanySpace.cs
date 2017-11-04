using System;

namespace Monopoly {
    public class ElectricCompanySpace : Buyable {

        public int price = 150;
        public int mortgage = 75;
        public Player owner;
        public bool isMortgaged = false;

        public ElectricCompanySpace(string name, int ID) : base(name, ID) {
        }
         
        override public int Buy(Player player) {
            owner = player;
            owner.utilsOwned++;
            owner.money = owner.money - price;
            return price;
        }

        override public int Mortgage() {
            isMortgaged = true;
            owner.money = owner.money + mortgage;
            return mortgage;
        }

        override public int BuyBack() {
            isMortgaged = false;
            int BuyCost = (int)(mortgage * 1.1);
            owner.money = owner.money - BuyCost;
            return BuyCost;
        }

        override public int ChargeRent(Player player, int roll) {
            int rentCost;
            if (owner.utilsOwned == 1) {
                rentCost = 4 * roll;
            }
            else {
                rentCost = 10 * roll;
            }
            player.money = player.money - rentCost;
            owner.money = owner.money + rentCost;
            return rentCost;
        }

        override public int Handle(Player player, int roll) {
            //if unowned
            if (owner == null) {
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
                if (owner != player) {
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
            owner = player;
        }

        override public int getPrice() {
            return price;
        }
    }
}
