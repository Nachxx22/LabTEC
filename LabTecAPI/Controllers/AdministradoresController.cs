namespace LabTecAPI.Controllers;

using LabTecAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AdministradoresController : ControllerBase
{
    private readonly LabManagementContext _context;

    public AdministradoresController(LabManagementContext context)
    {
        _context = context;
    }

    // GET: api/Administradores
    [HttpGet]
    public async Task<IActionResult> GetAdministradores()
    {
        var administradores = await _context.Administradores
            .Select(a => new {
                Correo = a.Correo,
                Contraseña = a.Contraseña
            })
            .ToListAsync();

        if (administradores == null || !administradores.Any())
            return NotFound();

        return Ok(administradores);
    }
    // GET: api/Administradores/{correo}
    [HttpGet("{correo}")]
    public async Task<IActionResult> GetAdministradorByCorreo(string correo)
    {
        var administrador = await _context.Administradores
            .Where(a => a.Correo == correo)
            .Select(a => new {
                Correo = a.Correo,
                Contraseña = a.Contraseña
            })
            .FirstOrDefaultAsync();

        if (administrador == null)
            return NotFound($"No se encontró un administrador con el correo {correo}.");

        return Ok(administrador);
    }

    // POST: api/Administradores
    [HttpPost]
    public async Task<IActionResult> PostAdministrador([FromBody] Administradore administrador)
    {
        _context.Administradores.Add(administrador);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetAdministradores", new { correo = administrador.Correo }, administrador);
    }
}
