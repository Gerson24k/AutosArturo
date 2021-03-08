using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosArturo
{
    class VEHICULOS
    {
        string placa;
        string marca;
        string modelo;
        string color;
        int precioxkilometro;

        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Color { get => color; set => color = value; }
        public int PrecioxKilometro { get => precioxkilometro; set => precioxkilometro = value; }
    }
}
