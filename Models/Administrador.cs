using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace opinicion_ciudadana.Models
{
    public class Administrador
    {
        public int ID_ADMINISTRADOR { get; set; }
        public string NOMBRE_ADMIN { get; set; }
        public string APELLIDOS { get; set; }
        public string CORREO_ELECTRONICO { get; set; }
        public string CONTRASENA { get; set; }
        public string confirmarContrasena{ get; set; }
    }
}