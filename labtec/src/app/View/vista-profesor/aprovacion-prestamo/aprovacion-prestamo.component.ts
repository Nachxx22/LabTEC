import {Component, OnInit} from '@angular/core';
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
import {ComunicationService} from "../../../auth.service";




interface InformacionType {
  id: number;
  placa: string;
  fechaPrestamo: string;
  estadoAprobacion: string;
  // Agrega otras propiedades según sea necesario
}



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
export class AprovacionPrestamoComponent implements OnInit {

  Cedula: string = "";
  data: InformacionType[] = [];

  async OrdenaInformacion(Informacion: InformacionType[]) {
    console.log(Informacion.length);
    // @ts-ignore
    this.data = this.data.concat(Informacion);
  }



  async updateStatus(item: any, status: string) {

    if(status == "Aceptado"){

    }
    

    item.estadoAprobacion = status;
    console.log("Este es el id " + item.id);
    console.log("Esta es la placa " + item.placa);
    console.log("Esta es la fecha " + item.fechaPrestamo);


    fetch('http://localhost:5276/api/ActualizarRecurso', {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json' // Tipo de contenido que estás enviando
        // Opcional: otros encabezados según sea necesario
      },
      body: JSON.stringify(this.data) // Datos que deseas enviar en la solicitud PUT
    })
      .then(response => {
        if (!response.ok) {
          throw new Error('Hubo un problema al actualizar el recurso.');
        }
        // Si la respuesta es exitosa, puedes hacer algo aquí si lo deseas
      })
      .catch(error => {
        console.error('Error:', error);
      });

  }

  constructor(private servicio: ComunicationService) {}

  ngOnInit() {
    this.Cedula = this.servicio.getCedulaProfesor();
    this.consultarSolicitudes(this.Cedula);

  }

  async consultarSolicitudes(cedulaProfesor: string): Promise<void> {


    fetch(`http://localhost:5276/api/VistaProfesor/${cedulaProfesor}`, {
      method: 'Get',
    })
      .then(response => response.json())
      .then(data => {

        //console.log(this.Informacion);
        this.OrdenaInformacion(data);
      });


  }



}
