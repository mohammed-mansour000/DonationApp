import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MainService {

  BASE_URL: string = environment.BASE_URL;
  constructor(private apiCaller: HttpClient) { }

  getCategories(){
    return this.apiCaller.get(`${this.BASE_URL}/Get_Category`);
  }

  getItems(){
    return this.apiCaller.get(`${this.BASE_URL}/Get_Items`);
  }
}
