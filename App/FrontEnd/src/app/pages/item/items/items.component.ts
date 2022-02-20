import { MainService } from './../../../services/main.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Item } from 'src/app/models/Item';
import { environment } from 'src/environments/environment';
import { Category } from 'src/app/models/Category';


@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})
export class ItemsComponent implements OnInit {

  Get_Items_Subscription = new Subscription();
  category_id: any ;
  items :Item[] = [];
  PHOTO_URL: string = environment.PHOTO_URL;

  Get_Category_Subscription = new Subscription();
  categories: Category[] = [];

  constructor(
    private router: Router, 
    private activatedRoute:ActivatedRoute,
    private mainService: MainService
  ) {
    this.category_id = activatedRoute.snapshot.paramMap.get("cat_id");
    console.log(this.category_id)
}


  ngOnInit(): void {
    this.getItemsByCategoryId();
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

  getItemsByCategoryId(category_id?: number) {
    this.Get_Items_Subscription = this.mainService.getItemsByCategoryId(category_id==null? this.category_id:category_id)
    .subscribe(
      res => {
        if(res != null){
          console.log(res)
          this.items = res;
        }
      }
    );
  }

  donate = (item_id: number | undefined) => {
    if(!this.mainService.isLoggedIn()){
      this.router.navigate(["login"]);
    }else{
      this.router.navigate(["/items/add-donation", item_id])
    }
  }

  ngOnDestroy(): void {
    this.Get_Items_Subscription.unsubscribe();
  }
}
