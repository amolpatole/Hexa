import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from '../services';
import { identifierModuleUrl } from '@angular/compiler';
import { registerLocaleData } from '@angular/common';

@Injectable({
  providedIn: 'root'
})


export class AuthGuard implements CanActivate {

  constructor(private userSVC:UserService){

  }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      //if(this.userSVC.LoggedUser){
        //return true;
      //} else
      //{
        //return false;
      //}
    return true;
  }
  
}
