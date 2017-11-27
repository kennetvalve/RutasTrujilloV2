using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RutasTrujilloV2.Models
{
    public class Ruta
    {
        [Key]
        public int IdRuta { get; set; }
        public String Letra { get; set; }
        public String Origen { get; set; }
        public String Destino { get; set; }

        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }
    }
}