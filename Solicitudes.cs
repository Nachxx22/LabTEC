using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
namespace Tiposdeplatos
{
    
    [ApiController] //define a la clase de abajo como controlador
    //de api aspnetcore
    [Route("labTec")]//define las rutas hacia donde hacer las solicitudes
    //get, set etc, comienzan con esto
    public class solicitudes:ControllerBase{
        [HttpGet]//definición de los metodos httpget
        [Route("getActivos")] //ruta getActivos, obtiene la lista
        //de todos los activos disponibles
        public ActionResult<IEnumerable<activosTemplate>> Get(){//obtiene
        //del servidor
            string filePath = "activos.json";
            string jsonText = System.IO.File.ReadAllText(filePath);//lee todo el archivo
            List<activosTemplate> registros;
            registros = JsonConvert.DeserializeObject<List<activosTemplate>>(jsonText);      
            IEnumerable<activosTemplate> activos = registros;
            return Ok(activos);
            //hay que mandarselo directamente como un json serializado
            //consultar si esto lo manda como string o como json
        }
        [Route("getReportes")]
        //metodo para obtener los reportes del usuario Operador
        public ActionResult <IEnumerable<reporteopTemplate>> getReporte(string username){
            //platilloTemplate json = JsonConvert.DeserializeObject<platilloTemplate>(nombrePlatillos);
            //Console.Write(nuevoplatillo.Tipo);
            string filePath = "reportes.json";
            string jsonText = System.IO.File.ReadAllText(filePath);//lee todo el archivo
            List<reporteopTemplate> reportes = JsonConvert.DeserializeObject<List<reporteopTemplate>>(jsonText);       
            IEnumerable<reporteopTemplate> reportesUsuario = reportes.Where(u => u.usuario == username);
            return Ok(reportesUsuario);
        }
        [HttpPost]//para los post de operadores
        //ruta para verificar el login del usuario.
        [Route("verificarLogin")]
        public ActionResult comprobarLogin([FromBody] loginTemplate nuevoLogin){
            //platilloTemplate json = JsonConvert.DeserializeObject<platilloTemplate>(nombrePlatillos);
            //Console.Write(nuevoplatillo.Tipo);
            string filePath = "login.json";
            string jsonText = System.IO.File.ReadAllText(filePath);//lee todo el archivo
            List<loginTemplate> registros = JsonConvert.DeserializeObject<List<loginTemplate>>(jsonText);
            loginTemplate usuario = registros.FirstOrDefault(u => u.correo ==nuevoLogin.correo); 
            bool valorReturn = verificarCredenciales(usuario,nuevoLogin.contrasena );
            Console.WriteLine("valor del login:",valorReturn);
            return Ok(valorReturn);
        }
        [Route("reservactivoEst")]
        public ActionResult comprobarLogin([FromBody] loginTemplate nuevoLogin){
            //platilloTemplate json = JsonConvert.DeserializeObject<platilloTemplate>(nombrePlatillos);
            //Console.Write(nuevoplatillo.Tipo);
            string filePath = "login.json";
            string jsonText = System.IO.File.ReadAllText(filePath);//lee todo el archivo
            List<loginTemplate> registros = JsonConvert.DeserializeObject<List<loginTemplate>>(jsonText);
            loginTemplate usuario = registros.FirstOrDefault(u => u.correo ==nuevoLogin.correo); 
            bool valorReturn = verificarCredenciales(usuario,nuevoLogin.contrasena );
            Console.WriteLine("valor del login:",valorReturn);
            return Ok(valorReturn);
        }
        public bool verificarCredenciales(loginTemplate usuario ,string password){
            if(usuario != null){//si el usuario existe
                if(usuario.contrasena == password){//si la contraseña es igual retorna 1
                    Console.WriteLine(usuario.contrasena);
                    Console.WriteLine(password);
                    Console.WriteLine("contraseña valida");
                    return true;
                }
                else{//si no es igual, retorna false
                    Console.WriteLine("contraseña erronea");
                    Console.WriteLine(usuario.contrasena);
                    Console.WriteLine(password);
                    return false;// si no , retorna 0
                    
                }
            }
            else{//si no lo encuentra, el usuario no existe
                Console.WriteLine("usuario no existe");
                return false;
            }
        }
       
    }
}