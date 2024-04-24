import { Component } from '@angular/core';

import {NgFor} from "@angular/common";

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
    NgFor
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
  constructor() {
  }
}
