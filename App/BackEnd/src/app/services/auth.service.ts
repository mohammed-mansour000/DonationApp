import { Result_LOGIN_BY_EMAIL_AND_PASSWORD, User } from './../models/User';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  BASE_URL: string = environment.BASE_URL;
  constructor(
    private apiCaller: HttpClient
  ) { }

  loginByEmailAndPassword(email: string, password: string): Observable<User> {
    return this.apiCaller.post<Result_LOGIN_BY_EMAIL_AND_PASSWORD>(`${this.BASE_URL}/GET_USER_BY_EMAIL_AND_PASSWORD`, {EMAIL:email, PASSWORD:password})
    .pipe(map(response => { this.Handle_Exception(response.errorMsg);
       return response.user;
      })
    );
  }

  getLocalStorage(): User{
    return JSON.parse(localStorage.getItem('user_data') || '{}');
  }
  
  Handle_Exception(msg?: string) {
    if ((msg != null) && (msg !== '')) {
      this.ShowMessage(msg , 3000);
    }
  }

  ShowMessage(message: string, d: number = 1000) {
	  alert(message);
  }
}
