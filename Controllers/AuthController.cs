using Microsoft.AspNetCore.Mvc;
using SistemaLaboral.Data;

namespace SistemaLaboral.Controllers
{
    public class AuthController : Controller
    {

        public readonly SistemaContext _context;

        public AuthController(SistemaContext context)
        {
            _context = context;
        }

        public IActionResult Index(){
            return View();
        }

           public IActionResult Register()
        {
            return View();
        }
        
    }
}