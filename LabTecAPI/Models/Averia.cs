using System;
using System.Collections.Generic;

namespace LabTecAPI.Models;

public partial class Averia
{
    public int AveriaId { get; set; }

    public int DevolucionId { get; set; }

    public string? Descripcion { get; set; }

    public DateOnly? FechaDeRegistro { get; set; }

    public virtual Devolucione Devolucion { get; set; } = null!;
}
