using System;

namespace Monopoly {
    public class ElectricCompanySpace : Space {

        public int cost = 150;
        public int mortgage = 75;
        public Player owner;
        public bool isMortgaged = false;

        public ElectricCompanySpace(string name, int ID) : base(name, ID) {
        }

        public int Buy(Player player) {
            owner = player;
            owner.utilsOwned++;
            owner.money = owner.money - cost;
            return cost;
        }

        public int Mortgage() {
            isMortgaged = true;
            owner.money = owner.money + mortgage;
            return mortgage;
        }

        public int BuyBack() {
            isMortgaged = false;
            int BuyCost = (int)(mortgage * 1.1);
            owner.money = owner.money - BuyCost;
            return BuyCost;
        }

        public int ChargeRent(Player player, int roll) {
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

        public void Trade(Player player) {
            owner = player;
        }
    }
}
