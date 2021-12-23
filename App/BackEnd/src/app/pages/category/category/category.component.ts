import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Category } from 'src/app/models/Category';
import { MainService } from 'src/app/services/main.service';
import { Location } from '@angular/common';


@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  Get_Category_Subscription = new Subscription();
  category: Category[] = [];
  constructor(private mainService:MainService,private location :Location) { }

  ngOnInit(): void {
    this.getCategories();
    //console.log(this.category);
  }

  
  getCategories() {
    this.Get_Category_Subscription = this.mainService.getCategories()
    .subscribe(
      res => {
        console.log(res);
        if(res != null){
          this.category = res;
        }
      }
    );
  }

  goBack(){
    this.location.back();
  }
  ngOnDestroy(): void {
    this.Get_Category_Subscription.unsubscribe();
  }
}
