
using Microsoft.AspNetCore.Mvc;
using SistemaLaboral.Models;
using SistemaLaboral.Data;
using Microsoft.EntityFrameworkCore;


namespace SistemaLaboral.Controllers
{
 
    public class EmpleadosController : Controller
    {
        public readonly SistemaContext _context;

        public EmpleadosController(SistemaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(){
            ViewBag.IdEmleado = HttpContext.Session.GetString("IdEmpleado"); //variable de sesion para la vista
            ViewBag.Nombre = HttpContext.Session.GetString("Nombre"); //variable de sesion para la vista

            var salida = await _context.Historial.OrderBy(his => his.Id).LastOrDefaultAsync(his => his.IdEmpleado == Int32.Parse(HttpContext.Session.GetString("IdEmpleado")));
            ViewBag.checkin = salida.FechaIngreso;
            ViewBag.checkout = salida.FechaSalida;

            if(salida != null){
                ViewBag.AllowIn  = true;
            }else{
                ViewBag.AllowIn  = false;

            }

            if(ViewBag.checkout == null){
                 ViewBag.AllowIn  = false;
            }

            return View();
        }
        
        //Vista para listar los empleados
        public async Task<IActionResult> Lista()
        {
            ViewBag.IdEmleado = HttpContext.Session.GetString("IdEmpleado"); //variable de sesion para la vista
            ViewBag.Nombre = HttpContext.Session.GetString("Nombre"); //variable de sesion para la vista

            return View( await _context.Empleados.ToListAsync());
        }

        //Vista para crear empleados
        public IActionResult Create(){
            return View();
        }    

        //accion para registrar empleado    
          public async Task<IActionResult> Register(Empleado empleado)
        {
            empleado.FechaRegistro = DateTime.Now;
           _context.Empleados.Add(empleado);
           await _context.SaveChangesAsync();
           return RedirectToAction("Index");
        }


        public async Task<IActionResult> Eliminar(int id){
            var empleado = await  _context.Empleados.FindAsync(id);

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Empleados");
        }


   
    }
}