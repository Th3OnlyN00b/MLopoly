using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly {
    public abstract class ChanceCard {
        public Board board;
        public ChanceCard(Board board) { this.board = board; }
        public abstract void Use(Player player, Player[] players);
    }

    public class CH1 : ChanceCard {
        public CH1(Board board) : base(board) { }
        public override void Use(Player player, Player[] players) {
            player.position = 0;
            player.money += 200;
        }
    }

    public class CH2 : ChanceCard {
        public CH2(Board board) : base(board) { }
        public override void Use(Player player, Player[] players) {
            if(player.position == 36) player.money += 200;
            player.position = 24;
            ((Buyable)board.Spaces[24]).Handle(player, 0);
        }
    }

    public class CH3 : ChanceCard {
        public CH3(Board board) : base(board) { }
        public override void Use(Player player, Player[] players) {
            if (player.position == 36 || player.position == 22) player.money += 200;
            player.position = 11;
            ((Buyable)board.Spaces[11]).Handle(player, 0);
        }
    }

    public class CH4 : ChanceCard {
        public CH4(Board board) : base(board) { }
        public override void Use(Player player, Player[] players) {
            Player owner;
            if (player.position == 22) {
                player.position = 28;
                owner = ((Buyable)board.Spaces[28]).Owner;
            } else {
                player.position = 12;
                owner = ((Buyable)board.Spaces[12]).Owner;
            }
            if (owner == null) {
                // TODO Offer Buy
            } else if (owner != player) {
                int roll = 10 * Game.RollDice();
                player.money -= roll;
                owner.money += roll;
            }


        }
    }

    public class CH5 : ChanceCard {
        public CH5(Board board) : base(board) { }
        public override void Use(Player player, Player[] players) {
            //Advance token to the nearest Railroad and pay owner twice the rental to which he/she {he} is otherwise entitled.
            //If Railroad is unowned, you may buy it from the Bank.
        }
    }

    public class CH6 : ChanceCard {
        public CH6(Board board) : base(board) { }
        public override void Use(Player player, Player[] players) {
            player.money += 50;
        }
    }

    public class CH7 : ChanceCard {
        public CH7(Board board) : base(board) { }
        public override void Use(Player player, Player[] players) {
            player.getOutOfJailOwned++;
        }
    }

    public class CH8 : ChanceCard {
        public CH8(Board board) : base(board) { }
        public override void Use(Player player, Player[] players) {
            player.position -= 3;
            board.Spaces[player.position].Handle(player, 0);
        }
    }

    public class CH9 : ChanceCard {
        public CH9(Board board) : base(board) { }
        public override void Use(Player player, Player[] players) {
            player.inJail = true;
            player.position = 10;
        }
    }

    public class CH10 : ChanceCard {
        public CH10(Board board) : base(board) { }
        public override void Use(Player player, Player[] players) {
            foreach(PropertySpace space in board.Spaces) {
                if (space.Owner == player) {
                    if (space.houseCount == 5) player.money -= 100;
                    else player.money -= space.houseCount * 25;
                }
               
            }
        }
    }
    public class CH11 : ChanceCard {
        public CH11(Board board) : base(board) { }
        public override void Use(Player player, Player[] players) {
            player.money -= 15;
        }
    }

    public class CH12 : ChanceCard {
        public CH12(Board board) : base(board) { }
        public override void Use(Player player, Player[] players) {
            //Take a trip to Reading Railroad–If you pass Go, collect $200
        }
    }

    public class CH13 : ChanceCard {
        public CH13(Board board) : base(board) { }
        public override void Use(Player player, Player[] players) {
            //Take a walk on the Boardwalk–Advance token to Boardwalk
            player.position = 39;
            board.Spaces[39].Handle(player, 0);
        }
    }

    public class CH14 : ChanceCard {
        public CH14(Board board) : base(board) { }
        public override void Use(Player player, Player[] players) {
            foreach(Player p in players) { 
                if(p != player && p.inGame) {
                    player.money -= 50;
                    p.money += 50;
                }
            }
        }
    }

    public class CH15 : ChanceCard {
        public CH15(Board board) : base(board) { }
        public override void Use(Player player, Player[] players) {
            player.money += 100;
        }
    }

    public class CH16 : ChanceCard {
        public CH16(Board board) : base(board) { }
        public override void Use(Player player, Player[] players) {
            player.money += 150;
        }
    }

}
