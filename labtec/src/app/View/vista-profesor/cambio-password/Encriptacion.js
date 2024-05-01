"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.encriptarContrasena = exports.generarNuevaContrasena = void 0;
var CryptoJS = require("crypto-js");
// Generar una nueva contraseña aleatoria
function generarNuevaContrasena() {
    // Código para generar una contraseña aleatoria
    return 'nuevacontrasena123'; // Aquí reemplaza con tu lógica para generar una contraseña aleatoria
}
exports.generarNuevaContrasena = generarNuevaContrasena;
// Función para encriptar una contraseña con MD5
function encriptarContrasena(contrasena) {
    return CryptoJS.MD5(contrasena).toString();
}
exports.encriptarContrasena = encriptarContrasena;
// Generar nueva contraseña aleatoria
var nuevaContrasena = generarNuevaContrasena();
// Encriptar la nueva contraseña
var contrasenaEncriptada = encriptarContrasena(nuevaContrasena);
console.log('Nueva contraseña generada:', nuevaContrasena);
console.log('Contraseña encriptada:', contrasenaEncriptada);
//MuJX9raJ
//ad8674bdb1b858c2aebbdcf281975b75
