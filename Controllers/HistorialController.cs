
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

        public async Task<IActionResult> Index(int pagina = 1)
        {
            
            int id = Int32.Parse(HttpContext.Session.GetString("IdEmpleado")); //variable de sesion para la vista
            ViewBag.Nombre = HttpContext.Session.GetString("Nombre");
            //Listar solo los registros del empleado
            var result = from historial in _context.Historial select historial;
            result = result.Where(his => his.IdEmpleado == id);

            return View(await result.ToListAsync());

        }

        public async Task<IActionResult> RegistrarIngreso()
        {
            var id = Int32.Parse(HttpContext.Session.GetString("IdEmpleado"));

            try
            {
                //objeto de registro
                var historial = new Historial()
                {
                    IdEmpleado = id,
                    FechaIngreso = DateTime.Now

                };

                _context.Historial.Add(historial);
                await _context.SaveChangesAsync();

                TempData["MessageSuccess"] = "Se ha registrado con exito!";
                return RedirectToAction("Index", "Empleados");


            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error" + ex;
                return View(ViewBag.ErrorMessage);
            }


        }

        public async Task<IActionResult> RegistrarSalida()
        {
            var id = Int32.Parse(HttpContext.Session.GetString("IdEmpleado"));

            try
            {
                var historial = await _context.Historial.OrderBy(his => his.Id).LastOrDefaultAsync(his => his.IdEmpleado == id && his.FechaSalida == null);

                historial.FechaSalida = DateTime.Now;
                await _context.SaveChangesAsync();

                TempData["MessageSuccess"] = "Se ha registrado con exito!";
                return RedirectToAction("Index", "Empleados");


            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error" + ex;
                return View(ViewBag.ErrorMessage);
            }


        }

        //Vista de editar observacion 
        public async Task<IActionResult> Editar(int id)
        {
            return View(await _context.Historial.FirstOrDefaultAsync(h => h.Id == id));
        }






    }
}