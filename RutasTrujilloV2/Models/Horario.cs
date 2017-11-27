using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RutasTrujilloV2.Models
{
    public class Horario
    {
        [Key]
        public int IdHorario { get; set; }
        public String HoraSalida { get; set; }
        public String HoraLlegada { get; set; }

        public int IdRuta { get; set; }
        public Ruta Ruta { get; set; }
    }
}