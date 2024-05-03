import { Routes } from '@angular/router';
import {SidenavComponent} from "./View/vistaAdministrador/Componentes/sidenav/sidenav.component";
import {LoginComponent} from "./View/vistaAdministrador/Componentes/login/login.component";

export const routes: Routes = [
  {path: 'sidenav', component: SidenavComponent},
  {path: 'login', component: LoginComponent},
  {path: '', redirectTo: 'login', pathMatch: 'full'}
  //children:[{path: 'tipoplato',component: TipoplatoComponent},
  // {path:'menu',component:MenuComponent},
  //{path:'estadisticas',component: EstadisticasComponent}]}

];
