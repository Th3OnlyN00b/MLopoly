using System;

namespace Monopoly {
    public class IncomeTaxSpace : Space {
        public IncomeTaxSpace(string name, int ID) : base(name, ID) {
        }

        public override int Handle(Player curPlayer, int roll) {
            bool straightCash = false;
            //TODO: ask for 10% or 200$
            if (straightCash) {
                curPlayer.money = curPlayer.money - 200;
                return 0;
            }
            else {
                curPlayer.money = (int)(curPlayer.money * 0.9);
                return 0;
            }

        }
    }
}
