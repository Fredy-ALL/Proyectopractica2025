using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Models
{
    public class Actividad
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Titulo { get; set; }

        [Required, MaxLength(500)]
        public string Descripcion { get; set; }

        public string Prioridad { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaEstimadaFinalizacion { get; set; }
        public string Estado { get; set; }

        // Solo el Id del usuario
        [Required]
        public int UsuarioId { get; set; }

        // Referencia al usuario, opcional
        public Usuario Usuario { get; set; }
    }
}
