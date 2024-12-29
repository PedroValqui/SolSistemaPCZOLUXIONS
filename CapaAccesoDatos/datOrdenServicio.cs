using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class datOrdenServicio
    {
        #region Singleton
        private static readonly datOrdenServicio UnicaInstancia = new datOrdenServicio();

        public static datOrdenServicio Instancia
        {
            get
            {
                return UnicaInstancia;
            }
        }
        #endregion Singleton

        #region Métodos

        // Listar todas las órdenes de servicio
        public List<entOrdenServicio> ListarOrdenesServicio()
        {
            SqlCommand cmd = null;
            List<entOrdenServicio> lista = new List<entOrdenServicio>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarOrdenesServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entOrdenServicio orden = new entOrdenServicio
                    {
                        IdOrden = Convert.ToInt32(dr["IdOrden"]),
                        IdCliente = Convert.ToInt32(dr["IdCliente"]),
                        IdEquipo = Convert.ToInt32(dr["IdEquipo"]),
                        IdServicio = Convert.ToInt32(dr["IdServicio"]),
                        FechaOrden = Convert.ToDateTime(dr["FechaOrden"]),
                        Estado = dr["Estado"].ToString()
                    };
                    lista.Add(orden);
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

        // Buscar una orden de servicio por ID
        public entOrdenServicio BuscarOrdenServicio(int idOrden)
        {
            SqlCommand cmd = null;
            entOrdenServicio orden = null;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarOrdenServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdOrden", idOrden);
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    orden = new entOrdenServicio
                    {
                        IdOrden = Convert.ToInt32(dr["IdOrden"]),
                        IdCliente = Convert.ToInt32(dr["IdCliente"]),
                        IdEquipo = Convert.ToInt32(dr["IdEquipo"]),
                        IdServicio = Convert.ToInt32(dr["IdServicio"]),
                        FechaOrden = Convert.ToDateTime(dr["FechaOrden"]),
                        Estado = dr["Estado"].ToString()
                    };
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

            return orden;
        }

        // Insertar una nueva orden de servicio
        public Boolean InsertarOrdenServicio(entOrdenServicio orden)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarOrdenServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prmIdCliente", orden.IdCliente);
                cmd.Parameters.AddWithValue("@prmIdEquipo", orden.IdEquipo);
                cmd.Parameters.AddWithValue("@prmIdServicio", orden.IdServicio);
                cmd.Parameters.AddWithValue("@prmFechaOrden", orden.FechaOrden);
                cmd.Parameters.AddWithValue("@prmEstado", orden.Estado);
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

        // Editar una orden de servicio existente
        public Boolean EditarOrdenServicio(entOrdenServicio orden)
        {
            SqlCommand cmd = null;
            Boolean editar = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditarOrdenServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prmIdOrden", orden.IdOrden);
                cmd.Parameters.AddWithValue("@prmIdCliente", orden.IdCliente);
                cmd.Parameters.AddWithValue("@prmIdEquipo", orden.IdEquipo);
                cmd.Parameters.AddWithValue("@prmIdServicio", orden.IdServicio);
                cmd.Parameters.AddWithValue("@prmFechaOrden", orden.FechaOrden);
                cmd.Parameters.AddWithValue("@prmEstado", orden.Estado);
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

        // Eliminar una orden de servicio por ID
        public Boolean EliminarOrdenServicio(int idOrden)
        {
            SqlCommand cmd = null;
            Boolean eliminar = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEliminarOrdenServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdOrden", idOrden);
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

        #endregion Métodos
    }
}