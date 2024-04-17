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
        //vista login 
        public IActionResult Index(){
            return View();
        }

        //accion de login
        [HttpPost]
        public async Task<IActionResult> Login(string identificacion, string password){

            var usuarioLoggeado = await  _context.Empleados.FirstOrDefaultAsync(em => em.Identificacion == identificacion);

            if(usuarioLoggeado != null && usuarioLoggeado.Password == password){
                HttpContext.Session.SetString("IdEmpleado", usuarioLoggeado.Id.ToString());
                HttpContext.Session.SetString("Nombre", usuarioLoggeado.Nombres); //crear variable de sesion 

                return RedirectToAction("Index", "Empleados");
            }else{

             return RedirectToAction("Index"); //retornar al login
            }


        }

           public IActionResult Register()
        {
            return View();
        }

        public IActionResult Logout(){

            HttpContext.Session.Clear();
            return RedirectToAction("index", "Auth");
        }
        
    }
}