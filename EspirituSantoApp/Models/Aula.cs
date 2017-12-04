using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EspirituSantoApp.Models
{
    public class Aula
    {
        [Key]
        public int Aula_ID { get; set; }
        public int Aula_Num { get; set; }

        //clave foranea para la tabla Curso
        public virtual ICollection<Curso> Cursos { get; set; }
    }
}