using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAplicacion
{
    public class LogServicios
    {
        #region singelton
        private static readonly LogServicios UnicaInstancia = new LogServicios();

        public static LogServicios Instancia
        {
            get
            {
                return LogServicios.UnicaInstancia;
            }
        }
        #endregion singleton

        #region Métodos
        public List<entServicios> ListarServicios()
        {
            try
            {
                return datServicios.Instancia.ListarServicios();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public entServicios BuscarServicios(int IdServicio)
        {
            try
            {
                return datServicios.Instancia.BuscarServicios(IdServicio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean InsertarServicios(entServicios s)
        {
            try
            {
                return datServicios.Instancia.InsertarServicios(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Boolean EditarServicios(entServicios s)
        {
            try
            {
                return datServicios.Instancia.EditarServicios(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean EliminarServicios(int IdServicio)
        {
            try
            {
                return datServicios.Instancia.EliminarServicios(IdServicio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Métodos
    }
}