
using Microsoft.AspNetCore.Mvc;
using SistemaLaboral.Data;

namespace SistemaLaboral.Controllers
{
    
    public class HistorialController : Controller
    {
        //Inyeccion de dependencias para la conexion a la db
        public readonly SistemaContext _context; 
        
        //Constructor que inicializa la conexion 
        public HistorialController(SistemaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

       
    }
}