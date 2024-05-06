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
    // PUT: api/Operadores/{carnet}
    [HttpPut("{carnet}")]
    public async Task<IActionResult> UpdateOperador(string carnet, [FromBody] Operadore operadorUpdated)
    {
        var operador = await _context.Operadores.FindAsync(carnet);
        if (operador == null)
        {
            return NotFound($"No se encontró un operador con el carnet {carnet}.");
        }

        // Actualizar propiedades si son proporcionadas
        if (operadorUpdated.Nombre != null)
            operador.Nombre = operadorUpdated.Nombre;
        if (operadorUpdated.Apellido != null)
            operador.Apellido = operadorUpdated.Apellido;
        if (operadorUpdated.FechaNacimiento != null)
            operador.FechaNacimiento = operadorUpdated.FechaNacimiento;
        if (operadorUpdated.Correo != null)
            operador.Correo = operadorUpdated.Correo;
        if (operadorUpdated.Contraseña != null)
            operador.Contraseña = operadorUpdated.Contraseña;

        _context.Operadores.Update(operador);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    // DELETE: api/Operadores/{carnet}
    [HttpDelete("{carnet}")]
    public async Task<IActionResult> DeleteOperador(string carnet)
    {
        var operador = await _context.Operadores.FindAsync(carnet);
        if (operador == null)
        {
            return NotFound($"No se encontró un operador con el carnet {carnet}.");
        }

        // Eliminar relaciones en SesionesOperador
        var sesiones = _context.SesionesOperadors.Where(s => s.Carnet == carnet);
        _context.SesionesOperadors.RemoveRange(sesiones);

        // Eliminar relaciones en Prestamos y Devoluciones si es posible, o manejarlas como null
        var prestamos = _context.Prestamos.Where(p => p.Carnet == carnet);
        _context.Prestamos.RemoveRange(prestamos);

        _context.Operadores.Remove(operador);
        await _context.SaveChangesAsync();
        return NoContent();
    }




}
