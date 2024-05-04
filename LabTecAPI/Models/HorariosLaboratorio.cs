using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LabTecAPI.Models;

public partial class HorariosLaboratorio
{
    [JsonIgnore]
    public int HorarioId { get; set; }

    public string LaboratorioNombre { get; set; } = null!;

    public DateOnly? Fecha { get; set; }

    public TimeOnly? HoraInicio { get; set; }

    public TimeOnly? HoraFin { get; set; }

    public string? CédulaProfesor { get; set; }

    [JsonIgnore]
    public virtual Profesore? CédulaProfesorNavigation { get; set; }

    [JsonIgnore]
    public virtual Laboratorio LaboratorioNombreNavigation { get; set; } = null!;
}
