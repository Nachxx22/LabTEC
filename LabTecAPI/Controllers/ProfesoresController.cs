using LabTecAPI.ModelsDTO;

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
    public async Task<IActionResult> PostProfesor([FromBody] ProfesoreDto dto)
    {
        if (!DateTime.TryParse(dto.FechaNacimiento, out var fechaParsed))
        {
            return BadRequest("Fecha inválida.");
        }
        var profesor = new Profesore
        {
            Cédula = dto.Cédula,
            Nombre = dto.Nombre,
            Apellido = dto.Apellido,
            Edad = dto.Edad,
            FechaNacimiento = DateOnly.FromDateTime(fechaParsed),
            Correo = dto.Correo,
            Contraseña = dto.Contraseña
        };
        _context.Profesores.Add(profesor);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetProfesores", new { cedula = profesor.Cédula }, profesor);
    }
    // PUT: api/Profesores/{cédula}
    [HttpPut("{cedula}")]
    public async Task<IActionResult> UpdateProfesor(string cedula, [FromBody] ProfesoreDto profesorUpdated)
    {
        var profesor = await _context.Profesores.FindAsync(cedula);
        if (profesor == null)
        {
            return NotFound($"No se encontró un profesor con la cédula {cedula}.");
        }

        bool dataChanged = false;
        if (profesorUpdated.Nombre != null && profesor.Nombre != profesorUpdated.Nombre)
        {
            profesor.Nombre = profesorUpdated.Nombre;
            dataChanged = true;
        }
        if (profesorUpdated.Apellido != null && profesor.Apellido != profesorUpdated.Apellido)
        {
            profesor.Apellido = profesorUpdated.Apellido;
            dataChanged = true;
        }
        if (profesorUpdated.Edad.HasValue && profesor.Edad != profesorUpdated.Edad)
        {
            profesor.Edad = profesorUpdated.Edad.Value;
            dataChanged = true;
        }
        if (!string.IsNullOrEmpty(profesorUpdated.FechaNacimiento) && DateTime.TryParse(profesorUpdated.FechaNacimiento, out var fechaParsed))
        {
            DateOnly parsedDate = DateOnly.FromDateTime(fechaParsed);
            if (profesor.FechaNacimiento != parsedDate)
            {
                profesor.FechaNacimiento = parsedDate;
                dataChanged = true;
            }
        }
        if (profesorUpdated.Correo != null && profesor.Correo != profesorUpdated.Correo)
        {
            profesor.Correo = profesorUpdated.Correo;
            dataChanged = true;
        }
        if (profesorUpdated.Contraseña != null && profesor.Contraseña != profesorUpdated.Contraseña)
        {
            profesor.Contraseña = profesorUpdated.Contraseña;
            dataChanged = true;
        }

        if (dataChanged)
        {
            _context.Profesores.Update(profesor);
            await _context.SaveChangesAsync();
        }

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
