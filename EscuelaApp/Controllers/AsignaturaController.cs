using EscuelaApp.Data;
using EscuelaApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaApp.Controllers
{
    [Route("/Asignaturas")]
    public class AsignaturaController : Controller
    {
        private EscuelaDbContext _context;
        public AsignaturaController(EscuelaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ASIGNATURAS = _context.Asignaturas.ToList();

            return View(ASIGNATURAS);
        }

        [HttpGet("detalles/{id?}")]
        public IActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            var ASIGNATURA = from asig in _context.Asignaturas
                             where asig.Id == id
                             select asig;

            return View(ASIGNATURA.SingleOrDefault());
        }
    }
}
