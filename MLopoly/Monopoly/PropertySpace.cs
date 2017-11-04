using System;

namespace Monopoly {
    public class PropertySpace : Buyable {

        public int price;
        public int mortgage;
        public int[] houses = new int[6];
        public int rent;
        public int houseCount = 0;
        public int housePrice;

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
            Owner = player;
            Owner.money = Owner.money - price;
            return price;
        }

        override public int Mortgage() {
            Owner.money = Owner.money + mortgage;
            IsMortgaged = true;
            return mortgage;
        }

        override public int BuyBack() {
            int buyCost = (int)(mortgage * 1.1);
            Owner.money = Owner.money - buyCost;
            IsMortgaged = false;
            return buyCost;
        }

        public int AddHouse() {
            houseCount++;
            Owner.money = Owner.money - housePrice;
            return houseCount;
        }

        public int SellHouse() {
            houseCount--;
            int sellPrice = (housePrice / 2);
            Owner.money = Owner.money + sellPrice;
            return sellPrice;
        }
        
        override public int ChargeRent(Player player, int roll) {
            int rentCharged = (houses[houseCount]);
            player.money = player.money - rentCharged;
            Owner.money = Owner.money + rentCharged;
            if (rentCharged > 200) {
                Console.ReadLine();
            }
            return rentCharged;
        }

        override public void Trade(Player player) {
            Owner = player;
        }

        public override int Handle(Player curPlayer, int roll) {
            //if unowned
            if(Owner == null) {
                bool purchase = false;
                if(curPlayer.isAI){
                //TODO offer to buy
                }
                else{
                    Console.WriteLine("Would you like to buy " + name + " for $" + price + "? Enter an integer");
                    Console.WriteLine("1: Yes");
                    Console.WriteLine("2: No");
                    int ans = int.Parse(Console.ReadLine());
                    if(ans == 1){
                        purchase = true;
                    }
                }
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
            else{
                //if not owned by player
                if(Owner != curPlayer) {
                    ChargeRent(curPlayer, roll);
                    return 0;
                }
                //if owned by player
                else {
                    return 0;
                }
            }
        }

        public override int GetPrice() {
            return price;
        }

    }
}
