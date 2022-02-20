import { UploadFile } from './../../../models/UploadFile';
import { environment } from './../../../../environments/environment';
import { Category } from './../../../models/Category';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Subscription } from 'rxjs';
import { Item } from 'src/app/models/Item';
import { MainService } from 'src/app/services/main.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {
  
  Get_Items_Subscription = new Subscription();
  Get_Categories_Subscription = new Subscription();
  items: Item[] = [];
  categories: Category[] = [];
  form!: FormGroup;
  item?: Item | null;
  PhotoFilePath?: string = "" ;
  PhotoFileName? : string = "";
  preparedFile: any;
  preparedFormData : FormData = new FormData();
  PHOTO_URL: string = environment.PHOTO_URL;
  constructor(
              private mainService: MainService,
              private modalService: NgbModal,
              private fb: FormBuilder,
              private location: Location
            ) { }

  ngOnInit(): void {
    this.getItems();
    this.getCategories();
  }

  getItems() {
    this.Get_Items_Subscription = this.mainService.getItems()
    .subscribe(
      res => {
        if(res != null){
          console.log(res)
          this.items = res;
        }
      }
    );
  }

  getCategories(){
    this.Get_Categories_Subscription = this.mainService.getCategories()
    .subscribe(
      res => {
        if(res != null){
          console.log(res)
          this.categories = res;
        }
      }
    );
  }
  
  Edit(){
    console.log(this.form.value)
    const editedItem: Item = {
      ITEM_ID: this.form.get("ITEM_ID")?.value,
      NAME: this.form.get("NAME")?.value,
      DESCRIPTION: this.form.get("DESCRIPTION")?.value,
      IS_ACTIVE: this.form.get("IS_ACTIVE")?.value,
      CATAGORY: {
        CATAGORY_ID: this.form.get("CATAGORY_ID")?.value
      }

    };
    this.mainService.editItem(editedItem)
    .subscribe(
      res => {
        if(res != null){
          console.log(res)
          // this.getItems();
          if(editedItem.ITEM_ID == -1){
            this.prepareUploadImage(this.preparedFormData, res);
          }else{
            this.getItems();
          }
        }
      }
    );
  }

  delete(item_id: number){
    if(confirm("are you sure?")){
      console.log(item_id);
      this.mainService.deleteItem(item_id)
      .subscribe(
        res => {
          console.log(res);
          this.getItems();
        }
      );
    }
  }

  formInit(data: Item | null): void {
    this.form = this.fb.group({
      ITEM_ID: new FormControl([data ? data.ITEM_ID : -1, Validators.required]).value,
      NAME: new FormControl([data ? data.NAME : "", Validators.required]).value,
      DESCRIPTION: new FormControl([data ? data.DESCRIPTION : "", Validators.required]).value,
      CATAGORY_ID: new FormControl([data ? data.CATAGORY.CATAGORY_ID : "", Validators.required]).value,
      IS_ACTIVE: new FormControl([1, Validators.required]).value
    })
  }

  openModal(content: TemplateRef<any>, o_item: Item | null){
    this.item = o_item
    console.log(this.item)
    this.formInit(this.item); 
    this.modalService.open(content, { backdrop: 'static', centered: true });
  }

  openImageModal(content: TemplateRef<any>, i_item: Item){
    this.PhotoFileName = i_item.UPLOAD_FILE?.FILE_NAME;
    this.PhotoFilePath = this.PHOTO_URL + this.PhotoFileName;
    this.item = i_item;
    console.log(this.PhotoFilePath)
    this.modalService.open(content, { backdrop: 'static', centered: true });
  }

  prepareImage(event: any){
    this.preparedFile = event.target.files[0];
    console.log(this.preparedFile)
    this.preparedFormData.append('uploadedFile', this.preparedFile, this.preparedFile.name)
  }

  prepareUploadImage(fd: FormData, preparedItem: Item){
    this.mainService.uploadPhoto(fd).subscribe((res: any) => {
      this.PhotoFileName = res.toString();
      this.PhotoFilePath = this.PHOTO_URL + this.PhotoFileName;
      console.log("PhotoFilePath", this.PhotoFilePath);
      if(res.toString().length > 0){
        const i_UploadFile: UploadFile = {
          UPLOADED_FILE_ID: preparedItem?.UPLOAD_FILE?.UPLOADED_FILE_ID ? preparedItem?.UPLOAD_FILE?.UPLOADED_FILE_ID : -1,
          FILE_NAME: this.PhotoFileName,
          ITEM_ID: preparedItem?.ITEM_ID,
          CATEGORY_ID: 0,
          DONATION_ID: 0
        } 
        this.mainService.editUploadFile(i_UploadFile)
        .subscribe(
          res => {
            if(res.UPLOADED_FILE_ID != null){
              this.getItems();
              alert("file uploaded successfully");
            }
          }
        );
      }
    });
  }

  uploadPhoto(event: any){
    var file = event.target.files[0];
    const formData : FormData = new FormData();
    formData.append('uploadedFile', file, file.name)
    console.log(file.name)
    this.mainService.uploadPhoto(formData).subscribe((res: any) => {
      this.PhotoFileName = res.toString();
      this.PhotoFilePath = this.PHOTO_URL + this.PhotoFileName;
      console.log("PhotoFilePath", this.PhotoFilePath);
      if(res.toString().length > 0){
        const i_UploadFile: UploadFile = {
          UPLOADED_FILE_ID: this.item?.UPLOAD_FILE?.UPLOADED_FILE_ID ? this.item?.UPLOAD_FILE?.UPLOADED_FILE_ID : -1,
          FILE_NAME: this.PhotoFileName,
          ITEM_ID: this.item?.ITEM_ID,
          CATEGORY_ID: 0,
          DONATION_ID: 0
        } 
        this.mainService.editUploadFile(i_UploadFile)
        .subscribe(
          res => {
            if(res.UPLOADED_FILE_ID != null){
              this.getItems();
              alert("file uploaded successfully");
            }
          }
        );
      }
    });
  }

  goBack(){
    this.location.back();
  }

  close(){
    this.modalService.dismissAll();
  }

  ngOnDestroy(): void {
    this.Get_Items_Subscription.unsubscribe();
    this.Get_Categories_Subscription.unsubscribe();
  }
}
