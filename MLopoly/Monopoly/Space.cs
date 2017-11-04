using System;

namespace Monopoly {
    public abstract class Space {

        public string name;
        public int ID;

        public Space(string name, int ID) {
            this.name = name;
            this.ID = ID;
        }
    }
}
