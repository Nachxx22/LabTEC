using System;
using System.Collections.Generic;

namespace LabTecAPI.Models;

public partial class Devolucione
{
    public int DevolucionId { get; set; }

    public int PrestamoId { get; set; }

    public string Carnet { get; set; } = null!;

    public DateOnly? FechaDevolucion { get; set; }

    public TimeOnly? HoraDevolucion { get; set; }

    public string? EstadoFinalDelActivo { get; set; }

    public virtual ICollection<Averia> Averia { get; set; } = new List<Averia>();

    public virtual Operadore CarnetNavigation { get; set; } = null!;

    public virtual Prestamo Prestamo { get; set; } = null!;
}
