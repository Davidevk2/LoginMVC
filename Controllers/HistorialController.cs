
using System.Data;
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
            int id  = Int32.Parse(HttpContext.Session.GetString("IdEmpleado")); //variable de sesion para la vista
            ViewBag.Nombre = HttpContext.Session.GetString("Nombre");

            //Listar solo los registros del empleado
            var result = from historial in   _context.Historial select historial;
            result = result.Where(his => his.IdEmpleado == id);

            return View( await result.ToListAsync());
             
        }
        
        [HttpPost]
        public async Task<IActionResult> RegistrarIngreso( [Bind("IdEmpleado")]Historial historial){
            var id = Int32.Parse(HttpContext.Session.GetString("IdEmpleado"));
        
            try{
                historial.IdEmpleado = id;

                _context.Historial.Add(historial);
                await _context.SaveChangesAsync();
                
                return RedirectToAction("Index", "Empleados");


            }catch(Exception ex){
                ViewBag.ErrorMessage = "Error"+ ex;
                return View(ViewBag.ErrorMessage);
            }
           

        }

        
 
       
    }
}