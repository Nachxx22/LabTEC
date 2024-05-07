import { Component, OnInit } from '@angular/core';
import {Router, RouterLink, RouterOutlet} from "@angular/router";
import { ActivatedRoute } from '@angular/router';
import {ComunicationService} from "../../auth.service";

@Component({
  selector: 'app-vista-profesor',
  standalone: true,
  imports: [
    RouterOutlet,
    RouterLink
  ],
  templateUrl: './vista-profesor.component.html',
  styleUrl: './vista-profesor.component.css'
})
export class VistaProfesorComponent implements OnInit {
  NombreProfesor: string = "";

  constructor(private servicio: ComunicationService) {}

  ngOnInit() {
    this.NombreProfesor = this.servicio.getNombreProfesor();
    //console.log("Este es el nombre que se recibe en la vista profesor " + this.NombreProfesor);
  }
}







