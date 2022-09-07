using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace opinicion_ciudadana.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        // GET: Admin
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult crearPregunta()
        {
        
            return View();
        }
    }
}