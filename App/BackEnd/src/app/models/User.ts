export interface User{
    USER_ID: string;
    FIRST_NAME: string;
    LAST_NAME: number;
    EMAIL: string;
    IS_ACTIVE: Boolean;
    ENTRY_DATE?: Date;
    PHONE: string;
    USER_TYPE_CODE: string;

}

export interface Result_Get_Users{
    users: User[];
    errorMsg: string;
}