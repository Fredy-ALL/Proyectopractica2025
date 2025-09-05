using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Models
{
    public class ActividadDto
    {
        [Required, MaxLength(255)]
        public string Titulo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        [RegularExpression("alta|media|baja")]
        public string Prioridad { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaEstimadaFinalizacion { get; set; }

        [Required]
        [RegularExpression("pendiente|en progreso|completada|cancelada")]
        public string Estado { get; set; }

        [Required]
        public int UsuarioId { get; set; }
    }
}
