using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LabTecAPI.Models;

public partial class Activo
{
    public string Placa { get; set; } = null!;

    public string? Tipo { get; set; }

    public string? Marca { get; set; }

    public DateOnly? FechaCompra { get; set; }

    public string? ImagenUrl { get; set; }
    public bool Ocupado { get; set; } = false;

    [JsonIgnore] //Funciona para que se ignore y no aparezca en el request del POST
    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
