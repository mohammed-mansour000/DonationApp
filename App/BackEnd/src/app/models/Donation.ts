import { Item } from './Item';
import { User } from './User';
import { Address } from './Address';
import { UploadFile } from './UploadFile';

export interface Donation{
    DONATION_ID : number;
    COLOR: string;
    SIZE: string;
    ENTRY_DATE?: Date;
    QUANTITY: number;
    IS_SHIPPED: boolean;
    SHIP_DATE: Date;
    USER?: User;
    ITEM?: Item;
    UPLOADED_FILES ?: UploadFile[];
    ADDRESS?: Address
}

export class Action_Result{
    errorMsg?: string;
}

export interface Result_GET_DONATIONS extends Action_Result{
    donations: Donation[];    
}

export interface Result_GET_DONATION_BY_IS_SHIPPED extends Action_Result{
    donations: Donation[];  
}

export interface Result_GET_DONATION_BY_IS_NOT_SHIPPED extends Action_Result{
    donations: Donation[];  
}

export interface Result_GET_DONATION_BY_USER_ID extends Action_Result{
    donations: Donation[];  
}

export interface Result_DELETE_DONATION extends Action_Result{
    Msg: string;
}

export interface Result_SHIP_DONATION extends Action_Result{
    Msg: string;
}