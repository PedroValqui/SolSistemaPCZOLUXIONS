using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CapaAccesoDatos
{
    public class datEquipos
    {
        #region singelton
        private static readonly datEquipos UnicaInstancia = new datEquipos();

        public static datEquipos Instancia
        {
            get
            {
                return datEquipos.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos        
        public List<entEquipos> ListarEquipos()
        {
            SqlCommand cmd = null;
            List<entEquipos> lista = new List<entEquipos>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();  //Conexión a la base de datos
                cmd = new SqlCommand("spListarEquipos", cn); //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entEquipos e = new entEquipos();
                    e.IdEquipo = Convert.ToInt32(dr["IdEquipo"]);
                    e.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                    e.Marca = Convert.ToString(dr["Marca"]);
                    e.Modelo = Convert.ToString(dr["Modelo"]);
                    e.NumeroSerie = Convert.ToString(dr["NumeroSerie"]);
                    e.DescripcionProblema = Convert.ToString(dr["DescripcionProblema"]);
                    e.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]);
                    lista.Add(e);
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

        public entEquipos BuscarEquipos(int idEquipo)
        {
            SqlCommand cmd = null;
            entEquipos e = null;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();//Conexión a la base de datos
                cmd = new SqlCommand("spBuscarEquipos", cn); //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdEquipos", idEquipo);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    e = new entEquipos();
                    e.IdEquipo = Convert.ToInt32(dr["IdEquipo"]);
                    e.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                    e.Marca = Convert.ToString(dr["Marca"]);
                    e.Modelo = Convert.ToString(dr["Modelo"]);
                    e.NumeroSerie = Convert.ToString(dr["NumeroSerie"]);
                    e.DescripcionProblema = Convert.ToString(dr["DescripcionProblema"]);
                    e.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]);
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

            return e;
        }

        public Boolean InsertarEquipos(entEquipos e)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexión a la base de datos
                cmd = new SqlCommand("spInsertarEquipos", cn); //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdCliente", e.IdCliente);
                cmd.Parameters.AddWithValue("@prmMarca", e.Marca);
                cmd.Parameters.AddWithValue("@prmModelo", e.Modelo);
                cmd.Parameters.AddWithValue("@prmNumeroSerie", e.NumeroSerie);
                cmd.Parameters.AddWithValue("@prmDescripcionProblema", e.DescripcionProblema);
                cmd.Parameters.AddWithValue("@prmFechaIngreso", e.FechaIngreso);
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

        public Boolean EditarEquipos(entEquipos e)
        {
            SqlCommand cmd = null;
            Boolean editar = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexión a la base de datos
                cmd = new SqlCommand("spEditarEquipos", cn); //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdEquipo", e.IdEquipo);
                cmd.Parameters.AddWithValue("@prmIdCliente", e.IdCliente);
                cmd.Parameters.AddWithValue("@prmMarca", e.Marca);
                cmd.Parameters.AddWithValue("@prmModelo", e.Modelo);
                cmd.Parameters.AddWithValue("@prmNumeroSerie", e.NumeroSerie);
                cmd.Parameters.AddWithValue("@prmDescripcionProblema", e.DescripcionProblema);
                cmd.Parameters.AddWithValue("@prmFechaIngreso", e.FechaIngreso);
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

        public Boolean EliminarEquipos(int idEquipo)
        {
            SqlCommand cmd = null;
            Boolean eliminar = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexión a la base de datos
                cmd = new SqlCommand("spEliminarEquipos", cn); //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdEquipos", idEquipo);
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

