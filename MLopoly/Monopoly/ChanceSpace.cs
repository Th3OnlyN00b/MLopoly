using System;

namespace Monopoly {
    public class ChanceSpace : Space{
        public ChanceSpace(string name, int ID) : base(name, ID) {
        }

        public override int Handle(Player curPlayer, int roll) {
            return 2;
        }
    }
}
