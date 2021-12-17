import { User } from './../../../models/User';
import { MainService } from './../../../services/main.service';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Subscription } from 'rxjs';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  Get_Users_Subscription = new Subscription();
  users: User[] = [];
  form!: FormGroup;
  user?: User;
  constructor(
              private mainService: MainService,
              private modalService: NgbModal,
              private fb: FormBuilder
            ) { }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.Get_Users_Subscription = this.mainService.getUsers().subscribe(
      res => {
        if(res != null){
          this.users = res;
        }
      }
    )
  }

  formInit(data: User): void {
    this.form = this.fb.group({
      name: [data ? data.FIRST_NAME: '', Validators.required],
      age: [data ? data.LAST_NAME: '', Validators.required],
      address: [data ? data.EMAIL: '', Validators.required],
    })
  }

  openModal(content: TemplateRef<any>, employeeId: any){
    //this.employeeDetails = this.employeeList.find((e: Employee) => e.id === employeeId);
    //this.formInit(this.employeeDetails); 
    this.modalService.open(content, { backdrop: 'static', centered: true });
  }
  
  close(){
    this.modalService.dismissAll();
  }

  ngOnDestroy(): void {
    this.Get_Users_Subscription.unsubscribe();
    }
}
