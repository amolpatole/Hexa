import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Events } from '../Models';

@Injectable({
  providedIn: 'root'
})

export class EventService {

  readonly apiURL = "http://localhost:3000";

  constructor(private httpClient:HttpClient) { }

  getEventsData(): Observable<Events[]> {
    return this.httpClient.get<Events[]>(`${this.apiURL}/events`);
  }

  saveEvent(event:Events):Observable<Events>{
   return this.httpClient.post<Events>(`${this.apiURL}/events`, event);
  }

  getEventById(id:number):Observable<Events>{
    return this.httpClient.get<Events>(`${this.apiURL}/events/${id}`);
  }

  updateEvent(event:Events): Observable<Events>{
    console.log(event);
    return this.httpClient.put<Events>(`${this.apiURL}/events/${event.id}/`, event);
  }
}
