using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToDoApi.Models
{
    public class Actividades
    {
        [Key]
        public int id { get; set; }

        [Required, MaxLength(150)]
        public string titulo { get; set; }

        [Required, MaxLength(500)]
        public string descripcion { get; set; }

        [Required, MaxLength(50)]
        public string Prioridad { get; set; } // 'alta', 'media', 'baja'

        [Required]
        public DateTime fecha_inicio { get; set; }

        [Required]
        public DateTime fecha_estimada_finalizaciom { get; set; }

        [Required, MaxLength(50)]
        public string estado { get; set; } // 'pendiente', 'en progreso', 'completada', 'cancelada'
    }
}

