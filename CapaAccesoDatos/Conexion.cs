using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;

namespace CapaAccesoDatos
{
    public class Conexion
    {
        #region singleton
        private static readonly Conexion UnicaInstancia = new Conexion();

        public static Conexion Instancia
        {
            get
            {
                return Conexion.UnicaInstancia;
            }
        }

        #endregion singleton

        #region metodos
        public SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=DESKTOP-GI6E9GB\\SQLEXPRESS; initial catalog=DBPCZOLUXIONS; Integrated Security=true ";

            return cn;
        }
        #endregion metodos
    }
}

