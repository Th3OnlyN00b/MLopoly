using System;

namespace Monopoly {
    public class PropertySpace : Buyable {

        public int price;
        public int mortgage;
        public int[] houses = new int[6];
        public int rent;
        public int houseCount = 0;
        public int housePrice;
        public bool isMortgaged = false;
        public Player owner;

        public PropertySpace(string name, int ID, int price, int housePrice, int rent, int house1, int house2, int house3, int house4, int house5) : base(name, ID) {
            this.price = price;
            mortgage = price/2;
            houses[0] = rent;
            houses[1] = house1;
            houses[2] = house2;
            houses[3] = house3;
            houses[4] = house4;
            houses[5] = house5;
            this.housePrice = housePrice;
        }

        override public int Buy(Player player) {
            owner = player;
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

        public int AddHouse() {
            houseCount++;
            owner.money = owner.money - housePrice;
            return houseCount;
        }

        public int SellHouse() {
            houseCount--;
            int sellPrice = (housePrice / 2);
            owner.money = owner.money + sellPrice;
            return sellPrice;
        }
        
        override public int ChargeRent(Player player, int roll) {
            int rentCharged = (houses[houseCount]);
            player.money = player.money - rentCharged;
            owner.money = owner.money + rentCharged;
            return rentCharged;
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
                if(owner != player) {
                    ChargeRent(player, roll);
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
