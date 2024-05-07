namespace LabTecAPI.ModelsDTO;

public class ActivoDto
{
    public string? Placa { get; set; } = null!;

    public string? Tipo { get; set; }

    public string? Marca { get; set; }

    public string? FechaCompra { get; set; }

    public string? ImagenUrl { get; set; }
    public string? Cedula { get; set; }
    public bool? Ocupado { get; set; } = false;
}