using System;
using System.Collections.Generic;

namespace LabTecAPI.Models;

public partial class Laboratorio
{
    public string Nombre { get; set; } = null!;

    public int? Capacidad { get; set; }

    public int? Computadoras { get; set; }

    public string? Facilidades { get; set; }

    public virtual ICollection<HorariosLaboratorio> HorariosLaboratorios { get; set; } = new List<HorariosLaboratorio>();
}
