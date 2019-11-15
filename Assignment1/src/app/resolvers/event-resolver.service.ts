import { Injectable } from '@angular/core';
import { EventService } from '../service';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Events } from '../Models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventResolverService implements Resolve<Events> {

  constructor(private eventSVC: EventService) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Events | Observable<Events> | Promise<Events> {
    let id = route.params["id"];
    return this.eventSVC.getEventById(id);
  }

}
