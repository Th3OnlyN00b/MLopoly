using System;

namespace Monopoly {

    public class Board {

        public Space[] Spaces = new Space[40];

        public Board() {
            Reset();
        }

        public Space MovePlayer(Player player, int roll) {
            player.position = (player.position + roll) % 40;
            return Spaces[player.position];
        }

        public void Reset() {
            name, id, price, houseprice, rent, house1, house2, house3, house4, house5,
            Spaces[0] = new GoSpace("go", 0);
            Spaces[1] = new PropertySpace("Mediteranian Avenue", 1, 60, 50, 2, 10, 30, 90, 160, 250);
            Spaces[2] = new CommunityChestSpace("Community Chest", 2);
            Spaces[3] = new PropertySpace("Baltic Avenue", 3, 60, 50, 4, 20, 60, 180, 320, 450);
            Spaces[4] = new IncomeTaxSpace();
            Spaces[5] = new RailroadSpace();
            Spaces[6] = new PropertySpace("Oriental Avenue", 6, 100, 50, 6, 30, 90, 270, 400, 550);
            Spaces[7] = new ChanceSpace();
            Spaces[8] = new PropertySpace("Vermont Avenue", 8, 100, 50, 6, 30, 90, 270, 400, 550);
            Spaces[9] = new PropertySpace("Connecicut Avenue", 9, 120, 50, 8, 40, 100, 300, 450, 600);
            Spaces[10] = new JailSpace();
            Spaces[11] = new PropertySpace("St. Charles Place", 11, 140, 100, 10, 50, 150, 450, 625, 750);
            Spaces[12] = new ElectricCompanySpace();
            Spaces[13] = new PropertySpace("States Avenue", 13, 140, 100, 10, 50, 150, 450, 625, 750);
            Spaces[14] = new PropertySpace("Virginia Avenue", 14, 160, 100, 12, 60, 180, 500, 700, 900);
            Spaces[15] = new RailroadSpace();
            Spaces[16] = new PropertySpace("St. James Place", 16, 180, 100, 14, 70, 200, 550, 750, 950);
            Spaces[17] = new CommunityChestSpace();
            Spaces[18] = new PropertySpace("Tennessee Avenue", 18, );
            Spaces[19] = new PropertySpace();
            Spaces[20] = new FreeParkingSpace();
            Spaces[21] = new PropertySpace();
            Spaces[22] = new ChanceSpace();
            Spaces[23] = new PropertySpace();
            Spaces[24] = new PropertySpace();
            Spaces[25] = new RailroadSpace();
            Spaces[26] = new PropertySpace();
            Spaces[27] = new PropertySpace();
            Spaces[28] = new WaterworksSpace();
            Spaces[29] = new PropertySpace();
            Spaces[30] = new GoToJailSpace();
            Spaces[31] = new PropertySpace();
            Spaces[32] = new PropertySpace();
            Spaces[33] = new CommunityChestSpace();
            Spaces[34] = new PropertySpace();
            Spaces[35] = new RailroadSpace();
            Spaces[36] = new ChanceSpace();
            Spaces[37] = new PropertySpace();
            Spaces[38] = new LuxuryTaxSpace();
            Spaces[39] = new PropertySpace();


        }
    }
}

