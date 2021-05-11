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
            var listaAsignaturas = _context.Asignaturas.ToList();

            return View(listaAsignaturas);
        }

        [HttpGet("detalles/{asignaturaId?}")]
        public IActionResult Details(string asignaturaId)
        {
            if (string.IsNullOrEmpty(asignaturaId))
            {
                return RedirectToAction("Index");
            }

            var asignatura = from asig in _context.Asignaturas
                             where asig.Id == asignaturaId
                             select asig;

            return View(asignatura.SingleOrDefault());
        }
    }
}
