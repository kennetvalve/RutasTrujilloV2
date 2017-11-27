using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RutasTrujilloV2.Models
{
    public class Empresa
    {
        [Key]
        public int IdEmpresa { get; set; }
        public String RazonSocial { get; set; }
        public String Ruc { get; set; }
    }
}