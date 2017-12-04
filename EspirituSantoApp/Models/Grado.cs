using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EspirituSantoApp.Models
{
    public class Grado
    {
        [Key]
        public int Grado_ID { get; set; }

        public string Grado_Nombre { get; set; }

        public DateTime Grado_Anio { get; set; }

        //claves foraneas para las tablas: Curso, GradoFinalizado
        public virtual ICollection<Curso> Cursos { get; set; }
        public virtual ICollection<GradoFinalizado> GradoFinalizados { get; set; }
    }
}