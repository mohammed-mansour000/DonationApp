import { MainService } from 'src/app/services/main.service';
import { User } from './../../models/User';
import { Component, ElementRef, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  @ViewChild("closeModalBtn") closeModalBtn?: ElementRef;
  user?: User;
  profileData = {
    USER_ID: this.mainService.getLocalStorage().USER_ID,
    FIRST_NAME: this.mainService.getLocalStorage().FIRST_NAME,
    LAST_NAME: this.mainService.getLocalStorage().LAST_NAME,
    EMAIL: this.mainService.getLocalStorage().EMAIL,
    PHONE: this.mainService.getLocalStorage().PHONE,
    USER_TYPE_CODE: this.mainService.getLocalStorage().USER_TYPE_CODE,
    IS_ACTIVE: this.mainService.getLocalStorage().IS_ACTIVE,
    ENTRY_DATE: this.mainService.getLocalStorage().ENTRY_DATE,
    PASSWORD: ""
  }
  constructor(
    private mainService: MainService,
    private modalService: NgbModal,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.user = this.mainService.getLocalStorage();
  }

  editProfile(){
    console.log("Save!");
    this.mainService.editUser(this.profileData)
    .subscribe(
      res => {
        if(res.USER_ID != null){
          localStorage.setItem(
            'user_data',
            JSON.stringify(res)
          );
          this.user = res;
          this.modalService.dismissAll();
          this.toastr.info("Profile Updated", "Your Profile")

        }
      }
    );
  }

  openModal(content: TemplateRef<any>) {
    this.modalService.open(content, { backdrop: 'static', centered: true });
  }

  navigateHistory(){}
}
