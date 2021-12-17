import { Result_Get_Users, User } from './../models/User';
import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class MainService {

  BASE_URL: string = environment.BASE_URL;
  constructor(private apiCaller: HttpClient) { }

  getCategories(){
    return this.apiCaller.get(`${this.BASE_URL}/Get_Category`)
    // .pipe(map(response => { this.Handle_Exception(response.errorMsg); return response.categories;}));;
  }

  getItems(){
    return this.apiCaller.get(`${this.BASE_URL}/Get_Items`);
  }

  getUsers(): Observable<User[]> {
    return this.apiCaller.get<Result_Get_Users>(`${this.BASE_URL}/Get_Users`)
    .pipe(map(response => { this.Handle_Exception(response.errorMsg); return response.users;}));
  }

  Handle_Exception(msg: string) {
    if ((msg != null) && (msg !== '')) {
      this.ShowMessage(msg , 3000);
    }
  }

  ShowMessage(message: string, d: number = 1000) {
	  alert(message);
  }
}
