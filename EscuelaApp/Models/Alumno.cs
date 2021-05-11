using System;
using System.Collections.Generic;

namespace EscuelaApp.Models
{
    public class Alumno: IModelBase
    {
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Evaluación> Evaluaciones { get; set; }
    }
}