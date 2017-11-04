using System;

namespace Monopoly {
    public class GoToJailSpace : Space {
        public GoToJailSpace(string name, int ID) : base(name, ID){
        }

        public override int Handle(Player curPlayer, int roll) {
            curPlayer.inJail = true;
            curPlayer.position = 10;
            return 0;
        }
    }
}
