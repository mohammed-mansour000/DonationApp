export interface UploadFile{
    UPLOADED_FILE_ID: number;
    FILE_NAME? : string;
    CATEGORY_ID? : number;
    ITEM_ID ?: number;
    DONATION_ID ?: number;
    ENTRY_DATE ?: Date;
}

export class Action_Result{
    errorMsg?: string;
}

export interface Result_Get_UPLOADED_FILE extends Action_Result{
    uploadFiles : UploadFile[];    
}

export interface Result_EDIT_UPLOADED_FILE extends Action_Result{
    uploadFile: UploadFile;   
}

