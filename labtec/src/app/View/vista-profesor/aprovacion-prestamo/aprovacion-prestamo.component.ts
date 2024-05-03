import { Component } from '@angular/core';
import {
  MatCell,
  MatCellDef,
  MatColumnDef,
  MatHeaderCell,
  MatHeaderRow,
  MatHeaderRowDef,
  MatRow, MatRowDef, MatTable
} from "@angular/material/table";
import {MatFormField, MatLabel} from "@angular/material/form-field";
import {MatOption} from "@angular/material/autocomplete";
import {MatPaginator} from "@angular/material/paginator";
import {MatSelect} from "@angular/material/select";
import {MatToolbar} from "@angular/material/toolbar";
import {NgForOf} from "@angular/common";
import {MatTableModule} from "@angular/material/table";
import {NgFor} from "@angular/common";
import {MatIcon} from "@angular/material/icon";


export interface Platillos { //por ahora esta interfaz queda asi
  Activo: string;
  Solicitante: string;
  Operador: string;
}
const platillos_ver: Platillos[] = [
  { Activo: 'FPGA', Solicitante: 'Pepe', Operador: 'Juan' }];



@Component({
  selector: 'app-aprovacion-prestamo',
  standalone: true,
  imports: [
    MatCell,
    MatTableModule,
    NgFor,
    MatCellDef,
    MatColumnDef,
    MatFormField,
    MatHeaderCell,
    MatHeaderRow,
    MatHeaderRowDef,
    MatLabel,
    MatOption,
    MatPaginator,
    MatRow,
    MatRowDef,
    MatSelect,
    MatTable,
    MatToolbar,
    NgForOf,
    MatIcon
  ],
  templateUrl: './aprovacion-prestamo.component.html',
  styleUrl: './aprovacion-prestamo.component.css'
})
export class AprovacionPrestamoComponent {

  data = [
    { id: 1, componente: 'FPGA', solicitante: 'Andrés', carnet: '2020129522', estado: '' }
    // Agrega más datos aquí si es necesario
  ];

  updateStatus(item: any, status: string) {
    item.estado = status;
  }

}
