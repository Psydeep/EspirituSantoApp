using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EspirituSantoApp.Models
{
    public class Curso
    {
        [Key]
        public int CursoID { get; set; }

        public string Cur_Nombre { get; set; }
        public int Cur_CuposDisp { get; set; }
        public string Cur_Paralelo { get; set; }

        //claves foraneas de las tablas: Aula, Grado

        [Display(Name = "Aula")]
        [Required(ErrorMessage = "Usted debe seleccionar: {0}")]
        public int Aula_ID { get; set; }

        [Display(Name = "Grado")]
        [Required(ErrorMessage = "Usted debe seleccionar: {0}")]
        public int Grado_ID { get; set; }

        public virtual Aula Aula { get; set; }
        public virtual Grado Grado { get; set; }


        //clave foranea para la tabla: Matricula
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}