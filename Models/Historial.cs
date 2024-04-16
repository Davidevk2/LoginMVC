using System.ComponentModel.DataAnnotations;

namespace SistemaLaboral.Models
{
    public class Historial
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaIngreso {get; set;}
        public DateTime FechaSalida {get; set;}

        public string? Observaciones {get; set;}

    }
}