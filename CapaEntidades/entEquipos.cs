using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class entEquipos
    {
        public int IdEquipo { get; set; }
        public int IdCliente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string NumeroSerie { get; set; }
        public string DescripcionProblema { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
