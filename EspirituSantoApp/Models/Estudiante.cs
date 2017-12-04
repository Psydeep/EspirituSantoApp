using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EspirituSantoApp.Models
{
    public class Estudiante
    {
        [Key]
        [Display(Name = "Estudiante")]
        public int Est_ID { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Usted debe ingresar: {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe tener entre {1} and {2} caracteres", MinimumLength = 3)]
        public string Est_Apellidos { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Usted debe ingresar: {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe tener entre {1} and {2} caracteres", MinimumLength = 3)]
        public string Est_Nombres { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Usted debe ingresar: {0}")]
        [StringLength(50)]
        public string Est_Direccion { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "Usted debe ingresar: {0}")]
        [StringLength(10)]
        public string Est_Telefono { get; set; }

        [Display(Name = "DNI")]
        [Required(ErrorMessage = "Usted debe ingresar: {0}")]
        public int Est_DNI { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "Usted debe ingresar: {0}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Est_FechaNac { get; set; }

        [Display(Name = "Género")]
        [Required(ErrorMessage = "Usted debe ingresar: {0}")]
        [StringLength(1)]
        public string Est_Genero { get; set; }

        [NotMapped]
        public int Edad { get { return DateTime.Now.Year - Est_FechaNac.Year; } }

        //claves foraneas para las tablas: Matricula, GradoFinalizado
        public virtual ICollection<Matricula> Matriculas { get; set; }
        public virtual ICollection<GradoFinalizado> GradoFinalizados { get; set; }
    }
}