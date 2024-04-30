import { Component } from '@angular/core';
import {
  MatCell,
  MatCellDef,
  MatColumnDef,
  MatHeaderCell, MatHeaderCellDef,
  MatHeaderRow,
  MatHeaderRowDef,
  MatRow, MatRowDef, MatTable
} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";
import {MatToolbar} from "@angular/material/toolbar";

import {MatButton} from "@angular/material/button";
import {MatDialog, MatDialogConfig} from "@angular/material/dialog";
import {FormActivosComponent} from "../form-activos/form-activos.component";
import {FormDevolucionComponent} from "../form-devolucion/form-devolucion.component";
export interface  devolucion{
  Id:number;
  Nombre:string;
  nombreRegistrado:string;
  apellidoRegistrado: string;
  correo: string;
  fechaSolicitud:string;
}
@Component({
  selector: 'app-devolucion-activos',
  standalone: true,
  imports: [
    MatCell,
    MatCellDef,
    MatColumnDef,
    MatHeaderCell,
    MatHeaderRow,
    MatHeaderRowDef,
    MatPaginator,
    MatRow,
    MatRowDef,
    MatTable,
    MatToolbar,
    MatButton,
    MatHeaderCellDef
  ],
  templateUrl: './devolucion-activos.component.html',
  styleUrl: './devolucion-activos.component.css'
})
export class DevolucionActivosComponent {
  displayedColumns: string[] = ['Id', 'Nombre','nombreRegistrado',
    'apellidoRegistrado','correo' , 'fechaSolicitud' ,'devolver'];
  dataSource: devolucion[] = [
    { Id: 1, Nombre: 'Juan', nombreRegistrado: 'Juan Pérez', apellidoRegistrado: 'Pérez', correo: 'juan@example.com', fechaSolicitud: '2024-04-29' },
    { Id: 2, Nombre: 'María', nombreRegistrado: 'María García', apellidoRegistrado: 'García', correo: 'maria@example.com', fechaSolicitud: '2024-04-30' },
    { Id: 3, Nombre: 'Pedro', nombreRegistrado: 'Pedro López', apellidoRegistrado: 'López', correo: 'pedro@example.com', fechaSolicitud: '2024-05-01' },
  ];
  mostrarForm(indice:number ,  nombre:string){//la i es de un valor para identificar cual boton fue presionado
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '450px';
    dialogConfig.data = {
      idActivo: indice,
      nombreActivo: nombre,
    };
    this.matDialog.open(FormDevolucionComponent,dialogConfig);
    //la linea anterior abre un dialog, que por contenido tendrá lo que haya
    //en formActivosComponent. y el ancho del dialog
  }
  constructor(private matDialog:MatDialog) { //se inyecta matdialog al constructor
  }

}
