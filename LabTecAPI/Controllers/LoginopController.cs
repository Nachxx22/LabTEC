using LabTecAPI.Models;

namespace LabTecAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
//definiciones del controlador y sus rutas
[Route("api/[controller]")]
[ApiController]
public class LoginopController : ControllerBase
{
    private readonly LabManagementContext _context;
    //constructor de la clase
    public LoginopController(LabManagementContext context)
    {
        _context = context;
    }
    //definiciones de los gets
    [HttpGet]//definición de los metodos httpget 
    [Route("verificarLogin")] //get para verificar el login.
    public async Task<IActionResult>verifLogin(string correo, string contrasena )
    {
        Console.Write("todo bien aca");
        //estructura de devolucion de vuelta:
        var resultado = new {
            LoginExitoso = false,
            UsuarioId = ""
        };
        var usuario = await _context.Operadores
            .Where(a => a.Correo == correo) //busqueme donde el correo 
            //sea igual al correo pasado,
            .Select(a => new {//hagame el selec y traigame las 
                Contraseña= a.Contraseña,
                Id = a.Carnet
            })
            .FirstOrDefaultAsync();
        //si no lo encuentra, o la contraseña es inválida , retorna false
        if(usuario != null ){
            if (usuario.Contraseña == contrasena)
            {
                resultado = new
                {
                    LoginExitoso = true,
                    UsuarioId = usuario.Id
                };
            }
        }
        return Ok(resultado);//retorn
    }//RECUERDE CAMBIARLE LA DIRECCION DE LA BASE DE DATOS!!!!!!!!
    [HttpPost]
    [Route("registrarse")]
    public async Task<IActionResult> registrarOp([FromBody] Operadore nuevoOp)
    {
        _context.Operadores.Add(nuevoOp);
        await _context.SaveChangesAsync();
        return Ok();
    }
    
    
}