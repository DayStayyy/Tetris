using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Tetris
{
    public partial class OptionInGame : Form
    {
        Game Game;
        public OptionInGame(Game game)
        {
            Game = game;
            InitializeComponent();
            // Create a TextBox control.
            this.Controls.Add(textBox1);
            this.Controls.Add(textBox2);
            this.Controls.Add(textBox3);
            this.Controls.Add(textBox4);
            this.Controls.Add(textBox5);
            this.Controls.Add(textBox6);
            assignChar(textBox3, Game.keysArr[0]);
            assignChar(textBox2, Game.keysArr[1]);
            assignChar(textBox4, Game.keysArr[2]);
            assignChar(textBox1, Game.keysArr[3]);
            assignChar(textBox5, Game.keysArr[4]);
            textBox3.KeyPress += new KeyPressEventHandler(keypressedLeft);
            textBox2.KeyPress += new KeyPressEventHandler(keypressedRight);
            textBox1.KeyPress += new KeyPressEventHandler(keypressedSpace);
            textBox4.KeyPress += new KeyPressEventHandler(keypressedDown);
            textBox5.KeyPress += new KeyPressEventHandler(keypressedTurn);
            textBox6.KeyPress += new KeyPressEventHandler(keypressedCode);

        }

        private void assignChar(TextBox textBox,Char chars) {
            if(chars == (char)Keys.Space)
            {
                textBox.Text = "Space";
            }
            else if (chars == (char)Keys.Down)
            {
                textBox.Text = "↓";
            }
            else if (chars == (char)Keys.Up)
            {
                textBox.Text = "↑";
            }
            else if (chars == (char)Keys.Left)
            {
                textBox.Text = "←";
            }
            else if (chars == (char)Keys.Right)
            {
                textBox.Text = "→";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void keypressedLeft(Object o, KeyPressEventArgs e)
        {
            Game.keysArr[0] = e.KeyChar;
            textBox3.Text = "";
        }
        private void keypressedRight(Object o, KeyPressEventArgs e)
        {
            Game.keysArr[1] = e.KeyChar;
            textBox2.Text = "";
        }
        private void keypressedDown(Object o, KeyPressEventArgs e)
        {
            Game.keysArr[2] = e.KeyChar;
            textBox4.Text = "";
        }
        private void keypressedSpace(Object o, KeyPressEventArgs e)
        {
            Game.keysArr[3] = e.KeyChar;
            textBox1.Text = "";
        }
        private void keypressedTurn(Object o, KeyPressEventArgs e)
        {
            Game.keysArr[4] = e.KeyChar;
            textBox5.Text = "";
        }
        private void keypressedCode(Object o, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                if(textBox6.Text == "cheat")
                {
                    PopUpScore popUp = new PopUpScore(Game);
                    popUp.ShowDialog();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            Game.gameOver();
            this.Close();
        }
    }
}
