import { Injectable } from '@angular/core';
import { Category, Product } from '../models';
import { Observable, of, throwError } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  
  readonly apiURL = "http://localhost:3000"

  constructor(private httpClient:HttpClient,) { }

  getProducts(): Observable<Product[]>{
    return this.httpClient.get<Product[]>(`${this.apiURL}/products`);
  }

  getProductById(id:number):Observable<Product>{
    return this.httpClient.get<Product>(`${this.apiURL}/products/${id}`);
  }

  addProduct(product:Product):Observable<Product>{
    return this.httpClient.post<Product>(`${this.apiURL}/products`, product);
    //return throwError("Error"); // Throw the error 
  }

  removeProduct(id:number):Observable<any>{
    return this.httpClient.delete<any>(`${this.apiURL}/products/${id}`);
  }

  getCategories():Observable<Category[]>{
    return this.httpClient.get<Category[]>(`${this.apiURL}/categories`);
  }
}
