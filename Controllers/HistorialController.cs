
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaLaboral.Data;
using SistemaLaboral.Models;

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

        public async Task<IActionResult> Index()
        {
            ViewBag.IdEmleado = HttpContext.Session.GetString("IdEmpleado"); //variable de sesion para la vista
            ViewBag.Nombre = HttpContext.Session.GetString("Nombre");
            return View( await _context.Historial.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarIngreso([Bind("IdEmpleado")]Historial historial){

            /* try{ */
           
                _context.Historial.Add(historial);
                await _context.SaveChangesAsync();
                
                return RedirectToAction("Index", "Empleados");

           

         /*    }catch(Exception ex){
                ViewBag.ErrorMessage = "Error"+ex;
                return View(ViewBag.ErrorMessage);
            } */
           

        }

        

       
    }
}