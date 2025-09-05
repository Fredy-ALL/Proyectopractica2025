using System;
using System.Collections.Generic;

namespace todoapi.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Imagen { get; set; }

    public int Status { get; set; }

    public int Tipo { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime CreatedAt1 { get; set; }

    public virtual ICollection<SeguimientoActividade> SeguimientoActividades { get; set; } = new List<SeguimientoActividade>();
}
