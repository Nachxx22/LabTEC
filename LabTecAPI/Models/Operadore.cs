using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LabTecAPI.Models;

public partial class Operadore
{
    public string Carnet { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string Correo { get; set; } = null!;

    public string? Contraseña { get; set; }
    
    public string? Cedula { get; set; }
    public int? Edad { get; set; }
    public bool? Aprobado { get; set; } = false;

    [JsonIgnore] //Funciona para que se ignore y no aparezca en el request del POST
    public virtual ICollection<Devolucione> Devoluciones { get; set; } = new List<Devolucione>();

    [JsonIgnore] //Funciona para que se ignore y no aparezca en el request del POST
    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
