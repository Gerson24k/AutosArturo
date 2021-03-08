using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutosArturo
{
    public partial class Form1 : Form
    {

    
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 formularioautos = new Form2();
            formularioautos.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 formularioclientes = new Form3();
            formularioclientes.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reportes formreportes = new Reportes();
            formreportes.Show();
        }
    }
}
