import { Component } from '@angular/core';
import {RouterLink, RouterOutlet} from '@angular/router';
import {SidenavComponent} from "./View/vistaAdministrador/Componentes/sidenav/sidenav.component";
import {HttpClientModule} from '@angular/common/http';
import {HttpClient} from "@angular/common/http";
import {LoginComponent} from "./View/vistaAdministrador/Componentes/login/login.component";
import {VistaActivosComponent} from "./View/vistaAdministrador/Componentes/vista-activos/vista-activos.component";
import {
  VistaLaboratoriosComponent
} from "./View/vistaAdministrador/Componentes/vista-laboratorios/vista-laboratorios.component";
import {
  DevolucionActivosComponent
} from "./View/vistaAdministrador/Componentes/devolucion-activos/devolucion-activos.component";
import {RegisterComponent} from "./View/vistaAdministrador/Componentes/register/register.component";


@Component({//decorador, describe el componente
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet , RouterLink, SidenavComponent ,LoginComponent
    ,HttpClientModule,VistaActivosComponent,VistaLaboratoriosComponent,DevolucionActivosComponent,RegisterComponent], //otros modulos que necesito aca se ponen aca en estos importa
  ///y se colocan aca
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {//clase appcomponent
  title = 'Labtec';
}
