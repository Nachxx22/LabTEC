import { Component } from '@angular/core';
import {FormsModule} from "@angular/forms";
import {MatButton} from "@angular/material/button";
import {MatCard, MatCardContent} from "@angular/material/card";
import {MatIcon} from "@angular/material/icon";
import {MatInput} from "@angular/material/input";
import {Router, RouterLink} from "@angular/router";
import {ComunicationService} from "../../../../Servicios/comunication.service";

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    FormsModule,
    MatButton,
    MatCard,
    MatCardContent,
    MatIcon,
    MatInput,
    RouterLink
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  //constructor de la clase, se le inyecta los comunication services
  constructor(private router: Router,private servicio:ComunicationService) {
  }
  //variables para los input o textbox del componente , aca se reciben
  //lo que el usuario ingrese
  cedulaTextbox= "";
  carnetTextbox="";
  nombreTextbox= "";
  apellidoTextbox="";
  edadTextbox= "";
  fenacimientoTextbox="";
  correoTextbox="";
  passwordTextbox= "";
  registrarUsuario() {
    //json de datos de registro para enviar al backend
    const datosaRegistrar ={//datos para el backend de login
      cedula:this.cedulaTextbox,//int
      carnet:this.carnetTextbox,//int
      nombre:this.nombreTextbox,
      apellido:this.apellidoTextbox,
      edad:this.edadTextbox,//edad es int
      fechaNacimiento:this.fenacimientoTextbox,//string por el momento
      correo:this.correoTextbox,//string
      contrasena:this.passwordTextbox//string
      //posible cambio a futuro.
    }
    //metodo que llama al comunication service y envia los datos:
    this.servicio.registrarse(datosaRegistrar).subscribe(
      response => {
        console.log('respuesta del servidor:', response);
      },
      error => {
        console.error('Error al enviar datos al servidor:', error);
      }
    );

  }
  volverLogin(){
    this.router.navigate(['login']);
  }


}
