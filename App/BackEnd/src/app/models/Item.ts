import { Category } from './Category';
import { UploadFile } from './UploadFile';

export interface Item{
    ITEM_ID : number;
    NAME: string;
    DESCRIPTION: string;
    ENTRY_DATE?: Date;
    IS_ACTIVE : boolean;
    CATAGORY : Category; 
    UPLOAD_FILE ?: UploadFile;
}

export class Action_Result{
    errorMsg?: string;
}

export interface Result_GET_ITEMS extends Action_Result{
    items: Item[];    
}