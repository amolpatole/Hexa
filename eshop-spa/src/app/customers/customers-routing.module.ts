import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CustomersComponent } from './customers.component';
import { OrdersComponent } from "./components/orders/orders.component";
import { ProfileComponent } from "./components/profile/profile.component";

const routes: Routes = [
  { path: '', component: CustomersComponent },
  { path: 'orders', component: OrdersComponent },
  { path: 'profile', component: ProfileComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomersRoutingModule { }
