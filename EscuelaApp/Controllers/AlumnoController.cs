using EscuelaApp.Data;
using EscuelaApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaApp.Controllers
{
    [Route("/alumnos")]
    public class AlumnoController : Controller
    {
        private EscuelaDbContext _context;

        public AlumnoController(EscuelaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var ALUMNOS = _context.Alumnos.ToList();

            return View(ALUMNOS);
        }

        [HttpGet("/alumnos/detalles/{alumnoId?}")]
        public IActionResult Details(string alumnoId)
        {
            if (string.IsNullOrEmpty(alumnoId)) 
            {
                return RedirectToAction("Index");
            }

            var ALUMNO = from alumno in _context.Alumnos
                         where alumno.Id == alumnoId
                         select alumno;

            return View(ALUMNO.SingleOrDefault());
        }

    }

}
