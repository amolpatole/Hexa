import { Component, OnInit } from '@angular/core';
import { Product, Category } from 'src/app/models';
import { ProductService } from 'src/app/services';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  product: Product;
  categories: Observable<Category[]>;
  formStatus:any = {
    submitted:false,
    valid:true
  };
  navigationEnabled:boolean=false;

  constructor(private productSvc: ProductService, private router:Router) {
    this.product = {
      name: "", brand: "", price: undefined, quantity: undefined,
      taxRate: undefined, manufacturingDate: undefined,
      reorderLevel: undefined, imageUrl: ""
    };

    this.categories = productSvc.getCategories();
  };

  ngOnInit() {
  }

  save(form) {
    this.formStatus.submitted = true;
    if (form.valid) {
      this.productSvc.addProduct(form.value).subscribe(
        res=>{
          this.navigationEnabled = true;
          this.router.navigate(['/'])
        }, 
        err=>{this.formStatus.valid =false;});
    } else {
      this.formStatus.valid =false;
    }
  };

}
