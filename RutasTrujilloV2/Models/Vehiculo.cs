using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RutasTrujilloV2.Models
{
    public class Vehiculo
    {
        [Key]
        public int IdVehiculo { get; set; }
        public int NumeroVehiculo { get; set; }
        public String Placa { get; set; }

        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }
    }
}