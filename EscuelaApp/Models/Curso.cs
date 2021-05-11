using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EscuelaApp.Models
{
    public class Curso: IModelBase
    {
        [Required(ErrorMessage = "El {0} es requerido")]
        public override string Nombre { get; set; }

        [Display(Name = "Jornada")]
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas{ get; set; }
        public List<Alumno> Alumnos{ get; set; }
        public string Dirección { get; set; }
        public string EscuelaId { get; set; }
        public Escuela Escuela { get; set; }

    }
}