using System;
using System.Collections.Generic;

namespace LabTecAPI.Models;

public partial class Activo
{
    public string Placa { get; set; } = null!;

    public string? Tipo { get; set; }

    public string? Marca { get; set; }

    public DateOnly? FechaCompra { get; set; }

    public string? ImagenUrl { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
