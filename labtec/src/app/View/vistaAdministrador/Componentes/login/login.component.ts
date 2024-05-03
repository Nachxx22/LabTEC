import { Component } from '@angular/core';
import {Router,RouterLink,RouterOutlet} from "@angular/router";


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterLink,RouterOutlet],
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
  /*el codigo del routerlink puede hacerse de 2 maneras, con un constructor o con el boton con routerLink
  * //creo que preferiblemente es mejor asi por temas de conectarse al backend*/

}
