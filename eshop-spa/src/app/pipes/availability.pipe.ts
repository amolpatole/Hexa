import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'availability'
})
export class AvailabilityPipe implements PipeTransform {

  transform(quantity: number, emptyMessage: string="Out of Stock", inStockMessage:string="In Stock"): string {
    if(quantity > 0)
      return inStockMessage;
    else
      return emptyMessage;
  }

}