import { Component } from '@angular/core';
import {NgFor} from "@angular/common";
import {NgIf} from "@angular/common";
import {MatCard, MatCardContent} from "@angular/material/card";
import {MatIcon} from "@angular/material/icon";
import {MatDialog, MatDialogConfig} from "@angular/material/dialog";
import {FormActivosComponent} from "../form-activos/form-activos.component";
import {MatButton} from "@angular/material/button";
import {MatToolbar} from "@angular/material/toolbar";
import {ComunicationService} from "../../../../Servicios/comunication.service";

export interface Activo { //creo una interfaz que se puede exportar,
  //con esto leo todos los elementos que existen en
  id: number; //el id
  name: string;//el nombre
  description: string; //la descripción
  imageURL: string; // Propiedad para almacenar la URL de la imagen del equipo
}
@Component({
  selector: 'app-vista-activos',
  standalone: true,
    imports: [
        NgFor, NgIf, MatCard, MatCardContent, MatIcon, MatButton, MatToolbar
    ],
  templateUrl: './vista-activos.component.html',
  styleUrl: './vista-activos.component.css'
})
export class VistaActivosComponent {
  activosRecibidos: Activo[] = [ //lista que se conecta a la bd, para recibir.
    {
    id: 1,
    name: 'Arduino',
    description: 'Uno,R3,Leonardo',
    imageURL: 'https://www.arduino.cc/en/uploads/Main/ArduinoUnoSMDFront.jpg'},
    {
      id: 2,
      name: 'FPGA',
      description: 'DE1-SOC',
      imageURL: 'https://th.bing.com/th/id/R.1604e8e62f8bb8eec18930f428b4e824?rik=sD1vtKHPfZNdpw&riu=http%3a%2f%2fwww-ug.eecg.toronto.edu%2fmsl%2fimages%2fde1_main.jpg&ehk=GbfOjPv9Y3omNQsgA8vl4pEiR%2fK7L4kjPbcDaNI1%2bc0%3d&risl=&pid=ImgRaw&r=0'
    }]; //archivo que recibe una lista
  //de activos del cliente
  //logica para recibir cosas del servidor

  //variables necesarias para la funcionalidad
  //mostrarModal: boolean = true; //variable para mostrar el forms de llenado.
  botonPresionado:number=0;  //se inicializa en 0, me indica
  id = 0;
  nombre = "";
  //que boton fue presionado para que en el form aparezca el nombre y tipo de elemento.

  mostrarForm(indice:number){//la i es de un valor para identificar cual boton fue presionado
    //y asi mostrar el form
    this.botonPresionado =indice; //de esta forma guardo cual boton
    //de todos fue presionado y puedo buscar con una funcion buscar activo, los
    //datos del elemento presionado
    //el codigo de abajo busca en el array de elementos el array especificado
    //de su boton correspondiente
    if (this.botonPresionado >= 0 && this.botonPresionado < this.activosRecibidos.length) {
      const activoSeleccionado = this.activosRecibidos[this.botonPresionado];
      this.id= activoSeleccionado.id;
      this.nombre =activoSeleccionado.name;
      // Aquí puedes realizar cualquier acción necesaria con el activo seleccionado
    } else {
      console.log('Índice fuera de rango');
    }
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '450px';
    dialogConfig.data = {
      idActivo: this.id,
      nombreActivo: this.nombre,
    };
    this.matDialog.open(FormActivosComponent,dialogConfig);
    //la linea anterior abre un dialog, que por contenido tendrá lo que haya
    //en formActivosComponent. y el ancho del dialog

  }
  //Constructor de la clase, se le inyecta el dialog, y el comunicationService.
  constructor(private matDialog:MatDialog , private servicio:ComunicationService) {}//se inyecta el servicio
  mostrarActivos(){//metodo que solicita del servidor todos los activos disponibles
    //para reservar.
    this.servicio.getActivos().subscribe(
      response => {
        console.log('Datos enviados al servidor:', response);

        this.activosRecibidos = response;
      },
      error => {
        console.error('Error al enviar datos al servidor:', error);
        // Maneja el error adecuadamente aquí
      }
    );
  }
  //matdialog para poder abrir matdialogs en este componente
// Para cerrar el modal

//metodo ngOninit , ejecuta al inicio
}

