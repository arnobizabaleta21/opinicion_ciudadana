using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace opinicion_ciudadana.Models
{
    public class Ciudadanos
    {
    public string TIPO_DOCUMENTO { get; set; }
     public string NUM_DOCUMENTO { get; set; }
     public string CONTRASENA { get; set; }
     public string NOMBRES_COMPLETOS { get; set; }
     public string APELLIDOS { get; set; }
     public string SEXO { get; set; }
     public string TELEFONO_CELULAR { get; set; }
     public string TELEFONO_FIJO { get; set; }
        public string CORREO_ELECTRONICO { get; set; }
        public string MUNICIPIO { get; set; }
        public string DIRECCION { get; set; }
        public string BARRIO_VEREDA { get; set; }
        public string FECHA_NACIMIENTO { get; set; }
        public string ETNIA { get; set; }
        public string CONDICION_DISCAPACIDAD { get; set; }
        public string ESTRATO_RESIDENCIA { get; set; }
        public string NIVEL_EDUCATIVO { get; set; }
        public string ACCESO_DISPOSITIVOS { get; set; }
        public string TIPO_DISPOSITIVOS { get; set; }
        public bool CONECTIVIDAD { get; set; }
        public bool AFILIACION { get; set; }

    }
}