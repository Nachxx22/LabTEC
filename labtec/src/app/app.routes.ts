import { Routes } from '@angular/router';
import {SidenavComponent} from "./View/vistaAdministrador/Componentes/sidenav/sidenav.component";
import {LoginComponent} from "./View/vistaAdministrador/Componentes/login/login.component";
import {RegistroTrabajoComponent} from "./View/vistaAdministrador/Componentes/registro-trabajo/registro-trabajo.component";
import {VistaActivosComponent} from "./View/vistaAdministrador/Componentes/vista-activos/vista-activos.component";
import {
  VistaLaboratoriosComponent
} from "./View/vistaAdministrador/Componentes/vista-laboratorios/vista-laboratorios.component";
import {DevolucionActivosComponent} from "./View/vistaAdministrador/Componentes/devolucion-activos/devolucion-activos.component";
import {RegisterComponent} from "./View/vistaAdministrador/Componentes/register/register.component";

export const routes: Routes = [
  {path: 'sidenav', component: SidenavComponent,
    children:[{path: 'reistrotrabajo',component: RegistroTrabajoComponent},
      {path: 'vistaActivos',component: VistaActivosComponent},
      {path:'vistaLaboratorios',component: VistaLaboratoriosComponent},
      {path:'vistaDevoluciones',component: DevolucionActivosComponent}
    ]},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: '', redirectTo: 'login', pathMatch: 'full'},
  //{path: 'vistaActivos',component: VistaActivosComponent}
  //children:[{path: 'tipoplato',component: TipoplatoComponent},
  // {path:'menu',component:MenuComponent},
  //{path:'estadisticas',component: EstadisticasComponent}]}
];
