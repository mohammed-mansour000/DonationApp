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
            //int dd = oDALC.EDIT_CATEGORY(c);


            //User user = oDALC.GET_USER_BY_USER_ID(2);
            //User userTest = new User();
            //userTest.USER_ID = -1;
            //userTest.FIRST_NAME = "test output ";
            //userTest.LAST_NAME = "test output ";
            //userTest.EMAIL = "besho@test output .com";
            //userTest.PASSWORD = "123";
            //userTest.PHONE = "8182828";
            //userTest.ENTRY_DATE = DateTime.Today;
            //userTest.IS_ACTIVE = true;
            //userTest.USER_TYPE_CODE = "001";
            //long user_id = oDALC.EDIT_USER(userTest);


            //List<User> users = oDALC.Get_Users();

            //User user = oDALC.GET_USER_BY_EMAIL_AND_PASSWORD("besho@gmail.com", "besho123");
            //foreach (User u  in users) {
            //    Console.WriteLine(u.FIRST_NAME);
            //}

            //List<Address> address = oDALC.GET_ADDRESS();

            //Address oaddress = oDALC.GET_ADDRESS_BY_ADDRESS_ID(1);

            //Address addressTest = new Address();
            //addressTest.ADDRESS_ID = 1;
            //addressTest.COUNTRY = "TEST UPDATED";
            //addressTest.CITY = "bet la7em";
            //addressTest.STREET = "abo l jeez";
            //addressTest.LATIDUTE = 5.444m;
            //addressTest.LANGITUDE = 25.444m;
            //int dd = oDALC.EDIT_ADDRESS(addressTest);

            //List<Address> address = oDALC.GET_ADDRESS_BY_COUNTRY("PALESTINE");


            Donation donation = new Donation();
            donation.DONATION_ID = -1;
            donation.COLOR = "YELOW";
            donation.QUANTITY = 5;
            donation.SIZE = "LLS";
            donation.SHIP_DATE = DateTime.Today.AddDays(13);
            donation.ENTRY_DATE = DateTime.Today;
            donation.IS_SHIPPED = false;

            donation.ADDRESS = new Address();
            donation.ADDRESS.ADDRESS_ID = 3;
            donation.ITEM = new Item();
            donation.ITEM.ITEM_ID = 1;
            donation.USER = new User();
            donation.USER.USER_ID = 2;
            int ss = oDALC.EDIT_DONATION(donation);

            //List<Donation> donation = oDALC.GET_DONATION_BY_IS_NOT_SHIPPED();
        }
    }
}
