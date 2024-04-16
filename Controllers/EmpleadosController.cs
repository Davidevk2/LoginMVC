
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

   
    }
}