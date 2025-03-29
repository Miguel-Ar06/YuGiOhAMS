using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yu_Gi_Oh_AMS
{
    public partial class Juego : Form
    {
        public Juego()
        {
            InitializeComponent();
        }

        private void Juego_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
