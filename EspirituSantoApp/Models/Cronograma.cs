using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EspirituSantoApp.Models
{
    public class Cronograma
    {
        [Key]
        public int Cron_ID { get; set; }

        [Display(Name = "Fecha Inicio")]
        [Required(ErrorMessage = "Usted debe ingresar: {0}")]
        public DateTime Cron_FechaInicio { get; set; }

        [Display(Name = "Fecha Fin")]
        [Required(ErrorMessage = "Usted debe ingresar: {0}")]
        public DateTime Cron_FechaFin { get; set; }

        //clave foranea para la tabla Matricula
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}