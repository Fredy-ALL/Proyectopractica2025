using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApi.Models
{
    public class SeguimientoActividad
    {
        [Key]
        public int Id { get; set; }

        // 🔗 Relación con Actividad
        [ForeignKey("Actividad")]
        public int ActividadId { get; set; }
        public Actividad Actividad { get; set; }

        // 🔗 Relación con Usuario
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Required, MaxLength(200)]
        public string Accion { get; set; }

        public DateTime FechaHora { get; set; } = DateTime.Now;
    }
}
