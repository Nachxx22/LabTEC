using LabTecAPI.ModelsDTO;

namespace LabTecAPI.Controllers;

using LabTecAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ActivosController : ControllerBase
{
    private readonly LabManagementContext _context;

    public ActivosController(LabManagementContext context)
    {
        _context = context;
    }

    // GET: api/Activos
    [HttpGet]
    public async Task<IActionResult> GetAllActivos()
    {
        var activos = await _context.Activos
            .Select(a => new {
                Placa = a.Placa,
                Tipo = a.Tipo,
                Marca = a.Marca,
                FechaCompra = a.FechaCompra,
                ImagenUrl = a.ImagenUrl,
                Ocupado=a.Ocupado
            })
            .ToListAsync();

        if (activos == null || !activos.Any())
            return NotFound();

        return Ok(activos);
    }
    // GET: api/Activos/{placa}
    [HttpGet("{placa}")]
    public async Task<IActionResult> GetActivoByPlaca(string placa)
    {
        var activo = await _context.Activos
            .Where(a => a.Placa == placa)
            .Select(a => new {
                Placa = a.Placa,
                Tipo = a.Tipo,
                Marca = a.Marca,
                FechaCompra = a.FechaCompra,
                ImagenUrl = a.ImagenUrl,
                Ocupado=a.Ocupado
            })
            .FirstOrDefaultAsync();

        if (activo == null)
            return NotFound($"No se encontró un activo con la placa {placa}.");

        return Ok(activo);
    }

    // POST: api/Activos
    [HttpPost]
    public async Task<IActionResult> PostActivo([FromBody] ActivoDto dto)
    {
        if (!DateTime.TryParse(dto.FechaCompra, out var fechaParsed))
        {
            return BadRequest("Fecha inválida.");
        }
        var nuevoActivo = new Activo
        {
            Placa=dto.Placa,
            Tipo = dto.Marca,
            Marca = dto.Marca,
            FechaCompra =DateOnly.FromDateTime(fechaParsed) ,
            ImagenUrl = dto.ImagenUrl,
            Ocupado =dto.Ocupado ,
        };
        _context.Activos.Add(nuevoActivo);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetAllActivos", new { placa = nuevoActivo.Placa }, nuevoActivo);
    }
    // PUT: api/Activos/{placa}
    [HttpPut("{placa}")]
    public async Task<IActionResult> UpdateActivo(string placa, [FromBody] ActivoDto activoUpdated)
    {
        var activo = await _context.Activos.FindAsync(placa);
        if (activo == null)
        {
            return NotFound($"No se encontró un activo con la placa {placa}.");
        }

        if (activoUpdated.Tipo != null) activo.Tipo = activoUpdated.Tipo;
        if (activoUpdated.Marca != null) activo.Marca = activoUpdated.Marca;
        if (!string.IsNullOrEmpty(activoUpdated.FechaCompra) && DateOnly.TryParse(activoUpdated.FechaCompra, out var fechaCompraParsed))
            activo.FechaCompra = fechaCompraParsed;
        if (activoUpdated.ImagenUrl != null) activo.ImagenUrl = activoUpdated.ImagenUrl;
        if (activoUpdated.Ocupado.HasValue) activo.Ocupado = activoUpdated.Ocupado.Value;

        _context.Activos.Update(activo);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}
