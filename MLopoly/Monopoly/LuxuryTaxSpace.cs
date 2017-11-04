using System;

namespace Monopoly {
    public class LuxuryTaxSpace : Space{
        public LuxuryTaxSpace(string name, int ID) : base(name, ID){
        }

        public override int Handle(Player curPlayer, int roll) {
            curPlayer.money = curPlayer.money - 100;
            return 0;
        }
    }
}
