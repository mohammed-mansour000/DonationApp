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
   }

  ngOnInit(): void {
    
  }

  login() {
    this.authService.loginByEmailAndPassword(this.model.EMAIL, this.model.PASSWORD)
    .subscribe(
      res => {
        if(res?.USER_ID != null){
          this.router.navigate(["menu"]);
        }
      }
    );
  }
}
