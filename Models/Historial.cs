using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaLaboral.Models
{
    public class Historial
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey ("Empleados")]
        public int IdEmpleado { get; set; }
        public DateTime FechaIngreso {get;}
        public DateTime FechaSalida {get; set;}

        public string? Observaciones {get; set;}

    }
}