import {Component, OnInit} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import {ComunicationService} from "../../../auth.service";
@Component({
  selector: 'app-login-profesor',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login-profesor.component.html',
  styleUrl: './login-profesor.component.css'
})


export class LoginProfesorComponent implements OnInit {

  Correo: string ="";
  Contrasena: string = "";


  private apiUrl = 'http://localhost:5276/vistaProfesor'; // URL del backend API

  constructor(private servicio:ComunicationService, private router: Router) {}

  ngOnInit(): void {
  }

  async login_profesor(correo: string, contraseña: string): Promise<void> {
    const data = JSON.stringify({correo, contraseña});
    //console.log(data);

    try {
      const response = await fetch('http://localhost:5276/api/VistaProfesor/loginProfesorPOST', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: data
      });

      if (!response.ok) {
        throw new Error("Algo malo está pasando");
      }

      const InformacionProfesor = await response.text();
      this.servicio.setInformacionProfesor(InformacionProfesor);
      this.router.navigate(['/vistaProfesor']);

    } catch (error) {
      console.error('Error:', error);
      // Manejar el error, mostrar un mensaje al usuario, etc.
    }

  }

}
