namespace LabTecAPI.Controllers;

using LabTecAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ProfesoresController : ControllerBase
{
    private readonly LabManagementContext _context;

    public ProfesoresController(LabManagementContext context)
    {
        _context = context;
    }

    // GET: api/Profesores
    [HttpGet]
    public async Task<IActionResult> GetProfesores()
    {
        var profesores = await _context.Profesores
            .Select(p => new {
                Cédula = p.Cédula,
                Contraseña = p.Contraseña
            })
            .ToListAsync();

        if (profesores == null || !profesores.Any())
            return NotFound();

        return Ok(profesores);
    }
    // GET: api/Profesores/{cédula}
    [HttpGet("{cedula}")]
    public async Task<IActionResult> GetProfesorByCedula(string cedula)
    {
        var profesor = await _context.Profesores
            .Where(p => p.Cédula == cedula)
            .Select(p => new {
                Cédula = p.Cédula,
                Contraseña = p.Contraseña
            })
            .FirstOrDefaultAsync();

        if (profesor == null)
            return NotFound($"No se encontró un profesor con la cédula {cedula}.");

        return Ok(profesor);
    }

    // POST: api/Profesores
    [HttpPost]
    public async Task<IActionResult> PostProfesor([FromBody] Profesore profesor)
    {
        _context.Profesores.Add(profesor);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetProfesores", new { cedula = profesor.Cédula }, profesor);
    }
}
