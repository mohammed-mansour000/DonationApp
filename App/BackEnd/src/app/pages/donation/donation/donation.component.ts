import { Donation } from './../../../models/Donation';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { MainService } from 'src/app/services/main.service';
import { Location } from '@angular/common';
import { Subscription } from 'rxjs';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-donation',
  templateUrl: './donation.component.html',
  styleUrls: ['./donation.component.css']
})
export class DonationComponent implements OnInit {

  Get_Donations_Subscription = new Subscription();
  Get_Donations_By_Is_Shipped_Subscription = new Subscription();
  Get_Donations_By_Is_Not_Shipped_Subscription = new Subscription();
  donations: Donation[] = [];
  form!: FormGroup;
  donation?: Donation | null;
  PhotoFilePath?: string = "" ;
  PhotoFileName? : string = "";
  PHOTO_URL: string = environment.PHOTO_URL;
  selectedFilter: string = "";
  slideConfig = {
    slidesToShow: 1,
    slidesToScroll: 1,
    //dots: true,
    infinite: true,
    autoplay: true,
    autoplaySpeed: 1500,
    responsive: [
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 3
        }
      },
      {
        breakpoint: 985,
        settings: {
          slidesToShow: 2
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
              private modalService: NgbModal,
              private fb: FormBuilder,
              private location: Location
            ) { }

  ngOnInit(): void {
    this.getDonations();
  }

  getDonations() {
    this.Get_Donations_Subscription = this.mainService.getDonations()
    .subscribe(
      res => {
        if(res != null){
          console.log(res)
          this.donations = res;
        }
      }
    );
  }

  handleFilterChange(){
    if(this.selectedFilter == "shipped"){
      this.getShippedDonation();
    }

    if(this.selectedFilter == "notShipped"){
      this.getNotShippedDonation();
    }

    if(this.selectedFilter == "all"){
      this.getDonations();
    }
  }

  getShippedDonation(){
    this.Get_Donations_By_Is_Shipped_Subscription = this.mainService.getDonationsByIsShipped()
    .subscribe(
      res => {
        if(res != null){
          console.log(res)
          this.donations = res;
        }
      }
    );
  }

  getNotShippedDonation(){
    this.Get_Donations_By_Is_Not_Shipped_Subscription = this.mainService.getDonationsByIsNotShipped()
    .subscribe(
      res => {
        if(res != null){
          console.log(res)
          this.donations = res;
        }
      }
    );
  }

  delete(donation_id: number){
    if(confirm("are you sure?")){
      console.log(donation_id);
      this.mainService.deleteDonation(donation_id)
      .subscribe(
        res => {
          console.log(res);
          this.getDonations();
        }
      );
    }
  }

  IS_SHIPPED_DONATION(donation_id:number , is_Shipped:boolean){
    this.mainService.IS_SHIPPED_DONATION(donation_id, is_Shipped)
    .subscribe(res=>{
      console.log(res);
      
      if(this.selectedFilter == "shipped"){
        this.getShippedDonation();
      }
  
      if(this.selectedFilter == "notShipped"){
        this.getNotShippedDonation();
      }
  
      if(this.selectedFilter == "all"){
        this.getDonations();
      }
    });
 }

  openImageModal(content: TemplateRef<any>, i_Donation: Donation){
    this.donation = i_Donation;
    console.log(this.donation)
    console.log(this.PhotoFilePath)
    this.modalService.open(content, { backdrop: 'static', centered: true });
  }

  goBack(){
    this.location.back();
  }

  ngOnDestroy(): void {
    this.Get_Donations_Subscription.unsubscribe();
  }
}
