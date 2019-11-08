import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'image'
})
export class ImagePipe implements PipeTransform {

  transform(imageUrl: string, defaultImage: string): string {
    if(!imageUrl || imageUrl.length > 0)
      return `assets/${defaultImage}`;
    else
      return imageUrl;
  }

}
