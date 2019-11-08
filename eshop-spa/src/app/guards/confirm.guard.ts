import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, CanDeactivate } from '@angular/router';
import { Observable } from 'rxjs';
import { AddProductComponent } from '../components';

@Injectable({
  providedIn: 'root'
})
export class ConfirmGuard implements CanDeactivate<AddProductComponent> {
  canDeactivate(component: AddProductComponent, currentRoute: ActivatedRouteSnapshot, currentState: RouterStateSnapshot, nextState?: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    if(!component.navigationEnabled){
      let result = confirm("Are you sure to leave this page?");
      return result;
    }else {
      return true;
    }
  }
}
