using System;

namespace Monopoly {
    public class PropertySpace : Space {

        public int price;
        public int mortgage;
        public int[] houses = new int[6];
        public int rent;
        public int houseCount = 0;
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
        }

        public int Buy(Player player) {
            owner = player;
            owner.money = owner.money - price;
        }

        public int Mortgage() {
            owner.money = owner.money + mortgage;
            isMortgaged = true;
            return mortgage;
        }

        public int BuyBack() {
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
            owner.money = owner.money + (housePrice / 2);
        }
        
        public int ChargeRent(Player player) {
            int rentCharged = (houses[houseCount]);
            player.money = player.money - rentCharged;
            owner.money = owner.money + rentCharged;
            return rentCharged;
        }

        public void Trade(Player player) {
            owner = player;
        }

    }
}
