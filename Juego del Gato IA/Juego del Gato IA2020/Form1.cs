using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Juego_del_Gato_IA2020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(rbIA.Checked == true)
            {
                Form2 fd = new Form2();
                this.Hide();
                fd.ShowDialog();
                this.Close();
            }
            if(rbVersus.Checked == true)
            {
                Form3 fs = new Form3();
                this.Hide();
                fs.ShowDialog();
                this.Close();
            }
        }
    }
}
