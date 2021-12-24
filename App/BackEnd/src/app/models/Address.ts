import { Category } from './Category';
import { UploadFile } from './UploadFile';

export interface Address{
    ADDRESS_ID : number;
    COUNTRY: string;
    CITY: string;
    STREET: string;
    LATIDUTE  : number; 
    LANGITUDE : number;
}

export class Action_Result{
    errorMsg?: string;
}

// export interface Result_GET_ITEMS extends Action_Result{
//     items: Item[];    
// }

// export interface Result_EDIT_ITEM extends Action_Result{
//     item: Item;    
// }

// export interface Result_DELETE_ITEM_BY_ITEM_ID extends Action_Result{
//     Msg: string;
// }