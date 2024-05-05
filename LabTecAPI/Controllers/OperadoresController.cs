namespace LabTecAPI.Controllers;

using LabTecAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class OperadoresController : ControllerBase
{
    private readonly LabManagementContext _context;

    public OperadoresController(LabManagementContext context)
    {
        _context = context;
    }

    // GET: api/Operadores
    [HttpGet]
    public async Task<IActionResult> GetOperadores()
    {
        var operadores = await _context.Operadores
            .Select(o => new {
                Carnet = o.Carnet,
                Contraseña = o.Contraseña
            })
            .ToListAsync();

        if (operadores == null || !operadores.Any())
            return NotFound();

        return Ok(operadores);
    }
    // GET: api/Operadores/{carnet}
    [HttpGet("{carnet}")]
    public async Task<IActionResult> GetOperadorByCarnet(string carnet)
    {
        var operador = await _context.Operadores
            .Where(o => o.Carnet == carnet)
            .Select(o => new {
                Carnet = o.Carnet,
                Contraseña = o.Contraseña
            })
            .FirstOrDefaultAsync();

        if (operador == null)
            return NotFound($"No se encontró un operador con el carnet {carnet}.");

        return Ok(operador);
    }

    // POST: api/Operadores
    [HttpPost]
    public async Task<IActionResult> PostOperador([FromBody] Operadore operador)
    {
        _context.Operadores.Add(operador);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetOperadores", new { carnet = operador.Carnet }, operador);
    }
}
