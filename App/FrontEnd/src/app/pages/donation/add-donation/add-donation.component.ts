import { Address } from './../../../models/Address';
import { Donation } from './../../../models/Donation';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MainService } from 'src/app/services/main.service';
import { UploadFile } from 'src/app/models/UploadFile';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-donation',
  templateUrl: './add-donation.component.html',
  styleUrls: ['./add-donation.component.css'],
})
export class AddDonationComponent implements OnInit {
  item_id: any;
  color: any;
  myFiles:any [] = [];
  images : string[] = [];
  showFirstForm: boolean = true;
  showSecondForm: boolean = false;
  donationData: Donation = {
    DONATION_ID: -1,
    QUANTITY: 1,
    SIZE: "",
    COLOR: "",
    SHIP_DATE: null,
    IS_SHIPPED: false,
    USER: {
      USER_ID: 0,
    },
    ITEM: {
      ITEM_ID: 0
    },
    ADDRESS: {
      ADDRESS_ID: 0
    }
  }
  langitude?: number;
  latitude?: number;
  isloading: boolean = false;

  constructor(
    private router: Router, 
    private activatedRoute:ActivatedRoute,
    private mainService: MainService,
    private toastr: ToastrService

  ) {
    this.item_id = activatedRoute.snapshot.paramMap.get("item_id");
    console.log(this.item_id)
}

  ngOnInit(): void {
  }

  print(){
    console.log(this.donationData.COLOR)
  }


 
     
  onFileChange(event:any) {
    if(this.images.length == 4 || this.myFiles.length == 4){
      alert("can't add more than 4 images");
    }else{
      if (event.target.files && event.target.files[0]) {
        var filesAmount = event.target.files.length;
        for (let i = 0; i < filesAmount; i++) {
          this.myFiles.push(event.target.files[i]);
          console.log(this.myFiles)
                var reader = new FileReader();
   
                reader.onload = (event:any) => {
                  console.log(event.target.result);
                   this.images.push(event.target.result); 
   
                  //  this.myForm.patchValue({
                  //     fileSource: this.images
                  //  });
                }
  
                reader.readAsDataURL(event.target.files[i]);
        }
    }
    }
   
  }

  removeImage(index: number)
  {
    console.log(index);
    this.myFiles.splice(index, 1);
    this.images.splice(index, 1);
    console.log(this.myFiles);

  }

  goSecondForm(){
    this.showFirstForm = false;
    this.showSecondForm = true;
  }

  goFirstForm(){
    this.showFirstForm = true;
    this.showSecondForm = false;
  }

  setLocationData(event: any){
    this.langitude = event.LANGITUDE;
    this.latitude = event.LATIDUTE;
    console.log(this.langitude, this.latitude);
  }

  donate(){
    this.isloading = true;
    const address = {
      ADDRESS_ID : -1,
      COUNTRY: "",
      CITY: "",
      STREET: "",
      LATIDUTE  : this.latitude, 
      LANGITUDE : this.langitude
    }
    this.mainService.EditAddress(address)
    .subscribe(
      res1 => {
        if(res1?.ADDRESS_ID != null){
          console.log(res1);
          this.donationData.USER = this.mainService.getLocalStorage();
          this.donationData.ADDRESS!.ADDRESS_ID = res1?.ADDRESS_ID;
          this.donationData.ITEM!.ITEM_ID = this.item_id;

          this.mainService.EditDonation(this.donationData)
          .subscribe(
            res2 => {
              if(res2?.DONATION_ID != null){
                console.log(res2);
                var count = 0;
                this.myFiles.forEach(file => {
                  const formData: FormData = new FormData();
                  formData.append('uploadedFile', file, file.name)
                  this.mainService.uploadPhoto(formData)
                  .subscribe(
                    res3 => {
                      if (res3.toString().length > 0) {
                        const i_UploadFile: UploadFile = {
                          UPLOADED_FILE_ID: -1,
                          FILE_NAME: res3.toString(),
                          ITEM_ID: 0,
                          CATEGORY_ID: 0,
                          DONATION_ID: res2.DONATION_ID
                        }
                        this.mainService.editUploadFile(i_UploadFile)
                        .subscribe(
                          res4 => {
                            if (res4.UPLOADED_FILE_ID != null) {
                              count++;
                              console.log("file uploaded successfully");
                              if(count == this.myFiles.length){
                                console.log("finished uploading");
                                this.isloading = false;
                                this.toastr.success("Submitted Successfully", "Donation Added!")
                                this.router.navigate(['categories']);
                              }

                            }
                          }
                        );
                      }
                    }
                  );
                });
              }
            }
          );
        }
      }
    );
   

  }
}
