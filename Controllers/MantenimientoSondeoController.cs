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
    public class MantenimientoSondeoController : Controller
    {
        private SqlConnection con;

        private void conectar()
        {
            string cadena = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(cadena);
        }
        // GET: MantenimientoSondeo
        public ActionResult Index()
        {
            MantenimientoSondeo ma = new MantenimientoSondeo();
            List<Sondeos> listaSondeos = ma.listarSondeos();
            Session["Sondeos"] = listaSondeos; 
            return View(listaSondeos);
        }

        // GET: MantenimientoSondeo/Details/5
        public ActionResult Details(int id)
        {

            MantenimientoSondeo ma = new MantenimientoSondeo();
            Sondeos sondeo = ma.mostrarSondeo(id);
            return View(sondeo);
        }

        // GET: MantenimientoSondeo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MantenimientoSondeo/Create
        [HttpPost]
        public ActionResult Create(Sondeos encuesta)
        {
            conectar();
            string query = "INSERT INTO SONDEOS(NOMBRE,DESCRIPCION,TEMA,FECHA_CREACION,HORA_CREACION,FECHA_FINAL,HORA_FINAL) VALUES(@NOMBRE,@DESCRIPCION,@TEMA,@FECHA_CREACION,@HORA_CREACION,@FECHA_FINAL,@HORA_FINAL)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@NOMBRE", encuesta.NOMBRE);
            cmd.Parameters.AddWithValue("@DESCRIPCION", encuesta.DESCRIPCION);
            cmd.Parameters.AddWithValue("@TEMA", encuesta.TEMA);
            string fechaC = DateTime.Now.Date.ToString();

            cmd.Parameters.AddWithValue("@FECHA_CREACION", fechaC.Substring(0, 10));
            cmd.Parameters.AddWithValue("@HORA_CREACION", DateTime.Now.ToString("hh:mm:ss tt"));
            cmd.Parameters.AddWithValue("@FECHA_FINAL", encuesta.FECHA_FINAL);
            cmd.Parameters.AddWithValue("@HORA_FINAL", encuesta.HORA_FINAL);
            con.Open();
            int i = cmd.ExecuteNonQuery();

            return RedirectToAction("Index", "MantenimientoSondeo");
        }

        // GET: MantenimientoSondeo/Edit/5
        public ActionResult Edit(int id)
        {
            MantenimientoSondeo ma = new MantenimientoSondeo();
            Sondeos sondeo = ma.mostrarSondeo(id);
            return View(sondeo);
        }

        // POST: MantenimientoSondeo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Sondeos encuesta)
        {
            ViewData["fechaFinSondeo"] = encuesta.FECHA_FINAL;
            ViewData["COD_SONDEO"] = encuesta.COD_SONDEO;
            MantenimientoSondeo ma = new MantenimientoSondeo();
            ma.editarSondeos(id, encuesta);

            return RedirectToAction("Index", "MantenimientoSondeo");
        }

        // GET: MantenimientoSondeo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MantenimientoSondeo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Preguntas()
        {
            return View();
        }
    }
}
