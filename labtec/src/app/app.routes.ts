import { Routes } from '@angular/router';
import {SidenavComponent} from "./View/vistaOperador/Componentes/sidenav/sidenav.component";
import {LoginComponent} from "./View/vistaOperador/Componentes/login/login.component";
import {VistaProfesorComponent} from "./View/vista-profesor/vista-profesor.component"
import {AprovacionPrestamoComponent} from "./View/vista-profesor/aprovacion-prestamo/aprovacion-prestamo.component";
import {CambioPasswordComponent} from "./View/vista-profesor/cambio-password/cambio-password.component";
import {ReservacionesComponent} from "./View/vista-profesor/reservaciones/reservaciones.component";
import {InicioComponent} from "./View/vista-profesor/inicio/inicio.component";
import {LoginProfesorComponent} from "./View/vista-profesor/login-profesor/login-profesor.component";
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import {CalendarioComponent} from "./View/vista-profesor/calendario/calendario.component";

export const routes: Routes = [
  {path: 'sidenav', component: SidenavComponent},
  {path: 'login', component: LoginComponent},
  {path: 'login-profesor', component: LoginProfesorComponent},
  {path: 'vistaProfesor', component: VistaProfesorComponent,
    children:[{path: 'cambio-password',component: CambioPasswordComponent},
      {path:'aprovacion-prestamo',component:AprovacionPrestamoComponent},
      {path:'reservaciones',component: ReservacionesComponent},
      {path:'inicio',component: InicioComponent},
      {path: 'calendario', component: CalendarioComponent}]},
  {path: '', redirectTo: 'login-profesor', pathMatch: 'full'}
  //children:[{path: 'tipoplato',component: TipoplatoComponent},
  // {path:'menu',component:MenuComponent},
  //{path:'estadisticas',component: EstadisticasComponent}]}

];

@NgModule({
  declarations: [

  ],
  imports: [
    CommonModule,
    FormsModule,
    LoginProfesorComponent,
    // Agrega FormsModule a los imports
  ]
})

export class AppRoutingModule { } // Exporta tu módulo de rutas
