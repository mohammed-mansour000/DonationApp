using System;
using System.Collections.Generic;
using static DALC.IDALC;

namespace TestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DALC.DALC oDALC = new DALC.DALC();


            //User user = oDALC.GET_USER_BY_USER_ID(2);
            //User userTest = new User();
            //userTest.USER_ID = 7;
            //userTest.FIRST_NAME = "besho update";
            //userTest.LAST_NAME = "al sayyed";
            //userTest.EMAIL = "besho@gmail.com";
            //userTest.PASSWORD = "besho123";
            //userTest.PHONE = "8182828";
            //userTest.ENTRY_DATE = DateTime.Today;
            //userTest.IS_ACTIVE = true;
            //userTest.USER_TYPE_CODE = "001";
            //oDALC.UPG_EDIT_USER(userTest);


            //List<User> users = oDALC.Get_Users();

            //User user = oDALC.GET_USER_BY_EMAIL_AND_PASSWORD("besho@gmail.com", "besho123");
            //foreach (User u  in users) {
            //    Console.WriteLine(u.FIRST_NAME);
            //}

            //List<Address> address = oDALC.GET_ADDRESS();

            //Address oaddress = oDALC.GET_ADDRESS_BY_ADDRESS_ID(1);

            //Address addressTest = new Address();
            //addressTest.ADDRESS_ID = -1;
            //addressTest.COUNTRY = "TO BE DELETED";
            //addressTest.CITY = "bet la7em";
            //addressTest.STREET = "abo l jeez";
            //addressTest.LATIDUTE = 5.444m;
            //addressTest.LANGITUDE = 25.444m;
            //oDALC.EDIT_ADDRESS(addressTest);

            //List<Address> address = oDALC.GET_ADDRESS_BY_COUNTRY("PALESTINE");
        }
    }
}
