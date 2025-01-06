using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class datServicios
    {
        #region singelton
        private static readonly datServicios UnicaInstancia = new datServicios();

        public static datServicios Instancia
        {
            get
            {
                return datServicios.UnicaInstancia;
            }
        }
        #endregion singelton

        #region metodos
        public List<entServicios> ListarServicios()
        {
            SqlCommand cmd = null;
            List<entServicios> lista = new List<entServicios>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();  // Conexión a la base de datos
                cmd = new SqlCommand("spListarServicios", cn); // Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entServicios s = new entServicios();
                    s.IdServicio = Convert.ToInt32(dr["IdServicio"]);
                    s.NombreServicio = Convert.ToString(dr["NombreServicio"]);
                    s.Costo = Convert.ToDecimal(dr["Costo"]);
                    lista.Add(s);
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

        public entServicios BuscarServicios(int idServicio)
        {
            SqlCommand cmd = null;
            entServicios s = null;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); // Conexión a la base de datos
                cmd = new SqlCommand("spBuscarServicio", cn); // Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdServicio", idServicio);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    s = new entServicios();
                    s.IdServicio = Convert.ToInt32(dr["IdServicio"]);
                    s.NombreServicio = Convert.ToString(dr["NombreServicio"]);
                    s.Costo = Convert.ToDecimal(dr["Costo"]);
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

            return s;
        }

        public Boolean InsertarServicios(entServicios s)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); // Conexión a la base de datos
                cmd = new SqlCommand("spInsertarServicio", cn); // Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmNombreServicio", s.NombreServicio);
                cmd.Parameters.AddWithValue("@prmCosto", s.Costo);
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

        public Boolean EditarServicios(entServicios s)
        {
            SqlCommand cmd = null;
            Boolean editar = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); // Conexión a la base de datos
                cmd = new SqlCommand("spEditarServicio", cn); // Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdServicio", s.IdServicio);
                cmd.Parameters.AddWithValue("@prmNombreServicio", s.NombreServicio);
                cmd.Parameters.AddWithValue("@prmCosto", s.Costo);
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

        public Boolean EliminarServicios(int idServicio)
        {
            SqlCommand cmd = null;
            Boolean eliminar = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); // Conexión a la base de datos
                cmd = new SqlCommand("spEliminarServicio", cn); // Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdServicio", idServicio);
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