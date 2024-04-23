import { Routes } from '@angular/router';
import {SidenavComponent} from "./View/vistaOperador/Componentes/sidenav/sidenav.component";
import {LoginComponent} from "./View/vistaOperador/Componentes/login/login.component";
import {RegistroTrabajoComponent} from "./View/vistaOperador/Componentes/registro-trabajo/registro-trabajo.component";

export const routes: Routes = [
  {path: 'sidenav', component: SidenavComponent,
    children:[{path: 'reistrotrabajo',component: RegistroTrabajoComponent}]},
  {path: 'login', component: LoginComponent},
  {path: '', redirectTo: 'login', pathMatch: 'full'}
  //children:[{path: 'tipoplato',component: TipoplatoComponent},
  // {path:'menu',component:MenuComponent},
  //{path:'estadisticas',component: EstadisticasComponent}]}

];
