import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  name:string = "amol patole";
  today:Date = new Date();
  isMarried:boolean = false;
  size:number = 30;
  colorCode:string = "#000000";
  products:any[] = [
    {id:1, name:"Burger", price: 100.32555, quantity:1},
    {id:2, name:"Pizza", price: 1501589.25444, quantity:1},
    {id:3, name:"Pepsi", price: 7515987152.01556, quantity:0},
    {id:4, name:"Mirnida", price: 40, quantity:1}
  ];

  products1:any[] = [

  ];

  constructor() { }

  ngOnInit() {
  }

  toggleMarried(){
    this.isMarried = !this.isMarried == true;
  }

  updateFont(data){
    this.size = data.value;
  }

  updateColor(data){
    this.colorCode = data.value;
  }

}
