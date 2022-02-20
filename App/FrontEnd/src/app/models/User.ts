export interface User{
    USER_ID?: number;
    FIRST_NAME?: string;
    LAST_NAME?: string;
    EMAIL?: string;
    IS_ACTIVE?: Boolean;
    ENTRY_DATE?: Date;
    PHONE?: string;
    USER_TYPE_CODE?: string;
    PASSWORD?: string;

}

export class Action_Result{
    errorMsg?: string;
}

export interface Result_Get_Users extends Action_Result{
    users: User[];    
}

export interface Result_DELETE_USER_BY_USER_ID extends Action_Result{
    Msg: string;
}

export interface Result_EDIT_USER extends Action_Result{
    user: User;
}

export interface Result_LOGIN_BY_EMAIL_AND_PASSWORD extends Action_Result{
    user: User;
}

export interface Result_Activate_User extends Action_Result{
    Msg: string;
}

