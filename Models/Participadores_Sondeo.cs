using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace opinicion_ciudadana.Models
{
    public class Participadores_Sondeo
    {
        public string ID_CIUDADANO { get; set; }
        public int COD_SONDEO { get; set; }
        public string FECHA_PART { get; set; }
        public string HORA_PART { get; set; }
    }
}