using System;
using System.Collections.Generic;
using static DALC.IDALC;

namespace BLC
{
    public class BLC
    {
        string ConnectionString = @"Data Source=DESKTOP-FI4HSGV\MANSURSQL;Initial Catalog=DonationAppDB;Integrated Security=True";

        #region Get_Users
        public List<User> Get_Users()
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            List<User> oUsers = new List<User>();
            oUsers = oDalc.Get_Users();
            
            return oUsers;
        }
        #endregion

        #region GET_USER_BY_USER_ID
        public User GET_USER_BY_USER_ID(long USER_ID)
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            User oUser = new User();
            oUser = oDalc.GET_USER_BY_USER_ID(USER_ID);

            return oUser;
        }
        #endregion

        #region EDIT_USER
        public Int32 EDIT_USER(User i_User)
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            int RETURNED_USER_ID = oDalc.EDIT_USER(i_User);

            return RETURNED_USER_ID;
        }
        #endregion

        #region DELETE_USER_BY_USER_ID
        public void DELETE_USER_BY_USER_ID(long USER_ID)
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            oDalc.DELETE_USER_BY_USER_ID(USER_ID);
        }
        #endregion

        #region DECATIVATE_USER_BY_USER_ID
        public void DECATIVATE_USER_BY_USER_ID(long USER_ID)
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            oDalc.DECATIVATE_USER_BY_USER_ID(USER_ID);
        }
        #endregion

        #region GET_USER_BY_EMAIL_AND_PASSWORD
        public User GET_USER_BY_EMAIL_AND_PASSWORD(string EMAIL, string PASSWORD)
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            User oUSER = new User();
            oUSER = oDalc.GET_USER_BY_EMAIL_AND_PASSWORD(EMAIL, PASSWORD);

            return oUSER;
        }
        #endregion

        #region GET_ADDRESS
        public List<Address> GET_ADDRESS()
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            List<Address> oADDRESSES = new List<Address>();
            oADDRESSES = oDalc.GET_ADDRESS();

            return oADDRESSES;
        }
        #endregion

        #region GET_ADDRESS_BY_ADDRESS_ID
        public Address GET_ADDRESS_BY_ADDRESS_ID(Int32 ADDRESS_ID)
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            Address oADDRESS = new Address();
            oADDRESS = oDalc.GET_ADDRESS_BY_ADDRESS_ID(ADDRESS_ID);

            return oADDRESS;
        }
        #endregion

        #region EDIT_ADDRESS
        public Int32 EDIT_ADDRESS(Address i_Address)
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            int RETURNED_ADDRESS_ID = oDalc.EDIT_ADDRESS(i_Address);

            return RETURNED_ADDRESS_ID;
        }
        #endregion

        #region DELETE_ADDRESS
        public void DELETE_ADDRESS(Int32 ADDRESS_ID)
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            oDalc.DELETE_ADDRESS(ADDRESS_ID);
        }
        #endregion

        #region GET_ADDRESS_BY_COUNTRY
        public List<Address> GET_ADDRESS_BY_COUNTRY(string COUNTRY)
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            List<Address> oADDRESSES = new List<Address>();
            oADDRESSES = oDalc.GET_ADDRESS_BY_COUNTRY(COUNTRY);

            return oADDRESSES;
        }
        #endregion

        #region GET_DONATIONS
        public List<Donation> GET_DONATIONS()
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            List<Donation> oDonations = new List<Donation>(); ;
            oDonations = oDalc.GET_DONATIONS();

            return oDonations;
        }
        #endregion

        #region GET_DONATION_BY_DONATION_ID
        public Donation GET_DONATION_BY_DONATION_ID(Int32 DONATION_ID)
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            Donation oDonation = new Donation(); ;
            oDonation = oDalc.GET_DONATION_BY_DONATION_ID(DONATION_ID);

            return oDonation;
        }
        #endregion

        #region GET_DONATION_BY_USER_ID
        public List<Donation> GET_DONATION_BY_USER_ID(Int32 USER_ID)
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            List<Donation> oDonations = new List<Donation>(); ;
            oDonations = oDalc.GET_DONATION_BY_USER_ID(USER_ID);

            return oDonations;
        }
        #endregion

        #region GET_DONATION_BY_ITEM_ID
        public List<Donation> GET_DONATION_BY_ITEM_ID(Int32 ITEM_ID)
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            List<Donation> oDonations = new List<Donation>(); ;
            oDonations = oDalc.GET_DONATION_BY_ITEM_ID(ITEM_ID);

            return oDonations;
        }
        #endregion

        #region GET_DONATION_BY_ADDRESS_ID
        public List<Donation> GET_DONATION_BY_ADDRESS_ID(Int32 ADDRESS_ID)
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            List<Donation> oDonations = new List<Donation>();
            oDonations = oDalc.GET_DONATION_BY_ADDRESS_ID(ADDRESS_ID);

            return oDonations;
        }
        #endregion

        #region GET_DONATION_BY_IS_SHIPPED
        public List<Donation> GET_DONATION_BY_IS_SHIPPED()
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            List<Donation> oDonations = new List<Donation>(); ;
            oDonations = oDalc.GET_DONATION_BY_IS_SHIPPED();

            return oDonations;
        }
        #endregion

        #region GET_DONATION_BY_IS_NOT_SHIPPED
        public List<Donation> GET_DONATION_BY_IS_NOT_SHIPPED()
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            List<Donation> oDonations = new List<Donation>(); ;
            oDonations = oDalc.GET_DONATION_BY_IS_NOT_SHIPPED();

            return oDonations;
        }
        #endregion

        #region EDIT_DONATION
        public Int32 EDIT_DONATION(Donation i_Donation)
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            int RETURNED_DONATION_ID = oDalc.EDIT_DONATION(i_Donation);

            return RETURNED_DONATION_ID;
        }
        #endregion

        #region DELETE_DONATION
        public void DELETE_DONATION(Int32 DONATION_ID)
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            oDalc.DELETE_DONATION(DONATION_ID);
        }
        #endregion

        #region DELETE_DONATION
        public void SHIP_DONATION(Int32 DONATION_ID)
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            oDalc.SHIP_DONATION(DONATION_ID);
        }
        #endregion
    }
}
