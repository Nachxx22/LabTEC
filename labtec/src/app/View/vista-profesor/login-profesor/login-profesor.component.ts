import {Component, OnInit} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login-profesor',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login-profesor.component.html',
  styleUrl: './login-profesor.component.css'
})


export class LoginProfesorComponent implements OnInit {

  typeEmailX: string ="";
  typePasswordX: string = "";

  constructor(private router: Router) { }

  ngOnInit(): void {
  }


  login(): void {
    // Verifica las credenciales
    if (this.typeEmailX === 'admin' && this.typePasswordX === 'admin') {
      // Redirige al usuario al dashboard
      this.router.navigate(['/vistaProfesor']);
    } else {
      // Código para manejar credenciales incorrectas
    }
  }
}
