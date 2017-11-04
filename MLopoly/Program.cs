using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monopoly;

namespace MLopoly {
    class Program {


        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Game game = new Game();
            BoardGUI b = new BoardGUI(game);
            Application.Run(b);
            game.Run();
        }
    }
}
