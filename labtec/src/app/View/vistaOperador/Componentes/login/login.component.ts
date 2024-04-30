import { Component } from '@angular/core';
import {Router,RouterLink,RouterOutlet} from "@angular/router";
import {MatCard, MatCardContent} from "@angular/material/card";
import {MatInput} from "@angular/material/input";
import {NgIf} from "@angular/common";
import {MatButton} from "@angular/material/button";
import {MatIcon} from "@angular/material/icon";


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterLink, RouterOutlet, MatCardContent, MatInput, NgIf, MatButton, MatIcon, MatCard],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})



export class LoginComponent {//definicion de la clase
  //supongo que aca declaro las variables que necesito para su uso en HTML
  isLogged = true;
  //constructor(private router: Router) {}
  //this.router.navigate(['/logged']);
  constructor(private router: Router) {}//invoco el metodo router
  //es como crear una clase
  //aca hay que meterle los servicios del login por asi decirlo
  verifyLogin(){ //metodo que verifica el login/
    if(this.isLogged){
      //por ahora sin flags
      this.router.navigate(['sidenav']);
    }
  }
  registrarse(){

  }
  /*el codigo del routerlink puede hacerse de 2 maneras, con un constructor o con el boton con routerLink
  * //creo que preferiblemente es mejor asi por temas de conectarse al backend*/

}
