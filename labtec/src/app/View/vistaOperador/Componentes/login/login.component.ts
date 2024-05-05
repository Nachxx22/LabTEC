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
  correo:string;
  contrasena:string;
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
  //constructor(private router: Router) {}
  //this.router.navigate(['/logged']);
  constructor(private router: Router, private servicio:ComunicationService) {}//invoco el metodo router
  //es como crear una clase
  //aca hay que meterle los servicios del login por asi decirlo
  verifyLogin(){ //metodo que verifica el login/
    const datosLogin ={//datos para el backend de login
      correo:this.usuarioTextbox,
      contrasena:this.contrasenaTextbox
    }
    console.log(datosLogin.contrasena);
    this.servicio.verifyLogin(datosLogin).subscribe(
      response => {
        console.log('Datos enviados al servidor:', response);
        this.isLogged = response;
        if (this.isLogged) {
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
  registrarse(){
    this.router.navigate(['register']);
  }
  /*el codigo del routerlink puede hacerse de 2 maneras, con un constructor o con el boton con routerLink
  * //creo que preferiblemente es mejor asi por temas de conectarse al backend*/

}
