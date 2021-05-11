using EscuelaApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaApp.Data
{
    public class EscuelaDbContext: DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evaluación> Evaluaciones { get; set; }

        public EscuelaDbContext(DbContextOptions<EscuelaDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Agrega una escuela
            var escuela = new Escuela()
            {
                AñoDeCreación = 2005,
                Nombre = "CSDB",
                Pais = "Colombia",
                Ciudad = "Bogota",
                TipoEscuela = TiposEscuela.Secundaria,
                Dirección = "Calle 17 kra 30"
            };

            // cargar Cursos de la escuela
            var cursos = CargarCursos(escuela);

            // cargar asignaturas a cada curso
            var asignaturas = CargarAsignaturas(cursos);

            // cargar alumnos a cada curso
            var alumnos = CargarAlumnos(cursos);

            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());
            
        }

        private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            var lista = new List<Asignatura>();
            foreach (Curso curso in cursos)
            {

                List<Asignatura> asignaturas = new List<Asignatura> {
                    new Asignatura { Nombre = "Matemáticas", CursoId = curso.Id },
                    new Asignatura { Nombre = "Educación Física", CursoId = curso.Id },
                    new Asignatura { Nombre = "Castellano", CursoId = curso.Id },
                    new Asignatura { Nombre = "Ciencias Naturales", CursoId = curso.Id }
                };
                lista.AddRange(asignaturas);
            }

            return lista;
        }

        private List<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>()
            {
                new Curso() {Nombre = "101", Jornada = TiposJornada.Mañana, EscuelaId = escuela.Id},
                new Curso() {Nombre = "102", Jornada = TiposJornada.Mañana, EscuelaId = escuela.Id},
                new Curso() {Nombre = "103", Jornada = TiposJornada.Tarde, EscuelaId = escuela.Id},
                new Curso() {Nombre = "104", Jornada = TiposJornada.Tarde, EscuelaId = escuela.Id},
                new Curso() {Nombre = "105", Jornada = TiposJornada.Noche, EscuelaId = escuela.Id},
            };
        }

        private List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            var lista = new List<Alumno>();

            Random rnd = new Random();
            foreach (var curso in cursos)   
            {
                var tmpList = GenerarAlumnos(rnd.Next(15, 30), curso);
                lista.AddRange(tmpList);
            }

            return lista;
        }

        private List<Alumno> GenerarAlumnos(int cantidad, Curso curso)
        {

            string[] nombres = { "Alba", "Felipe", "Maria", "Pedro" };
            string[] apellidos = { "Ruiz", "Sarmiento", "Rodriguez", "Hernandez" };
            string[] segundosNombres = { "Freddy", "Daniel", "Rick", "Murthy" };

            var ALUMNOS = from nombre in nombres
                          from apellido in apellidos
                          from segundoNombre in segundosNombres
                          select new Alumno { 
                              Nombre = $"{nombre} {segundoNombre} {apellido}",
                              CursoId = curso.Id };

            return ALUMNOS.OrderBy(alumno => alumno.Id).Take(cantidad).ToList();
        }
    }
}
