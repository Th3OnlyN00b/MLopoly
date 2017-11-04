using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly {
    public abstract class CommunityChestCard {
        public Board board;
        public String Name;
        public CommunityChestCard(Board board) { this.board = board; }
        public abstract void Use(Player player, Player[] players);
    }

    public class CC1 : CommunityChestCard {
        public CC1(Board board) : base(board) {
            Name = "Advance to Go(Collect $200)";
        }
        public override void Use(Player player, Player[] players) {
            player.position = 0;
            player.money += 200;
        }
    }

    public class CC2 : CommunityChestCard {
        public CC2(Board board) : base(board) {
            Name = "Bank error in your favor—Collect $200";
        }
        public override void Use(Player player, Player[] players) {
            player.money += 200;
        }
    }

    public class CC3 : CommunityChestCard {
        public CC3(Board board) : base(board) {
            Name = "Doctor's fee—Pay $50";
        }
        public override void Use(Player player, Player[] players) {
            player.money -= 50;
        }
    }

    public class CC4 : CommunityChestCard {
        public CC4(Board board) : base(board) {
            Name = "From sale of stock you get $50";
        }
        public override void Use(Player player, Player[] players) {
            player.money += 50;
        }
    }

    public class CC5 : CommunityChestCard {
        public CC5(Board board) : base(board) {
            Name = "Get Out of Jail Free";
        }
        public override void Use(Player player, Player[] players) {
            player.getOutOfJailOwned++;
        }
    }

    public class CC6 : CommunityChestCard {
        public CC6(Board board) : base(board) {
            Name = "Go to Jail–Go directly to jail–Do not pass Go–Do not collect $200";
        }
        public override void Use(Player player, Player[] players) {
            player.position = 10;
            player.inJail = true;
        }
    }

    public class CC7 : CommunityChestCard {
        public CC7(Board board) : base(board) {
            Name = "Grand Opera Night—Collect $50 from every player for opening night seats";
        }
        public override void Use(Player player, Player[] players) {
            foreach(Player p in players) {
                if(p != player && p.inGame) {
                    p.money -= 50;
                    player.money += 50;
                }
            }
        }
    }

    public class CC8 : CommunityChestCard {
        public CC8(Board board) : base(board) {
            Name = "Holiday Fund matures—Receive $100";
        }
        public override void Use(Player player, Player[] players) {
            player.money += 100;
        }
    }

    public class CC9 : CommunityChestCard {
        public CC9(Board board) : base(board) {
            Name = "Income tax refund–Collect $20";
        }
        public override void Use(Player player, Player[] players) {
            player.money += 20;
        }
    }

    public class CC10 : CommunityChestCard {
        public CC10(Board board) : base(board) {
            Name = "It is your birthday—Collect $10";
        }
        public override void Use(Player player, Player[] players) {
            player.money += 10;
        }
    }

    public class CC11 : CommunityChestCard {
        public CC11(Board board) : base(board) {
            Name = "Life insurance matures–Collect $100";
        }
        public override void Use(Player player, Player[] players) {
            player.money += 100;
        }
    }

    public class CC12 : CommunityChestCard {
        public CC12(Board board) : base(board) {
            Name = "Pay hospital fees of $100";
        }
        public override void Use(Player player, Player[] players) {
            player.money -= 100;
        }
    }

    public class CC13 : CommunityChestCard {
        public CC13(Board board) : base(board) {
            Name = "Pay school fees of $150";
        }
        public override void Use(Player player, Player[] players) {
            player.money -= 150;
        }
    }

    public class CC14 : CommunityChestCard {
        public CC14(Board board) : base(board) {
            Name = "Receive $25 consultancy fee";
        }
        public override void Use(Player player, Player[] players) {
            player.money += 25;
        }
    }

    public class CC15 : CommunityChestCard {
        public CC15(Board board) : base(board) {
            Name = "You are assessed for street repairs–$40 per house–$115 per hotel";
        }
        public override void Use(Player player, Player[] players) {
            foreach(Space sp in board.Spaces) {
                if(sp is PropertySpace ps) {
                    if (ps.Owner == player) {
                        if (ps.houseCount != 5) player.money -= 40*ps.houseCount;
                        else player.money -= 115;
                    }
                }
            }
        }
    }

    public class CC16 : CommunityChestCard {
        public CC16(Board board) : base(board) {
            Name = "You have won second prize in a beauty contest–Collect $10";
        }
        public override void Use(Player player, Player[] players) {
            player.money += 10;
        }
    }

    public class CC17 : CommunityChestCard {
        public CC17(Board board) : base(board) {
            Name = "You inherit $100";
        }
        public override void Use(Player player, Player[] players) {
            player.money += 100;
        }
    }
}
