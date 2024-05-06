using LabTecAPI.ModelsDTO;

namespace LabTecAPI.Controllers;

using LabTecAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AveriasController : ControllerBase
{
    private readonly LabManagementContext _context;

    public AveriasController(LabManagementContext context)
    {
        _context = context;
    }

    // GET: api/Averias
    [HttpGet]
    public async Task<IActionResult> GetAllAverias()
    {
        var averias = await _context.Averias
            .Select(a => new {
                a.AveriaId,
                a.DevolucionId,
                a.Descripcion,
                a.FechaDeRegistro
            })
            .ToListAsync();

        if (averias == null || !averias.Any())
            return NotFound();

        return Ok(averias);
    }

    // GET: api/Averias/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAveriaById(int id)
    {
        var averia = await _context.Averias
            .Where(a => a.AveriaId == id)
            .Select(a => new {
                a.AveriaId,
                a.DevolucionId,
                a.Descripcion,
                a.FechaDeRegistro
            })
            .FirstOrDefaultAsync();

        if (averia == null)
            return NotFound($"No se encontró una avería con el ID {id}.");

        return Ok(averia);
    }

    // POST: api/Averias
    [HttpPost]
    public async Task<IActionResult> PostAveria([FromBody] AveriaDto dto)
    {
        if (!DateTime.TryParse(dto.FechaDeRegistro, out var fechaParsed))
        {
            return BadRequest("Fecha inválida.");
        }

        var nuevaAveria = new Averia
        {
            DevolucionId = dto.DevolucionId,
            Descripcion = dto.Descripcion,
            FechaDeRegistro =DateOnly.FromDateTime(fechaParsed)
        };
        _context.Averias.Add(nuevaAveria);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetAllAverias", new { id = nuevaAveria.AveriaId }, nuevaAveria);
    }
    // PUT: api/Averias/{averiaId}
    [HttpPut("{averiaId}")]
    public async Task<IActionResult> UpdateAveria(int averiaId, [FromBody] AveriaDto averiaUpdated)
    {
        var averia = await _context.Averias.FindAsync(averiaId);
        if (averia == null)
        {
            return NotFound($"No se encontró una avería con el ID {averiaId}.");
        }

        // Actualiza el campo DevolucionId solo si se proporciona en el DTO
        if (averiaUpdated.DevolucionId.HasValue)
            averia.DevolucionId = averiaUpdated.DevolucionId.Value;

        // Actualiza la descripción solo si se proporciona en el DTO
        if (averiaUpdated.Descripcion != null)
            averia.Descripcion = averiaUpdated.Descripcion;

        // Convierte y actualiza la fecha de registro solo si se proporciona en el DTO
        if (!string.IsNullOrEmpty(averiaUpdated.FechaDeRegistro) && DateOnly.TryParse(averiaUpdated.FechaDeRegistro, out var fechaParsed))
            averia.FechaDeRegistro = fechaParsed;

        _context.Averias.Update(averia);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}
