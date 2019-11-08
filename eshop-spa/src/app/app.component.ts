import { Component } from '@angular/core';
import { UserService } from './services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: []
})
export class AppComponent {
  title = 'eshop-spa';
  currentUser:any;
  
  constructor(private userSVC:UserService){
    this.userSVC.currentUser.subscribe(res=>this.currentUser = res);
  }
}
