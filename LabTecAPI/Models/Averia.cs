using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LabTecAPI.Models;

public partial class Averia
{
    [JsonIgnore] //Funciona para que se ignore y no aparezca en el request del POST
    public int AveriaId { get; set; }

    public int DevolucionId { get; set; }

    public string? Descripcion { get; set; }

    public DateOnly? FechaDeRegistro { get; set; }

    [JsonIgnore] //Funciona para que se ignore y no aparezca en el request del POST
    public virtual Devolucione Devolucion { get; set; } = null!;
}
