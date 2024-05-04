using System;
using System.Collections.Generic;

namespace LabTecAPI.Models;

public partial class Prestamo
{
    public int PrestamoId { get; set; }

    public string Placa { get; set; } = null!;

    public string Carnet { get; set; } = null!;

    public DateOnly? FechaPrestamo { get; set; }

    public TimeOnly? HoraPrestamo { get; set; }

    public string? CarnetEstudiante { get; set; }

    public string? EstadoDelPrestamo { get; set; }

    public DateOnly? FechaDeAprobacion { get; set; }

    public string? Cedula { get; set; }

    public virtual Operadore CarnetNavigation { get; set; } = null!;

    public virtual Profesore? CedulaNavigation { get; set; }

    public virtual ICollection<Devolucione> Devoluciones { get; set; } = new List<Devolucione>();

    public virtual Activo PlacaNavigation { get; set; } = null!;
}
