using System.ComponentModel.DataAnnotations;

namespace LabTecAPI.Models;

public class HorarioLaboratorio
{
    //Ignorar todo esto, el correcto es el HorariosLaboratorio
    public int HorarioID { get; set; }

    [MaxLength(50,ErrorMessage = "El nombre es demasiado largo debe tener menos de 50 caracteres")] //Funciona para limitar la cantidad de caracteres que se guardan/reciben
    public string LaboratorioNombre { get; set; }
    
    public DateTime Fecha { get; set; }
    
    public TimeSpan HoraInicio { get; set; }
    
    public TimeSpan HoraFin { get; set; }
    
    public string CédulaProfesor { get; set; }
    
}