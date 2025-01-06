using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaAccesoDatos;

namespace CapaAplicacion
{
    public class logClientes
    {
        #region Singleton
        private static readonly logClientes UnicaInstancia = new logClientes();

        public static logClientes Instancia
        {
            get
            {
                return logClientes.UnicaInstancia;
            }
        }
        #endregion Singleton

        #region Métodos

        public List<entClientes> ListarClientes()
        {
            try
            {
                return datClientes.Instancia.ListarClientes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public entClientes BuscarClientes(int IdCliente)
        {
            try
            {
                return datClientes.Instancia.BuscarClientes(IdCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertarClientes(entClientes cliente)
        {
            try
            {
                return datClientes.Instancia.InsertarClientes(cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditarClientes(entClientes cliente)
        {
            try
            {
                return datClientes.Instancia.EditarClientes(cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarClientes(int IdCliente)
        {
            try
            {
                return datClientes.Instancia.EliminarClientes(IdCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Métodos
    }
}
