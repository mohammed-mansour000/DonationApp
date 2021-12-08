using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using static DALC.IDALC;

namespace DALC
{
    public class DALC
    {
        string ConnectionString = @"Data Source=DESKTOP-FI4HSGV\MANSURSQL;Initial Catalog=DonationAppDB;Integrated Security=True";

        #region Get Users
        public List<User> Get_Users()
        {
            string query = "UPG_GET_USERS";
            List<User> oList = new List<User>();

            using (SqlConnection _con = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {
                  

                    _cmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                    _dap.Fill(dt);


                    if (dt.Rows != null)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            User oUser = new User();
                            oUser.USER_ID = Convert.ToInt64(item["USER_ID"]);
                            oUser.FIRST_NAME = item["FIRST_NAME"].ToString();
                            oUser.LAST_NAME = item["LAST_NAME"].ToString();
                            oUser.EMAIL = item["EMAIL"].ToString();
                            oUser.PHONE = item["PHONE"].ToString();
                            oUser.USER_TYPE_CODE = item["USER_TYPE_CODE"].ToString();
                            oUser.IS_ACTIVE = (bool?)item["IS_ACTIVE"];
                            oUser.ENTRY_DATE = Convert.ToDateTime(item["ENTRY_DATE"]);
                            oList.Add(oUser);
                        }
                    }
                }
                
            }

