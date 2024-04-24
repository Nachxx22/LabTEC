import { Component } from '@angular/core';
import {RouterLink, RouterOutlet} from '@angular/router';
import {SidenavComponent} from "./View/vistaOperador/Componentes/sidenav/sidenav.component";
import {HttpClientModule} from '@angular/common/http';
import {HttpClient} from "@angular/common/http";
import {LoginComponent} from "./View/vistaOperador/Componentes/login/login.component";
import {VistaActivosComponent} from "./View/vistaOperador/Componentes/vista-activos/vista-activos.component";


@Component({//decorador, describe el componente
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet , RouterLink, SidenavComponent ,LoginComponent
    ,HttpClientModule,VistaActivosComponent], //otros modulos que necesito aca se ponen aca en estos importa
  ///y se colocan aca
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {//clase appcomponent
  title = 'Labtec';
}
