using CapaAplicacion;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    public class ClientesController : Controller
    {
        [HttpGet]
        public ActionResult Lista(String msg)
        {
            try
            {
                ViewBag.mensaje = msg;
                List<entClientes> lista = logClientes.Instancia.ListarClientes();
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
                return RedirectToAction("Lista", "Clientes", new { msg = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Insertar(FormCollection formulario)
        {
            try
            {
                Boolean inserto = false;
                entClientes c = new entClientes();
                c.Nombres = Convert.ToString(formulario["txtNombres"]);
                c.Apellidos = Convert.ToString(formulario["txtApellidos"]);
                c.TipoDocumentoIdentidad = Convert.ToString(formulario["txtTipoDocumentoIdentidad"]);
                c.DocumentoIdentidad = Convert.ToString(formulario["txtDocumentoIdentidad"]);
                c.Celular = Convert.ToString(formulario["txtCelular"]);
                c.Correo = Convert.ToString(formulario["txtCorreo"]);

                inserto = logClientes.Instancia.InsertarClientes(c);
                if (inserto)
                {
                    return RedirectToAction("Lista", "Clientes");
                }
                else
                {
                    return View(formulario);
                }
            }
            catch (Exception c)
            {
                return RedirectToAction("Lista", "Clientes", new { msg = c.Message });
            }
        }

        [HttpGet]
        public ActionResult Editar(int IdCliente)
        {
            try
            {
                entClientes c = new entClientes();
                c = logClientes.Instancia.BuscarClientes(IdCliente);
                return View(c);
            }
            catch (Exception c)
            {
                return RedirectToAction("Lista", "Clientes", new { msg = c.Message });
            }
        }

        [HttpPost]
        public ActionResult Editar(FormCollection formulario)
        {
            try
            {
                Boolean inserto = false;
                entClientes c = new entClientes();
                c.IdCliente = Convert.ToInt32(formulario["txtIdCliente"]);
                c.Nombres = Convert.ToString(formulario["txtNombres"]);
                c.Apellidos = Convert.ToString(formulario["txtApellidos"]);
                c.TipoDocumentoIdentidad = Convert.ToString(formulario["txtTipoDocumentoIdentidad"]);
                c.DocumentoIdentidad = Convert.ToString(formulario["txtDocumentoIdentidad"]);
                c.Celular = Convert.ToString(formulario["txtCelular"]);
                c.Correo = Convert.ToString(formulario["txtCorreo"]);

                inserto = logClientes.Instancia.EditarClientes(c);
                if (inserto)
                {
                    return RedirectToAction("Lista", "Clientes");
                }
                else
                {
                    return View(formulario);
                }
            }
            catch (Exception c)
            {
                return RedirectToAction("Lista", "Clientes", new { msg = c.Message });
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int IdCliente)
        {
            try
            {
                Boolean elimino = false;
                elimino = logClientes.Instancia.EliminarClientes(IdCliente);
                if (elimino)
                {
                    return RedirectToAction("Lista", "Clientes");
                }
                else
                {
                    return RedirectToAction("MenuPrincipal", "Intranet");
                }
            }
            catch (Exception c)
            {
                return RedirectToAction("Lista", "Clientes", new { msg = c.Message });
            }
        }
    }
}