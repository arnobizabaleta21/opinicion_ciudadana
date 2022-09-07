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
    public class AccesoCiudController : Controller
    {
        private SqlConnection con;

        private void conectar() {
            string cadena = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(cadena);
        }
        // GET: AccesoCiud
        public ActionResult Index()
        {
            ViewBag.Message = "Estimado Ciudadano, recuerda que la contraseña por defecto es su Nro de identiticación";
            return View();
        }
        [HttpPost]
        public ActionResult Index(string NUM_DOCUMENTO, string CONTRASENA)
        {
            LOCiudadanos lo = new LOCiudadanos();
            Ciudadanos ciudadano = lo.EncontrarCiudadano(NUM_DOCUMENTO, CONTRASENA);
            if (ciudadano.NOMBRES_COMPLETOS != null)
            {
                FormsAuthentication.SetAuthCookie(ciudadano.NUM_DOCUMENTO, false);
                Session["Admin"] = ciudadano;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();
            }
        }
        public ActionResult Registrar()
        {
            return View();
        }

        [ HttpPost]
        public ActionResult Registrar( Ciudadanos ciudadano)
        {
            bool registrado;
            string mensaje;

            conectar();
            SqlCommand cmd = new SqlCommand("SP_REGISTRARCIUDADANO",con);
            cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO",ciudadano.TIPO_DOCUMENTO);
            cmd.Parameters.AddWithValue("@NUM_DOCUMENTO", ciudadano.NUM_DOCUMENTO);
            cmd.Parameters.AddWithValue("@NOMBRES_COMPLETOS", ciudadano.NOMBRES_COMPLETOS);
            cmd.Parameters.AddWithValue("@CONTRASENA", ciudadano.NUM_DOCUMENTO);
            cmd.Parameters.AddWithValue("@APELLIDOS", ciudadano.APELLIDOS);
            cmd.Parameters.AddWithValue("@SEXO", ciudadano.SEXO);
            cmd.Parameters.AddWithValue("@TELEFONO_CELULAR", ciudadano.TELEFONO_CELULAR);
            cmd.Parameters.AddWithValue("@TELEFONO_FIJO", ciudadano.TELEFONO_FIJO);
            cmd.Parameters.AddWithValue("@CORREO_ELECTRONICO", ciudadano.CORREO_ELECTRONICO);
            cmd.Parameters.AddWithValue("@MUNICIPIO", ciudadano.MUNICIPIO);
            cmd.Parameters.AddWithValue("@DIRECCION", ciudadano.DIRECCION);
            cmd.Parameters.AddWithValue("@BARRIO_VEREDA", ciudadano.BARRIO_VEREDA);
            cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", ciudadano.FECHA_NACIMIENTO);
            cmd.Parameters.AddWithValue("@ETNIA", ciudadano.ETNIA);
            cmd.Parameters.AddWithValue("@CONDICION_DISCAPACIDAD", ciudadano.CONDICION_DISCAPACIDAD);
            cmd.Parameters.AddWithValue("@ESTRATO_RESIDENCIA", ciudadano.ESTRATO_RESIDENCIA);
            cmd.Parameters.AddWithValue("@NIVEL_EDUCATIVO", ciudadano.NIVEL_EDUCATIVO);
            cmd.Parameters.AddWithValue("@ACCESO_DISPOSITIVOS",  ciudadano.ACCESO_DISPOSITIVOS);
            cmd.Parameters.AddWithValue("@TIPO_DISPOSITIVOS", ciudadano.TIPO_DISPOSITIVOS);
            cmd.Parameters.AddWithValue("@CONECTIVIDAD", ciudadano.CONECTIVIDAD);
            cmd.Parameters.AddWithValue("@AFILIACION", ciudadano.AFILIACION);

            SqlParameter regis = new SqlParameter("@REGISTRADO",SqlDbType.Bit);
            SqlParameter mens = new SqlParameter("@MENSAJE", SqlDbType.VarChar,100);
            regis.Direction = ParameterDirection.Output;
            mens.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(regis);
            cmd.Parameters.Add(mens);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            registrado = Convert.ToBoolean(cmd.Parameters["@REGISTRADO"].Value);
            mensaje = cmd.Parameters["@MENSAJE"].Value.ToString();

            ViewData["Mensaje"] = mensaje;

            if (registrado)
            {
                return RedirectToAction("Index","AccesoCiud");
            }
            else
            {
                return View();
            }

            

        }
    }
}