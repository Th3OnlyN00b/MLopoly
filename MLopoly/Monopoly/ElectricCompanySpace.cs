﻿using System;

namespace Monopoly {
    public class ElectricCompanySpace : Buyable {

        public int price = 150;
        public int mortgage = 75;

        public ElectricCompanySpace(string name, int ID) : base(name, ID) {
        }
         
        override public int Buy(Player player) {
            Owner = player;
            Owner.utilsOwned++;
            Owner.money = Owner.money - price;
            return price;
        }

        override public int Mortgage() {
            IsMortgaged = true;
            Owner.money = Owner.money + mortgage;
            return mortgage;
        }

        override public int BuyBack() {
            IsMortgaged = false;
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
            if (Owner == null) {
                bool purchase = false;
                if (player.isAI) {
                    if (player.money > (price)) {
                        Buy(player);
                        return 0;
                    }
                }
                else {
                    Console.WriteLine("Would you like to buy " + name + " for $" + price + "? Enter an integer");
                    Console.WriteLine("1: Yes");
                    Console.WriteLine("2: No");
                    int ans = int.Parse(Console.ReadLine());
                    if (ans == 1) {
                        purchase = true;
                    }
                }
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
                if (Owner != player) {
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

        override public int GetPrice() {
            return price;
        }
    }
}
