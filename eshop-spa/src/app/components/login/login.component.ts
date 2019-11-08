import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { UserService } from 'src/app/services';
import { Router } from '@angular/router';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

  constructor(private userSVC: UserService, private formBuilder: FormBuilder, private router: Router) {
    this.loginForm = this.formBuilder.group({
      username: new FormControl("", Validators.required),
      password: new FormControl("", Validators.compose([Validators.required, Validators.minLength(8)])),
    });
  }

  ngOnInit() {
  }

  public get Password() {
    return this.loginForm.controls["password"];
  }
  public get UserName() {
    return this.loginForm.controls["username"];
  }

  login() {
    if (this.loginForm.valid) {
      let username = this.loginForm.value.username;
      let password = this.loginForm.value.password;
      this.userSVC.getUser(username, password).subscribe(
        result => {
          if (result.length > 0) {

            // To save the user detial as observable
            this.userSVC.saveUserState(result);
            this.router.navigate(['/']);
          } else {
            alert("User does not exists")
          }
        },
        erro => {
          alert("Error in validating user");
        }
      )
    } else {
      alert("Invalid username and password....");
    }
  }
}
