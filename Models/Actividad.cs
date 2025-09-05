using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApi.Models
{
    public class Actividad
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Titulo { get; set; }

        [Required, MaxLength(500)]
        public string Descripcion { get; set; }

        [Required, MaxLength(50)]
        public string Prioridad { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaEstimadaFinalizacion { get; set; }

        [Required, MaxLength(50)]
        public string Estado { get; set; }

        // 🔗 Relación con Usuario
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
