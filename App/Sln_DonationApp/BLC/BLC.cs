using System;
using System.Collections.Generic;
using static DALC.IDALC;

namespace BLC
{
    public class BLC
    {
        string ConnectionString = @"Data Source=DESKTOP-FI4HSGV\MANSURSQL;Initial Catalog=DonationAppDB;Integrated Security=True";

        public List<User> Get_Users()
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            List<User> oUsers = new List<User>();
            oUsers = oDalc.Get_Users();
            
            return oUsers;
        }
    }
}
