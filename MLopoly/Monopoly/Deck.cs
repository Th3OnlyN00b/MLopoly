namespace Monopoly {
    public class Deck {
        public Board board;

        public Deck(Board board) {
            this.board = board;
        }

        public void Use(Player player, Player[] curPlayers) {
            ChanceCard CH1 = new CH1(board);
            CH1.Use(player, curPlayers);
        }
    }
}