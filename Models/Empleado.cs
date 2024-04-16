

using System.ComponentModel.DataAnnotations;

namespace SistemaLaboral.Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nombres {get; set;}
        public string? Apellidos {get; set;}
        [Required]
        public string? Identificacion {get; set;}
        [Required]
        public string? Correo {get; set;}
        [Required]
        public string? Password {get; set;}
        public DateTime? UltimoIngreso {get; set;}
        public DateTime? FechaRegistro {get; set;}
        
    }
}