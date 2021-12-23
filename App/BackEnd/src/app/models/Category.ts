export interface Category{
    CATAGORY_ID: number;
    NAME?: string;
    DESCRIPTION?: string;
    ENTRY_DATE?: Date;
}

export class Action_Result{
    errorMsg?: string;
}

export interface Result_Get_Category extends Action_Result{
    categories: Category[];    
}