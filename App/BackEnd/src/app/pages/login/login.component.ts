import { AuthService } from './../../services/auth.service';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  model: any = {};
  loading = false;
  constructor(
    private router: Router,
    private authService: AuthService
  ) {
    this.model = {};
    this.model.EMAIL = "";
    this.model.PASSWORD = "";

    if(this.authService.getLocalStorage()){
      this.router.navigate(["menu"]);
    }
   }

  ngOnInit(): void {
    console.log(this.authService.getLocalStorage());
  }

  login() {
    this.authService.loginByEmailAndPassword(this.model.EMAIL, this.model.PASSWORD)
    .subscribe(
      res => {
        if(res?.USER_ID != null && res?.USER_TYPE_CODE == "003"){
          console.log("welcome admin")
          localStorage.setItem(
            'user_data',
            JSON.stringify(res)
          );
          this.router.navigate(["menu"]);
        }else if(res?.USER_ID != null  && res?.USER_TYPE_CODE != "003"){
          alert("this email is not admin");
        }
      }
    );
  }
}
