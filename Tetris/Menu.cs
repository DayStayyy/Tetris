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
        public Menu()
        {
            InitializeComponent();
            // System.Media.SoundPlayer sp = new System.Media.SoundPlayer(@"C:\Users\adrie\Cours\Tetris\Tetris\Tetris\src\rock.wav");
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(@"..\..\src\rock.wav");

            sp.PlayLooping();

            //sp.Play();
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
