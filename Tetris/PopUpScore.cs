using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace Tetris
{
    public partial class PopUpScore : Form
    {
        Game Game;
        public PopUpScore(Game game)
        {
            Game = game;
            InitializeComponent();
            this.Controls.Add(textBox1);
            textBox1.KeyPress += new KeyPressEventHandler(keypressed);
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void keypressed(Object o, KeyPressEventArgs e)
        {
            Debug.WriteLine("Send to debug output window");
            if (e.KeyChar == (char)Keys.Enter)
            {
                Debug.WriteLine("Send to debug output window2");

                try
                {
                    Debug.WriteLine("FREROT");

                    Game.score = Int32.Parse(textBox1.Text);
                    Game.updateScore();
                    Debug.WriteLine("FREROT2");

                }
                catch (FormatException)
                {}
            }
        }
    }

}
