using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SistemaLaboral.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        [HttpPost]
        public async Task<IActionResult>Login(string identificacion, string password){

            var user = _context.Empleados.FirstOrDefault(u => u.Identificacion == identificacion);

            if (user != null && user.Password == password)
            {
                // Guardar información del usuario en la sesión
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                HttpContext.Session.SetString("UserName", user.Nombres);
                // ViewBag.User = user.Id.ToString();
                // ViewBag.Login = true;


                return RedirectToAction("Index", "Empleados");
            }


            return RedirectToAction("Index");
        }

           public IActionResult Register()
        {
            return View();
        }

        public IActionResult Logout(){

            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Auth");
        }
        
    }
}