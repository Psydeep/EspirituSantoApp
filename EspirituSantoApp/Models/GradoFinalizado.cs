using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EspirituSantoApp.Models
{
    public class GradoFinalizado
    {
        [Key]
        public int GF_ID { get; set; }

        // claves foraneas de las tablas: Estudiante, Grado

        public int Alu_ID { get; set; }
        public int Grado_ID { get; set; }

        public virtual Estudiante Estudiante { get; set; }
        public virtual Grado Grado { get; set; }
    }
}