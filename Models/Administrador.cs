using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace opinicion_ciudadana.Models
{
    public class Administrador
    {
        public int ID_ADMINISTRADOR { get; set; }
        public string NOMBRES { get; set; }
        public string CORREO { get; set; }
        public string CONTRASENA { get; set; }
        public string confirmarContrasena{ get; set; }
    }
}