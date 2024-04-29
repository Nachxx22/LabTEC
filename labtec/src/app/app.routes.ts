import { Routes } from '@angular/router';
import {SidenavComponent} from "./View/vistaOperador/Componentes/sidenav/sidenav.component";
import {LoginComponent} from "./View/vistaOperador/Componentes/login/login.component";
import {VistaProfesorComponent} from "./View/vista-profesor/vista-profesor.component"
export const routes: Routes = [
  {path: 'sidenav', component: SidenavComponent},
  {path: 'login', component: LoginComponent},
  {path: 'vistaProfesor', component: VistaProfesorComponent},
  {path: '', redirectTo: 'vistaProfesor', pathMatch: 'full'}
  //children:[{path: 'tipoplato',component: TipoplatoComponent},
  // {path:'menu',component:MenuComponent},
  //{path:'estadisticas',component: EstadisticasComponent}]}

];
