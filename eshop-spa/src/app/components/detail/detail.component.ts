import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from 'src/app/services';
import { Product } from 'src/app/models';

@Component({
  selector: 'detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {
  
  product:Product;
  
  constructor(private route:ActivatedRoute, private productSvc:ProductService) { 
    this.product = this.route.snapshot.data["item"];
  }

  ngOnInit() {
  }

}
