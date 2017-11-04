using System;

namespace Monopoly {

    public class Game {

        public bool Running { get; set; }
        public Player[] players;
        public Board board = new Board();
        private static Random rand = new Random();
        public int againCount = 0;
        public int jailCount = 0;
        public bool again = true;
        public Deck deck;

        public Game() {
            Running = true;
            players = new Player[] { new Player(0, false), new Player(1,true), new Player(2,true), new Player(3,true) };
            deck = new Deck(board);
            Run();
        }

        public void Run() {
            while (!gameOver()) {
                Player curPlayer;
                for(int j = 0; playInGame() > 1; j = (j+1)%4) {
                    curPlayer = players[j];
                    //Check if player has lost yet
                    Console.WriteLine(curPlayer.inGame);
                    if(!curPlayer.inGame){
                        continue;
                    }
                    while (again) {
                        Console.WriteLine();
                        Console.WriteLine("----------------------------------------------------------------------");
                        Console.WriteLine("---------------------------Player " + j + "'s turn!---------------------------");
                        Console.WriteLine("----------------------------------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Player " + j + " wealth = " + players[j].money);
                        Console.WriteLine("Player " + j + " position = " + players[j].position);
                        Console.WriteLine();
                        again = false;
                        //Roll Dice
                        int die1 = RollDice();
                        int die2 = RollDice();
                        Console.WriteLine("Die 1 roll: " + die1);
                        Console.WriteLine("Die 2 roll: " + die2);
                        Console.WriteLine("Dice Roll for player " + j + ": " + (die1 + die2));
                        Console.WriteLine();
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
                        Console.WriteLine("You landed on " + board.Spaces[curPlayer.position].name);
                        Console.WriteLine();
                        //handle movement based on space
                        int action = board.Spaces[curPlayer.position].Handle(curPlayer, (die1 + die2));
                        if(action == 1) {
                            //bidding system:
                            int lastBid = 0;
                            Buyable temp = (Buyable)(board.Spaces[curPlayer.position]);
                            int curBid = temp.GetPrice();
                            int highestBid = curBid;
                            int highestPlayer = -1;
                            for (int i = 0; lastBid < curBid || i != highestPlayer; i = ((i + 1) % 4)) {
                                if(players[i].inGame == false){
                                    i++;
                                    continue;
                                }
                                Console.WriteLine();
                                Console.WriteLine("Player " + i + " turn to bid");
                                lastBid = curBid;
                                Console.WriteLine("LastBid = " + lastBid);
                                //TODO: get a bid from each player
                                if(players[i].isAI){
                                    if(players[i].getBid(curPlayer.position, board, lastBid, out int bid)) {

                                    }
                                }
                                else{
                                    Console.WriteLine("Enter your bid for " + board.Spaces[curPlayer.position].name);
                                    curBid = int.Parse(Console.ReadLine());
                                }
                                Console.WriteLine("curBid " + curBid);
                                if(curBid > highestBid){
                                    highestPlayer = i;
                                    highestBid = curBid;
                                }
                            }
                            if(highestPlayer != -1){
                                temp.Buy(players[highestPlayer]);
                                players[highestPlayer].money -= (highestBid-temp.GetPrice());
                            }
                        }
                        if(action == 2) {
                            ChanceCard card = deck.DrawChanceCard(curPlayer, players);
                            Console.WriteLine(card.Name);
                        }
                        if(action == 3) {
                            CommunityChestCard card = deck.DrawCommunityChestCard(curPlayer, players);
                            Console.WriteLine(card.Name);
                        }
                        handlePossible(curPlayer);
                    }
                    again = true;
                    againCount = 0;
                }
            }
        }

        public void handlePossible(Player curPlayer){
            Console.WriteLine("What would you like to do? Enter your choice as an integer.");
            Console.WriteLine();
            Console.WriteLine("Current wealth: " + curPlayer.money);
            Console.WriteLine();
            Console.Write("Current properties (5 houses means a hotel): ");
            //find properties
            int t = 0;
            foreach(Space sp in board.Spaces){
                if(sp is Buyable space){
                    if(space.Owner == curPlayer){
                        t++;
                        Console.Write(space.name);
                        if (space is PropertySpace s) {
                            Console.WriteLine(" which has " + s.houseCount + " houses");
                        }
                        if(space.IsMortgaged){
                            Console.Write(" and is mortgaged; ");
                        }
                        else{
                            Console.Write(" and is not mortgaged; ");
                        }
                    }
                }
            }
            if(t == 0){Console.WriteLine("None!");}
            else{Console.WriteLine();}
            int exit = -1;
            while(true){
                Console.WriteLine("1: Buy houses for your properties");
                Console.WriteLine("2: Sell houses on your properties");
                Console.WriteLine("3: Mortgage your properties");
                Console.WriteLine("4: Buy back your properties");
                Console.WriteLine("5: Exit");
                exit = int.Parse(Console.ReadLine());
                if(exit == 5){break;}
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
                Console.WriteLine("You got doubles!");
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
            int d1 = rand.Next(1, 7);
            return d1;
        }
    }

}
