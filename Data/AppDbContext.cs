using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;

namespace ToDoApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Actividad> Actividades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Actividad>()
                .Property(a => a.titulo)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Actividad>()
                .Property(a => a.descripcion)
                .HasMaxLength(500)
                .IsRequired();

            modelBuilder.Entity<Actividad>()
                .Property(a => a.estado)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Actividad>()
                .Property(a => a.Prioridad)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
