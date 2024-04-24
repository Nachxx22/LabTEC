import {Component, Input} from '@angular/core';
import {MatCard} from "@angular/material/card";
import {Activo} from "../vista-activos/vista-activos.component";


@Component({
  selector: 'app-activo',
  standalone: true,
  imports: [
    MatCard
  ],
  templateUrl: './activo.component.html',
  styleUrl: './activo.component.css'
})
export class ActivoComponent {
  //por ahora trabajarlo asi , hasta que este implementada la BD.

  constructor() { }

  @Input() activo: Activo = {} as Activo;  //espera recibir un objeto tipo activo del padre
//si no recibe nada es un objeto vacio
}

