namespace LabTecAPI.ModelsDTO;

public class HorariosLaboratorioDto
{
    public string? LaboratorioNombre { get; set; }
    public string? Fecha { get; set; } // Cambiado a string
    public string? HoraInicio { get; set; } // Cambiado a string
    public string? HoraFin { get; set; } // Cambiado a string
    public string? CédulaProfesor { get; set; }
}

