using EscuelaApp.Data;
using EscuelaApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaApp.Controllers
{
    [Route("/cursos")]
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

        [HttpGet("/cursos/detalles/{cursoId?}")]
        public IActionResult Details(string cursoId)
        {
            if (string.IsNullOrEmpty(cursoId)) 
            {
                return RedirectToAction("Index");
            }

            var CURSO = from curso in _context.Cursos
                         where curso.Id == cursoId
                         select curso;

            return View(CURSO.SingleOrDefault());
        }

    }

}
