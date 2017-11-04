using System;

namespace Monopoly {

    public class Player {

        public int money;
        public int PlayerNumber;
        public int position;
        public int railroadsOwned;
        public int utilsOwned;
        public int getOutOfJailOwned = 0;
        public int jailTries = 0;
        public bool inJail = false;
        public bool inGame = true;
        public bool isAI;

        public Player(int ID, bool AI) {
            money = 1500;
            isAI = AI;
            position = 0;
            railroadsOwned = 0;
            utilsOwned = 0;
            this.PlayerNumber = ID;
        }

        public bool getBid(int pos, Board board, int lastBid, out int bid) {
            Buyable spot = (Buyable)(board.Spaces[pos]);
            //TODO get bid.
            bid = lastBid;
            return true;
        }
    }
}

