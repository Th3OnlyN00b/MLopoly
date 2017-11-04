﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Monopoly;

namespace MLopoly {
    public partial class BoardGUI : Form {

        private Graphics formGraphics;
        private Game game;
        private Rectangle[] rectangles = new Rectangle[40];

        public BoardGUI(Game game) {
            InitializeComponent();
            this.game = game;
            formGraphics = CreateGraphics();
        }

        public void Tick() {
            BoardGUI_Paint(null, null);
        }

        private void BoardGUI_Load(object sender, EventArgs e) {
            int posIndex = 0;
            while (posIndex < 11) {
                int x = (Width / 13 * (11 - (posIndex % 11)));
                int y = (Height / 13 * 11);
                CreateRectangle(x, y, posIndex);
                formGraphics.FillRectangle(new SolidBrush(Color.BlueViolet), new Rectangle(x, y, 80, 80));
                formGraphics.DrawString(posIndex + "", new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold), new SolidBrush(Color.Yellow), x, y);
                posIndex++;
            }
            while (posIndex < 21) {
                int x = (Width / 13);
                int y = (Height / 13 * (10 - (posIndex % 11)));
                CreateRectangle(x, y, posIndex);
                formGraphics.FillRectangle(new SolidBrush(Color.BlueViolet), new Rectangle(x, y, 80, 80));
                formGraphics.DrawString(posIndex + "", new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold), new SolidBrush(Color.Yellow), x, y);
                posIndex++;
            }
            while (posIndex < 31) {
                int x = (Width / 13 * (posIndex - 19));
                int y = (Height / 13);
                CreateRectangle(x, y, posIndex);
                formGraphics.FillRectangle(new SolidBrush(Color.BlueViolet), new Rectangle(x, y, 80, 80));
                formGraphics.DrawString(posIndex + "", new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold), new SolidBrush(Color.Yellow), x, y);
                posIndex++;
            }
            while (posIndex < 40) {
                int x = (Width / 13 * 11);
                int y = (Height / 13 * (posIndex - 29));
                CreateRectangle(x, y, posIndex);
                formGraphics.FillRectangle(new SolidBrush(Color.BlueViolet), new Rectangle(x, y, 80, 80));
                formGraphics.DrawString(posIndex + "", new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold), new SolidBrush(Color.Yellow), x, y);
                posIndex++;
            }
        }

        private void BoardGUI_Paint(object sender, PaintEventArgs e) {

            for (int i = 0; i < 40; i++) {
                formGraphics.FillRectangle(new SolidBrush(Color.LightCoral), rectangles[i]);
                formGraphics.DrawRectangle(new Pen(Color.Gray, 3), rectangles[i]);
                formGraphics.DrawString(game.board.Spaces[i].name, new Font(FontFamily.GenericSansSerif, 7.0F, FontStyle.Bold), new SolidBrush(Color.DarkSlateGray), rectangles[i].X, rectangles[i].Y);
            }
            for(int i = 0; i < 4; i++) {
                int pos = game.players[i].position;
                Rectangle r = rectangles[pos];
                Rectangle n = new Rectangle();
                switch (i) {
                    case 0: n.X = r.X + 20; n.Y = r.Y + 20; break;
                    case 1: n.X = r.Width - 20; n.Y = r.Y + 20; break;
                    case 2: n.X = r.X + 20; n.Y = r.Height - 20; break;
                    case 3: n.X = r.X + r.Width - 20; n.Y = r.Y + r.Height - 20; break;
                }
                n.Width = 230 / 4;
                n.Height = 155 / 4;
                formGraphics.FillEllipse(new SolidBrush(Color.Cyan), n);
            }
        }

        private void CreateRectangle(int x, int y, int index) {
            rectangles[index] = new Rectangle(x, y, 230, 155);
        }
    }
}
