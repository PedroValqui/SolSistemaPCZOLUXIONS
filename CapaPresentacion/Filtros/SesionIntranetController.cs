using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacion.Filtros
{
    public class SesionIntranetController : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Session["Usuarios"] == null)
            {
                filterContext.Result = new RedirectResult("/Intranet/InicioSesion");
            }
            base.OnActionExecuted(filterContext);
        }


    }
}