import { Result_EDIT_UPLOADED_FILE } from './../models/UploadFile';
import { Item, Result_DELETE_ITEM_BY_ITEM_ID, Result_EDIT_ITEM, Result_GET_ITEMS } from './../models/Item';
import { Result_Get_Users, User, Result_DELETE_USER_BY_USER_ID, Result_EDIT_USER } from './../models/User';
import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {map} from 'rxjs/operators';
import { Category, Result_Get_Category } from '../models/Category';
import { UploadFile } from '../models/UploadFile';

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

  getItems(): Observable<Item[]>{
    return this.apiCaller.get<Result_GET_ITEMS>(`${this.BASE_URL}/Get_Items`)
    .pipe(map(response => { this.Handle_Exception(response.errorMsg);
       return response.items;
      })
    );
  }

  getUsers(): Observable<User[]> {
    return this.apiCaller.get<Result_Get_Users>(`${this.BASE_URL}/Get_Users`)
    .pipe(map(response => { this.Handle_Exception(response.errorMsg);
       return response.users;
      })
    );
  }

  deleteUser(user_id: number): Observable<string> {
    return this.apiCaller.post<Result_DELETE_USER_BY_USER_ID>(`${this.BASE_URL}/DELETE_USER_BY_USER_ID?USER_ID=${user_id}`, user_id)
    .pipe(map(response => { this.Handle_Exception(response.errorMsg);
       return response.Msg;
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

  editItem(item: Item): Observable<Item>{
    return this.apiCaller.post<Result_EDIT_ITEM>(`${this.BASE_URL}/EDIT_ITEM`, item)
    .pipe(map(response => { this.Handle_Exception(response.errorMsg);
       return response.item;
      })
    );
  }

  deleteItem(item_id: number): Observable<string> {
    return this.apiCaller.post<Result_DELETE_ITEM_BY_ITEM_ID>(`${this.BASE_URL}/DELETE_ITEM_BY_ITEM_ID?ITEM_ID=${item_id}`, item_id)
    .pipe(map(response => { this.Handle_Exception(response.errorMsg);
       return response.Msg;
      })
    );
  }

  editUploadFile(i_UploadFile: UploadFile): Observable<UploadFile>{
    return this.apiCaller.post<Result_EDIT_UPLOADED_FILE>(`${this.BASE_URL}/EDIT_UPLOADED_FILE`, i_UploadFile)
    .pipe(map(response => { this.Handle_Exception(response.errorMsg);
       return response.uploadFile;
      })
    );
  }

  uploadPhoto(file: any): Observable<string>{
    return this.apiCaller.post<string>(`${this.BASE_URL}/savefile`, file);
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
