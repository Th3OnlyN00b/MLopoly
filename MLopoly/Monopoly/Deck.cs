using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly {
    class Deck {

        public Board board;
        public Deck(Board board) {
            this.board = board;
            ChanceCard c1 = new CH1(board);
        }
    }
}
