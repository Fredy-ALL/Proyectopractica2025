using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; }

        [Required, MaxLength(100)]
        public string Apellido { get; set; }

        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; }

        public string Imagen { get; set; }

        public int Status { get; set; } = 1;

        public int Tipo { get; set; } = 1;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
