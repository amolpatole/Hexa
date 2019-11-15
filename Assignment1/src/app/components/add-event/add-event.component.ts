import { Component, OnInit } from '@angular/core';
import { Events } from 'src/app/Models';
import { EventService } from 'src/app/service';
import { Router } from '@angular/router';

@Component({
  selector: 'add-event',
  templateUrl: './add-event.component.html',
  styleUrls: ['./add-event.component.css']
})
export class AddEventComponent implements OnInit {

  events: Events;
  formStatus:any = {
    submitted:false,
    valid:true
  };

  constructor(private eventSVC: EventService, private router: Router) {
    this.events = {
      title: "",
      speaker: "",
      startDate: undefined,
      endDate: undefined,
      location: "",
      registrationUrl: "",
      organizer: "",
      startTime: undefined,
      endTime: undefined
    };
  }

  ngOnInit() {
  }

  saveEvent(form) {
    this.formStatus.submitted = true;
    if (form.valid) {
      this.eventSVC.saveEvent(form.value).subscribe(
        response => {
          this.formStatus.submitted = true;
          this.router.navigate(['/']);
        },
        error => {
          //
          console.log("Something went wrong");
          this.formStatus.valid =false;
        }
      )
    } else {
      //
      console.log("Something went wrong...");
      this.formStatus.valid =false;
    }
  };

}
