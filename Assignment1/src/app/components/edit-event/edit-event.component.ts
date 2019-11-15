import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Events } from 'src/app/Models';
import { EventService } from 'src/app/service';

@Component({
  selector: 'edit-event',
  templateUrl: './edit-event.component.html',
  styleUrls: ['./edit-event.component.css']
})
export class EditEventComponent implements OnInit {

  events: Events;
  formStatus:any = {
    submitted:false,
    valid:true
  };

  constructor(private route:ActivatedRoute, private eventSVC: EventService, private router: Router) {
    this.events = this.route.snapshot.data["item"];
   }

  ngOnInit() {
  }

  saveEvent(form) {
    this.formStatus.submitted = true;
    console.log(form.value);
    if (form.valid) {
      this.eventSVC.updateEvent(form.value).subscribe(
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
