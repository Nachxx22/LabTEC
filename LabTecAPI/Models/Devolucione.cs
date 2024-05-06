using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LabTecAPI.Models;

public partial class Devolucione
{
    [JsonIgnore] //Funciona para que se ignore y no aparezca en el request del POST
    public int DevolucionId { get; set; }

    public int PrestamoId { get; set; }

    public string Carnet { get; set; } = null!;

    public DateOnly? FechaDevolucion { get; set; }

    public TimeOnly? HoraDevolucion { get; set; }

    public string? EstadoFinalDelActivo { get; set; }

    [JsonIgnore] //Funciona para que se ignore y no aparezca en el request del POST
    public virtual ICollection<Averia> Averia { get; set; } = new List<Averia>();

    [JsonIgnore] //Funciona para que se ignore y no aparezca en el request del POST
    public virtual Operadore CarnetNavigation { get; set; } = null!;

    [JsonIgnore] //Funciona para que se ignore y no aparezca en el request del POST
    public virtual Prestamo Prestamo { get; set; } = null!;
}
