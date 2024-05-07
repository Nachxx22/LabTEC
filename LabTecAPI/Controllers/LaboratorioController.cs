using LabTecAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabTecAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LaboratorioController : ControllerBase
{
    private readonly LabManagementContext _context;

    public LaboratorioController(LabManagementContext context)
    {
        _context = context;
    }

    // GET: api/Laboratorios/{nombre}
    [HttpGet("{nombre}")]
    public async Task<IActionResult> GetLaboratorio(string nombre)
    {
        var laboratorio = await _context.Laboratorios
            .Where(l => l.Nombre == nombre)
            .Select(l => new {
                Nombre = l.Nombre,
                Capacidad = l.Capacidad,
                Computadoras = l.Computadoras,
                Facilidades = l.Facilidades
            })
            .FirstOrDefaultAsync();

        if (laboratorio == null)
            return NotFound($"No se encontró un laboratorio con el nombre {nombre}.");

        return Ok(laboratorio);
    }
    // GET: api/HorariosLaboratorios/Laboratorios
    [HttpGet]
    public async Task<IActionResult> GetLaboratorios()
    {
        var laboratorios = await _context.Laboratorios
            .Select(l => new {
                Nombre = l.Nombre,
                Capacidad = l.Capacidad,
                Computadoras = l.Computadoras,
                Facilidades = l.Facilidades
                // Si decides incluir información básica de horarios, puedes descomentar la siguiente línea
                // Horarios = l.HorariosLaboratorios.Select(h => new { h.Fecha, h.HoraInicio, h.HoraFin, h.CédulaProfesor })
            })
            .ToListAsync();

        if (laboratorios == null || !laboratorios.Any())
            return NotFound("No se encontraron laboratorios.");

        return Ok(laboratorios);
    }

   

    

    // POST: api/Laboratorios
    [HttpPost]
    public async Task<IActionResult> PostLaboratorio([FromBody] Laboratorio nuevoLaboratorio)
    {
        _context.Laboratorios.Add(nuevoLaboratorio);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetLaboratorio), new { nombre = nuevoLaboratorio.Nombre }, nuevoLaboratorio);
    }
    // PUT: api/Laboratorios/{nombre}
    [HttpPut("{nombre}")]
    public async Task<IActionResult> UpdateLaboratorio(string nombre, [FromBody] Laboratorio laboratorioUpdated)
    {
        var laboratorio = await _context.Laboratorios.FindAsync(nombre);
        if (laboratorio == null)
        {
            return NotFound($"No se encontró un laboratorio con el nombre {nombre}.");
        }

        if (laboratorioUpdated.Capacidad.HasValue) laboratorio.Capacidad = laboratorioUpdated.Capacidad.Value;
        if (laboratorioUpdated.Computadoras.HasValue) laboratorio.Computadoras = laboratorioUpdated.Computadoras.Value;
        if (laboratorioUpdated.Facilidades != null) laboratorio.Facilidades = laboratorioUpdated.Facilidades;

        _context.Laboratorios.Update(laboratorio);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    

}
