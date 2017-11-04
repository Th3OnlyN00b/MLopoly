using System;

namespace Monopoly {
    public class RailroadSpace : Space {

        public int price = 200;
        public int mortgage = 100;
        public Player owner;
        bool isMortgaged = false;

        public RailroadSpace(string name, int ID) : base(name, ID) {
        }

        public int Buy(Player player) {
            owner = player;
            owner.railroadsOwned++;
            owner.money = owner.money - price;
            return price;
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

        public int ChargeRent(Player player) {
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

        public void Trade(Player player) {
            owner = player;
        }
    }
}
