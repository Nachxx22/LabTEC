using System.Text.Json.Serialization;

namespace LabTecAPI.ModelsDTO;

public class PrestamoDto
{
    [JsonIgnore] //Funciona para que se ignore y no aparezca en el request del POST
    public int PrestamoId { get; set; }

    public string? Placa { get; set; } 
    
    
    //carnet del operador , se genera para aprobar el prestamo.

    public string? Carnet { get; set; }

    public string? FechaPrestamo { get; set; }

    public string? HoraPrestamo { get; set; }
    
    [JsonIgnore]
    public string? CarnetEstudiante { get; set; } //ELIMINAR
    //añadido de las 3 variables faltantes
    
    public string? Nombre { get; set; }
    
    public string? Apellidos { get; set; }
    
    public string? Correo { get; set; }
    //fecha de aprobación del profesor.lo hace la vista Profesor
    public string? FechaDeAprobacion { get; set; } //ELIMINAR
    //para saber que profesor lo aprueba
    
    //cedula de quien lo aprueba 
    public string? Cedula { get; set; } //CONSERVAR
    public bool? NecesitaAprobacion { get; set; } = false;
    
    //si es true o false ocupa la cedula o no.
    public bool? EstadoAprobacion { get; set; } = false;
    
    //esto lo aprueba el operador.
    public bool? Entregado { get; set; } = false;
}