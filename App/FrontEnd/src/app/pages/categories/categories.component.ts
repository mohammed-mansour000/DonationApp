import { Router } from '@angular/router';
import { MainService } from './../../services/main.service';
import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Category } from 'src/app/models/Category';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  PHOTO_URL: string = environment.PHOTO_URL;
  Get_Category_Subscription = new Subscription();
  categories: Category[] = [];
  
  constructor(
    private mainService: MainService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getCategories();
  }

  getCategories() {
    this.Get_Category_Subscription = this.mainService.getCategories()
      .subscribe(
        res => {
          console.log(res);
          if (res != null) {
            this.categories = res;
          }
        }
      );
  }

  navigateToItems(cat_id: any){
    this.router.navigate(['/items', cat_id]);  
  }

  ngOnDestroy(): void {
    this.Get_Category_Subscription.unsubscribe();
  }
}
