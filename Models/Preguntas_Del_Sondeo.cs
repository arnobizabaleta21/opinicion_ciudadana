using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace opinicion_ciudadana.Models
{
   
    public class Preguntas_Del_Sondeo
    {
        public int COD_PREGUNTA { get; set; }
        public int COD_SONDEO { get; set; }
        public string RESPUESTA { get; set; }
    }
}