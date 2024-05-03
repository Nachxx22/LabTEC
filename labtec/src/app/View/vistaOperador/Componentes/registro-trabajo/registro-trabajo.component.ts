import { Component } from '@angular/core';
import {MatToolbar} from "@angular/material/toolbar";
import {MatTable, MatTableModule} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";
import {FormsModule} from "@angular/forms";
import {RouterLink, RouterOutlet} from "@angular/router";
import {NgIf} from "@angular/common";
import {MatIcon} from "@angular/material/icon";
import {MatButton} from "@angular/material/button";
import {ComunicationService} from "../../../../Servicios/comunication.service";
import {DataSource} from "@angular/cdk/collections";

export interface Registros {
  fecha: string;
  ingreso: string;
  salida: string;
  horasTrabajadas: number,
  usuario:string;
}

@Component({
  selector: 'app-registro-trabajo',
  standalone: true,
  imports: [
    MatToolbar,
    MatTable,
    MatPaginator,
    FormsModule,
    RouterOutlet,//rquerido
    RouterLink,//requerido
    MatTableModule,
    MatToolbar,
    NgIf,
    MatPaginator,
    MatIcon,
    FormsModule,
    MatButton,
  ],
  templateUrl: './registro-trabajo.component.html',
  styleUrl: './registro-trabajo.component.css'
})
export class RegistroTrabajoComponent {

  constructor(private servicio:ComunicationService) {
  }
  dataSource: Registros[] = [];//aca se guardan los datos solicitados del servidor
  //titulos para las columnas;
  displayedColumns: string[] = ['Fecha', 'Ingreso','Salida','Horas_trabajadas'];


  //metodo que obtiene los reportes del usuario.
  obtenerReportes(){
    this.servicio.getReportes("gerardo").subscribe(
      response => {
        console.log('Datos enviados al servidor:', response);
        // Realiza cualquier otra lógica que necesites aquí
        this.dataSource = response;
      },
      error => {
        console.error('Error al enviar datos al servidor:', error);
        // Maneja el error adecuadamente aquí
      }
    );
  }
}
