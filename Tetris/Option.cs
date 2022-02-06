using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Option : Form
    {
        Menu Menu;
        public Option(Menu menu)
        {
            Menu = menu;
            InitializeComponent();
            // Create a TextBox control.
            this.Controls.Add(textBox1);
            this.Controls.Add(textBox2);
            this.Controls.Add(textBox3);
            this.Controls.Add(textBox4);
            this.Controls.Add(textBox5);
            assignChar(textBox3, Menu.keysArr[0]);
            assignChar(textBox2, Menu.keysArr[1]);
            assignChar(textBox4, Menu.keysArr[2]);
            assignChar(textBox1, Menu.keysArr[3]);
            assignChar(textBox5, Menu.keysArr[4]);
            textBox3.KeyPress += new KeyPressEventHandler(keypressedLeft);
            textBox2.KeyPress += new KeyPressEventHandler(keypressedRight);
            textBox1.KeyPress += new KeyPressEventHandler(keypressedSpace);
            textBox4.KeyPress += new KeyPressEventHandler(keypressedDown);
            textBox5.KeyPress += new KeyPressEventHandler(keypressedTurn);
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
            Menu.keysArr[0] = e.KeyChar;
            textBox3.Text = "";
        }
        private void keypressedRight(Object o, KeyPressEventArgs e)
        {
            Menu.keysArr[1] = e.KeyChar;
            textBox2.Text = "";
        }
        private void keypressedDown(Object o, KeyPressEventArgs e)
        {
            Menu.keysArr[2] = e.KeyChar;
            textBox4.Text = "";
        }
        private void keypressedSpace(Object o, KeyPressEventArgs e)
        {
            Menu.keysArr[3] = e.KeyChar;
            textBox1.Text = "";
        }
        private void keypressedTurn(Object o, KeyPressEventArgs e)
        {
            Menu.keysArr[4] = e.KeyChar;
            textBox5.Text = "";
        }

    }
}
