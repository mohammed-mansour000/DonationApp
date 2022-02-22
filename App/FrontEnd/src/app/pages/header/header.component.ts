import { Router } from '@angular/router';
import { MainService } from 'src/app/services/main.service';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  isLoggedIn: boolean = false;
  
  constructor(
    private mainService: MainService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.isLoggedIn = this.mainService.isLoggedIn();
  }

  logout(){
    this.mainService.removeLocalStorage();
    this.isLoggedIn = this.mainService.isLoggedIn();
  }
}
