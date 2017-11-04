using System;

namespace Monopoly {

    public class Player {

        public int money;
        public int PlayerNumber;
        public int position;
        public int railroadsOwned;
        public int utilsOwned;

        public Player(int ID) {
            money = 1500;
            position = 0;
            railroadsOwned = 0;
            utilsOwned = 0;
            this.PlayerNumber = ID;
        }


    }
}

