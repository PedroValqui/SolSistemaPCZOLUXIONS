using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class entClientes
    {
        public int IdCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string TipoDocumentoIdentidad { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
    }
}
