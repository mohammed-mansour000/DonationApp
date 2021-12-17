import { User } from './../../../models/User';
import { MainService } from './../../../services/main.service';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Subscription } from 'rxjs';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  Get_Users_Subscription = new Subscription();
  users: User[] = [];
  form!: FormGroup;
  user?: User | null;

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

  
  add(){
    // this.fireService.addEmployee(this.form.value).then(res =>{
    //   alert("employee added");
    // }).catch(err => {
    //   console.log(err)
    // })
  }

  update(user: User){
    // this.fireService.updateEmployee(employeeId, this.form.value).then(res =>{

    // }).catch(err => {
    //   console.log(err)
    // })
  }

  Edit(){
    this.mainService.editUser(this.form.value)
    .subscribe(
      res => {
        if(res != null){
          console.log(res)
        }
      }
    );
  }

  delete(user_id: number){
    if(confirm("are you sure?")){
      console.log(user_id);
      this.mainService.deleteUser(user_id)
      .subscribe(
        res => {
          console.log(res);
          this.getUsers();
        }
      );
    }
  }

  formInit(data: User | null): void {
    this.form = this.fb.group({
      USER_ID: new FormControl([data ? data.USER_ID : -1, Validators.required]).value,
      PHONE: new FormControl([data ? data.USER_ID : "ASDASD", Validators.required]).value,
      USER_TYPE_CODE: new FormControl([data ? data.USER_ID : "ASDASD", Validators.required]).value,
      IS_ACTIVE: new FormControl([0, Validators.required]).value,
      PASSWORD: new FormControl([data ? data.USER_ID : "ASDASD", Validators.required]).value,
      FIRST_NAME: new FormControl([data ? data.FIRST_NAME : '', Validators.required]).value,
      LAST_NAME: new FormControl([data ? data.LAST_NAME : '', Validators.required]).value,
      EMAIL: new FormControl([data ? data.EMAIL : '', Validators.required]).value,
    })

    console.log(this.form.value)
  }

  openModal(content: TemplateRef<any>, o_user: User | null){
    this.user = o_user
    this.formInit(this.user); 
    this.modalService.open(content, { backdrop: 'static', centered: true });
  }
  
  close(){
    this.modalService.dismissAll();
  }

  ngOnDestroy(): void {
    this.Get_Users_Subscription.unsubscribe();
    }
}
