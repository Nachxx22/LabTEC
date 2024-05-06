namespace LabTecAPI.ModelsDTO;

public class OperadorDto
{
    public string? Carnet { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? FechaNacimiento { get; set; }

    public string? Correo { get; set; } = null!;

    public string? Contraseña { get; set; }
    public string? Cedula { get; set; }
    public int? Edad { get; set; }
    public bool? Aprobado { get; set; } = false;
}