import { Routes } from '@angular/router';
import {SidenavComponent} from "./View/vistaOperador/Componentes/sidenav/sidenav.component";
import {LoginComponent} from "./View/vistaOperador/Componentes/login/login.component";
import {VistaProfesorComponent} from "./View/vista-profesor/vista-profesor.component"
import {AprovacionPrestamoComponent} from "./View/vista-profesor/aprovacion-prestamo/aprovacion-prestamo.component";
import {CambioPasswordComponent} from "./View/vista-profesor/cambio-password/cambio-password.component";
import {ReservacionesComponent} from "./View/vista-profesor/reservaciones/reservaciones.component";

export const routes: Routes = [
  {path: 'sidenav', component: SidenavComponent},
  {path: 'login', component: LoginComponent},
  {path: 'vistaProfesor', component: VistaProfesorComponent,
    children:[{path: 'cambio-password',component: CambioPasswordComponent},
      {path:'aprovacion-prestamo',component:AprovacionPrestamoComponent},
      {path:'reservaciones',component: ReservacionesComponent}]},
  {path: '', redirectTo: 'vistaProfesor', pathMatch: 'full'}
  //children:[{path: 'tipoplato',component: TipoplatoComponent},
  // {path:'menu',component:MenuComponent},
  //{path:'estadisticas',component: EstadisticasComponent}]}

];
