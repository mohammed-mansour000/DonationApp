import { Result_Get_Items_By_Category } from './../models/Item';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Category, Result_Get_Category } from '../models/Category';
import {map} from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Item } from '../models/Item';
import { Result_EDIT_USER, Result_LOGIN_BY_EMAIL_AND_PASSWORD, User } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class MainService {

  BASE_URL: string = environment.BASE_URL;
  PHOTO_URL: string = environment.PHOTO_URL;

  constructor(private apiCaller: HttpClient) { }

   getCategories(): Observable<Category[]>{
    return this.apiCaller.get<Result_Get_Category>(`${this.BASE_URL}/Get_Category`)
    .pipe(map(response => { this.Handle_Exception(response.errorMsg);
       return response.categories;
      })
    );
  }

  getItemsByCategoryId(cat_id: any): Observable<Item[]>{
    return this.apiCaller.post<Result_Get_Items_By_Category>(`${this.BASE_URL}/GET_ITEM_BY_CATEGORY_ID?c_Id=${cat_id}`, cat_id )
    .pipe(map(response => { this.Handle_Exception(response.errorMsg);
       return response.items;
      })
    );
  }

  editUser(user: User): Observable<User>{
    return this.apiCaller.post<Result_EDIT_USER>(`${this.BASE_URL}/EDIT_USER`, user)
    .pipe(map(response => { this.Handle_Exception(response.errorMsg);
      return response.user;
    })
    );
  }

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
