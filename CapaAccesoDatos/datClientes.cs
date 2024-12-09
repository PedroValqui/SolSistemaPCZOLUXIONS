using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoDatos
{
    public class datClientes
    {
        #region singelton
        private static readonly datClientes UnicaInstancia = new datClientes();

        public static datClientes Instancia
        {
            get
            {
                return datClientes.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos        
        public List<entClientes> ListarClientes()
        {
            SqlCommand cmd = null;
            List<entClientes> lista = new List<entClientes>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();  //Conexión a la base de datos
                cmd = new SqlCommand("spListarClientes", cn); //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entClientes c = new entClientes();
                    c.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                    c.Nombres = Convert.ToString(dr["Nombres"]);
                    c.Apellidos = Convert.ToString(dr["Apellidos"]);
                    c.TipoDocumentoIdentidad = Convert.ToString(dr["TipoDocumentoIdentidad"]);
                    c.DocumentoIdentidad = Convert.ToString(dr["DocumentoIdentidad"]);
                    c.Celular = Convert.ToString(dr["Celular"]);
                    c.Correo = Convert.ToString(dr["Correo"]);
                    lista.Add(c);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return lista;
        }

        public entClientes BuscarClientes(int idUsuario)
        {
            SqlCommand cmd = null;
            entClientes c = null;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();//Conexión a la base de datos
                cmd = new SqlCommand("spBuscarClientes", cn); //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdUsuario", idUsuario);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    c = new entClientes();
                    c.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                    c.Nombres = Convert.ToString(dr["Nombres"]);
                    c.Apellidos = Convert.ToString(dr["Apellidos"]);
                    c.TipoDocumentoIdentidad = Convert.ToString(dr["TipoDocumentoIdentidad"]);
                    c.DocumentoIdentidad = Convert.ToString(dr["DocumentoIdentidad"]);
                    c.Celular = Convert.ToString(dr["Celular"]);
                    c.Correo = Convert.ToString(dr["Correo"]);

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return c;
        }

        public Boolean InsertarClientes(entClientes c)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexión a la base de datos
                cmd = new SqlCommand("spInsertarClientes", cn); //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmNombres", c.Nombres);
                cmd.Parameters.AddWithValue("@prmApellidos", c.Apellidos);
                cmd.Parameters.AddWithValue("@prmTipoDocumento", c.TipoDocumentoIdentidad);
                cmd.Parameters.AddWithValue("@prmDocumentoIdentidad", c.DocumentoIdentidad);
                cmd.Parameters.AddWithValue("@prmCelular", c.Celular);
                cmd.Parameters.AddWithValue("@prmCorreo", c.Correo);
                cn.Open();

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    inserta = true;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return inserta;
        }

        public Boolean EditarClientes(entClientes c)
        {
            SqlCommand cmd = null;
            Boolean editar = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexión a la base de datos
                cmd = new SqlCommand("spEditarClientes", cn); //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdCliente", c.IdCliente);
                cmd.Parameters.AddWithValue("@prmNombres", c.Nombres);
                cmd.Parameters.AddWithValue("@prmApellidos", c.Apellidos);
                cmd.Parameters.AddWithValue("@prmTipoDocumento", c.TipoDocumentoIdentidad);
                cmd.Parameters.AddWithValue("@prmDocumentoIdentidad", c.DocumentoIdentidad);
                cmd.Parameters.AddWithValue("@prmCelular", c.Celular);
                cmd.Parameters.AddWithValue("@prmCorreo", c.Correo);
                cn.Open();

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    editar = true;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return editar;
        }

        public Boolean EliminarClientes(int idCliente)
        {
            SqlCommand cmd = null;
            Boolean eliminar = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexión a la base de datos
                cmd = new SqlCommand("spEliminarClientes", cn); //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdClientes", idCliente);
                cn.Open();

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    eliminar = true;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return eliminar;
        }
        #endregion metodos
    }
}
