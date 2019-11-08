import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'reverseNumOrText'
})
export class ReverseNumOrTextPipe implements PipeTransform {

  transform(value: any): string {
    
    if(!value)
      return "";
    else{
      let result = "";
      for (let index = 0; index < value.length; index++) {
        result = value.charAt(index) + result;
      }
      return result;
    }
  }

}
