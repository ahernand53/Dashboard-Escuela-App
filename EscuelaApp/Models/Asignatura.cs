using System;
using System.Collections.Generic;

namespace EscuelaApp.Models
{
    public class Asignatura:ObjetoEscuelaBase
    {
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Evaluaci�n> Evaluaciones { get; set; }
    }
}