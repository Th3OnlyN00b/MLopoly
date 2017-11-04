using System;

namespace Monopoly {
    public class GoSpace : Space {
        public GoSpace(string name, int ID) : base(name, ID) {
        }

        public override int Handle(Player curPlayer, int roll) {
            return 0;
        }
    }
}
