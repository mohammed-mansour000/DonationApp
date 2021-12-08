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
        string ConnectionString = @"Data Source=DESKTOP-S5F8T01\SQLEXPRESS;Initial Catalog=DonationAppDB;Integrated Security=True";

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




        #region Get Catagory
        public List<Category> Get_Category()
        {
            string query = "UPG_GET_CATEGORY";
            List<Category> oList = new List<Category>();

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
                            Category oCatagory = new Category();
                            oCatagory.CATAGORY_ID = Convert.ToInt32(item["CATEGORY_ID"]);
                            oCatagory.NAME = item["NAME"].ToString();
                            oCatagory.DESCRIPTION = item["DESCRIPTION"].ToString();
                            oCatagory.ENTRY_DATE = Convert.ToDateTime(item["ENTRY_DATE"]);
                 
                            oList.Add(oCatagory);
                        }
                    }
                }

            }

            return oList;
        }


        #endregion Get Catagory

        #region Get Catagory By Id
        public Category GET_CATEGORY_BY_ID(Int32 cId)
        {

            string query = "UPG_GET_CATEGORY_BY_CATEGORY_ID " ;
            Category c = new Category();

            using (SqlConnection _con = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {

                    _cmd.Parameters.Add("CATEGORY_ID", SqlDbType.Int);
                    _cmd.Parameters["CATEGORY_ID"].Value = cId;

                    _cmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                    _dap.Fill(dt);


                    if (dt.Rows != null)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            c.CATAGORY_ID = Convert.ToInt32(item["CATEGORY_ID"]);
                            c.NAME = item["NAME"].ToString();
                            c.DESCRIPTION = item["DESCRIPTION"].ToString();
                            c.ENTRY_DATE = Convert.ToDateTime(item["ENTRY_DATE"]);

                           
                        }
                    }
                }

            }

            return c;
        }
        #endregion

        #region delete Catagory
        public void DELETE_CATEGORY(Int32 cId)
        {

            string query = "UPG_DELETE_CATEGORY_BY_CATEGORY_ID";

            using (SqlConnection _con = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;

                    _cmd.Parameters.Add("CATEGORY_ID", SqlDbType.Int);
                    _cmd.Parameters["CATEGORY_ID"].Value = cId;

                    _con.Open();
                    _cmd.ExecuteNonQuery();
                    _con.Close();
                }

            }

        }
        #endregion


        #region Edit Catagory
        public void EDIT_CATEGORY(Category category)
        {

            string query = "UPG_EDIT_CATEGORY";

            using (SqlConnection _con = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;

                    _cmd.Parameters.Add("@CATEGORY_ID", SqlDbType.Int);
                    _cmd.Parameters["@CATEGORY_ID"].Value = category.CATAGORY_ID;

                    _cmd.Parameters.Add("@NAME", SqlDbType.NVarChar);
                    _cmd.Parameters["@NAME"].Value = category.NAME;

                    _cmd.Parameters.Add("@DESCRIPTION", SqlDbType.NVarChar);
                    _cmd.Parameters["@DESCRIPTION"].Value = category.DESCRIPTION;

                    _cmd.Parameters.Add("@ENTRY_DATE", SqlDbType.DateTime);
                    _cmd.Parameters["@ENTRY_DATE"].Value = category.ENTRY_DATE;

                    _con.Open();
                    _cmd.ExecuteNonQuery();
                    _con.Close();
                }

            }

        }

        #endregion

        #region Get Items
        public List<Item> GET_ITEMS()
        {
            string query = "UPG_GET_ITEMS";
            List<Item> oList = new List<Item>();

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
                            Item oItem = new Item();
                            oItem.ITEM_ID = Convert.ToInt32(item["ITEM_ID"]);
                            oItem.NAME = item["ItemName"].ToString();
                            oItem.DESCRIPTION = item["ItemDescription"].ToString();
                            oItem.ENTRY_DATE = Convert.ToDateTime(item["ItemEntryDate"]);
                            oItem.IS_ACTIVE = (bool?)item["IS_ACTIVE"];
                            oItem.CATAGORY = new Category();
                            oItem.CATAGORY.CATAGORY_ID = Convert.ToInt32(item["CATEGORY_ID"]);
                            oItem.CATAGORY.NAME= item["CatagoryName"].ToString();
                            oItem.CATAGORY.DESCRIPTION= item["CatagoryDescription"].ToString();
                            oItem.CATAGORY.ENTRY_DATE= Convert.ToDateTime(item["CatagoryEntryDate"]);

                            oList.Add(oItem);
                        }
                    }
                }

            }

            return oList;
        }


        #endregion Get Catagory

        #region Get Item By Id
        public Item GET_ITEM_BY_ID(Int32 iId)
        {

            string query = "UPG_GET_ITEM_BY_ITEM_ID ";
            Item oItem = new Item();

            using (SqlConnection _con = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {

                    _cmd.Parameters.Add("ITEM_ID", SqlDbType.Int);
                    _cmd.Parameters["ITEM_ID"].Value = iId;

                    _cmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                    _dap.Fill(dt);


                    if (dt.Rows != null)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            oItem.ITEM_ID = Convert.ToInt32(item["ITEM_ID"]);
                            oItem.NAME = item["ItemName"].ToString();
                            oItem.DESCRIPTION = item["ItemDescription"].ToString();
                            oItem.ENTRY_DATE = Convert.ToDateTime(item["ItemEntryDate"]);
                            oItem.IS_ACTIVE = (bool?)item["IS_ACTIVE"];
                            oItem.CATAGORY = new Category();
                            oItem.CATAGORY.CATAGORY_ID = Convert.ToInt32(item["CATEGORY_ID"]);
                            oItem.CATAGORY.NAME = item["CatagoryName"].ToString();
                            oItem.CATAGORY.DESCRIPTION = item["CatagoryDescription"].ToString();
                            oItem.CATAGORY.ENTRY_DATE = Convert.ToDateTime(item["CatagoryEntryDate"]);


                        }
                    }
                }

            }

            return oItem;
        }
        #endregion

    }
}
