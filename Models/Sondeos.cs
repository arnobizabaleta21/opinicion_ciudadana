using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace opinicion_ciudadana.Models
{
    public class Sondeos
    {
        public int COD_SONDEO { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public string TEMA{ get; set; }
        public string FECHA_CREACION { get; set; }
        public string HORA_CREACION { get; set; }
        public string FECHA_FINAL { get; set; }
        public string HORA_FINAL { get; set; }
        public string RUTA_IMG { get; set; }
        public int COD_INFORME { get; set; }
    }
}