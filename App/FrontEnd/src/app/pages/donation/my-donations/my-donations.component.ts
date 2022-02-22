import { Component, OnInit } from '@angular/core';

import { Subscription } from 'rxjs';
import { Donation } from 'src/app/models/Donation';
import { MainService } from 'src/app/services/main.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-my-donations',
  templateUrl: './my-donations.component.html',
  styleUrls: ['./my-donations.component.css']
})
export class MyDonationsComponent implements OnInit {

  user_Id: any ;
  donations :Donation[] = [];
  Get_Donations_Subscription = new Subscription();
  PHOTO_URL: string = environment.PHOTO_URL;



 
  slideConfig = {
    slidesToShow: 1,
    slidesToScroll: 1,
    //dots: true,
    infinite: true,
    autoplay: true,
    autoplaySpeed: 1500,
    arrows:false,
    responsive: [
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 1
        }
      },
      {
        breakpoint: 985,
        settings: {
          slidesToShow: 1
        }
      },
      {
        breakpoint: 765,
        settings: {
          slidesToShow: 1
        }
      }
    ]
  };
  constructor(
    private mainService: MainService,

  ) { }

  ngOnInit(): void {
    this.user_Id=this.mainService.getLocalStorage().USER_ID;
    this.getDonationsByUserId(this.user_Id);
  }

  getDonationsByUserId(user_Id?: number) {
    this.Get_Donations_Subscription = this.mainService.getDonationByUserId(user_Id)
    .subscribe(
      res => {
        if(res != null){
          console.log(res)
          this.donations = res;
        }
      }
    );
  }

  ngOnDestroy(): void {
    this.Get_Donations_Subscription.unsubscribe();
  }

}
