using CapaAplicacion;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Configuration;

namespace CapaPresentacion.Controllers
{
    public class UsuariosController : Controller
    {
        
        [HttpGet]
        public ActionResult Lista(String msg)
        {
            try
            {
                ViewBag.mensaje = msg;
                List<entUsuarios> lista = logUsuarios.Instancia.ListarUsuarios();
                return View(lista);
            }
            catch (Exception u)
            {
                return RedirectToAction("MenuPrincipal", "Intranet", new { msg = "Ocurrió un error inesperado" });
            }
        }

        
        [HttpGet]
        public ActionResult Insertar(String msg)
        {
            try
            {
                ViewBag.mensaje = msg;
                return View();
            }
            catch (Exception u)
            {
                return RedirectToAction("Lista", "Usuarios", new { msg = u.Message });
            }
        }

        
        [HttpPost]
        public ActionResult Insertar(FormCollection formulario)
        {
            try
            {
                Boolean inserto = false;
                entUsuarios u = new entUsuarios();
                u.Nombres = Convert.ToString(formulario["txtNombres"]);
                u.Apellidos = Convert.ToString(formulario["txtApellidos"]);
                u.Correo = Convert.ToString(formulario["txtCorreo"]);
                u.Cargo = Convert.ToString(formulario["txtCargo"]);
                u.Usuario = Convert.ToString(formulario["txtUsuario"]);
                u.Contrasena = Convert.ToString(formulario["txtContrasena"]);
                
                inserto = logUsuarios.Instancia.InsertarUsuario(u);
                if (inserto)
                {
                    return RedirectToAction("Lista", "Usuarios");
                }
                else
                {
                    return View(formulario);
                }
            }
            catch (Exception u)
            {
                return RedirectToAction("Lista", "Usuarios", new { msg = u.Message });
            }
        }


        
        [HttpGet]
        public ActionResult Editar(int IdUsuario)
        {
            try
            {
                entUsuarios u = new entUsuarios();
                u = logUsuarios.Instancia.BuscarUsuario(IdUsuario);
                return View(u);
            }
            catch (Exception u)
            {
                return RedirectToAction("Lista", "Usuarios", new { msg = u.Message });
            }
        }

        
        [HttpPost]
        public ActionResult Editar(FormCollection formulario)
        {
            try
            {
                Boolean inserto = false;
                entUsuarios u = new entUsuarios();
                u.IdUsuario = Convert.ToInt32(formulario["txtIdUsuario"]);
                u.Nombres = Convert.ToString(formulario["txtNombres"]);
                u.Apellidos = Convert.ToString(formulario["txtApellidos"]);
                u.Correo = Convert.ToString(formulario["txtCorreo"]);
                u.Cargo = Convert.ToString(formulario["txtCargo"]);
                u.Usuario = Convert.ToString(formulario["txtUsuario"]);
                u.Contrasena = Convert.ToString(formulario["txtContrasena"]);

                inserto = logUsuarios.Instancia.EditarUsuario(u);
                if (inserto)
                {
                    return RedirectToAction("Lista", "Usuarios");
                }
                else
                {
                    return View(formulario);
                }
            }
            catch (Exception u)
            {
                return RedirectToAction("Lista", "Usuarios", new { msg = u.Message });
            }
        }

        
        [HttpGet]
        public ActionResult Eliminar(int IdUsuario)
        {
            try
            {
                Boolean elimino = false;
                elimino = logUsuarios.Instancia.EliminarUsuario(IdUsuario);
                if (elimino)
                {
                    return RedirectToAction("Lista", "Usuarios");
                }
                else
                {
                    return RedirectToAction("MenuPrincipal", "Intranet");
                }
            }
            catch (Exception u)
            {
                return RedirectToAction("Lista", "Usuarios", new { msg = u.Message });
            }
        }
    }
}