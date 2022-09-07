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
    public class LOCiudadanos
    {
        private SqlConnection con;

        private void conectar()
        {
            string cadena = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(cadena);
        }

        public Ciudadanos EncontrarCiudadano(string NUM_DOCUMENTO, string CONTRASENA)
        {
            Ciudadanos ciududano = new Ciudadanos();
            conectar();
            string query = "SELECT * FROM CIUDADANOS WHERE NUM_DOCUMENTO = @NUM_DOCUMENTO AND dbo.DESENCRYPTAR(CONTRASENA)  = @CONTRASENA";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@NUM_DOCUMENTO", NUM_DOCUMENTO);
            cmd.Parameters.AddWithValue("@CONTRASENA", CONTRASENA);
            cmd.CommandType = CommandType.Text;
            con.Open();

            SqlDataReader Registros = cmd.ExecuteReader();
            while (Registros.Read())
            {
                ciududano.NUM_DOCUMENTO = Registros["NUM_DOCUMENTO"].ToString();
                ciududano.NOMBRES_COMPLETOS = Registros["NOMBRES_COMPLETOS"].ToString();
                ciududano.APELLIDOS = Registros["APELLIDOS"].ToString();
                ciududano.CORREO_ELECTRONICO = Registros["CORREO_ELECTRONICO"].ToString();
                ciududano.CONTRASENA = Registros["CONTRASENA"].ToString();
                ciududano.SEXO = Registros["SEXO"].ToString();
                ciududano.TELEFONO_CELULAR = Registros["TELEFONO_CELULAR"].ToString();
                ciududano.TELEFONO_FIJO = Registros["TELEFONO_FIJO"].ToString();
                ciududano.MUNICIPIO = Registros["MUNICIPIO"].ToString();
                ciududano.DIRECCION = Registros["DIRECCION"].ToString();
                ciududano.BARRIO_VEREDA = Registros["BARRIO_VEREDA"].ToString();
                ciududano.FECHA_NACIMIENTO = Registros["FECHA_NACIMIENTO"].ToString();
                ciududano.ETNIA = Registros["ETNIA"].ToString();
                ciududano.CONDICION_DISCAPACIDAD = Registros["CONDICION_DISCAPACIDAD"].ToString();
                ciududano.ESTRATO_RESIDENCIA = Registros["ESTRATO_RESIDENCIA"].ToString();
                ciududano.NIVEL_EDUCATIVO = Registros["NIVEL_EDUCATIVO"].ToString();
                ciududano.ACCESO_DISPOSITIVOS = Convert.ToBoolean( Registros["ACCESO_DISPOSITIVOS"] );
                ciududano.TIPO_DISPOSITIVOS = Registros["TIPO_DISPOSITIVOS"].ToString();
                ciududano.CONECTIVIDAD = Convert.ToBoolean(Registros["CONECTIVIDAD"]);
                ciududano.AFILIACION = Registros["AFILIACION"].ToString();
            }

            return ciududano;

        }
    }
}