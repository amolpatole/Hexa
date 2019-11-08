import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'availablity'
})
export class AvailablityPipe implements PipeTransform {

  transform(quantity: number): string {
    if(quantity <= 0)
    return "OUt of stock";
    else 
    return "In stock"
  }
  
}
