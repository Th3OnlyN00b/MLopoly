using System;

namespace Monopoly {
    public class JailSpace : Space {
        public JailSpace(string name, int ID) : base(name, ID) {
        }

        public override int Handle(Player curPlayer, int roll) {
            return 0;
        }
    }
}
