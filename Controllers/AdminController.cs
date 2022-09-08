using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using opinicion_ciudadana.Models;
using opinicion_ciudadana.Logica;
using System.Web.Security;

namespace opinicion_ciudadana.Controllers
{
    public class AdminController : Controller
    {
        private SqlConnection con;

        private void conectar()
        {
            string cadena = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(cadena);
        }
        // GET: Admin

        // GET: Admin
        public ActionResult Home()
        {
            return View();
        }

      
        public ActionResult Informes()
        {
            return View();
        }

    }
}