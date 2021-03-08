using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosArturo
{
    class ALQUILER
    {
        string nit;
        string nombrecliente;
        string direccion;

        string placa;
        string marca;
        string modelo;
        string color;
        int precioxkilometro;
        DateTime fechaalquiler;
        DateTime fechadevolucion;
        int kilometrosrecorridos;
        int totalpago;
        public string Nit { get => nit; set => nit = value; }
        public string Nombrecliente { get => nombrecliente; set => nombrecliente = value; }
        public string Direccion { get => direccion; set => direccion = value; }

      

        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Color { get => color; set => color = value; }
        public int PrecioxKilometro { get => precioxkilometro; set => precioxkilometro = value; }
        public DateTime FechaAlquilr { get => fechaalquiler; set => fechaalquiler = value; }

        public DateTime FechaDevolucion { get => fechadevolucion; set => fechadevolucion = value; }
        public int KilometrosRecorridos { get => kilometrosrecorridos; set => kilometrosrecorridos = value; }
        public int TotalPago { get => totalpago; set => totalpago = value; }



    }
}
