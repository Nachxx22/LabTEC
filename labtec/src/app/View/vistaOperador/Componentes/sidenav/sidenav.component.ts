import {Component, OnInit} from '@angular/core';
import {MatDrawer, MatDrawerContainer, MatSidenav} from "@angular/material/sidenav";
import {MatList, MatListItem, MatNavList} from "@angular/material/list";
import {MatButton} from "@angular/material/button";
import {MatIcon} from "@angular/material/icon";
import {MatDrawerContent} from "@angular/material/sidenav";
import {MatButtonModule} from "@angular/material/button";
import { RouterLink, RouterOutlet} from "@angular/router";
import { MatIconModule } from '@angular/material/icon';
import {MatToolbar} from "@angular/material/toolbar";
import {ComunicationService} from "../../../../Servicios/comunication.service";

@Component({
  selector: 'app-sidenav',
  standalone: true,
  imports: [
    MatIconModule,
    MatSidenav,
    MatButtonModule,
    MatDrawer,
    MatList,
    MatDrawerContainer,
    MatNavList,
    MatListItem,
    MatButton,
    MatDrawerContent,
    MatIcon,
    RouterLink,
    MatToolbar,
    RouterOutlet
  ],
  templateUrl: './sidenav.component.html',
  styleUrl: './sidenav.component.css'
})
export class SidenavComponent {
  constructor(private servicio:ComunicationService) {

  }
  fechaActual: string = new Date().toDateString();
  obtenerHoraActual(): string {
    const horaActual: Date = new Date();
    const hora: number = horaActual.getHours();
    const minutos: number = horaActual.getMinutes();
    const segundos: number = horaActual.getSeconds();

    return `${hora}:${minutos}:${segundos}`;
  }
  logout(){
    const datosaRegistrar ={//datos para el backend de login
      Carnet:this.servicio.getUsuarioId(),//int
      Fecha:this.fechaActual,
      HoraInicio:this.obtenerHoraActual(),
      HoraFin:this.obtenerHoraActual(),//edad es int
    }
    this.servicio.logout(datosaRegistrar).subscribe(
      response => {
        console.log('Datos de reserva:', response);

      },
      error => {
        console.error('Error al enviar datos al servidor:', error);

      }
    );
  }

}
