using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly {
    public abstract class ChanceCard {
        public Board board;
        public ChanceCard(Board board) { this.board = board; }
        public abstract void Use(Player player);
    }

    public class CH1 : ChanceCard {
        public CH1(Board board) : base(board) { }
        public override void Use(Player player) {
            player.position = 0;
            //board.Spaces[0].Handle(player);
        }
    }

    public class CH6 : ChanceCard {
        public CH6(Board board) : base(board) { }
        public override void Use(Player player) {
            player.money += 50;
        }
    }

    public class CH7 : ChanceCard {
        public CH7(Board board) : base(board) { }
        public override void Use(Player player) {
            player.getOutOfJailOwned++;
        }
    }

    public class CH8 : ChanceCard {
        public CH8(Board board) : base(board) { }
        public override void Use(Player player) {
            player.position -= 3;
            //board.Spaces[player.position].Handle(player)
        }
    }

}
