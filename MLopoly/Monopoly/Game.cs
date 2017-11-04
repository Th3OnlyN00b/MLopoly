using System;

namespace Monopoly {

    public class Game {

        public bool Running { get; set; }
        public Player[] players;
        public Board board = new Board();
        Random rand = new Random();

        public Game() {
            Running = true;
            players = new Player[] { new Player(0), new Player(1), new Player(2), new Player(3) };
            Run();
        }

        public void Run() {
            while(Running) {
                foreach(Player curPlayer in players) {
                    int dieResult = RollDice();
                    Space curSpace = board.MovePlayer(curPlayer, dieResult);
                    if(curSpace is PropertySpace) {

                    }
                    
                }
            }
        }

        public int RollDice() {
            int d1 = rand.Next(1, 6);
            int d2 = rand.Next(1, 6);
            // TODO Doubles = get second turn
            return d1+d2;
        }
    }

}
