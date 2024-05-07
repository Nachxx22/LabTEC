using LabTecAPI.ModelsDTO;

namespace LabTecAPI.Controllers;

using LabTecAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PrestamosController : ControllerBase
{
    private readonly LabManagementContext _context;

    public PrestamosController(LabManagementContext context)
    {
        _context = context;
    }

    // GET: api/Prestamos
    [HttpGet]
    public async Task<IActionResult> GetAllPrestamos()
    {
        var prestamos = await _context.Prestamos
            .Select(p => new {
                p.PrestamoId,
                p.Placa,
                p.Carnet,
                p.Nombre,
                p.Apellido,
                p.Correo,
                p.FechaPrestamo,
                p.HoraPrestamo,
                p.Cedula,
                p.NecesitaAprobacion,
                p.EstadoAprobacion,
                p.Entregado
            })
            .ToListAsync();

        if (prestamos == null || !prestamos.Any())
            return NotFound();

        return Ok(prestamos);
    }

    // GET: api/Prestamos/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPrestamoById(int id)
    {
        var prestamo = await _context.Prestamos
            .Where(p => p.PrestamoId == id)
            .Select(p => new {
                p.PrestamoId,
                p.Placa,
                p.Carnet,
                p.Nombre,
                p.Apellido,
                p.Correo,
                p.FechaPrestamo,
                p.HoraPrestamo,
                p.Cedula,
                p.NecesitaAprobacion,
                p.EstadoAprobacion,
                p.Entregado
            })
            .FirstOrDefaultAsync();

        if (prestamo == null)
            return NotFound($"No se encontró un préstamo con el ID {id}.");

        return Ok(prestamo);
    }

    // POST: api/Prestamos
    [HttpPost]
    public async Task<IActionResult> PostPrestamo([FromBody] PrestamoDto dto)
    {
        if (!DateTime.TryParse(dto.FechaPrestamo, out var fechaPrestamoParsed))
        {
            return BadRequest("Fecha inválida.");
        }
        
        if (!TimeSpan.TryParse(dto.HoraPrestamo, out var horaPrestamoParsed))
        {
            return BadRequest("Hora de inicio inválida.");
        }

        var nuevoPrestamo = new Prestamo
        {
            Placa = dto.Placa,
            Carnet = dto.Carnet,
            Nombre = dto.Nombre,
            Apellido = dto.Nombre,
            Correo = dto.Nombre,
            FechaPrestamo = DateOnly.FromDateTime(fechaPrestamoParsed),
            HoraPrestamo = TimeOnly.FromTimeSpan(horaPrestamoParsed),
            Cedula = dto.Cedula,
            NecesitaAprobacion = dto.NecesitaAprobacion,
            EstadoAprobacion = dto.EstadoAprobacion,
            Entregado = dto.Entregado
        };
        _context.Prestamos.Add(nuevoPrestamo);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetAllPrestamos", new { id = nuevoPrestamo.PrestamoId }, nuevoPrestamo);
    }
    // PUT: api/Prestamos/{prestamoId}
    [HttpPut("{prestamoId}")]
    public async Task<IActionResult> UpdatePrestamo(int prestamoId, [FromBody] PrestamoDto prestamoUpdated)
    {
        var prestamo = await _context.Prestamos.FindAsync(prestamoId);
        if (prestamo == null)
        {
            return NotFound($"No se encontró un préstamo con el ID {prestamoId}.");
        }

        // Actualiza campos sólo si se proporcionan en el DTO
        if (prestamoUpdated.Placa != null)
            prestamo.Placa = prestamoUpdated.Placa;
        if (prestamoUpdated.Correo != null)
            prestamo.Correo = prestamoUpdated.Correo;
        if (prestamoUpdated.Nombre != null)
            prestamo.Nombre = prestamoUpdated.Nombre;
        if (prestamoUpdated.Apellido != null)
            prestamo.Apellido = prestamoUpdated.Apellido;
        if (prestamoUpdated.Carnet != null)
            prestamo.Carnet = prestamoUpdated.Carnet;
        if (!string.IsNullOrEmpty(prestamoUpdated.FechaPrestamo) && DateOnly.TryParse(prestamoUpdated.FechaPrestamo, out var fechaPrestamoParsed))
            prestamo.FechaPrestamo = fechaPrestamoParsed;
        if (!string.IsNullOrEmpty(prestamoUpdated.HoraPrestamo) && TimeOnly.TryParse(prestamoUpdated.HoraPrestamo, out var horaPrestamoParsed))
            prestamo.HoraPrestamo = horaPrestamoParsed;
        if (prestamoUpdated.Cedula != null)
            prestamo.Cedula = prestamoUpdated.Cedula;
        if (prestamoUpdated.NecesitaAprobacion.HasValue)
            prestamo.NecesitaAprobacion = prestamoUpdated.NecesitaAprobacion.Value;
        if (prestamoUpdated.EstadoAprobacion.HasValue)
            prestamo.EstadoAprobacion = prestamoUpdated.EstadoAprobacion.Value;
        if (prestamoUpdated.Entregado.HasValue)
            prestamo.Entregado = prestamoUpdated.Entregado.Value;

        _context.Prestamos.Update(prestamo);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}
