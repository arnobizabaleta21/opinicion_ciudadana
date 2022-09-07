using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace opinicion_ciudadana.Models
{
    public class Informes
    {
		public int COD_INFORME { get; set; }
		public string NOMBRE { get; set; }
		public string RUTA_ARCHIVO { get; set; }
		public string FECHA_CREACION { get; set; }
		public string HORA_CREACION { get; set; }
		public int ID_ADMINISTRADOR { get; set; }
	}

	


}