using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidades;
using CapaAccesoDatos;

namespace CapaPresentacion.Controllers
{
    public class IntranetController : Controller
    {
        [HttpGet]
        public ActionResult InicioSesion(String msg)
        {
            Session["Usuario"] = null;
            ViewBag.mensaje = msg;
            return View();
        }
        [HttpPost]
        public ActionResult InicioSesion(FormCollection formulario)
        {
            try
            {
                String usuario = Convert.ToString(formulario["txtUsuario"]);
                String contrasena = Convert.ToString(formulario["txtContrasena"]);
                Empleado empleado = logEmpleado.Instancia.VerificarInicioSesion(usuario, contrasena);
                if (empleado != null)
                {
                    Session["empleado"] = empleado;
                    return View("MenuPrincipal");
                }
                else
                {
                    return RedirectToAction("InicioSesion", "Intranet", new { msg = "El usuario o la contraseña son incorrectos" });
                }
            }
            catch (Exception ex)
            {

                return RedirectToAction("InicioSesion", "Intranet", new { msg = ex.Message });
            }

        }

        [HttpGet]
        public ActionResult MenuPrincipal()
        {
            return View();
        }
    }
}