using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly {
    public abstract class ChanceCard {
        public Board board;
        public String Name;
        public ChanceCard(Board board) { this.board = board; }
        public abstract void Use(Player player, Player[] players);
    }

    public class CH1 : ChanceCard {
        public CH1(Board board) : base(board) {
            Name = "Advance to Go(Collect $200)";
        }
        public override void Use(Player player, Player[] players) {
            player.position = 0;
            player.money += 200;
        }
    }

    public class CH2 : ChanceCard {
        public CH2(Board board) : base(board) {
            Name = "Advance to Illinois Ave—If you pass Go, collect $200";
        }
        public override void Use(Player player, Player[] players) {
            if (player.position == 36) player.money += 200;
            player.position = 24;
            ((Buyable)board.Spaces[24]).Handle(player, 0);
        }
    }

    public class CH3 : ChanceCard {
        public CH3(Board board) : base(board) {
            Name = "Advance to St. Charles Place – If you pass Go, collect $200";
        }
        public override void Use(Player player, Player[] players) {
            if (player.position == 36 || player.position == 22) player.money += 200;
            player.position = 11;
            ((Buyable)board.Spaces[11]).Handle(player, 0);
        }
    }

    public class CH4 : ChanceCard {
        public CH4(Board board) : base(board) {
            Name = "Advance token to nearest Utility. If unowned, you may buy it from the Bank. If owned, throw dice and pay owner a total ten times the amount thrown.";
        }
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
        public CH5(Board board) : base(board) {
            Name = "Advance token to the nearest Railroad and pay owner twice the rental to which he/she {he} is otherwise entitled. If Railroad is unowned, you may buy it from the Bank.";
        }
        public override void Use(Player player, Player[] players) {
            if (player.position == 7) player.position = 15;
            else if (player.position == 22) player.position = 25;
            else { player.position = 5; player.money += 200; }
        }
    }

    public class CH6 : ChanceCard {
        public CH6(Board board) : base(board) {
            Name = "Bank pays you dividend of $50";
        }
        public override void Use(Player player, Player[] players) {
            player.money += 50;
        }
    }

    public class CH7 : ChanceCard {
        public CH7(Board board) : base(board) {
            Name = "Get Out of Jail Free";
        }
        public override void Use(Player player, Player[] players) {
            player.getOutOfJailOwned++;
        }
    }

    public class CH8 : ChanceCard {
        public CH8(Board board) : base(board) {
            Name = "Go Back 3 Spaces";
        }
        public override void Use(Player player, Player[] players) {
            player.position -= 3;
            board.Spaces[player.position].Handle(player, 0);
        }
    }

    public class CH9 : ChanceCard {
        public CH9(Board board) : base(board) {
            Name = "Go to Jail–Go directly to Jail–Do not pass Go, do not collect $200";
        }
        public override void Use(Player player, Player[] players) {
            player.inJail = true;
            player.position = 10;
        }
    }

    public class CH10 : ChanceCard {
        public CH10(Board board) : base(board) {
            Name = "Make general repairs on all your property–For each house pay $25–For each hotel $100";
        }
        public override void Use(Player player, Player[] players) {
            foreach (Space sp in board.Spaces) {
                if (sp is PropertySpace space) {
                    if (space.Owner == player) {
                        if (space.houseCount == 5) player.money -= 100;
                        else player.money -= space.houseCount * 25;
                    }
                }
            }
        }
    }
    public class CH11 : ChanceCard {
        public CH11(Board board) : base(board) {
            Name = "Pay poor tax of $15";
        }
        public override void Use(Player player, Player[] players) {
            player.money -= 15;
        }
    }

    public class CH12 : ChanceCard {
        public CH12(Board board) : base(board) {
            Name = "Take a trip to Reading Railroad–If you pass Go, collect $200";
        }
        public override void Use(Player player, Player[] players) {
            player.position = 5;
            player.money += 200;
        }
    }

    public class CH13 : ChanceCard {
        public CH13(Board board) : base(board) {
            Name = "Take a walk on the Boardwalk–Advance token to Boardwalk";
        }
        public override void Use(Player player, Player[] players) {
            player.position = 39;
            board.Spaces[39].Handle(player, 0);
        }
    }

    public class CH14 : ChanceCard {
        public CH14(Board board) : base(board) {
            Name = "You have been elected Chairman of the Board–Pay each player $50";
        }
        public override void Use(Player player, Player[] players) {
            foreach (Player p in players) {
                if (p != player && p.inGame) {
                    player.money -= 50;
                    p.money += 50;
                }
            }
        }
    }

    public class CH15 : ChanceCard {
        public CH15(Board board) : base(board) {
            Name = "You have won a crossword competition—Collect $100";
        }
        public override void Use(Player player, Player[] players) {
            player.money += 100;
        }
    }

    public class CH16 : ChanceCard {
        public CH16(Board board) : base(board) {
            Name = "Your building and loan matures—Collect $150";
        }
        public override void Use(Player player, Player[] players) {
            player.money += 150;
        }
    }

}
