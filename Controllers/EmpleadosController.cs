
using Microsoft.AspNetCore.Mvc;
using SistemaLaboral.Models;
using SistemaLaboral.Data;


namespace SistemaLaboral.Controllers
{
 
    public class EmpleadosController : Controller
    {
        public readonly SistemaContext _context;

        public EmpleadosController(SistemaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.IdEmpleado = HttpContext.Session.GetString("UserName");
            return View();
        }

          public async Task<IActionResult> Register(Empleado empleado)
        {
           _context.Empleados.Add(empleado);
           await _context.SaveChangesAsync();
           return RedirectToAction("Index");
        }

   
    }
}