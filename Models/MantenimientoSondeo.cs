using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using opinicion_ciudadana.Logica;
namespace opinicion_ciudadana.Models
{
    public class MantenimientoSondeo
    {
        private SqlConnection con;

        private void conectar()
        {
            string cadena = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(cadena);
        }

        public List<Sondeos> listarSondeos()
        {
            List<Sondeos> listaEncuentas = new List<Sondeos>();
            conectar();
            string query = "SELECT * FROM SONDEOS";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                Sondeos encuesta = new Sondeos()
                {
                    COD_SONDEO = Convert.ToInt32(registros["COD_SONDEO"]),
                    DESCRIPCION = registros["DESCRIPCION"].ToString(),
                    NOMBRE = registros["NOMBRE"].ToString(),
                    TEMA = registros["TEMA"].ToString(),
                    FECHA_CREACION = registros["FECHA_CREACION"].ToString(),
                    HORA_CREACION = registros["HORA_CREACION"].ToString(),
                    FECHA_FINAL = registros["FECHA_FINAL"].ToString(),
                    HORA_FINAL = registros["HORA_FINAL"].ToString()


                };

                listaEncuentas.Add(encuesta);
                
              
               
         
            }
            return listaEncuentas;

        }

       public Sondeos mostrarSondeo( int COD_SONDEO)
        {
            Sondeos datosEnc = new Sondeos();
            conectar();
            string query = "SELECT * FROM SONDEOS WHERE COD_SONDEO = @COD_SONDEO";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@COD_SONDEO", COD_SONDEO);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                datosEnc.COD_SONDEO = Convert.ToInt32(registros["COD_SONDEO"]);
                datosEnc.DESCRIPCION = registros["DESCRIPCION"].ToString();
                datosEnc.NOMBRE = registros["NOMBRE"].ToString();
                datosEnc.TEMA = registros["TEMA"].ToString();
                datosEnc.FECHA_CREACION = registros["FECHA_CREACION"].ToString();
                datosEnc.HORA_CREACION = registros["HORA_CREACION"].ToString();
                datosEnc.FECHA_FINAL = registros["FECHA_FINAL"].ToString();
                datosEnc.HORA_FINAL = registros["HORA_FINAL"].ToString();
            }
            return datosEnc;

        }

        public int editarSondeos(int COD,Sondeos encuesta)
        {
            conectar();
            string query = "UPDATE SONDEOS SET NOMBRE = @NOMBRE,DESCRIPCION=@DESCRIPCION,TEMA = @TEMA,FECHA_FINAL = @FECHA_FINAL,HORA_FINAL = HORA_FINAL WHERE COD_SONDEO = @COD_SONDEO";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@COD_SONDEO", COD);
            cmd.Parameters.AddWithValue("@NOMBRE", encuesta.NOMBRE);
            cmd.Parameters.AddWithValue("@DESCRIPCION", encuesta.DESCRIPCION);
            cmd.Parameters.AddWithValue("@TEMA", encuesta.TEMA);

            cmd.Parameters.AddWithValue("@FECHA_FINAL", encuesta.FECHA_FINAL);
            cmd.Parameters.AddWithValue("@HORA_FINAL", encuesta.HORA_FINAL);
            cmd.CommandType = CommandType.Text;
            con.Open();
            int i = cmd.ExecuteNonQuery();
            return i;
        }
    }
}