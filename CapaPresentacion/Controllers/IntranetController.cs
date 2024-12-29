using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaAplicacion;
using CapaEntidades;

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
                entUsuarios u = logUsuarios.Instancia.VerificarUsuarios(usuario, contrasena);
                if (u != null)
                {
                    Session["Usuario"] = u;
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