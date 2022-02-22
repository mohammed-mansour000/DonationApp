
import { Donation, Result_EDIT_DONATION, Result_GET_DONATION_BY_USER_ID } from './../models/Donation';
import { Result_Get_Items_By_Category } from './../models/Item';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Category, Result_Get_Category } from '../models/Category';
import {map} from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Item } from '../models/Item';
import { Result_EDIT_USER, Result_LOGIN_BY_EMAIL_AND_PASSWORD, User } from '../models/User';
import { Result_EDIT_UPLOADED_FILE, UploadFile } from '../models/UploadFile';
import { Address, Result_EDIT_ADDRESS } from '../models/Address';

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

  getDonationByUserId(user_id: any): Observable<Donation[]>{
    return this.apiCaller.post<Result_GET_DONATION_BY_USER_ID>(`${this.BASE_URL}/GET_DONATION_BY_USER_ID`, {USER_ID: user_id} )
    .pipe(map(response => { this.Handle_Exception(response.errorMsg);
       return response.donations;
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

  editUploadFile(i_UploadFile: UploadFile): Observable<UploadFile>{
    return this.apiCaller.post<Result_EDIT_UPLOADED_FILE>(`${this.BASE_URL}/EDIT_UPLOADED_FILE`, i_UploadFile)
    .pipe(map(response => { this.Handle_Exception(response.errorMsg);
       return response.uploadFile;
      })
    );
  }

  EditDonation(donation: Donation): Observable<Donation>{
    return this.apiCaller.post<Result_EDIT_DONATION>(`${this.BASE_URL}/EDIT_DONATION`, donation)
    .pipe(map(response => { this.Handle_Exception(response.errorMsg);
       return response.donation;
      })
    );
  }

  EditAddress(address: Address): Observable<Address>{
    return this.apiCaller.post<Result_EDIT_ADDRESS>(`${this.BASE_URL}/EDIT_ADDRESS`, address)
    .pipe(map(response => { this.Handle_Exception(response.errorMsg);
      return response.address;
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

  uploadPhoto(file: any): Observable<string>{
    return this.apiCaller.post<string>(`${this.BASE_URL}/savefile`, file);
  }

  getLocalStorage(): User{
    return JSON.parse(localStorage.getItem('user_data') || '{}');
  }

  removeLocalStorage(){
    localStorage.removeItem('user_data');
  }

  isLoggedIn(){
    return !!localStorage.getItem('user_data');
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
