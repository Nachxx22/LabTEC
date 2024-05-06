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
        return Ok();
    }
    // PUT: api/HorariosLaboratorio/{horarioId}
    [HttpPut("{horarioId}")]
    public async Task<IActionResult> UpdateHorarioLaboratorio(int horarioId, [FromBody] HorariosLaboratorioDto horarioUpdated)
    {
        var horario = await _context.HorariosLaboratorios.FindAsync(horarioId);
        if (horario == null)
        {
            return NotFound($"No se encontró un horario con el ID {horarioId}.");
        }

        if (horarioUpdated.LaboratorioNombre != null)
            horario.LaboratorioNombre = horarioUpdated.LaboratorioNombre;
        if (!string.IsNullOrEmpty(horarioUpdated.Fecha) && DateOnly.TryParse(horarioUpdated.Fecha, out var fechaParsed))
            horario.Fecha = fechaParsed;
        if (!string.IsNullOrEmpty(horarioUpdated.HoraInicio) && TimeOnly.TryParse(horarioUpdated.HoraInicio, out var horaInicioParsed))
            horario.HoraInicio = horaInicioParsed;
        if (!string.IsNullOrEmpty(horarioUpdated.HoraFin) && TimeOnly.TryParse(horarioUpdated.HoraFin, out var horaFinParsed))
            horario.HoraFin = horaFinParsed;
        if (horarioUpdated.CédulaProfesor != null)
            horario.CédulaProfesor = horarioUpdated.CédulaProfesor;

        _context.HorariosLaboratorios.Update(horario);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    
    //Request Adicionales
    // GET: api/HorariosLaboratorios/cedulaProfesor
    [HttpGet("Horarios/{cedula}")]
    public async Task<IActionResult> GetHorariosByProfesor(string cedula)
    {
        var horarios = await _context.HorariosLaboratorios
            .Where(h => h.CédulaProfesor == cedula)
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
    // GET: api/HorariosLaboratorios/Horarios
    [HttpGet("Horarios")]
    public async Task<IActionResult> GetHorarios()
    {
        var operadores = await _context.HorariosLaboratorios
            .Select(o => new {
                Horarioid=o.HorarioId,
                Fecha = o.Fecha,
                HoraInicio = o.HoraInicio,
                HoraFin = o.HoraFin,
                CédulaProfesor = o.CédulaProfesor
            })
            .ToListAsync();

        if (operadores == null || !operadores.Any())
            return NotFound();

        return Ok(operadores);
    }
    
}