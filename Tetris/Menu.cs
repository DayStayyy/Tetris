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
    public partial class Menu : Form
    {
        String[] arrMusic = new String[] { "tetris", "tetrisFast", "tetrisMetal", "rock" };
        public Menu()
        {

            InitializeComponent();
            Random rnd = new Random();
            int number = rnd.Next(0, 4);
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer($@"..\..\src\{arrMusic[number]}.wav");
            sp.PlayLooping();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game obj1 = new Game();
            obj1.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Option obj2 = new Option();
            obj2.Show();
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
