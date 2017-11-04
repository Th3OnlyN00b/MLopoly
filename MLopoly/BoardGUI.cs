using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLopoly {
    public partial class BoardGUI : Form {
        public BoardGUI() {
            InitializeComponent();
            Draw();
        }

        private void Draw() {
            Console.Write("drew");
            SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            Graphics formGraphics;
            formGraphics = CreateGraphics();
            formGraphics.FillRectangle(myBrush, new Rectangle(0, 0, 200, 300));
        }
    }
}
