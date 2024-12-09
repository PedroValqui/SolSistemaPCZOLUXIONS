using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class entOrdenServicio
    {
        public int IdOrden { get; set; }
        public int IdCliente { get; set; }
        public int IdEquipo { get; set; }
        public int IdServicio { get; set; }
        public DateTime FechaOrden { get; set; }
        public string Estado { get; set; }
    }
}

