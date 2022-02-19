import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MainService } from 'src/app/services/main.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
 
  loading = false;
  loginData = {
    EMAIL: "",
    PASSWORD: ""
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

  login(){
    this.loading = true;
    this.mainService.loginByEmailAndPassword(this.loginData.EMAIL, this.loginData.PASSWORD)
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

  goToSignup(){
    this.router.navigate(['signup']);
  }
}
