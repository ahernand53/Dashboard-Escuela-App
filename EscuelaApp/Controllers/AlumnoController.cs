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

        [HttpGet("/alumnos/detalles")]
        public IActionResult Details()
        {
            var ALUMNO = _context.Alumnos.FirstOrDefault();

            return View(ALUMNO);
        }

    }

}
