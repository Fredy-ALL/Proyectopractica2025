using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ToDoApi.Models;

namespace ToDoApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<SeguimientoActividad> SeguimientoActividades { get; set; }

    }
}