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

    public partial class Reportes : Form
    {
        
        public Reportes()
        {
            InitializeComponent();
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            actualizar();
            
        }
        private void actualizar()
        {
            List<VEHICULOS> Vehiculos = new List<VEHICULOS>();
            List<CLIENTES> Clientes = new List<CLIENTES>();
            List<ALQUILER> Alquileres = new List<ALQUILER>();
            // Leemos -.-----------------------------
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
            
            //Leemos-----------------------------------
            FileStream stream1 = new FileStream("Personas.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader1 = new StreamReader(stream1);

            //Un ciclo para leer el archivo hasta el final del archivo
            //Lo leído se va guardando en un control richTextBox
            while (reader1.Peek() > -1)
            //Esta linea envía el texto leído a un control richTextBox, se puede cambiar para que
            //lo muestre en otro control por ejemplo un combobox
            {
                CLIENTES clit = new CLIENTES();
                clit.Nit = reader1.ReadLine();
                clit.Nombrecliente = reader1.ReadLine();
                clit.Direccion = reader1.ReadLine();
                Clientes.Add(clit);
            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader1.Close();
           
            //Leemos---------------------------------------
            FileStream stream2 = new FileStream("Alquileres.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader2 = new StreamReader(stream2);

            //Un ciclo para leer el archivo hasta el final del archivo
            //Lo leído se va guardando en un control richTextBox
            while (reader2.Peek() > -1)
            //Esta linea envía el texto leído a un control richTextBox, se puede cambiar para que
            //lo muestre en otro control por ejemplo un combobox
            {
                ALQUILER alqtemp = new ALQUILER();
                alqtemp.Nit = reader2.ReadLine();
                alqtemp.Nombrecliente = reader2.ReadLine();
                alqtemp.Direccion = reader2.ReadLine();
                alqtemp.Placa = reader2.ReadLine();
                alqtemp.Marca = reader2.ReadLine();
                alqtemp.Modelo = reader2.ReadLine();
                alqtemp.Color = reader2.ReadLine();
                alqtemp.PrecioxKilometro = Convert.ToInt32(reader2.ReadLine());
                alqtemp.FechaAlquilr = Convert.ToDateTime(reader2.ReadLine());
                alqtemp.FechaDevolucion = Convert.ToDateTime(reader2.ReadLine());
                alqtemp.KilometrosRecorridos = Convert.ToInt32(reader2.ReadLine());
                alqtemp.TotalPago = Convert.ToInt32(reader2.ReadLine());
                Alquileres.Add(alqtemp);
            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader2.Close();
            ;
            // Escribimos
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = Alquileres;
            dataGridView3.Refresh();
            //Escribimos------------------------------------
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Clientes;
            dataGridView1.Refresh();
            // Escribimos-------------------------------
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = Vehiculos;
            dataGridView2.Refresh();
            //buscamos el valor mas alto;
            //s0lo ordenamos la lista
            if (Alquileres.Count <= 0)
            {

            }
            else
            {
                List<ALQUILER> sorted = Alquileres.OrderByDescending(x => x.KilometrosRecorridos).ToList();
                label5.Text = sorted[0].KilometrosRecorridos.ToString();
            }
            

        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actualizar();
        
            MessageBox.Show("Datos actualizados");
        }
    }
    
}
