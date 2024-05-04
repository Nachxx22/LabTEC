using System;
using System.Collections.Generic;

namespace LabTecAPI.Models;

public partial class Operadore
{
    public string Carnet { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string Correo { get; set; } = null!;

    public string? Contraseña { get; set; }

    public virtual ICollection<Devolucione> Devoluciones { get; set; } = new List<Devolucione>();

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
