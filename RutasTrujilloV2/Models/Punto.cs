using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RutasTrujilloV2.Models
{
    public class Punto
    {
        [Key]
        public int IdPunto { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }

        public int IdRuta { get; set; }
        public Ruta Ruta { get; set; }
    }
}