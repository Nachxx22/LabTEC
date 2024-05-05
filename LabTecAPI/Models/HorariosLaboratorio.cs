using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LabTecAPI.Models;

public partial class HorariosLaboratorio
{
    [JsonIgnore] //Funciona para que se ignore y no aparezca en el request del POST
    public int HorarioId { get; set; }

    public string LaboratorioNombre { get; set; } = null!;

    public DateOnly? Fecha { get; set; }

    public TimeOnly? HoraInicio { get; set; }

    public TimeOnly? HoraFin { get; set; }

    public string? CédulaProfesor { get; set; }

    [JsonIgnore] //Funciona para que se ignore y no aparezca en el request del POST
    public virtual Profesore? CédulaProfesorNavigation { get; set; }

    [JsonIgnore] //Funciona para que se ignore y no aparezca en el request del POST
    public virtual Laboratorio LaboratorioNombreNavigation { get; set; } = null!;
}
