using CapaAplicacion;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    public class ServiciosController : Controller
    {
        [HttpGet]
        public ActionResult Lista(String msg)
        {
            try
            {
                ViewBag.mensaje = msg;
                List<entServicios> lista = LogServicios.Instancia.ListarServicios();
                return View(lista);
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                return RedirectToAction("Lista", "Servicios", new { msg = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Insertar(FormCollection formulario)
        {
            try
            {
                Boolean inserto = false;
                entServicios s = new entServicios();
                s.NombreServicio = formulario["txtNombreServicio"];
                s.Costo = Convert.ToDecimal(formulario["txtCosto"]);


                inserto = LogServicios.Instancia.InsertarServicios(s);
                if (inserto)
                {
                    return RedirectToAction("Lista", "Servicios");
                }
                else
                {
                    return View(formulario);
                }
            }
            catch (Exception s)
            {
                return RedirectToAction("Lista", "Servicios", new { msg = s.Message });
            }
        }

        [HttpGet]
        public ActionResult Editar(int IdServicio)
        {
            try
            {
                entServicios s = new entServicios();
                s = LogServicios.Instancia.BuscarServicios(IdServicio);
                return View(s);
            }
            catch (Exception s)
            {
                return RedirectToAction("Lista", "Servicios", new { msg = s.Message });
            }
        }

        [HttpPost]
        public ActionResult Editar(FormCollection formulario)
        {
            try
            {
                Boolean inserto = false;
                entServicios s = new entServicios();
                s.IdServicio = Convert.ToInt32(formulario["txtIdServicio"]);
                s.NombreServicio = Convert.ToString(formulario["txtNombreServicio"]);
                s.Costo = Convert.ToDecimal(formulario["txtCosto"]);

                inserto = LogServicios.Instancia.EditarServicios(s);
                if (inserto)
                {
                    return RedirectToAction("Lista", "Servicios");
                }
                else
                {
                    return View(formulario);
                }
            }
            catch (Exception s)
            {
                return RedirectToAction("Lista", "Servicios", new { msg = s.Message });
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int IdServicio)
        {
            try
            {
                Boolean elimino = false;
                elimino = LogServicios.Instancia.EliminarServicios(IdServicio);
                if (elimino)
                {
                    return RedirectToAction("Lista", "Servicios");
                }
                else
                {
                    return RedirectToAction("MenuPrincipal", "Intranet");
                }
            }
            catch (Exception s)
            {
                return RedirectToAction("Lista", "Servicios", new { msg = s.Message });
            }
        }
    }
}