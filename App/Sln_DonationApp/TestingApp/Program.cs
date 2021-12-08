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

            List<User> users = oDALC.Get_Users();
            foreach (User u  in users) {
                Console.WriteLine(u.FIRST_NAME);
            }
        }
    }
}
