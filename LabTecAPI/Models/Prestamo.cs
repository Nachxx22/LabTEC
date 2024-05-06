using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LabTecAPI.Models;

public partial class Prestamo
{
    public int PrestamoId { get; set; }

    public string Placa { get; set; } 

    public string Carnet { get; set; }

    public DateOnly? FechaPrestamo { get; set; }

    public TimeOnly? HoraPrestamo { get; set; }

    public string? CarnetEstudiante { get; set; }
    

    public DateOnly? FechaDeAprobacion { get; set; }

    public string? Cedula { get; set; }
    public bool NecesitaAprobacion { get; set; } = false;
    public bool EstadoAprobacion { get; set; } = false;
    public bool Entregado { get; set; } = false;

    [JsonIgnore] //Funciona para que se ignore y no aparezca en el request del POST
    public virtual Operadore CarnetNavigation { get; set; } = null!;

    [JsonIgnore] //Funciona para que se ignore y no aparezca en el request del POST
    public virtual Profesore? CedulaNavigation { get; set; }

    [JsonIgnore] //Funciona para que se ignore y no aparezca en el request del POST
    public virtual ICollection<Devolucione> Devoluciones { get; set; } = new List<Devolucione>();

    [JsonIgnore] //Funciona para que se ignore y no aparezca en el request del POST
    public virtual Activo PlacaNavigation { get; set; } = null!;
}
