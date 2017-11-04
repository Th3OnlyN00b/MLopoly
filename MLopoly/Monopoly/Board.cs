using System;

namespace Monopoly {

    public class Board {

        public Space[] Spaces = new Space[40];

        public Board() {
            Reset();
        }

        public Space MovePlayer(Player player, int roll) {
            int pos = (player.position + roll);
            if(pos >= 40) {
                player.money = player.money + 200;
            }
            player.position = pos % 40;
            return Spaces[player.position];
        }

        public void Reset() {
            Spaces[0] = new GoSpace("Go", 0);
            Spaces[1] = new PropertySpace("Mediteranian Avenue", 1, 60, 50, 2, 10, 30, 90, 160, 250);
            Spaces[2] = new CommunityChestSpace("Community Chest", 2);
            Spaces[3] = new PropertySpace("Baltic Avenue", 3, 60, 50, 4, 20, 60, 180, 320, 450);
            Spaces[4] = new IncomeTaxSpace("Income Tax", 4);
            Spaces[5] = new RailroadSpace("Reading Railroad", 5);
            Spaces[6] = new PropertySpace("Oriental Avenue", 6, 100, 50, 6, 30, 90, 270, 400, 550);
            Spaces[7] = new ChanceSpace("Chance Space", 7);
            Spaces[8] = new PropertySpace("Vermont Avenue", 8, 100, 50, 6, 30, 90, 270, 400, 550);
            Spaces[9] = new PropertySpace("Connecicut Avenue", 9, 120, 50, 8, 40, 100, 300, 450, 600);
            Spaces[10] = new JailSpace("Jail", 10);
            Spaces[11] = new PropertySpace("St. Charles Place", 11, 140, 100, 10, 50, 150, 450, 625, 750);
            Spaces[12] = new ElectricCompanySpace("Electric Company", 12);
            Spaces[13] = new PropertySpace("States Avenue", 13, 140, 100, 10, 50, 150, 450, 625, 750);
            Spaces[14] = new PropertySpace("Virginia Avenue", 14, 160, 100, 12, 60, 180, 500, 700, 900);
            Spaces[15] = new RailroadSpace("Pennsylvania Railroad", 15);
            Spaces[16] = new PropertySpace("St. James Place", 16, 180, 100, 14, 70, 200, 550, 750, 950);
            Spaces[17] = new CommunityChestSpace("Community Chest Space", 17);
            Spaces[18] = new PropertySpace("Tennessee Avenue", 18, 180, 100, 14, 70, 200, 550, 750, 950);
            Spaces[19] = new PropertySpace("New York Avenue", 19, 200, 100, 16, 80, 220, 600, 800, 1000);
            Spaces[20] = new FreeParkingSpace("Free Parking", 20);
            Spaces[21] = new PropertySpace("Kentucky Avenue", 21, 220, 150, 18, 90, 250, 700, 875, 1050);
            Spaces[22] = new ChanceSpace("Chance Space", 22);
            Spaces[23] = new PropertySpace("Indiana Avenue", 23, 220, 150, 18, 90, 250, 700, 875, 1050);
            Spaces[24] = new PropertySpace("Illinois Avenue", 24, 240, 150, 20, 100, 300, 750, 925, 1100);
            Spaces[25] = new RailroadSpace("B&O Railroad", 25);
            Spaces[26] = new PropertySpace("Atlantic Avenue", 26, 260, 150, 22, 110, 330, 800, 975, 1150);
            Spaces[27] = new PropertySpace("Ventnor Avenue", 27, 260, 150, 22, 110, 330, 800, 975, 1150);
            Spaces[28] = new WaterworksSpace("Water Works", 28);
            Spaces[29] = new PropertySpace("Marvin Gardens", 29, 280, 150, 24, 120, 360, 850, 1025, 1200);
            Spaces[30] = new GoToJailSpace("Go to Jail", 30);
            Spaces[31] = new PropertySpace("Pacific Avenue", 31, 300, 200, 26, 130, 390, 900, 1100, 1275);
            Spaces[32] = new PropertySpace("North Carolina Avenue", 32, 300, 200, 26, 130, 390, 900, 1100, 1275);
            Spaces[33] = new CommunityChestSpace("Community Chest Space", 33);
            Spaces[34] = new PropertySpace("Pennsylvania", 34, 320, 200, 28, 150, 450, 1000, 1200, 1400);
            Spaces[35] = new RailroadSpace("Short Line", 35);
            Spaces[36] = new ChanceSpace("Chance Space", 36);
            Spaces[37] = new PropertySpace("Park Place", 37, 350, 200, 35, 175, 500, 1100, 1300, 1500);
            Spaces[38] = new LuxuryTaxSpace("Luxury Tax", 38);
            Spaces[39] = new PropertySpace("Boardwalk", 39, 400, 200, 50, 200, 600, 1400, 1700, 2000);
        }
    }
}

