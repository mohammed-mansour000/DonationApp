import { UploadFile } from "./UploadFile";

export interface Category{
    CATAGORY_ID: number;
    NAME?: string;
    DESCRIPTION?: string;
    ENTRY_DATE?: Date;
    UPLOAD_FILE ?: UploadFile;

}

export class Action_Result{
    errorMsg?: string;
}

export interface Result_Get_Category extends Action_Result{
    categories: Category[];    
}

export interface Result_EDIT_CATEGORY extends Action_Result{
    category: Category;
}

export interface Result_DELETE_CATEGORY_BY_CATEGORY_ID extends Action_Result{
    Msg: string;
}