import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent, AboutComponent, AddProductComponent, RegisterComponent, DetailComponent, LoginComponent, NotFoundComponent } from './components';
import { ProductResolver } from './resolvers';
import { AuthGuard, ConfirmGuard} from './guards';

const routes: Routes = [
  {path:'', component:HomeComponent, pathMatch:'full'},
  {path:'about', component:AboutComponent, pathMatch:'full'},
  {path:'detail/:id', component:DetailComponent, resolve:{item:ProductResolver} },
  {
    path:'product/add', 
    component:AddProductComponent, 
    canActivate:[AuthGuard], 
    canDeactivate:[ConfirmGuard] 
  },
  {path:'register', component:RegisterComponent },
  {path:'login', component:LoginComponent },
  { path: 'customers', loadChildren: () => import('./customers/customers.module').then(m => m.CustomersModule) },
  { path:'**', component:NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
