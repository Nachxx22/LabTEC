namespace LabTecAPI.ModelsDTO;

public class PrestamoDto
{
    
    public int PrestamoId { get; set; }

    public string? Placa { get; set; } 

    public string? Carnet { get; set; }

    public string? FechaPrestamo { get; set; }

    public string? HoraPrestamo { get; set; }

    public string? CarnetEstudiante { get; set; }
    

    public string? FechaDeAprobacion { get; set; }

    public string? Cedula { get; set; }
    public bool? NecesitaAprobacion { get; set; } = false;
    public bool? EstadoAprobacion { get; set; } = false;
    public bool? Entregado { get; set; } = false;
}