using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LabTecAPI.Models;

public partial class Profesore
{
    public string Cédula { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Edad { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string Correo { get; set; } = null!;

    public string? Contraseña { get; set; }

    [JsonIgnore] //Funciona para que se ignore y no aparezca en el request del POST
    public virtual ICollection<HorariosLaboratorio> HorariosLaboratorios { get; set; } = new List<HorariosLaboratorio>();

    [JsonIgnore] //Funciona para que se ignore y no aparezca en el request del POST
    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
