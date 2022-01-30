import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MainService } from 'src/app/services/main.service';

@Component({
  selector: 'app-add-donation',
  templateUrl: './add-donation.component.html',
  styleUrls: ['./add-donation.component.css'],
})
export class AddDonationComponent implements OnInit {
  item_id: any;
  color: any;
  myFiles:string [] = [];
  images : string[] = [];
  showFirstForm: boolean = true;
  showSecondForm: boolean = false;
  donationData = {
    QUANTITY: null,
    SIZE: "",
    COLOR: ""
  }
  constructor(
    private router: Router, 
    private activatedRoute:ActivatedRoute,
    private mainService: MainService
  ) {
    this.item_id = activatedRoute.snapshot.paramMap.get("item_id");
    console.log(this.item_id)
}

  ngOnInit(): void {
  }

  print(){
    console.log(this.color)
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

  donate(){

  }
  // submit(){
  //   console.log(this.myForm.value);
  //   this.http.post('http://localhost:8001/upload.php', this.myForm.value)
  //     .subscribe(res => {
  //       console.log(res);
  //       alert('Uploaded Successfully.');
  //     })
  // }
}
