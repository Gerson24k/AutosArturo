using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AutosArturo
{
    public partial class Form2 : Form
    {
        List<VEHICULOS> Vehiculos = new List<VEHICULOS>();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            //Abrimos el archivo, en este caso lo abrimos para lectura
            FileStream stream = new FileStream("Vehiculos.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            //Un ciclo para leer el archivo hasta el final del archivo
            //Lo leído se va guardando en un control richTextBox
            while (reader.Peek() > -1)
            //Esta linea envía el texto leído a un control richTextBox, se puede cambiar para que
            //lo muestre en otro control por ejemplo un combobox
            {
                VEHICULOS vehtemp = new VEHICULOS();
                vehtemp.Placa = reader.ReadLine();
                vehtemp.Marca = reader.ReadLine();
                vehtemp.Modelo = reader.ReadLine();
                vehtemp.Color = reader.ReadLine();
                vehtemp.PrecioxKilometro = Convert.ToInt32(reader.ReadLine());
                Vehiculos.Add(vehtemp);
            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sioono = buscar(textBox1.Text);
            if (sioono == 1)
            {
                VEHICULOS vehtemp = new VEHICULOS();
                vehtemp.Placa = textBox1.Text;
                vehtemp.Marca = textBox2.Text;
                vehtemp.Modelo = textBox3.Text;
                vehtemp.Color = textBox4.Text;
                vehtemp.PrecioxKilometro = Convert.ToInt32(textBox5.Text);
                Vehiculos.Add(vehtemp);
                File.Delete("Vehiculos.txt");
                FileStream stream = new FileStream("Vehiculos.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);

                //El ciclo foreach, va recorriendo automáticamente cada elemento de la lista
                //y lo va copiando a la variable p, luego esa variable ya la podemos
                //guardar al archivo de texto, como la variable p representa cada persona
                //de la lista, es necesario indicar cada propiedad de la persona que vamos
                //a guardar en el archivo
                foreach (var p in Vehiculos)
                {
                    writer.WriteLine(p.Placa);
                    writer.WriteLine(p.Marca);
                    writer.WriteLine(p.Modelo);
                    writer.WriteLine(p.Color);
                    writer.WriteLine(p.PrecioxKilometro);
                }

                //Cerrar el archivo
                writer.Close();
                textBox1.Clear();
                textBox1.Focus();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                MessageBox.Show("Datos almacenados exitosamente");

            }
            else
            {
                MessageBox.Show("No es posible regigistrar este vehiculo pues la placa ya existe en la base de datos");
            }

        }

        private int buscar(string placa)
        {
            if (Vehiculos.Count == 0)
            {
                return 1;
            }

            for (int x = 0; x < Vehiculos.Count; x++)
            {
                if (Vehiculos[x].Placa.Contains(placa))
                {
                    return -1;
                }
            }
            return 1;
        }

           
       

    }
}
