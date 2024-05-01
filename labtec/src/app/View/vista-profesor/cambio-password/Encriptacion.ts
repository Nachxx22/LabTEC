import * as CryptoJS from 'crypto-js';

// Generar una nueva contraseña aleatoria
export function generarNuevaContrasena(): string {
  // Código para generar una contraseña aleatoria
  return 'nuevacontrasena123'; 
}

// Función para encriptar una contraseña con MD5
export function encriptarContrasena(contrasena: string): string {
  return CryptoJS.MD5(contrasena).toString();
}

// Generar nueva contraseña aleatoria
const nuevaContrasena = generarNuevaContrasena();

// Encriptar la nueva contraseña
const contrasenaEncriptada = encriptarContrasena(nuevaContrasena);

console.log('Nueva contraseña generada:', nuevaContrasena);
console.log('Contraseña encriptada:', contrasenaEncriptada);

//MuJX9raJ
//ad8674bdb1b858c2aebbdcf281975b75
