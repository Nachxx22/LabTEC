using LabTecAPI.Models;

namespace LabTecAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
//definiciones del controlador y sus rutas
[Route("api/[controller]")]
[ApiController]
public class LoginadController : ControllerBase
{
    private readonly LabManagementContext _context;
    //constructor de la clase
    public LoginadController(LabManagementContext context)
    {
        _context = context;
    }
    //definiciones de los gets
    [HttpGet]//definición de los metodos httpget 
    [Route("ADverificarLogin")] //get para verificar el login.
    public async Task<IActionResult>verifLogin(string correo, string contrasena )
    {
       
        //estructura de devolucion de vuelta:
        var resultado = new {
            LoginExitoso = false,
        };
        
        var usuario = await _context.Administradores
            .Where(a => a.Correo == correo) //busqueme donde el correo 
            //sea igual al correo pasado,
            .Select(a => new {//hagame el selec y traigame las 
                Contraseña= a.Contraseña,
            })
            .FirstOrDefaultAsync();
        
        //si no lo encuentra, o la contraseña es inválida , retorna false
        if(usuario != null ){
            if (usuario.Contraseña == contrasena)
            {
                resultado = new
                {
                    LoginExitoso = true,
                };
            }
        }
        return Ok(resultado);//return
    }
}