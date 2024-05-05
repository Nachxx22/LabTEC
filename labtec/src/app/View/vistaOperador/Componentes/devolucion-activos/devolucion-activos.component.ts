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
import {ComunicationService} from "../../../../Servicios/comunication.service";
export interface  devolucion{
  id:number;
  nombre:string;
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
    { id: 1, nombre: 'Juan', nombreRegistrado: 'Juan Pérez', apellidoRegistrado: 'Pérez', correo: 'juan@example.com', fechaSolicitud: '2024-04-29' },
    { id: 2, nombre: 'María', nombreRegistrado: 'María García', apellidoRegistrado: 'García', correo: 'maria@example.com', fechaSolicitud: '2024-04-30' },
    { id: 3, nombre: 'Pedro', nombreRegistrado: 'Pedro López', apellidoRegistrado: 'López', correo: 'pedro@example.com', fechaSolicitud: '2024-05-01' },
  ];
  mostrarForm(indice:number ,  nombre:string ,correito:string){//la i es de un valor para identificar cual boton fue presionado
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '450px';
    dialogConfig.data = {
      idActivo: indice,
      nombreActivo: nombre,
      correo:correito
      //aca falta pasarle la contraseña para que se mande el id del operador.
    };
    this.matDialog.open(FormDevolucionComponent,dialogConfig);
    //la linea anterior abre un dialog, que por contenido tendrá lo que haya
    //en formActivosComponent. y el ancho del dialog
  }
  //constructor de la clase
  constructor(private servicio:ComunicationService,private matDialog:MatDialog) { //se inyecta matdialog al constructor
  }
  //metodo que solicita los activos disponibles del usuario en la bd
  mostrarActivos(){
    //este get se le manda el username o id del operador para traer los datos de la
    //bd
    this.servicio.getaprobarSolicitud("hola").subscribe(
      response => {
        console.log('Datos enviados al servidor:', response);

        this.dataSource = response; //iguala el datasource a la respuesta
        //recibida del servidor.
      },
      error => {
        console.error('Error al enviar datos al servidor:', error);
        // Maneja el error adecuadamente aquí
      }
    );
  }

}
