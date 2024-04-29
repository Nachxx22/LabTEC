import { Component } from '@angular/core';
import {MatIcon, MatIconModule} from "@angular/material/icon";
import {MatDrawer, MatDrawerContainer, MatDrawerContent, MatSidenav} from "@angular/material/sidenav";
import {MatButton, MatButtonModule} from "@angular/material/button";
import {MatList, MatListItem, MatNavList} from "@angular/material/list";
import {RouterLink, RouterOutlet} from "@angular/router";
import {MatToolbar} from "@angular/material/toolbar";

@Component({
  selector: 'app-vista-profesor',
  standalone: true,
  imports: [
    MatIconModule,
    MatSidenav,
    MatButtonModule,
    MatDrawer,
    MatList,
    MatDrawerContainer,
    MatNavList,
    MatListItem,
    MatButton,
    MatDrawerContent,
    MatIcon,
    RouterLink,
    MatToolbar,
    RouterOutlet
  ],
  templateUrl: './vista-profesor.component.html',
  styleUrl: './vista-profesor.component.css'
})
export class VistaProfesorComponent {

}
