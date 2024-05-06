using LabTecAPI.ModelsDTO;

namespace LabTecAPI.Controllers;

using LabTecAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class SesionesOperadorController : ControllerBase
{
    private readonly LabManagementContext _context;

    public SesionesOperadorController(LabManagementContext context)
    {
        _context = context;
    }

    // GET: api/SesionesOperador
    [HttpGet]
    public async Task<IActionResult> GetAllSesionesOperador()
    {
        var sesiones = await _context.SesionesOperadors
            .Select(s => new {
                s.Carnet,
                s.Fecha,
                s.HoraInicio,
                s.HoraFin
            })
            .ToListAsync();

        if (sesiones == null || !sesiones.Any())
            return NotFound();

        return Ok(sesiones);
    }

    // GET: api/SesionesOperador/{carnet}
    [HttpGet("{carnet}")]
    public async Task<IActionResult> GetSesionByCarnet(string carnet)
    {
        var sesion = await _context.SesionesOperadors
            .Where(s => s.Carnet == carnet)
            .Select(s => new {
                s.Carnet,
                s.Fecha,
                s.HoraInicio,
                s.HoraFin
            })
            .FirstOrDefaultAsync();

        if (sesion == null)
            return NotFound($"No se encontró una sesión con el carnet {carnet}.");

        return Ok(sesion);
    }

    // POST: api/SesionesOperador
    [HttpPost]
    public async Task<IActionResult> PostSesionOperador([FromBody] SesionesOperadorDto dto)
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

        var nuevaSesion = new SesionesOperador
        {
            Carnet = dto.Carnet,
            Fecha = DateOnly.FromDateTime(fechaParsed),
            HoraInicio = TimeOnly.FromTimeSpan(horaInicioParsed),
            HoraFin = TimeOnly.FromTimeSpan(horaFinParsed),
        };
        _context.SesionesOperadors.Add(nuevaSesion);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetAllSesionesOperador", new { carnet = nuevaSesion.Carnet }, nuevaSesion);
    }
}
