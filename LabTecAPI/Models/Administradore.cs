using System;
using System.Collections.Generic;

namespace LabTecAPI.Models;

public partial class Administradore
{
    public string Correo { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Contraseña { get; set; }
}
