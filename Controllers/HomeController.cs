using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace opinicion_ciudadana.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SinPermiso()
        {
            ViewBag.Message = "Usted no tiene permisos para acceder a este página";

            return View();
        }

        public ActionResult ValidarCertificaciones()
        {
            return View();
        }

    }
}