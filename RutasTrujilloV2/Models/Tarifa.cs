using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RutasTrujilloV2.Models
{
    public class Tarifa
    {
        [Key]
        public int IdTarifa { get; set; }
        public String Tipo { get; set; }
        public float Precio { get; set; }

        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }
    }
}