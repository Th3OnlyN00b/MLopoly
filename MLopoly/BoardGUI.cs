using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monopoly;

namespace MLopoly {
    public partial class BoardGUI : Form {

        private Graphics formGraphics;
        private Game game;

        public BoardGUI(Game game) {
            InitializeComponent();
            this.game = game;
            formGraphics = CreateGraphics();
        }

        private void BoardGUI_Load(object sender, EventArgs e) {

        }

        private void BoardGUI_Paint(object sender, PaintEventArgs e) {
            foreach (Player p in game.players) {
                Console.WriteLine(p.position);
                formGraphics.FillEllipse(new SolidBrush(Color.Red), new Rectangle((Width/(p.position+1)-50), Height - (Height / (10)), 10, 10));
                //formGraphics.FillRectangle(new SolidBrush(Color.Red), new Rectangle(0, 0, 200, 300));
            }
        }
    }
}
