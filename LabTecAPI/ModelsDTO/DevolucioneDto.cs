namespace LabTecAPI.ModelsDTO;

public class DevolucioneDto
{

    public int PrestamoId { get; set; }

    public string Carnet { get; set; } = null!;

    public string FechaDevolucion { get; set; }

    public string HoraDevolucion { get; set; }

    public string EstadoFinalDelActivo { get; set; }
}