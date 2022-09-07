using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using opinicion_ciudadana.Models;

namespace opinicion_ciudadana.Logica
{
    public class LOAdmin
    {
        private SqlConnection con;

        private void conectar()
        {
            string cadena = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(cadena);
        }

        public Administrador EncontrarAdmin(string CORREO_ELECTRONICO, string CONTRASENA)
        {
            Administrador admon = new Administrador();
            conectar();
            string query = "SELECT * FROM ADMINISTRADORES WHERE CORREO_ELECTRONICO = @CORREO_ELECTRONICO AND dbo.DESENCRYPTAR(CONTRASENA)  = @CONTRASENA";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@CORREO_ELECTRONICO", CORREO_ELECTRONICO);
            cmd.Parameters.AddWithValue("@CONTRASENA", CONTRASENA);
            cmd.CommandType = CommandType.Text;
            con.Open();

            SqlDataReader Registros = cmd.ExecuteReader();
            while (Registros.Read())
            {
                admon.ID_ADMINISTRADOR = Convert.ToInt32( Registros["ID_ADMINISTRADOR"]);
                admon.NOMBRE_ADMIN = Registros["NOMBRE_ADMIN"].ToString();
                admon.CORREO_ELECTRONICO = Registros["CORREO_ELECTRONICO"].ToString();
                admon.CONTRASENA = Registros["CONTRASENA"].ToString();
            }

            return admon;

        }
    }
}