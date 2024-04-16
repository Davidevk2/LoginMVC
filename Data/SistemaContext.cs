
using Microsoft.EntityFrameworkCore;
using SistemaLaboral.Models;

namespace SistemaLaboral.Data
{
    public class SistemaLaboral : DbContext{

        public SistemaLaboral(DbContextOptions<SistemaLaboral> options) : base(options){


        }

        //Modelos a utilizar
        public DbSet<Historial> Historials { get; set; }
        public DbSet<Empleado> Empleados { get; set; }

    }
}