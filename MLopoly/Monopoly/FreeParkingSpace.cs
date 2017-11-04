using System;

namespace Monopoly {
    public class FreeParkingSpace : Space {
        public FreeParkingSpace(string name, int ID) : base(name, ID) {
        }

        public override int Handle(Player curPlayer, int roll) {
            return 0;
        }
    }
}
