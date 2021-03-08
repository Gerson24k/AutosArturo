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
    public partial class Form3 : Form
    {
        List<VEHICULOS> Vehiculos = new List<VEHICULOS>();
        List<CLIENTES> Clientes = new List<CLIENTES>();
        List<ALQUILER> Alquileres = new List<ALQUILER>();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
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
                comboBox1.Items.Add(vehtemp.Placa);
                Vehiculos.Add(vehtemp);
            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
            abrir();
            abriralquiler();


        }
        private void abrir()
        {
            FileStream stream = new FileStream("Personas.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            //Un ciclo para leer el archivo hasta el final del archivo
            //Lo leído se va guardando en un control richTextBox
            while (reader.Peek() > -1)
            //Esta linea envía el texto leído a un control richTextBox, se puede cambiar para que
            //lo muestre en otro control por ejemplo un combobox
            {
                CLIENTES clit = new CLIENTES();
                clit.Nit = reader.ReadLine();
                clit.Nombrecliente = reader.ReadLine();
                clit.Direccion = reader.ReadLine();
                Clientes.Add(clit);
            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
        }
        private void abriralquiler()
        {
            FileStream stream = new FileStream("Alquileres.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            //Un ciclo para leer el archivo hasta el final del archivo
            //Lo leído se va guardando en un control richTextBox
            while (reader.Peek() > -1)
            //Esta linea envía el texto leído a un control richTextBox, se puede cambiar para que
            //lo muestre en otro control por ejemplo un combobox
            {
                ALQUILER alqtemp = new ALQUILER();
                alqtemp.Nit = reader.ReadLine();
                alqtemp.Nombrecliente = reader.ReadLine();
                alqtemp.Direccion = reader.ReadLine();
                alqtemp.Placa = reader.ReadLine();
                alqtemp.Marca = reader.ReadLine();
                alqtemp.Modelo = reader.ReadLine();
                alqtemp.Color = reader.ReadLine();
                alqtemp.PrecioxKilometro = Convert.ToInt32(reader.ReadLine());
                alqtemp.FechaAlquilr = Convert.ToDateTime(reader.ReadLine());
                alqtemp.FechaDevolucion = Convert.ToDateTime(reader.ReadLine());
                alqtemp.KilometrosRecorridos = Convert.ToInt32(reader.ReadLine());
                alqtemp.TotalPago = Convert.ToInt32(reader.ReadLine());
                Alquileres.Add(alqtemp);
            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
        }
        private void guardarcliente()
        {
            FileStream stream = new FileStream("Personas.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            //El ciclo foreach, va recorriendo automáticamente cada elemento de la lista
            //y lo va copiando a la variable p, luego esa variable ya la podemos
            //guardar al archivo de texto, como la variable p representa cada persona
            //de la lista, es necesario indicar cada propiedad de la persona que vamos
            //a guardar en el archivo
            foreach (var p in Clientes)
            {
                writer.WriteLine(p.Nit);
                writer.WriteLine(p.Nombrecliente);
                writer.WriteLine(p.Direccion);
            }

            //Cerrar el archivo
            writer.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int siono = buscar(textBox1.Text);
                if (siono == -1)
                {
                    CLIENTES clit = new CLIENTES();
                    clit.Nit = textBox1.Text;
                    clit.Nombrecliente = textBox2.Text;
                    clit.Direccion = textBox3.Text;
                    Clientes.Add(clit);
                    guardarcliente();
                }
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un carro primero");

            }
            else
            {
                string placa = comboBox1.SelectedItem.ToString();
                //busca y muestra los datos, se guarda en una lista temporal
                VEHICULOS cocos = Vehiculos.Find(carmelo => carmelo.Placa == placa);
                ALQUILER alqtemp = new ALQUILER();
                alqtemp.Nit = textBox1.Text;
                alqtemp.Nombrecliente = textBox2.Text;
                alqtemp.Direccion = textBox3.Text;
                alqtemp.Placa = cocos.Placa;
                alqtemp.Marca = cocos.Marca;
                alqtemp.Modelo = cocos.Modelo;
                alqtemp.Color = cocos.Color;
                alqtemp.PrecioxKilometro = (cocos.PrecioxKilometro);
                alqtemp.FechaAlquilr = monthCalendar1.SelectionStart;
                alqtemp.FechaDevolucion = monthCalendar2.SelectionStart;
                alqtemp.KilometrosRecorridos = Convert.ToInt32(textBox4.Text);
                alqtemp.TotalPago = Convert.ToInt32(textBox4.Text) * cocos.PrecioxKilometro;
                Alquileres.Add(alqtemp);
                FileStream stream = new FileStream("Alquileres.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);
                //El ciclo foreach, va recorriendo automáticamente cada elemento de la lista
                //y lo va copiando a la variable p, luego esa variable ya la podemos
                //guardar al archivo de texto, como la variable p representa cada persona
                //de la lista, es necesario indicar cada propiedad de la persona que vamos
                //a guardar en el archivo
                foreach (var p in Alquileres)
                {
                    writer.WriteLine(p.Nit);
                    writer.WriteLine(p.Nombrecliente);
                    writer.WriteLine(p.Direccion);
                    writer.WriteLine(p.Placa);
                    writer.WriteLine(p.Marca);
                    writer.WriteLine(p.Modelo);
                    writer.WriteLine(p.Color);
                    writer.WriteLine(p.PrecioxKilometro);
                    writer.WriteLine(p.FechaAlquilr);
                    writer.WriteLine(p.FechaDevolucion);
                    writer.WriteLine(p.KilometrosRecorridos);
                    writer.WriteLine(p.TotalPago);
                }

                //Cerrar el archivo
                writer.Close();
                textBox1.Clear();
                textBox1.Focus();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                MessageBox.Show("Exito");
            }
            }
        private int buscar(string nombre)
        {

            for (int x = 0; x < Clientes.Count; x++)
            {
                if (Clientes[x].Nombrecliente.Contains(nombre))
                {
                    return 1;
                }
            }
            return -1;
        }
    }
}
