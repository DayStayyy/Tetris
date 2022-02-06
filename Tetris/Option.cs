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
        public Option()
        {
            InitializeComponent();
            // Create a TextBox control.
            TextBox tb = new TextBox();
            this.Controls.Add(tb);
            tb.KeyPress += new KeyPressEventHandler(keypressed);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void keypressed(Object o, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
            }
        }
    }
}
