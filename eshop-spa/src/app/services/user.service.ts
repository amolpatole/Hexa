import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models';
import { Observable, BehaviorSubject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  readonly apiUrl="http://localhost:3000/users";
  userSubject:BehaviorSubject<any>;
  currentUser:Observable<any>;

  constructor(private http:HttpClient) {
    this.userSubject = new BehaviorSubject<any>(JSON.parse(localStorage.getItem("user")));
    this.currentUser = this.userSubject.asObservable();
   }

  addUser(user:User):Observable<any>{
   // let options={
      //headers:{"Content-Type":"application/json",
        //      "Accept":"application/json"}
    //}
    // here we used interceptor
    return this.http.post<any>(this.apiUrl, user);
  }

  getUser(username:string, password:string):Observable<any>{
    let url = `${this.apiUrl}?username=${username}&password=${password}`;
    return this.http.get<any>(url);
  }

  saveUserState(user){
    // Remove password from userState object
    delete user.password;
    // Set user information to localstorage
    localStorage.setItem("user", JSON.stringify(user))
    this.userSubject.next(user);
  }

  removeUserState(){
    // To clear loacl storage
    localStorage.clear();
    // Again send the notification
    this.userSubject.next(null);
  }

  public get CurrentUser():any{
    return this.userSubject.value;
  }
}
