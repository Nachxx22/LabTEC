const crypto = require('crypto');

// Función para generar un password aleatorio
function generarPasswordAleatorio(length) {
  const caracteres = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
  let password = '';
  for (let i = 0; i < length; i++) {
    const indice = Math.floor(Math.random() * caracteres.length);
    password += caracteres.charAt(indice);
  }
  return password;
}

// Función para encriptar un password utilizando MD5
function encriptarPasswordMD5(password) {
  const hash = crypto.createHash('md5');
  hash.update(password);
  return hash.digest('hex');
}

// Generar un password aleatorio de longitud 8
const nuevoPassword = generarPasswordAleatorio(8);

// Encriptar el password utilizando MD5
const passwordEncriptado = encriptarPasswordMD5(nuevoPassword);

console.log('Nuevo password generado:', nuevoPassword);
console.log('Password encriptado:', passwordEncriptado);
