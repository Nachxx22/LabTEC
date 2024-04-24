import { Routes } from '@angular/router';
import {SidenavComponent} from "./View/vistaOperador/Componentes/sidenav/sidenav.component";
import {LoginComponent} from "./View/vistaOperador/Componentes/login/login.component";
import {RegistroTrabajoComponent} from "./View/vistaOperador/Componentes/registro-trabajo/registro-trabajo.component";
import {VistaActivosComponent} from "./View/vistaOperador/Componentes/vista-activos/vista-activos.component";

export const routes: Routes = [
  {path: 'sidenav', component: SidenavComponent,
    children:[{path: 'reistrotrabajo',component: RegistroTrabajoComponent},
      {path: 'vistaActivos',component: VistaActivosComponent}]},
  {path: 'login', component: LoginComponent},
  {path: '', redirectTo: 'login', pathMatch: 'full'},
  {path: 'vistaActivos',component: VistaActivosComponent}
  //children:[{path: 'tipoplato',component: TipoplatoComponent},
  // {path:'menu',component:MenuComponent},
  //{path:'estadisticas',component: EstadisticasComponent}]}

];