            return oList;
        }
        #endregion

        #region GET_USER_BY_USER_ID
        public User GET_USER_BY_USER_ID(long USER_ID)
        {
            string query = "UPG_GET_USER_BY_USER_ID";
            User oUser = new User();

            using (SqlConnection _con = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {


                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("USER_ID", SqlDbType.Int);
                    _cmd.Parameters["USER_ID"].Value = USER_ID;
                    DataTable dt = new DataTable();
                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                    _dap.Fill(dt);


                    if (dt.Rows != null)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                           
                            oUser.USER_ID = Convert.ToInt64(item["USER_ID"]);
                            oUser.FIRST_NAME = item["FIRST_NAME"].ToString();
                            oUser.LAST_NAME = item["LAST_NAME"].ToString();
                            oUser.EMAIL = item["EMAIL"].ToString();
                            oUser.PHONE = item["PHONE"].ToString();
                            oUser.USER_TYPE_CODE = item["USER_TYPE_CODE"].ToString();
                            oUser.IS_ACTIVE = (bool?)item["IS_ACTIVE"];
                            oUser.ENTRY_DATE = Convert.ToDateTime(item["ENTRY_DATE"]);
                            
                        }
                    }
                }

            }

            return oUser;
        }
        #endregion

        #region EDIT_USER
        public void EDIT_USER(User i_User)
        {
            string query = "UPG_EDIT_USER";

            using (SqlConnection _con = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {


                    _cmd.CommandType = CommandType.StoredProcedure;

                    _cmd.Parameters.Add("USER_ID", SqlDbType.Int);
                    _cmd.Parameters["USER_ID"].Value = i_User.USER_ID;

                    _cmd.Parameters.Add("FIRST_NAME", SqlDbType.NVarChar);
                    _cmd.Parameters["FIRST_NAME"].Value = i_User.FIRST_NAME;

                    _cmd.Parameters.Add("LAST_NAME", SqlDbType.NVarChar);
                    _cmd.Parameters["LAST_NAME"].Value = i_User.LAST_NAME;

                    _cmd.Parameters.Add("EMAIL", SqlDbType.NVarChar);
                    _cmd.Parameters["EMAIL"].Value = i_User.EMAIL;

                    _cmd.Parameters.Add("PASSWORD", SqlDbType.NVarChar);
                    _cmd.Parameters["PASSWORD"].Value = i_User.PASSWORD;

                    _cmd.Parameters.Add("ENTRY_DATE", SqlDbType.Date);
                    _cmd.Parameters["ENTRY_DATE"].Value = i_User.ENTRY_DATE;

                    _cmd.Parameters.Add("PHONE", SqlDbType.NVarChar);
                    _cmd.Parameters["PHONE"].Value = i_User.PHONE;

                    _cmd.Parameters.Add("IS_ACTIVE", SqlDbType.Bit);
                    _cmd.Parameters["IS_ACTIVE"].Value = i_User.IS_ACTIVE;

                    _cmd.Parameters.Add("USER_TYPE_CODE", SqlDbType.NVarChar);
                    _cmd.Parameters["USER_TYPE_CODE"].Value = i_User.USER_TYPE_CODE;

                    _con.Open();
                    _cmd.ExecuteNonQuery();
                    _con.Close();

                }

            }

        }
        #endregion

        #region DELETE_USER_BY_USER_ID
        public void DELETE_USER_BY_USER_ID(long USER_ID)
        {
            string query = "UPG_DELETE_USER_BY_USER_ID";

            using (SqlConnection _con = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {


                    _cmd.CommandType = CommandType.StoredProcedure;

                    _cmd.Parameters.Add("USER_ID", SqlDbType.Int);
                    _cmd.Parameters["USER_ID"].Value = USER_ID;

                    _con.Open();
                    _cmd.ExecuteNonQuery();
                    _con.Close();

                }

            }

        }
        #endregion

        #region DELETE_USER_BY_USER_ID
        public void DECATIVATE_USER_BY_USER_ID(long USER_ID)
        {
            string query = "UPG_DECATIVATE_USER_BY_USER_ID";

            using (SqlConnection _con = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {


                    _cmd.CommandType = CommandType.StoredProcedure;

                    _cmd.Parameters.Add("USER_ID", SqlDbType.Int);
                    _cmd.Parameters["USER_ID"].Value = USER_ID;

                    _con.Open();
                    _cmd.ExecuteNonQuery();
                    _con.Close();

                }

            }

        }
        #endregion

        #region GET_USER_BY_EMAIL_AND_PASSWORD
        public User GET_USER_BY_EMAIL_AND_PASSWORD(string EMAIL, string PASSWORD)
        {
            string query = "UPG_GET_USER_BY_EMAIL_AND_PASSWORD";
            User oUser = new User();

            using (SqlConnection _con = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {


                    _cmd.CommandType = CommandType.StoredProcedure;

                    _cmd.Parameters.Add("EMAIL", SqlDbType.NVarChar);
                    _cmd.Parameters["EMAIL"].Value = EMAIL;

                    _cmd.Parameters.Add("PASSWORD", SqlDbType.NVarChar);
                    _cmd.Parameters["PASSWORD"].Value = PASSWORD;

                    DataTable dt = new DataTable();
                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                    _dap.Fill(dt);


                    if (dt.Rows != null)
                    {
                        foreach (DataRow item in dt.Rows)
                        {

                            oUser.USER_ID = Convert.ToInt64(item["USER_ID"]);
                            oUser.FIRST_NAME = item["FIRST_NAME"].ToString();
                            oUser.LAST_NAME = item["LAST_NAME"].ToString();
                            oUser.EMAIL = item["EMAIL"].ToString();
                            oUser.PHONE = item["PHONE"].ToString();
                            oUser.USER_TYPE_CODE = item["USER_TYPE_CODE"].ToString();
                            oUser.IS_ACTIVE = (bool?)item["IS_ACTIVE"];
                            oUser.ENTRY_DATE = Convert.ToDateTime(item["ENTRY_DATE"]);

                        }
                    }

                }

            }
            return oUser;
        }
        #endregion

        #region GET_ADDRESS
        public List<Address> GET_ADDRESS()
        {
            string query = "UPG_GET_ADDRESS";
            List<Address> oList = new List<Address>();

            using (SqlConnection _con = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {


                    _cmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                    _dap.Fill(dt);


                    if (dt.Rows != null)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            Address oAddress = new Address();
                            oAddress.ADDRESS_ID = Convert.ToInt32(item["ADDRESS_ID"]);
                            oAddress.COUNTRY= item["COUNTRY"].ToString();
                            oAddress.CITY = item["CITY"].ToString();
                            oAddress.STREET = item["STREET"].ToString();
                            oAddress.LATIDUTE = (decimal)item["LATIDUTE"];
                            oAddress.LANGITUDE = (decimal)item["LANGITUDE"];
                            oList.Add(oAddress);
                        }
                    }
                }

            }

            return oList;
        }
        #endregion

        #region GET_ADDRESS_BY_ADDRESS_ID
        public Address GET_ADDRESS_BY_ADDRESS_ID(Int32 ADDRESS_ID)
        {
            string query = "UPG_GET_ADDRESS_BY_ADDRESS_ID";
            Address oAddress = new Address();

            using (SqlConnection _con = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {


                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("ADDRESS_ID", SqlDbType.Int);
                    _cmd.Parameters["ADDRESS_ID"].Value = ADDRESS_ID;
                    DataTable dt = new DataTable();
                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                    _dap.Fill(dt);


                    if (dt.Rows != null)
                    {
                        foreach (DataRow item in dt.Rows)
                        {

                            oAddress.ADDRESS_ID = Convert.ToInt32(item["ADDRESS_ID"]);
                            oAddress.COUNTRY = item["COUNTRY"].ToString();
                            oAddress.CITY = item["CITY"].ToString();
                            oAddress.STREET = item["STREET"].ToString();
                            oAddress.LATIDUTE = (decimal)item["LATIDUTE"];
                            oAddress.LANGITUDE = (decimal)item["LANGITUDE"];

                        }
                    }
                }

            }

            return oAddress;
        }
        #endregion

        #region EDIT_ADDRESS
        public void EDIT_ADDRESS(Address i_Address)
        {
            string query = "UPG_EDIT_ADDRESS";

            using (SqlConnection _con = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {


                    _cmd.CommandType = CommandType.StoredProcedure;

                    _cmd.Parameters.Add("ADDRESS_ID", SqlDbType.Int);
                    _cmd.Parameters["ADDRESS_ID"].Value = i_Address.ADDRESS_ID;

                    _cmd.Parameters.Add("CITY", SqlDbType.NVarChar);
                    _cmd.Parameters["CITY"].Value = i_Address.CITY;

                    _cmd.Parameters.Add("COUNTRY", SqlDbType.NVarChar);
                    _cmd.Parameters["COUNTRY"].Value = i_Address.COUNTRY;

                    _cmd.Parameters.Add("STREET", SqlDbType.NVarChar);
                    _cmd.Parameters["STREET"].Value = i_Address.STREET;

                    _cmd.Parameters.Add("LANGITUDE", SqlDbType.Decimal);
                    _cmd.Parameters["LANGITUDE"].Value = i_Address.LANGITUDE;

                    _cmd.Parameters.Add("LATIDUTE", SqlDbType.Decimal);
                    _cmd.Parameters["LATIDUTE"].Value = i_Address.LATIDUTE;


                    _con.Open();
                    _cmd.ExecuteNonQuery();
                    _con.Close();

                }

            }

        }
        #endregion

        #region DELETE_ADDRESS
        public void DELETE_ADDRESS(Int32 ADDRESS_ID)
        {
            string query = "UPG_DELETE_ADDRESS";

            using (SqlConnection _con = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {


                    _cmd.CommandType = CommandType.StoredProcedure;

                    _cmd.Parameters.Add("ADDRESS_ID", SqlDbType.Int);
                    _cmd.Parameters["ADDRESS_ID"].Value = ADDRESS_ID;

                    _con.Open();
                    _cmd.ExecuteNonQuery();
                    _con.Close();

                }

            }

        }
        #endregion

        #region GET_ADDRESS_BY_COUNTRY
        public List<Address> GET_ADDRESS_BY_COUNTRY(string COUNTRY)
        {
            string query = "UPG_GET_ADDRESS_BY_COUNTRY";
            List<Address> oList = new List<Address>();

            using (SqlConnection _con = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {


                    _cmd.CommandType = CommandType.StoredProcedure;

                    _cmd.Parameters.Add("COUNTRY", SqlDbType.NVarChar);
                    _cmd.Parameters["COUNTRY"].Value = COUNTRY;

                    DataTable dt = new DataTable();
                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                    _dap.Fill(dt);


                    if (dt.Rows != null)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            Address oAddress = new Address();
                            oAddress.ADDRESS_ID = Convert.ToInt32(item["ADDRESS_ID"]);
                            oAddress.COUNTRY = item["COUNTRY"].ToString();
                            oAddress.CITY = item["CITY"].ToString();
                            oAddress.STREET = item["STREET"].ToString();
                            oAddress.LATIDUTE = (decimal)item["LATIDUTE"];
                            oAddress.LANGITUDE = (decimal)item["LANGITUDE"];
                            oList.Add(oAddress);
                        }
                    }
                }

            }

            return oList;
        }
        #endregion
    }
}
