using System;

namespace Monopoly {
    public class RailroadSpace : Buyable {

        public int price = 200;
        public int mortgage = 100;
        public Player owner;
        bool isMortgaged = false;

        public RailroadSpace(string name, int ID) : base(name, ID) {
        }

        override public int Buy(Player player) {
            owner = player;
            owner.railroadsOwned++;
            owner.money = owner.money - price;
            return price;
        }

        override public int Mortgage() {
            owner.money = owner.money + mortgage;
            isMortgaged = true;
            return mortgage;
        }

        override public int BuyBack() {
            int buyCost = (int)(mortgage * 1.1);
            owner.money = owner.money - buyCost;
            isMortgaged = false;
            return buyCost;
        }

        override public int ChargeRent(Player player, int roll) {
            int cost = 0;
            switch (owner.railroadsOwned){
                case 1:
                    cost = 25;
                    break;
                case 2:
                    cost = 50;
                    break;
                case 3:
                    cost = 100;
                    break;
                case 4:
                    cost = 200;
                    break;
            }
            player.money = player.money - cost;
            owner.money = owner.money + cost;
            return cost;
        }

        override public void Trade(Player player) {
            owner = player;
        }

        public override int Handle(Player curPlayer, int roll) {
            //if unowned
            if(owner == null) {
                bool purchase = false;
                //TODO offer to buy
                //Player buys it
                if (purchase) {
                    Buy(curPlayer);
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
                if(owner != curPlayer) {
                    ChargeRent(curPlayer, roll);
                    return 0;
                }
                //if owned by player
                else {
                    return 0;
                }
            }
        }

        public override int getPrice() {
            return price;
        }
    }
}
