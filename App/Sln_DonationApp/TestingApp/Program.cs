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

            //List<Item> items = oDALC.GET_ITEMS();
            //foreach (Item i in items)
            //{
            //    Console.WriteLine(i.ITEM_ID);
            //    Console.WriteLine(i.NAME);
            //    Console.WriteLine(i.DESCRIPTION);
            //    Console.WriteLine(i.IS_ACTIVE);
            //    Console.WriteLine(i.ENTRY_DATE);
            //    Console.WriteLine(i.CATAGORY.CATAGORY_ID);
            //    Console.WriteLine(i.CATAGORY.NAME);
            //    Console.WriteLine(i.CATAGORY.DESCRIPTION);
            //    Console.WriteLine(i.CATAGORY.ENTRY_DATE);

            //}
            //Item i=oDALC.GET_ITEM_BY_ID(3);
            //Console.WriteLine(i.ITEM_ID);
            //Console.WriteLine(i.NAME);
            //Console.WriteLine(i.DESCRIPTION);
            //Console.WriteLine(i.IS_ACTIVE);
            //Console.WriteLine(i.ENTRY_DATE);
            //Console.WriteLine(i.CATAGORY.CATAGORY_ID);
            //Console.WriteLine(i.CATAGORY.NAME);
            //Console.WriteLine(i.CATAGORY.DESCRIPTION);
            //Console.WriteLine(i.CATAGORY.ENTRY_DATE);

            //Category c = new Category();
            //Console.WriteLine("press -1 if you are need to add ");
            //c.CATAGORY_ID = Int32.Parse(Console.ReadLine());
            //Console.WriteLine("enter your name");
            //c.NAME = Console.ReadLine();
            //Console.WriteLine("enter your desc");
            //c.DESCRIPTION = Console.ReadLine();
            //c.ENTRY_DATE = DateTime.Now;
            //oDALC.EDIT_CATEGORY(c);


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
