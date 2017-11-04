namespace Monopoly {
    public class Deck {
        private Board board;

        public Deck(Board board) {
            this.board = board;
        }

        public void Use(Player player) {
            ChanceCard CH1 = new CH1(board);
            CH1.Use(player);
        }
    }
}