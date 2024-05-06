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
    public async Task<IActionResult> PostActivo([FromBody] Activo nuevoActivo)
    {
        _context.Activos.Add(nuevoActivo);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetAllActivos", new { placa = nuevoActivo.Placa }, nuevoActivo);
    }
}
