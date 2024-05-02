import { Component } from '@angular/core';
import {RouterLink, RouterOutlet} from "@angular/router";


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
export class VistaProfesorComponent {

}


