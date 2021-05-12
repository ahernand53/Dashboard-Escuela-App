using EscuelaApp.Data;
using EscuelaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaApp.Controllers
{
    [Route("/Cursos")]
    public class CursoController : Controller
    {
        private EscuelaDbContext _context;

        public CursoController(EscuelaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var CURSOS = _context.Cursos.ToList();

            return View(CURSOS);
        }

        [HttpGet("/Cursos/Detalles/{id?}")]
        public IActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id)) 
            {
                return RedirectToAction("Index");
            }

            var CURSO = from curso in _context.Cursos
                         where curso.Id == id
                         select curso;

            return View(CURSO.SingleOrDefault());
        }

        [HttpGet("Nuevo")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Nuevo")]
        public IActionResult Store(Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", curso);
            }

            var escuela = _context.Escuelas.FirstOrDefault();
            curso.EscuelaId = escuela.Id;

            _context.Cursos.Add(curso);
            _context.SaveChanges();
            ViewBag.Mensaje = "Curso creado satisfatoriamente";

            return View("Details", curso);
        }

        [HttpGet("Editar/{id?}")]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            var CURSO = from curso in _context.Cursos
                        where curso.Id == id
                        select curso;

            return View(CURSO.FirstOrDefault());
        }

        [HttpPost("Editar")]
        public IActionResult Update(Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", curso);
            }

            var cursoActualizar = (from c in _context.Cursos
                                   where c.Id == curso.Id
                                   select c).FirstOrDefault();

            if (cursoActualizar == null)
            {
                return NotFound();
            }

            cursoActualizar.Nombre = curso.Nombre;
            cursoActualizar.Jornada = curso.Jornada;
            cursoActualizar.Dirección = curso.Dirección;          
            _context.SaveChanges();

            ViewBag.Mensaje = "Curso Actualizado Exitosamente";

            return View("Edit", curso);
        }

    }

}
