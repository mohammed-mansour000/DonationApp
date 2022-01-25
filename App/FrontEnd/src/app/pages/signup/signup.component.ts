import { User } from './../../models/User';
import { Router } from '@angular/router';
import { MainService } from './../../services/main.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  loading = false;
  signupData = {
    USER_ID: -1,
    FIRST_NAME: "",
    LAST_NAME: "",
    PHONE: "",
    EMAIL: "",
    IS_ACTIVE: true,
    USER_TYPE_CODE: "001",
    PASSWORD: '',
    CONFIRM_PASSWORD: ''
  }

  constructor(
    private mainService: MainService,
    private router: Router  
  ) { 
    if(this.mainService.isLoggedIn()){
      this.router.navigate(['categories']);
    }
  }

  ngOnInit(): void {
  }

  checkConfirmPassword(){
    return this.signupData.PASSWORD === this.signupData.CONFIRM_PASSWORD;
  }

  signup(){
    this.loading = true;
    this.mainService.editUser(this.signupData)
    .subscribe(
      res => {
        if(res?.USER_ID != null){
          console.log("welcome user")
          localStorage.setItem(
            'user_data',
            JSON.stringify(res)
          );
          this.loading = true;
          this.router.navigate(["categories"]);
        }else{
          this.loading = false;
        }
      },
      () => { this.loading = false; }
    );
  }

  goToLogin(){
    this.router.navigate(['login']);
  }
}
