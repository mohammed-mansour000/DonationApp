import { MainService } from './../../../services/main.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Item } from 'src/app/models/Item';
import { environment } from 'src/environments/environment';


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
  }

  getItemsByCategoryId() {
    this.Get_Items_Subscription = this.mainService.getItemsByCategoryId(this.category_id)
    .subscribe(
      res => {
        if(res != null){
          console.log(res)
          this.items = res;
        }
      }
    );
  }
}
