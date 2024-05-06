namespace LabTecAPI.ModelsDTO;

public class ProfesoreDto
{
    public string Cédula { get; set; } = null!;

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public int Edad { get; set; }

    public string FechaNacimiento { get; set; }

    public string Correo { get; set; } = null!;

    public string? Contraseña { get; set; }
}