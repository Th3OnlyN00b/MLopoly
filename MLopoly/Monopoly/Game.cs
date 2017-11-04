using System;

namespace Monopoly {

    public class Game {

        public bool Running { get; set; }
        public Player[] players;
        public Board board = new Board();
        Random rand = new Random();
        public int againCount = 0;
        public int jailCount = 0;
        public bool again = false;

        public Game() {
            Running = true;
            players = new Player[] { new Player(0), new Player(1), new Player(2), new Player(3) };
            Run();
        }

        public void Run() {
            while(Running) {
                foreach(Player curPlayer in players) {
                    while (again) {
                        //Roll Dice
                        int die1 = RollDice();
                        int die2 = RollDice();

                        //Check if Jail and handle accordingly
                        if (curPlayer.inJail) {
                            handleJail(curPlayer);
                        }
                        //check to see if roll gives second turn
                        else {
                            checkAgain(die1, die2);
                        }

                        curPlayer.position = curPlayer.position + (die1 + die2);


                        
                    }
                    again = false;
                }
            }
        }

        public bool checkAgain(int die1, int die2) {
            if (die1 == die2) {
                again = true;
                againCount++;
                //if they roll double 3 times they go to jail.
                if (againCount == 3) {
                    curPlayer.position = 10;
                    break;
                }
            }
            else {
                again = false;
                againCount = 0;
            }
        }

        public void handleJail(Player curPlayer) {
            //TODO Offer Payout and get out of jail card (if possible)
            bool payOut = false;
            bool jailCard = false;
            //if player uses jail card
            if (jailCard) {
                curPlayer.position = curPlayer.position + (die1 + die2);
                //handle doubles normally
                checkAgain();
            }
            else {
                //if player pays
                if (payOut) {
                    curPlayer.money = curPlayer.money - 500;
                    curPlayer.position = curPlayer.position + (die1 + die2);
                }
                else {
                    //if they succed in rolling out.
                    if (die1 == die2) {
                        curPlayer.position = curPlayer.position + (die1 + die2);
                    }
                    //if they fail their turn is over.
                    else {
                        if (jailCount == 3) {
                            curPlayer.money = curPlayer.money - 500;
                            curPlayer.position = curPlayer.postion + (die1 + die2);
                        }
                        else {
                            jailCount++;
                            break;
                        }
                    }
                }
            }
        }

        public int RollDice() {
            int d1 = rand.Next(1, 6);
            return d1;
        }
    }

}
