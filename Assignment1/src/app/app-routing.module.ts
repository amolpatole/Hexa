import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent, AddEventComponent, EditEventComponent } from './components';
import { EventResolverService } from './resolvers/event-resolver.service';

const routes: Routes = [
  {path:'', component:HomeComponent, pathMatch:'full'},
  {path:'addEvent', component:AddEventComponent, pathMatch:'full'},
  {path:'editEvent/:id', component:EditEventComponent, resolve:{item:EventResolverService} },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
