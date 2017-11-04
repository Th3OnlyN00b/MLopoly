using System;

namespace Monopoly {

    public class Game {

        public bool Running { get; set; }
        public Player[] players;
        public Board board = new Board();
        private static Random rand = new Random();
        public int againCount = 0;
        public int jailCount = 0;
        public bool again = false;
        public Deck chanceDeck;

        public Game() {
            Running = true;
            players = new Player[] { new Player(0, true), new Player(1,true), new Player(2,true), new Player(3,true) };
            chanceDeck = new Deck(board);
            Run();
        }

        public void Run() {
            while (!gameOver()) {
                Player curPlayer;
                for(int j = 0; playInGame() > 1; j = (j%4) + 1) {
                    curPlayer = players[j];
                    //Check if player has lost yet
                    if(!curPlayer.inGame){
                        continue;
                    }
                    while (again) {
                        //Roll Dice
                        int die1 = RollDice();
                        int die2 = RollDice();

                        //Check if Jail and handle accordingly
                        if (curPlayer.inJail) {
                            handleJail(curPlayer, die1, die2);
                        }
                        //If still in jail end turn
                        if (curPlayer.inJail) {
                            break;
                        }
                        //check to see if roll gives second turn
                        checkAgain(curPlayer, die1, die2);
                        //Move Player
                        board.MovePlayer(curPlayer, (die1 + die2));
                        //handle movement based on space
                        int action = board.Spaces[curPlayer.position].Handle(curPlayer, (die1 + die2));
                        if(action == 1) {
                            //bidding system:
                            int lastBid = 0;
                            Buyable temp = (Buyable)(board.Spaces[curPlayer.position]);
                            int curBid = temp.GetPrice();
                            for (int i = 0; lastBid < curBid; i = ((i % 4) + 1)) {
                                lastBid = curBid;
                                //TODO: get a bid from each player
                                if(players[i].isAI){
                                    if(players[i].getBid(curPlayer.position, board, lastBid, out int bid)) {

                                    }
                                }
                                else{
                                    Console.WriteLine("Enter your bid for " + board.Spaces[curPlayer.position].name);
                                    curBid = int.Parse(Console.ReadLine());
                                }
                            }
                        }
                        if(action == 2) {
                          //  chanceDeck.Use(curPlayer, players);
                        }
                        //if(action == 3) {
                        //   CommunityChest(curPlayer, board);
                        //}
                    }
                    again = false;
                    againCount = 0;
                }
            }
        }

        public int playInGame(){
            int playCount = 0;
            for(int i = 0; i < 4; i++){
                if(players[i].money < 0){
                    players[i].inGame = false;
                }
                else{
                    playCount++;
                }
            }
            return playCount;
        }

        public void checkAgain(Player curPlayer, int die1, int die2) {
            if (die1 == die2) {
                again = true;
                againCount++;
                //if they roll double 3 times they go to jail.
                if (againCount == 3) {
                    curPlayer.position = 10;
                    curPlayer.inJail = true;
                }
            }
            else {
                again = false;
                againCount = 0;
            }
        }

        public void handleJail(Player curPlayer, int die1, int die2) {
            //TODO Offer Payout and get out of jail card (if possible)
            bool payOut = false;
            bool jailCard = false;
            //if player uses jail card
            if (jailCard) {
                curPlayer.inJail = false;
                board.MovePlayer(curPlayer, (die1 + die2)); ;
                //handle doubles normally
                checkAgain(curPlayer, die1, die2);
            }
            else {
                //if player pays
                if (payOut) {
                    curPlayer.money = curPlayer.money - 500;
                    curPlayer.inJail = false;
                    board.MovePlayer(curPlayer, (die1 + die2)); ;
                }
                else {
                    //if they succed in rolling out.
                    if (die1 == die2) {
                        curPlayer.inJail = false;
                        board.MovePlayer(curPlayer, (die1 + die2)); ;
                    }
                    //if they fail their turn is over.
                    else {
                        if (jailCount == 3) {
                            curPlayer.money = curPlayer.money - 500;
                            curPlayer.inJail = false;
                            board.MovePlayer(curPlayer, (die1 + die2));
                        }
                        else {
                            jailCount++;
                        }
                    }
                }
            }
        }

        public bool gameOver() {
            return false;
        }

        public static int RollDice() {
            int d1 = rand.Next(1, 6);
            return d1;
        }
    }

}
