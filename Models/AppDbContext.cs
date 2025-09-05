using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ToDoApi.Models;
using todoapi.Models;

namespace todoapi.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividad> Actividades { get; set; }

    public virtual DbSet<SeguimientoActividade> SeguimientoActividades { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SQL5113.site4now.net;Database=db_9da898_todoapp;User Id=db_9da898_todoapp_admin;Password=F@20250827*;Encrypt=False;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividad>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Activida__3213E83FFD257937");

            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.fecha_estimada_finalizaciom)
                .HasColumnType("datetime")
                .HasColumnName("fecha_estimada_finalizaciom");
            entity.Property(e => e.fecha_inicio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.Prioridad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("prioridad");
            entity.Property(e => e.titulo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<SeguimientoActividade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Seguimie__3213E83F4E3E2F53");

            entity.ToTable("Seguimiento_Actividades");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Accion)
                .IsUnicode(false)
                .HasColumnName("accion");
            entity.Property(e => e.ActividadId).HasColumnName("actividad_id");
            entity.Property(e => e.FechaHora)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_hora");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Actividad).WithMany(p => p.SeguimientoActividades)
                .HasForeignKey(d => d.ActividadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Seguimien__activ__44FF419A");

            entity.HasOne(d => d.Usuario).WithMany(p => p.SeguimientoActividades)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Seguimien__usuar__45F365D3");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3213E83FC8A456DF");

            entity.HasIndex(e => e.Email, "UQ__Usuarios__AB6E6164E8F6A67E").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__Usuarios__B15BE12EC6D481F8").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedAt1)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CreatedAt");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Imagen)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imagen");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Status)
                .HasDefaultValue(1)
                .HasColumnName("status");
            entity.Property(e => e.Tipo)
                .HasDefaultValue(1)
                .HasColumnName("tipo");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
