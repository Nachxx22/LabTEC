using System;
using System.Collections.Generic;

namespace LabTecAPI.Models;

public partial class SesionesOperador
{
    public string Carnet { get; set; } = null!;

    public DateOnly? Fecha { get; set; }

    public TimeOnly? HoraInicio { get; set; }

    public TimeOnly? HoraFin { get; set; }

    public virtual Operadore CarnetNavigation { get; set; } = null!;
}
