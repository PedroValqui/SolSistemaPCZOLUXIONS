using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaAccesoDatos;

namespace CapaAplicacion
{
    public class logUsuarios
    {
        #region singelton
        private static readonly logUsuarios UnicaInstancia = new logUsuarios();

        public static logUsuarios Instancia
        {
            get
            {
                return logUsuarios.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos
        public entUsuarios VerificarUsuarios(String Usuario, String Contrasena)
        {
            try
            {
                return datUsuarios.Instancia.VerificarUsuarios(Usuario, Contrasena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<entUsuarios> ListarUsuarios()
        {
            try
            {
                return datUsuarios.Instancia.ListarUsuarios();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public entUsuarios BuscarUsuario(int IdUsuario)
        {
            try
            {
                return datUsuarios.Instancia.BuscarUsuario(IdUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean InsertarUsuario(entUsuarios u)
        {
            try
            {
                return datUsuarios.Instancia.InsertarUsuario(u);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Boolean EditarUsuario(entUsuarios u)
        {
            try
            {
                return datUsuarios.Instancia.EditarUsuario(u);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean EliminarUsuario(int IdUsuario)
        {
            try
            {
                return datUsuarios.Instancia.EliminarUsuario(IdUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion metodos

    }
}