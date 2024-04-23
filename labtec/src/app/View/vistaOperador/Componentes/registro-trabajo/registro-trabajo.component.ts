import { Component } from '@angular/core';
import {MatToolbar} from "@angular/material/toolbar";
import {MatTable, MatTableModule} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";
import {FormsModule} from "@angular/forms";
import {RouterLink, RouterOutlet} from "@angular/router";
import {NgIf} from "@angular/common";
import {MatIcon} from "@angular/material/icon";

export interface Registros {
  Fecha: string;
  Ingreso: string;
  Salida: string;
  Horas_trabajadas: number;
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
  ],
  templateUrl: './registro-trabajo.component.html',
  styleUrl: './registro-trabajo.component.css'
})
export class RegistroTrabajoComponent {
  //dataSource: Registros[]=[] ; //con esto se guardan los datos recibidos de la
  //base de datos.
  dataSource: Registros[] = [
    {Fecha: '2024-04-22', Ingreso: '08:00', Salida: '17:00', Horas_trabajadas: 8 }
    // Agrega más objetos de acuerdo a tus datos
  ];
  displayedColumns: string[] = ['Fecha', 'Ingreso','Salida','Horas_trabajadas'];
  //titulos de las columnas
}
