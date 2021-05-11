using EscuelaApp.Data;
using EscuelaApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaApp.Controllers
{
    public class EscuelaController : Controller
    {
        private EscuelaDbContext _context { get; set; }
        public EscuelaController(EscuelaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var ESCUELA = _context.Escuelas.FirstOrDefault();

            return View(ESCUELA);
        }
    }
}
