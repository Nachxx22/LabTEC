using LabTecAPI.Models;
using LabTecAPI.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabTecAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DevolucionesController : ControllerBase
{
    private readonly LabManagementContext _context;

    public DevolucionesController(LabManagementContext context)
    {
        _context = context;
    }

    // GET: api/Devoluciones/{devolucionId}
    [HttpGet("{devolucionId}")]
    public async Task<IActionResult> GetDevolucion(int devolucionId)
    {
        var devolucion = await _context.Devoluciones
            .Where(d => d.DevolucionId == devolucionId)
            .Select(d => new {
                DevolucionId = d.DevolucionId,
                PrestamoId = d.PrestamoId,
                Carnet = d.Carnet,
                FechaDevolucion = d.FechaDevolucion,
                HoraDevolucion = d.HoraDevolucion,
                EstadoFinalDelActivo = d.EstadoFinalDelActivo
            })
            .FirstOrDefaultAsync();

        if (devolucion == null)
            return NotFound($"No se encontró una devolución con el ID {devolucionId}.");

        return Ok(devolucion);
    }

    // POST: api/Devoluciones
    [HttpPost]
    public async Task<IActionResult> PostDevolucion([FromBody] DevolucioneDto devolucionDto)
    {
        var nuevaDevolucion = new Devolucione
        {
            PrestamoId = devolucionDto.PrestamoId.GetValueOrDefault(), // Assumed non-nullable in the entity model
            Carnet = devolucionDto.Carnet,
            FechaDevolucion = devolucionDto.FechaDevolucion != null ? DateOnly.Parse(devolucionDto.FechaDevolucion) : null,
            HoraDevolucion = devolucionDto.HoraDevolucion != null ? TimeOnly.Parse(devolucionDto.HoraDevolucion) : null,
            EstadoFinalDelActivo = devolucionDto.EstadoFinalDelActivo
        };

        _context.Devoluciones.Add(nuevaDevolucion);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetDevolucion), new { devolucionId = nuevaDevolucion.DevolucionId }, nuevaDevolucion);
    }
    // PUT: api/Devoluciones/{devolucionId}
    [HttpPut("{devolucionId}")]
    public async Task<IActionResult> UpdateDevolucion(int devolucionId, [FromBody] DevolucioneDto devolucionUpdated)
    {
        var devolucion = await _context.Devoluciones.FindAsync(devolucionId);
        if (devolucion == null)
        {
            return NotFound($"No se encontró una devolución con el ID {devolucionId}.");
        }

        if (devolucionUpdated.PrestamoId.HasValue) devolucion.PrestamoId = devolucionUpdated.PrestamoId.Value;
        if (devolucionUpdated.Carnet != null) devolucion.Carnet = devolucionUpdated.Carnet;
        if (devolucionUpdated.FechaDevolucion != null && DateOnly.TryParse(devolucionUpdated.FechaDevolucion, out var fechaDevolucion))
            devolucion.FechaDevolucion = fechaDevolucion;
        if (devolucionUpdated.HoraDevolucion != null && TimeOnly.TryParse(devolucionUpdated.HoraDevolucion, out var horaDevolucion))
            devolucion.HoraDevolucion = horaDevolucion;
        if (devolucionUpdated.EstadoFinalDelActivo != null) devolucion.EstadoFinalDelActivo = devolucionUpdated.EstadoFinalDelActivo;

        _context.Devoluciones.Update(devolucion);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}
