using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ToDoApi.Models;
using todoapi.Models;

namespace todoapi.Models;

public partial class SeguimientoActividade
{
    public int Id { get; set; }

    public int ActividadId { get; set; }

    public int UsuarioId { get; set; }

    public string Accion { get; set; } = null!;

    public DateTime FechaHora { get; set; }

    public string Actividades { get; set; } = null!;


    public virtual Usuario Usuario { get; set; } = null!;
}