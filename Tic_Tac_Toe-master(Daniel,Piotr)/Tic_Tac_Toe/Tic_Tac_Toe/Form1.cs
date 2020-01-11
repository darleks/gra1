using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
          GFX engine;
         Board theBoard;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics toPass = panel1.CreateGraphics();
            engine = new GFX(toPass);

            theBoard = new Board();
            theBoard.initBoard();

            refreshLabel();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Point mouse = Cursor.Position;
            mouse = panel1.PointToClient(mouse);
            theBoard.detectHit(mouse);

            refreshLabel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            theBoard.reset();
            GFX.setUpCanvas();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void wButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void oButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Projekt gry kółko i krzyżyk");
        }

        public void refreshLabel()
        {
            String newText = "Ruch wykonuje gracz:";
            if (theBoard.getPlayerForTurn() == Board.X)
            {
                newText += "X";
            }
            else
            {
                newText += "O";
            }
            newText += "\n";
            newText += "Gracz X wygrał grę:" + theBoard.getXwins() + " raz(y)\n";
            newText += "Gracz O wygrał grę:" + theBoard.getOwins() + " raz(y)";

            label1.Text = newText;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
