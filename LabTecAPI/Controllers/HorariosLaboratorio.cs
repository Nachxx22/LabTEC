using LabTecAPI.Models;
using LabTecAPI.ModelsDTO;

namespace LabTecAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class HorariosLaboratoriosController : ControllerBase
{
    private readonly LabManagementContext _context;

    public HorariosLaboratoriosController(LabManagementContext context)
    {
        _context = context;
    }

    // GET: api/HorariosLaboratorios/Lab01F2
    [HttpGet("{laboratorioNombre}")]
    public async Task<IActionResult> GetHorariosByLaboratorio(string laboratorioNombre)
    {
        var horarios = await _context.HorariosLaboratorios
            .Where(h => h.LaboratorioNombre == laboratorioNombre)
            .Select(h => new {
                Fecha = h.Fecha,
                HoraInicio = h.HoraInicio,
                HoraFin = h.HoraFin,
                CédulaProfesor = h.CédulaProfesor
            })
            .ToListAsync();

        if (horarios == null || !horarios.Any())
            return NotFound();

        return Ok(horarios);
    }
    [HttpPost]
    public async Task<IActionResult> PostHorarioLaboratorio([FromBody] HorariosLaboratorioDto dto)
    {
        if (!DateTime.TryParse(dto.Fecha, out var fechaParsed))
        {
            return BadRequest("Fecha inválida.");
        }
        if (!TimeSpan.TryParse(dto.HoraInicio, out var horaInicioParsed))
        {
            return BadRequest("Hora de inicio inválida.");
        }
        if (!TimeSpan.TryParse(dto.HoraFin, out var horaFinParsed))
        {
            return BadRequest("Hora de fin inválida.");
        }

        var nuevoHorario = new HorariosLaboratorio
        {
            LaboratorioNombre = dto.LaboratorioNombre,
            Fecha = DateOnly.FromDateTime(fechaParsed),
            HoraInicio = TimeOnly.FromTimeSpan(horaInicioParsed),
            HoraFin = TimeOnly.FromTimeSpan(horaFinParsed),
            CédulaProfesor = dto.CédulaProfesor
        };

        _context.HorariosLaboratorios.Add(nuevoHorario);  // Añade el nuevo horario al contexto de la base de datos
        await _context.SaveChangesAsync();  // Guarda los cambios en la base de datos

        // Devuelve una respuesta que indica que el horario ha sido creado exitosamente
        // CreatedAtAction devuelve un status code 201 (Created) y además puede devolver un URI al recurso creado si es necesario
        return CreatedAtAction(nameof(GetHorarioLaboratorio), new { id = nuevoHorario.HorarioId }, nuevoHorario);
    }




    [HttpGet("{id}")]
    public async Task<ActionResult<HorariosLaboratorio>> GetHorarioLaboratorio(int id)
    {
        var horario = await _context.HorariosLaboratorios.FindAsync(id);
        if (horario == null)
        {
            return NotFound();
        }
        return horario;
    }
    
}