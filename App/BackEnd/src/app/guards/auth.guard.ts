import { User } from './../models/User';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor( 
    private authService: AuthService, 
    private router: Router 
  ){ }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    if(this.authService.getLocalStorage() && this.authService.getLocalStorage().USER_TYPE_CODE != "003"){        
      console.log("rooo7 l3ab ma fe localstorage")
      this.router.navigate(["login"]);
      return false;
    }
    return true;
  }
  
}
