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
    public class AccesoAdminController : Controller
    {
        private SqlConnection con;

        private void conectar()
        {
            string cadena = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(cadena);
        }
        // GET: AccesoAdmin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string CORREO_ELECTRONICO, string CONTRASENA)
        {

            LOAdmin lo = new LOAdmin();
            Administrador admin = lo.EncontrarAdmin(CORREO_ELECTRONICO, CONTRASENA);
            if (admin.NOMBRE_ADMIN != null)
            {
                FormsAuthentication.SetAuthCookie(admin.CORREO_ELECTRONICO, false);
                Session["Admin"] = admin;
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
        [HttpPost]
        public ActionResult Registrar(Administrador admin)
        {
            while (validarContrasena( admin.CONTRASENA ) == false)
            {
                ViewData["Mensaje"] = "Tu contraseña es muy insegura";
                return View();
            }

            while (admin.CONTRASENA != admin.confirmarContrasena)
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }
            bool registrado;
            string mensaje;

            conectar();
            SqlCommand cmd = new SqlCommand("SP_REGISTRARADMIN", con);
            cmd.Parameters.AddWithValue("@NOMBRE_ADMIN", admin.NOMBRE_ADMIN);
            cmd.Parameters.AddWithValue("@APELLIDOS", admin.APELLIDOS);
            cmd.Parameters.AddWithValue("@CORREO_ELECTRONICO", admin.CORREO_ELECTRONICO);
            cmd.Parameters.AddWithValue("@CONTRASENA", admin.CONTRASENA);
            SqlParameter regis = new SqlParameter("@REGISTRADO", SqlDbType.Bit);
            SqlParameter mens = new SqlParameter("@MENSAJE", SqlDbType.VarChar, 100);
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
                return RedirectToAction("Index", "AccesoAdmin");
            }
            else
            {
                return View();
            }


        }

        public bool validarContrasena (string password){

            bool mayuscula = false, minuscula = false, espaciosBlancos = false, caracterEsp = false, numero = false;

            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsUpper(password,i))
                {
                    mayuscula = true;
                }
                 else if (Char.IsLower(password, i))
                {
                    minuscula = true;
                }
                else if (Char.IsDigit(password, i))
                {
                    numero = true;
                }
                else if (Char.IsWhiteSpace(password, i))
                {
                    espaciosBlancos = true;
                }
                else
                {
                    caracterEsp = true;
                }
            }

            if ( mayuscula && minuscula && numero && caracterEsp && espaciosBlancos == false && password.Length >= 8)
            {
                return true;
            }
            else
            {
                return false;
            }
            
            
        }
    }
}