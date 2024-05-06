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
    public async Task<IActionResult> PostAveria([FromBody] Averia nuevaAveria)
    {
        _context.Averias.Add(nuevaAveria);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetAllAverias", new { id = nuevaAveria.AveriaId }, nuevaAveria);
    }
}
