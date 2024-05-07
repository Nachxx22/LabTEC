using LabTecAPI.ModelsDTO;

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
    public async Task<IActionResult> PostOperador([FromBody] OperadorDto dto)
    {
        if (dto == null || string.IsNullOrWhiteSpace(dto.Carnet) || string.IsNullOrWhiteSpace(dto.Correo))
        {
            return BadRequest("Carnet y Correo son campos obligatorios.");
        }

        var nuevoOperador = new Operadore
        {
            Carnet = dto.Carnet,
            Nombre = dto.Nombre,
            Apellido = dto.Apellido,
            FechaNacimiento = !string.IsNullOrEmpty(dto.FechaNacimiento) && DateOnly.TryParse(dto.FechaNacimiento, out var fechaNacParsed) 
                ? fechaNacParsed 
                : null,
            Correo = dto.Correo,
            Contraseña = dto.Contraseña,
            Cedula = dto.Cedula,
            Edad = dto.Edad,
            Aprobado = dto.Aprobado ?? false
        };

        _context.Operadores.Add(nuevoOperador);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // Manejo de errores específicos como violaciones de restricciones de la base de datos
            return BadRequest($"Error al guardar los datos: {ex.Message}");
        }

        return CreatedAtAction(nameof(PostOperador), new { carnet = nuevoOperador.Carnet }, nuevoOperador);
    }
    
    // PUT: api/Operadores/{carnet}
    [HttpPut("{carnet}")]
    public async Task<IActionResult> UpdateOperador(string carnet, [FromBody] OperadorDto operadorUpdated)
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
        if (!string.IsNullOrEmpty(operadorUpdated.FechaNacimiento) && DateOnly.TryParse(operadorUpdated.FechaNacimiento, out var fechaParsed))
            operador.FechaNacimiento = fechaParsed;
        if (operadorUpdated.Cedula != null)
            operador.Cedula = operadorUpdated.Cedula;
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
