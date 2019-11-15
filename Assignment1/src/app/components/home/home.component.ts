import { Component, OnInit } from '@angular/core';
import { Events } from 'src/app/Models';
import { EventService } from 'src/app/service';
import { Observable } from 'rxjs';


@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  events: Observable<Events[]>;

  constructor(private eventService: EventService) {
    this.events = this.eventService.getEventsData();
  }

  ngOnInit() {
    
  }

}
