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
    // PUT: api/Profesores/{cédula}
    [HttpPut("{cedula}")]
    public async Task<IActionResult> UpdateProfesor(string cedula, [FromBody] Profesore profesorUpdated)
    {
        var profesor = await _context.Profesores.FindAsync(cedula);
        if (profesor == null)
        {
            return NotFound($"No se encontró un profesor con la cédula {cedula}.");
        }

        // Actualizar propiedades si son proporcionadas
        if (profesorUpdated.Nombre != null)
            profesor.Nombre = profesorUpdated.Nombre;
        if (profesorUpdated.Apellido != null)
            profesor.Apellido = profesorUpdated.Apellido;
        if (profesorUpdated.Edad != null)
            profesor.Edad = profesorUpdated.Edad;
        if (profesorUpdated.FechaNacimiento != null)
            profesor.FechaNacimiento = profesorUpdated.FechaNacimiento;
        if (profesorUpdated.Correo != null)
            profesor.Correo = profesorUpdated.Correo;
        if (profesorUpdated.Contraseña != null)
            profesor.Contraseña = profesorUpdated.Contraseña;

        _context.Profesores.Update(profesor);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    // DELETE: api/Profesores/{cédula}
    [HttpDelete("{cedula}")]
    public async Task<IActionResult> DeleteProfesor(string cedula)
    {
        var profesor = await _context.Profesores.FindAsync(cedula);
        if (profesor == null)
        {
            return NotFound($"No se encontró un profesor con la cédula {cedula}.");
        }

        // Eliminar relaciones en HorariosLaboratorios
        var horarios = _context.HorariosLaboratorios.Where(h => h.CédulaProfesor == cedula);
        _context.HorariosLaboratorios.RemoveRange(horarios);

        // Eliminar relaciones en Prestamos si es posible, o manejarlas como null
        var prestamos = _context.Prestamos.Where(p => p.Cedula == cedula);
        _context.Prestamos.RemoveRange(prestamos);

        _context.Profesores.Remove(profesor);
        await _context.SaveChangesAsync();
        return NoContent();
    }



}
