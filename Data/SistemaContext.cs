
using Microsoft.EntityFrameworkCore;
using SistemaLaboral.Models;

namespace SistemaLaboral.Data
{
    public class SistemaContext : DbContext{

        public SistemaContext(DbContextOptions<SistemaContext> options) : base(options){


        }

        //Modelos a utilizar
        public DbSet<Historial> Historial { get; set; }
        public DbSet<Empleado> Empleados { get; set; }

    }
}