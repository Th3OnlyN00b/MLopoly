using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly {
    public abstract class Buyable : Space{

        public Player Owner { get; set; }

        public bool IsMortgaged { get; set; }

        public Buyable(string name, int ID) : base(name, ID) {
        }

        public abstract int Buy(Player player);

        public abstract int GetPrice();
        

        public abstract int Mortgage();

        public abstract int BuyBack();

        public abstract int ChargeRent(Player player, int roll);

        public abstract void Trade(Player player);
    }
}
