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
    public class datUsuarios
    {
        #region singelton
        private static readonly datUsuarios UnicaInstancia = new datUsuarios();

        public static datUsuarios Instancia
        {
            get
            {
                return datUsuarios.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos
        public entUsuarios VerificarUsuarios(String Usuario, String Contrasena)
        {
            entUsuarios u = null;
            SqlCommand cmd = null;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexión a la base de datos
                cmd = new SqlCommand("spVerificarUsuarios", cn); //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmUsuario", Usuario);
                cmd.Parameters.AddWithValue("@prmContrasena", Contrasena);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    u = new entUsuarios();
                    u.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    u.Nombres = Convert.ToString(dr["Nombres"]);
                    u.Apellidos = Convert.ToString(dr["Apellidos"]);
                    u.Correo = Convert.ToString(dr["Correo"]);
                    u.Cargo = Convert.ToString(dr["Cargo"]);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                cmd.Connection.Close();
            }

            return u;
        }



        public List<entUsuarios> ListarUsuarios()
        {
            SqlCommand cmd = null;
            List<entUsuarios> lista = new List<entUsuarios>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();  //Conexión a la base de datos
                cmd = new SqlCommand("spListarUsuarios", cn); //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entUsuarios u = new entUsuarios();
                    u.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    u.Nombres = Convert.ToString(dr["Nombres"]);
                    u.Apellidos = Convert.ToString(dr["Apellidos"]);
                    u.Correo = Convert.ToString(dr["Correo"]);
                    u.Cargo = Convert.ToString(dr["Cargo"]);
                    lista.Add(u);
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

        public entUsuarios BuscarUsuario(int idUsuario)
        {
            SqlCommand cmd = null;
            entUsuarios u = null;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();//Conexión a la base de datos
                cmd = new SqlCommand("spBuscarUsuario", cn); //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdUsuario", idUsuario);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    u = new entUsuarios();

                    u.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    u.Nombres = Convert.ToString(dr["Nombres"]);
                    u.Apellidos = Convert.ToString(dr["Apellidos"]);
                    u.Correo = Convert.ToString(dr["Correo"]);
                    u.Cargo = Convert.ToString(dr["Cargo"]);

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

            return u;
        }

        public Boolean InsertarUsuario(entUsuarios u)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexión a la base de datos
                cmd = new SqlCommand("spInsertarUsuario", cn); //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmNombres", u.Nombres);
                cmd.Parameters.AddWithValue("@prmApellidos", u.Apellidos);
                cmd.Parameters.AddWithValue("@prmCorreo", u.Correo);
                cmd.Parameters.AddWithValue("@prmCargo", u.Cargo);
                cmd.Parameters.AddWithValue("@prmUsuario", u.Usuario);
                cmd.Parameters.AddWithValue("@prmContrasena", u.Contrasena);
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

        public Boolean EditarUsuario(entUsuarios u)
        {
            SqlCommand cmd = null;
            Boolean editar = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexión a la base de datos
                cmd = new SqlCommand("spEditarUsuario", cn); //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdUsuario", u.IdUsuario);
                cmd.Parameters.AddWithValue("@prmNombres", u.Nombres);
                cmd.Parameters.AddWithValue("@prmApellidos", u.Apellidos);
                cmd.Parameters.AddWithValue("@prmCorreo", u.Correo);
                cmd.Parameters.AddWithValue("@prmCargo", u.Cargo);
                cmd.Parameters.AddWithValue("@prmUsuario", u.Usuario);
                cmd.Parameters.AddWithValue("@prmContrasena", u.Contrasena);
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

        public Boolean EliminarUsuario(int idUsuario)
        {
            SqlCommand cmd = null;
            Boolean eliminar = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexión a la base de datos
                cmd = new SqlCommand("spEliminarUsuario", cn); //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdUsuario", idUsuario);
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
