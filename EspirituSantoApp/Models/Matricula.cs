using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EspirituSantoApp.Models
{
    public class Matricula
    {
        [Key]
        public int Mat_ID { get; set; }

        [Display(Name = "Fecha de Matrícula")]
        [Required(ErrorMessage = "Usted debe ingresar: {0}")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Mat_fecha { get; set; }

        //claves foraneas de las tablas: Estudiante, Cronograma, curso

        [Display(Name = "Estudiante")]
        [Required(ErrorMessage = "Usted debe seleccionar: {0}")]
        public int Est_ID { get; set; }

        [Display(Name = "Cronograma")]
        [Required(ErrorMessage = "Usted debe seleccionar: {0}")]
        public int Cron_ID { get; set; }

        [Display(Name = "Curso")]
        [Required(ErrorMessage = "Usted debe seleccionar: {0}")]
        public int Cur_ID { get; set; }


        public virtual Estudiante Estudiante { get; set; }
        public virtual Cronograma Cronograma { get; set; }
        public virtual Curso Curso { get; set; }

    }
}