import { Component } from '@angular/core';
import {Router,RouterLink,RouterOutlet} from "@angular/router";
import {MatCard, MatCardContent} from "@angular/material/card";
import {MatInput} from "@angular/material/input";
import {NgIf} from "@angular/common";
import {MatButton} from "@angular/material/button";
import {MatIcon} from "@angular/material/icon";
import {ComunicationService} from "../../../../Servicios/comunication.service";
import {FormsModule} from "@angular/forms";

export interface loginTemplate{ //class template para obtener datos del Json
  loginExitoso:boolean,
  usuarioId :string
}
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterLink, RouterOutlet, MatCardContent, MatInput, NgIf, MatButton, MatIcon, MatCard, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})



export class LoginComponent {//definicion de la clase
  //supongo que aca declaro las variables que necesito para su uso en HTML
  isLogged = false;
  usuarioTextbox= "";
  contrasenaTextbox="";
  //definicion de la estructura de respuesta:
  datosRecibidos: loginTemplate | null = null;
  //constructor(private router: Router) {}
  //this.router.navigate(['/logged']);
  constructor(private router: Router, private servicio:ComunicationService) {}//invoco el metodo router

  verifyLogin(){ //metodo que verifica el login/
    console.log(this.usuarioTextbox);
    this.servicio.verifyLogin(this.usuarioTextbox,this.contrasenaTextbox).subscribe(
      response => {
        console.log('Datos enviados al servidor:', response);
        this.datosRecibidos = response as loginTemplate;
        console.log('Tipo de dato de datosRecibidos:', typeof this.datosRecibidos);
        console.log('Datos recibidoputo:', this.datosRecibidos);

        console.log('Login exitoso:', this.datosRecibidos?.loginExitoso);
        console.log('Usuario ID:', this.datosRecibidos?.usuarioId);
        if (this.datosRecibidos?.loginExitoso) {
          this.servicio.setUsuarioId(this.datosRecibidos?.usuarioId); //guarda el id del usuario
          //para hacer busquedas por id.
          console.log('Usuario ID:', this.servicio.getUsuarioId());
          this.router.navigate(['sidenav']);
        } else {
          console.log('Usuario incorrecto');
        }
      },
      error => {
        console.error('Error al enviar datos al servidor:', error);

      }
    );
  }

}
