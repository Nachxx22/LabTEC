using LabTecAPI.Models;
namespace LabTecAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
[Route("api/[controller]")]
[ApiController]
public class ReportesOperadores : ControllerBase
{
    private readonly LabManagementContext _context;
    //constructor de la clase
    public ReportesOperadores(LabManagementContext context)
    {
        _context = context;
    }
    [HttpGet]//definición de los metodos httpget
    [Route("getReportes")]
    public async Task<IActionResult>obtenerReportes(string idOperador)
    {
        //estructura de devolucion de vuelta:
        
        var listaResultados = new List<object>();
        var usuario = await _context.SesionesOperadors
            .Where(a => a.Carnet == idOperador) //busqueme donde el correo 
            //sea igual al correo pasado,
            .Select(a => new {//hagame el selec y traigame las 
                Fecha = a.Fecha.ToString(),
                Ingreso = a.HoraInicio.ToString(),
                Salida = a.HoraFin.ToString(),
                Horastrabajadas = (int?)EF.Functions.DateDiffHour(a.HoraInicio, a.HoraFin) 
                //horas trabajadas pasa por la funcion DateDiff que me calcula en la bd
            })
            .ToListAsync();
        //si no lo encuentra, o la contraseña es inválida , retorna false
        foreach (var resultado in usuario)
        {
            listaResultados.Add(new
            {
                fecha = resultado.Fecha,
                ingreso = resultado.Ingreso,
                salida = resultado.Salida,
                horasTrabajadas = resultado.Horastrabajadas
            });
        }
        return Ok(listaResultados);//retorn
    }
}