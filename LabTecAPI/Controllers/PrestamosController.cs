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
                p.FechaPrestamo,
                p.HoraPrestamo,
                p.CarnetEstudiante,
                p.FechaDeAprobacion,
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
                p.FechaPrestamo,
                p.HoraPrestamo,
                p.CarnetEstudiante,
                p.FechaDeAprobacion,
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
        if (!DateTime.TryParse(dto.FechaDeAprobacion, out var fechaAprobacionParsed))
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
            FechaPrestamo = DateOnly.FromDateTime(fechaPrestamoParsed),
            HoraPrestamo = TimeOnly.FromTimeSpan(horaPrestamoParsed),
            CarnetEstudiante = dto.CarnetEstudiante,
            FechaDeAprobacion = DateOnly.FromDateTime(fechaAprobacionParsed),
            Cedula = dto.Cedula,
            NecesitaAprobacion = dto.NecesitaAprobacion,
            EstadoAprobacion = dto.NecesitaAprobacion,
            Entregado = dto.Entregado
            
        };
        _context.Prestamos.Add(nuevoPrestamo);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetAllPrestamos", new { id = nuevoPrestamo.PrestamoId }, nuevoPrestamo);
    }
}
