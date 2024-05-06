using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LabTecAPI.Models;

public partial class Laboratorio
{
    public string Nombre { get; set; } = null!;

    public int? Capacidad { get; set; }

    public int? Computadoras { get; set; }

    public string? Facilidades { get; set; }

    [JsonIgnore] //Funciona para que se ignore y no aparezca en el request del POST
    public virtual ICollection<HorariosLaboratorio> HorariosLaboratorios { get; set; } = new List<HorariosLaboratorio>();
}
