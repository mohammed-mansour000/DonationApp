import { Component, OnInit, TemplateRef } from '@angular/core';
import { Subscription } from 'rxjs';
import { Category } from 'src/app/models/Category';
import { MainService } from 'src/app/services/main.service';
import { Location } from '@angular/common';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { environment } from 'src/environments/environment';
import { UploadFile } from 'src/app/models/UploadFile';


@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  Get_Category_Subscription = new Subscription();
  categories: Category[] = [];
  category?: Category | null;
  form!: FormGroup;
  PhotoFilePath?: string = "";
  PhotoFileName?: string = "";
  preparedFile: any;
  preparedFormData: FormData = new FormData();
  PHOTO_URL: string = environment.PHOTO_URL;

  constructor(private mainService: MainService, private location: Location, private modalService: NgbModal, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.getCategories();
    //console.log(this.category);
  }


  getCategories() {
    this.Get_Category_Subscription = this.mainService.getCategories()
      .subscribe(
        res => {
          console.log(res);
          if (res != null) {
            this.categories = res;
          }
        }
      );
  }
  
  Edit() {
    console.log(this.form.value)
    const editedCategory: Category = {
      CATAGORY_ID: this.form.get("CATEGORY_ID")?.value,
      NAME: this.form.get("NAME")?.value,
      DESCRIPTION: this.form.get("DESCRIPTION")?.value,
    };
    this.mainService.editCategory(editedCategory)
      .subscribe(
        res => {
          if (res != null) {
            console.log(res)
            if (editedCategory.CATAGORY_ID == -1) {
              this.prepareUploadImage(this.preparedFormData, res);
            } else {
              this.getCategories();
            }
          }
        }
      );
  }

  delete(category_id: number) {
    if (confirm("are you sure?")) {
      console.log(category_id);
      this.mainService.deleteCategory(category_id)
        .subscribe(
          res => {
            console.log(res);
            this.getCategories();
          }
        );
    }
  }

  openModal(content: TemplateRef<any>, o_category: Category | null) {
    this.category = o_category
    this.formInit(this.category);
    this.modalService.open(content, { backdrop: 'static', centered: true });
  }

  formInit(data: Category | null): void {
    this.form = this.fb.group({
      CATEGORY_ID: new FormControl([data ? data.CATAGORY_ID : -1, Validators.required]).value,
      NAME: new FormControl([data ? data.NAME : "", Validators.required]).value,
      DESCRIPTION: new FormControl([data ? data.DESCRIPTION : "", Validators.required]).value
    })

    console.log(this.form.value)
  }

  prepareImage(event: any) {
    this.preparedFile = event.target.files[0];
    this.preparedFormData.append('uploadedFile', this.preparedFile, this.preparedFile.name)
  }

  prepareUploadImage(fd: FormData, preparedCategory: Category) {
    this.mainService.uploadPhoto(fd).subscribe((res: any) => {
      this.PhotoFileName = res.toString();
      this.PhotoFilePath = this.PHOTO_URL + this.PhotoFileName;
      console.log("PhotoFilePath", this.PhotoFilePath);
      if (res.toString().length > 0) {
        const i_UploadFile: UploadFile = {
          UPLOADED_FILE_ID: preparedCategory?.UPLOAD_FILE?.UPLOADED_FILE_ID ? preparedCategory?.UPLOAD_FILE?.UPLOADED_FILE_ID : -1,
          FILE_NAME: this.PhotoFileName,
          ITEM_ID: 0,
          CATEGORY_ID: preparedCategory?.CATAGORY_ID,
          DONATION_ID: 0
        }
        this.mainService.editUploadFile(i_UploadFile)
          .subscribe(
            res => {
              if (res.UPLOADED_FILE_ID != null) {
                this.getCategories();
                alert("file uploaded successfully");
              }
            }
          );
      }
    });
  }


  openImageModal(content: TemplateRef<any>, o_category: Category) {
    this.PhotoFileName = o_category.UPLOAD_FILE?.FILE_NAME;
    this.PhotoFilePath = this.PHOTO_URL + this.PhotoFileName;
    this.category = o_category;
    console.log(this.PhotoFilePath)
    this.modalService.open(content, { backdrop: 'static', centered: true });
  }

  uploadPhoto(event: any) {
    var file = event.target.files[0];
    const formData: FormData = new FormData();
    formData.append('uploadedFile', file, file.name)
    this.mainService.uploadPhoto(formData).subscribe((res: any) => {
      this.PhotoFileName = res.toString();
      this.PhotoFilePath = this.PHOTO_URL + this.PhotoFileName;
      console.log("PhotoFilePath", this.PhotoFilePath);
      if (res.toString().length > 0) {
        const i_UploadFile: UploadFile = {
          UPLOADED_FILE_ID: this.category?.UPLOAD_FILE?.UPLOADED_FILE_ID ? this.category?.UPLOAD_FILE?.UPLOADED_FILE_ID : -1,
          FILE_NAME: this.PhotoFileName,
          ITEM_ID: 0,
          CATEGORY_ID: this.category?.CATAGORY_ID,
          DONATION_ID: 0
        }
        this.mainService.editUploadFile(i_UploadFile)
          .subscribe(
            res => {
              if (res.UPLOADED_FILE_ID != null) {
                this.getCategories();
                alert("file uploaded successfully");
              }
            }
          );
      }
    });
  }

  goBack() {
    this.location.back();
  }
  ngOnDestroy(): void {
    this.Get_Category_Subscription.unsubscribe();
  }
}
