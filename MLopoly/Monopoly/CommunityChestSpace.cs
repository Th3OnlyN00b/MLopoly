using System;

namespace Monopoly {
    public class CommunityChestSpace : Space {
        public CommunityChestSpace(string name, int ID) : base(name, ID) {
        }

        public override int Handle(Player curPlayer, int roll) {
            return 3;
        }
    }
}
