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
            Item i=oDALC.GET_ITEM_BY_ID(3);
            Console.WriteLine(i.ITEM_ID);
            Console.WriteLine(i.NAME);
            Console.WriteLine(i.DESCRIPTION);
            Console.WriteLine(i.IS_ACTIVE);
            Console.WriteLine(i.ENTRY_DATE);
            Console.WriteLine(i.CATAGORY.CATAGORY_ID);
            Console.WriteLine(i.CATAGORY.NAME);
            Console.WriteLine(i.CATAGORY.DESCRIPTION);
            Console.WriteLine(i.CATAGORY.ENTRY_DATE);

            //Category c = new Category();
            //Console.WriteLine("press -1 if you are need to add ");
            //c.CATAGORY_ID = Int32.Parse(Console.ReadLine());
            //Console.WriteLine("enter your name");
            //c.NAME = Console.ReadLine();
            //Console.WriteLine("enter your desc");
            //c.DESCRIPTION = Console.ReadLine();
            //c.ENTRY_DATE = DateTime.Now;
            //oDALC.EDIT_CATEGORY(c);

        }
    }
}
