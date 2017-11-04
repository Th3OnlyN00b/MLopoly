namespace Monopoly {
    public class Deck {
        public Board board;
        public ChanceCard[] ChanceCards;
        public CommunityChestCard[] CommunityChestCards;
        private int ChanceCardIndex;
        private int CommunityChestCardIndex;


        public Deck(Board board) {
            this.board = board;
            ChanceCards = new ChanceCard[] { new CH1(board), new CH2(board), new CH3(board), new CH4(board),
                                        new CH5(board), new CH6(board), new CH7(board), new CH8(board),
                                        new CH9(board), new CH10(board), new CH11(board), new CH12(board),
                                        new CH13(board), new CH14(board), new CH15(board), new CH16(board) };
            CommunityChestCards = new CommunityChestCard[] { new CC1(board), new CC2(board), new CC3(board), new CC4(board),
                                        new CC5(board), new CC6(board), new CC7(board), new CC8(board),
                                        new CC9(board), new CC10(board), new CC11(board), new CC12(board),
                                        new CC13(board), new CC14(board), new CC15(board), new CC16(board), new CC17(board) };

            ShuffleChanceCards();
            ShuffleCommunityChestCards();
            ChanceCardIndex = 0;
            CommunityChestCardIndex = 0;
        }

        public void ShuffleChanceCards() {
            ChanceCards = ChanceCards;
            // TODO Add a shuffle function
        }

        public void ShuffleCommunityChestCards() {
            CommunityChestCards = CommunityChestCards;
            // TODO Add a shuffle function
        }

        public ChanceCard DrawChanceCard(Player player, Player[] curPlayers) {
            ChanceCard cardDrawn = ChanceCards[ChanceCardIndex++];
            cardDrawn.Use(player, curPlayers);
            if (ChanceCardIndex == 16){
                ChanceCardIndex = 0;
                ShuffleChanceCards();
            }
            return cardDrawn;
        }

        public CommunityChestCard DrawCommunityChestCard(Player player, Player[] curPlayers) {
            CommunityChestCard cardDrawn = CommunityChestCards[ChanceCardIndex++];
            cardDrawn.Use(player, curPlayers);
            if (CommunityChestCardIndex == 17) {
                CommunityChestCardIndex = 0;
                ShuffleCommunityChestCards();
            }
            return cardDrawn;
        }
    }
}