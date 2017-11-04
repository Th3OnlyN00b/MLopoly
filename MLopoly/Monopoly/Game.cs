using MLopoly;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Monopoly {

    public class Game {

        public bool Running { get; set; }
        public Player[] players;
        public Board board = new Board();
        private static Random rand = new Random();
        public int againCount = 0;
        public bool again = true;
        public Deck deck;
        public bool beenDareDoneDat = false;

        public Game() {
            Running = true;
            players = new Player[] {new Player(0, false), new Player(1,true), new Player(2,true), new Player(3,true) };
            deck = new Deck(board);
            //Run();
        }

        public void Run(BoardGUI b) {
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
                        b.Tick();
                        Console.WriteLine("You landed on " + board.Spaces[curPlayer.position].name);
                        Console.WriteLine();
                        //handle movement based on space
                        int action = board.Spaces[curPlayer.position].Handle(curPlayer, (die1 + die2));
                        b.Tick();
                        if (action == 1) {
                            //bidding system:
                            int lastBid = 0;
                            Buyable temp = (Buyable)(board.Spaces[curPlayer.position]);
                            int curBid = temp.GetPrice();
                            int highestBid = curBid;
                            int highestPlayer = -1;
                            int attempt = playInGame();
                            for (int i = 0; (lastBid < curBid || i != highestPlayer) && attempt > 0; i = ((i + 1) % 4)) {
                                if(players[i].inGame == false){
                                    continue;
                                }
                                attempt--;
                                Console.WriteLine();
                                Console.WriteLine("Player " + i + " turn to bid");
                                lastBid = curBid;
                                Console.WriteLine("LastBid = " + lastBid);
                                //TODO: get a bid from each player
                                if(players[i].isAI){
                                    int ech = rand.Next(1, 6);
                                    int bech = ((Buyable)(board.Spaces[curPlayer.position])).GetPrice();
                                    int blech = bech + (int)((double)((double)bech * ((double)ech / (((double)ech * 2) + 1))));
                                    Console.WriteLine(bech);
                                    Console.WriteLine(blech);
                                    if (curBid < blech) {
                                        curBid = curBid + rand.Next(4, 10);
                                    }
                                }
                                else{
                                    Console.WriteLine("Enter your bid for " + board.Spaces[curPlayer.position].name);
                                    curBid = int.Parse(Console.ReadLine());
                                }
                                b.BoardGUI_Paint(null, null);
                                Console.WriteLine("curBid " + curBid);
                                if(curBid > highestBid){
                                    attempt = 4;
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

                    b.Tick();
                }
            }
            foreach(Player p in players) {
                if (p.inGame) {
                    Console.WriteLine("Player " + p.PlayerNumber + " wins!");
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
            beenDareDoneDat = false;
            while(true){
                Console.WriteLine("Player balence: $" + curPlayer.money);
                Console.WriteLine();
                Console.WriteLine("1: Buy houses for your properties");
                Console.WriteLine("2: Sell houses on your properties");
                Console.WriteLine("3: Mortgage your properties");
                Console.WriteLine("4: Buy back your properties");
                Console.WriteLine("5: Exit");
                if (!curPlayer.isAI) {
                    exit = int.Parse(Console.ReadLine());
                }
                else {
                    if (beenDareDoneDat) {
                        exit = 5;
                    }
                    else if(curPlayer.money > 400) {
                        exit = 1;
                    }
                    else if(curPlayer.money < 0) {
                        exit = 3;
                    }
                    else if(curPlayer.money > 200) {
                        exit = 4;
                    }
                    else {
                        exit = 5;
                    }
                }
                Console.WriteLine();
                if(exit == 5){break;}
                //BuyBack
                if (exit == 4) {
                    List<Buyable> spList = new List<Buyable>();
                    foreach (Space sp in board.Spaces) {
                        if ((sp is Buyable space) && space.IsMortgaged && space.Owner == curPlayer) {
                            spList.Add(space);
                        }
                    }
                    bool esc = false;
                    int escape = -1;
                    while (!esc) {
                        int k = 0;
                        foreach (Buyable sp in spList) {
                            Console.WriteLine(k + ": " + sp.name + " with a cost to buy back of " + (sp.GetPrice()/2)*1.1);
                            k++;
                        }
                        Console.WriteLine(k + ": Exit");
                        Console.WriteLine();
                        Console.WriteLine("Enter an int for your selection");
                        if (curPlayer.isAI) {
                            if (curPlayer.money > 200) {
                                escape = 0;
                            }
                            else {
                                escape = k;
                            }
                        }
                        else {
                            escape = int.Parse(Console.ReadLine());
                        }
                        if(escape == k) {
                            esc = true;
                        }
                        else {
                            Buyable a = spList[escape];
                            spList.RemoveAt(escape);
                            a.BuyBack();
                        }
                    }
                } //end buyback
                if(exit == 3) {
                    List<Buyable> spList = new List<Buyable>();
                    foreach (Space sp in board.Spaces) {
                        if ((sp is Buyable space) && !space.IsMortgaged && space.Owner == curPlayer) {
                            if(space is PropertySpace s && s.houseCount > 0) {
                                continue;
                            }
                            spList.Add(space);
                        }
                    }
                    bool esc = false;
                    int escape = -1;
                    while (!esc) {
                        int k = 0;
                        foreach (Buyable sp in spList) {
                            Console.WriteLine(k + ": " + sp.name + " with mortgage payment of " + (sp.GetPrice() / 2));
                            k++;
                        }
                        Console.WriteLine(k + ": Exit");
                        Console.WriteLine();
                        Console.WriteLine("Enter an int for your selection");
                        if (curPlayer.isAI) {
                            if (curPlayer.money < 0) {
                                escape = 0;
                            }
                            else {
                                escape = k;
                            }
                        }
                        else {
                            escape = int.Parse(Console.ReadLine());
                        }
                        if (escape == k) {
                            esc = true;
                        }
                        else {
                            Buyable a = spList[escape];
                            spList.RemoveAt(escape);
                            a.Mortgage();
                        }
                    }
                } //end mortgage
                if(exit == 2) { //sell houses
                    List<PropertySpace> spList = new List<PropertySpace>();
                    foreach (Space sp in board.Spaces) {
                        if ((sp is PropertySpace space) && space.houseCount > 0) {
                            spList.Add(space);
                        }
                    }
                    bool esc = false;
                    int escape = -1;
                    while (!esc) {
                        int k = 0;
                        foreach (PropertySpace sp in spList) {
                            if (sp.houseCount > 0) {
                                Console.WriteLine(k + ": " + sp.name + " with " + sp.houseCount + " houses for sale at $" + (sp.housePrice / 2));
                                k++;
                            }
                        }
                        Console.WriteLine(k + ": Exit");
                        Console.WriteLine();
                        Console.WriteLine("Enter an int for your selection");
                        escape = int.Parse(Console.ReadLine());
                        if (escape == k) {
                            esc = true;
                        }
                        else {
                            PropertySpace a = spList[escape];
                            if (a.houseCount == 1) {
                                spList.RemoveAt(escape);
                            }
                            a.SellHouse();
                        }
                    }
                } //end sell houses
                if(exit == 1) {
                    List<PropertySpace> spList = new List<PropertySpace>();
                    foreach (Space sp in board.Spaces) {
                        if ((sp is PropertySpace space) && space.houseCount < 5 && curPlayer == space.Owner && ownsMonopoly(curPlayer, space, board)) {
                            spList.Add(space);
                        }
                    }
                    bool esc = false;
                    int escape = -1;
                    while (!esc) {
                        int k = 0;
                        foreach (PropertySpace sp in spList) {
                            if (sp.houseCount < 5) {
                                Console.WriteLine(k + ": " + sp.name + " with " + sp.houseCount + " houses at a cost of $" + sp.housePrice);
                                k++;
                            }
                        }
                        Console.WriteLine(k + ": Exit");
                        Console.WriteLine();
                        Console.WriteLine("Enter an int for your selection");
                        if (curPlayer.isAI) {
                            if (curPlayer.money > 400) {
                                escape = 0;
                            }
                            else {
                                escape = k;
                            }
                        }
                        else {
                            escape = int.Parse(Console.ReadLine());
                        }
                        if (escape == k) {
                            esc = true;
                        }
                        else {
                            PropertySpace a = spList[escape];
                            if (a.houseCount == 4) {
                                spList.RemoveAt(escape);
                            }
                            a.AddHouse();
                        }
                    }
                }
                beenDareDoneDat = true;
            }
        }

        public bool ownsMonopoly(Player player, PropertySpace prop, Board bored) {
            if(prop.ID == 1 || prop.ID == 3) {
                if(((PropertySpace)(board.Spaces[1])).Owner == ((PropertySpace)(board.Spaces[3])).Owner) {
                    return true;
                }
                else {
                    return false;
                }
            }
            if (prop.ID == 6 || prop.ID == 8 || prop.ID == 9) {
                if (((PropertySpace)(board.Spaces[6])).Owner == ((PropertySpace)(board.Spaces[8])).Owner && ((PropertySpace)(board.Spaces[9])).Owner == ((PropertySpace)(board.Spaces[8])).Owner) {
                    return true;
                }
                else {
                    return false;
                }
            }
            if (prop.ID == 11 || prop.ID == 13 || prop.ID == 14) {
                if (((PropertySpace)(board.Spaces[11])).Owner == ((PropertySpace)(board.Spaces[13])).Owner && ((PropertySpace)(board.Spaces[13])).Owner == ((PropertySpace)(board.Spaces[14])).Owner) {
                    return true;
                }
                else {
                    return false;
                }
            }
            if (prop.ID == 16 || prop.ID == 18 || prop.ID == 19) {
                if (((PropertySpace)(board.Spaces[16])).Owner == ((PropertySpace)(board.Spaces[18])).Owner && ((PropertySpace)(board.Spaces[19])).Owner == ((PropertySpace)(board.Spaces[18])).Owner) {
                    return true;
                }
                else {
                    return false;
                }
            }
            if (prop.ID == 21 || prop.ID == 23 || prop.ID == 24) {
                if (((PropertySpace)(board.Spaces[21])).Owner == ((PropertySpace)(board.Spaces[23])).Owner && ((PropertySpace)(board.Spaces[23])).Owner == ((PropertySpace)(board.Spaces[24])).Owner) {
                    return true;
                }
                else {
                    return false;
                }
            }
            if (prop.ID == 26 || prop.ID == 27 || prop.ID == 29) {
                if (((PropertySpace)(board.Spaces[26])).Owner == ((PropertySpace)(board.Spaces[27])).Owner && ((PropertySpace)(board.Spaces[29])).Owner == ((PropertySpace)(board.Spaces[27])).Owner) {
                    return true;
                }
                else {
                    return false;
                }
            }
            if (prop.ID == 31 || prop.ID == 32 || prop.ID == 34) {
                if (((PropertySpace)(board.Spaces[31])).Owner == ((PropertySpace)(board.Spaces[32])).Owner && ((PropertySpace)(board.Spaces[32])).Owner == ((PropertySpace)(board.Spaces[34])).Owner) {
                    return true;
                }
                else {
                    return false;
                }
            }
            if (prop.ID == 37 || prop.ID == 39) {
                if (((PropertySpace)(board.Spaces[37])).Owner == ((PropertySpace)(board.Spaces[39])).Owner) {
                    return true;
                }
                else {
                    return false;
                }
            }
            return false;
        }

        public int playInGame(){
            int playCount = 0;
            for(int i = 0; i < 4; i++){
                if (players[i].inGame) {
                    if (players[i].money < 0) {
                        Console.WriteLine("Player " + i + " has lost with a balence of $" + players[i].money);
                        Console.ReadLine();
                        players[i].inGame = false;
                    }
                    else {
                        playCount++;
                    }
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
            bool jailCard = true;
            bool payOut = false;
            if (curPlayer.getOutOfJailOwned > 0) {
                jailCard = true;
            }
            else {
                jailCard = false;
            }
            //if player uses jail card
            if (jailCard) {
                curPlayer.inJail = false;
                curPlayer.getOutOfJailOwned--;
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
                        if (curPlayer.jailTries == 3) {
                            curPlayer.money = curPlayer.money - 500;
                            curPlayer.inJail = false;
                            board.MovePlayer(curPlayer, (die1 + die2));
                            curPlayer.jailTries = 0;
                        }
                        else {
                            curPlayer.jailTries++;
                        }
                    }
                }
            }
        }

        public bool gameOver() {
            if (playInGame() == 1) {
                return true;
            }
            else {
                return false;
            }
        }

        public static int RollDice() {
            int d1 = rand.Next(1, 7);
            return d1;
        }
    }

}
