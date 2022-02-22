using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static DALC.IDALC;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        IConfiguration _config;
        BLC.BLC _blc;
        private readonly IWebHostEnvironment _env; //for photos
        public DataController(IConfiguration config, IWebHostEnvironment env) //in order to use variables inside appsettings.json --its dependency injection
        {
            _config = config;
            _blc = new BLC.BLC(config);
            _blc.ConnectionString = _config.GetConnectionString("DonationAppDB");
            _env = env;
        }

        [Route("Get_Users")]
        [HttpGet]
        public Result_Get_Users Get_Users()
        {
            Result_Get_Users oResult_Get_Users = new Result_Get_Users();
            try
            {
                oResult_Get_Users.users = new List<User>();
                oResult_Get_Users.users = _blc.Get_Users();
                return oResult_Get_Users;
            }
            catch (Exception e)
            {
                oResult_Get_Users.errorMsg = e.Message;
                return oResult_Get_Users;
            }    
        }

        [Route("GET_USER_BY_USER_ID")]
        [HttpPost]
        public Result_Get_User_BY_USER_ID GET_USER_BY_USER_ID(long USER_ID)
        {
            Result_Get_User_BY_USER_ID oResult_Get_User_BY_USER_ID = new Result_Get_User_BY_USER_ID();
            try
            {
                oResult_Get_User_BY_USER_ID.user = new User();
                oResult_Get_User_BY_USER_ID.user = _blc.GET_USER_BY_USER_ID(USER_ID);
                return oResult_Get_User_BY_USER_ID;
            }
            catch (Exception e)
            {
                oResult_Get_User_BY_USER_ID.errorMsg = e.Message;
                oResult_Get_User_BY_USER_ID.user = null;
                return oResult_Get_User_BY_USER_ID;
            }
        }

        [Route("EDIT_USER")]
        [HttpPost]
        public Result_EDIT_USER EDIT_USER(User i_user)
        {
            Result_EDIT_USER oResult_EDIT_USER = new Result_EDIT_USER();
            try
            {
                oResult_EDIT_USER.user = new User();
                oResult_EDIT_USER.user = i_user;
                oResult_EDIT_USER.user.USER_ID = _blc.EDIT_USER(i_user);

                return oResult_EDIT_USER;
            }
            catch (Exception e)
            {
                oResult_EDIT_USER.errorMsg = e.Message;
                oResult_EDIT_USER.user = null;

                return oResult_EDIT_USER;
            }
        }

        [Route("DELETE_USER_BY_USER_ID")]
        [HttpPost]
        public Result_DELETE_USER_BY_USER_ID DELETE_USER_BY_USER_ID(long USER_ID)
        {
            Result_DELETE_USER_BY_USER_ID oResult_DELETE_USER_BY_USER_ID = new Result_DELETE_USER_BY_USER_ID();
            try
            {
                Console.WriteLine(Convert.ToInt32(USER_ID) + " from api");
                _blc.DELETE_USER_BY_USER_ID(USER_ID);
                oResult_DELETE_USER_BY_USER_ID.Msg = "User Deleted!!";
                return oResult_DELETE_USER_BY_USER_ID;
            }
            catch (Exception e)
            {
                oResult_DELETE_USER_BY_USER_ID.errorMsg = e.Message;
                return oResult_DELETE_USER_BY_USER_ID;
            }
        }

        [Route("DECATIVATE_USER_BY_USER_ID")]
        [HttpPost]
        public Result_DECATIVATE_USER_BY_USER_ID DECATIVATE_USER_BY_USER_ID(Params_DECATIVATE_USER_BY_USER_ID oParams_DECATIVATE_USER_BY_USER_ID)
        {
            Result_DECATIVATE_USER_BY_USER_ID oResult_DECATIVATE_USER_BY_USER_ID = new Result_DECATIVATE_USER_BY_USER_ID();
            try
            {
                _blc.DECATIVATE_USER_BY_USER_ID(oParams_DECATIVATE_USER_BY_USER_ID.USER_ID, oParams_DECATIVATE_USER_BY_USER_ID.IS_ACTIVE);
                if (oParams_DECATIVATE_USER_BY_USER_ID.IS_ACTIVE == 0)
                {

                    oResult_DECATIVATE_USER_BY_USER_ID.Msg = "User Deactivated!!";

                }
                else
                {
                    oResult_DECATIVATE_USER_BY_USER_ID.Msg = "User activated!!";

                }
                return oResult_DECATIVATE_USER_BY_USER_ID;
            }
            catch (Exception e)
            {
                oResult_DECATIVATE_USER_BY_USER_ID.errorMsg = e.Message;
                return oResult_DECATIVATE_USER_BY_USER_ID;
            }
        }

        [Route("GET_USER_BY_EMAIL_AND_PASSWORD")]
        [HttpPost]
        public Result_GET_USER_BY_EMAIL_AND_PASSWORD GET_USER_BY_EMAIL_AND_PASSWORD(Params_GET_USER_BY_EMAIL_AND_PASSWORD o_params)
        {
            Result_GET_USER_BY_EMAIL_AND_PASSWORD oResult_GET_USER_BY_EMAIL_AND_PASSWORD = new Result_GET_USER_BY_EMAIL_AND_PASSWORD();
            try
            {
                Console.WriteLine(o_params.EMAIL, o_params.PASSWORD);
                oResult_GET_USER_BY_EMAIL_AND_PASSWORD.user = new User();
                oResult_GET_USER_BY_EMAIL_AND_PASSWORD.user = _blc.GET_USER_BY_EMAIL_AND_PASSWORD(o_params.EMAIL, o_params.PASSWORD);
                
                return oResult_GET_USER_BY_EMAIL_AND_PASSWORD;
            }
            catch (Exception e)
            {
                oResult_GET_USER_BY_EMAIL_AND_PASSWORD.errorMsg = e.Message;
                oResult_GET_USER_BY_EMAIL_AND_PASSWORD.user = null;
                return oResult_GET_USER_BY_EMAIL_AND_PASSWORD;
            }
        }

        [Route("GET_ADDRESS")]
        [HttpGet]
        public Result_GET_ADDRESS GET_ADDRESS()
        {
            Result_GET_ADDRESS oResult_GET_ADDRESS = new Result_GET_ADDRESS();
            try
            {
                oResult_GET_ADDRESS.addresses = new List<Address>();
                oResult_GET_ADDRESS.addresses = _blc.GET_ADDRESS();
                return oResult_GET_ADDRESS;
            }
            catch (Exception e)
            {
                oResult_GET_ADDRESS.errorMsg = e.Message;
                return oResult_GET_ADDRESS;
            }
        }

        [Route("GET_ADDRESS_BY_ADDRESS_ID")]
        [HttpPost]
        public Result_GET_ADDRESS_BY_ADDRESS_ID GET_ADDRESS_BY_ADDRESS_ID(Int32 ADDRESS_ID)
        {
            Result_GET_ADDRESS_BY_ADDRESS_ID oResult_GET_ADDRESS_BY_ADDRESS_ID = new Result_GET_ADDRESS_BY_ADDRESS_ID();
            try
            {
                oResult_GET_ADDRESS_BY_ADDRESS_ID.address = new Address();
                oResult_GET_ADDRESS_BY_ADDRESS_ID.address = _blc.GET_ADDRESS_BY_ADDRESS_ID(ADDRESS_ID);
                return oResult_GET_ADDRESS_BY_ADDRESS_ID;
            }
            catch (Exception e)
            {
                oResult_GET_ADDRESS_BY_ADDRESS_ID.errorMsg = e.Message;
                oResult_GET_ADDRESS_BY_ADDRESS_ID.address = null;
                return oResult_GET_ADDRESS_BY_ADDRESS_ID;
            }
        }

        [Route("EDIT_ADDRESS")]
        [HttpPost]
        public Result_EDIT_ADDRESS EDIT_ADDRESS(Address i_address)
        {
            Result_EDIT_ADDRESS oResult_EDIT_ADDRESS = new Result_EDIT_ADDRESS();
            try
            {
                oResult_EDIT_ADDRESS.address = new Address();
                oResult_EDIT_ADDRESS.address = i_address;
                oResult_EDIT_ADDRESS.address.ADDRESS_ID = _blc.EDIT_ADDRESS(i_address);

                return oResult_EDIT_ADDRESS;
            }
            catch (Exception e)
            {
                oResult_EDIT_ADDRESS.errorMsg = e.Message;
                oResult_EDIT_ADDRESS.address = null;

                return oResult_EDIT_ADDRESS;
            }
        }

        [Route("DELETE_ADDRESS")]
        [HttpPost]
        public Result_DELETE_ADDRESS DELETE_ADDRESS(Int32 ADDRESS_ID)
        {
            Result_DELETE_ADDRESS oResult_DELETE_ADDRESS = new Result_DELETE_ADDRESS();
            try
            {
                _blc.DELETE_ADDRESS(ADDRESS_ID);
                oResult_DELETE_ADDRESS.Msg = "Address Deleted!!";
                return oResult_DELETE_ADDRESS;
            }
            catch (Exception e)
            {
                oResult_DELETE_ADDRESS.errorMsg = e.Message;
                return oResult_DELETE_ADDRESS;
            }
        }

        [Route("GET_ADDRESS_BY_COUNTRY")]
        [HttpPost]
        public Result_GET_ADDRESS_BY_COUNTRY GET_ADDRESS_BY_COUNTRY(string COUNTRY)
        {
            Result_GET_ADDRESS_BY_COUNTRY oResult_GET_ADDRESS_BY_COUNTRY = new Result_GET_ADDRESS_BY_COUNTRY();
            try
            {
                oResult_GET_ADDRESS_BY_COUNTRY.addresses = new List<Address>();
                oResult_GET_ADDRESS_BY_COUNTRY.addresses = _blc.GET_ADDRESS_BY_COUNTRY(COUNTRY);
                return oResult_GET_ADDRESS_BY_COUNTRY;
            }
            catch (Exception e)
            {
                oResult_GET_ADDRESS_BY_COUNTRY.errorMsg = e.Message;
                return oResult_GET_ADDRESS_BY_COUNTRY;
            }
        }

        [Route("GET_DONATIONS")]
        [HttpGet]
        public Result_GET_DONATIONS GET_DONATIONS()
        {
            Result_GET_DONATIONS oResult_GET_DONATIONS = new Result_GET_DONATIONS();
            try
            {
                oResult_GET_DONATIONS.donations = new List<Donation>();
                oResult_GET_DONATIONS.donations = _blc.GET_DONATIONS();
                return oResult_GET_DONATIONS;
            }
            catch (Exception e)
            {
                oResult_GET_DONATIONS.errorMsg = e.Message;
                return oResult_GET_DONATIONS;
            }
        }

        [Route("GET_DONATION_BY_DONATION_ID")]
        [HttpPost]
        public Result_GET_DONATION_BY_DONATION_ID GET_DONATION_BY_DONATION_ID(Int32 DONATION_ID)
        {
            Result_GET_DONATION_BY_DONATION_ID oResult_GET_DONATION_BY_DONATION_ID = new Result_GET_DONATION_BY_DONATION_ID();
            try
            {
                oResult_GET_DONATION_BY_DONATION_ID.donation = new Donation();
                oResult_GET_DONATION_BY_DONATION_ID.donation = _blc.GET_DONATION_BY_DONATION_ID(DONATION_ID);
                return oResult_GET_DONATION_BY_DONATION_ID;
            }
            catch (Exception e)
            {
                oResult_GET_DONATION_BY_DONATION_ID.errorMsg = e.Message;
                oResult_GET_DONATION_BY_DONATION_ID.donation = null;
                return oResult_GET_DONATION_BY_DONATION_ID;
            }
        }

        [Route("GET_DONATION_BY_USER_ID")]
        [HttpPost]
        public Result_GET_DONATION_BY_USER_ID GET_DONATION_BY_USER_ID(Params_GET_DONATION_BY_USER_ID oParams_GET_DONATION_BY_USER_ID)
        {
            Result_GET_DONATION_BY_USER_ID oResult_GET_DONATION_BY_USER_ID = new Result_GET_DONATION_BY_USER_ID();
            try
            {
                oResult_GET_DONATION_BY_USER_ID.donations = new List<Donation>();
                oResult_GET_DONATION_BY_USER_ID.donations = _blc.GET_DONATION_BY_USER_ID(oParams_GET_DONATION_BY_USER_ID.USER_ID);
                return oResult_GET_DONATION_BY_USER_ID;
            }
            catch (Exception e)
            {
                oResult_GET_DONATION_BY_USER_ID.errorMsg = e.Message;
                return oResult_GET_DONATION_BY_USER_ID;
            }
        }

        [Route("GET_DONATION_BY_ITEM_ID")]
        [HttpPost]
        public Result_GET_DONATION_BY_ITEM_ID GET_DONATION_BY_ITEM_ID(Params_GET_DONATION_BY_ITEM_ID oParams_GET_DONATION_BY_ITEM_ID)
        {
            Result_GET_DONATION_BY_ITEM_ID oResult_GET_DONATION_BY_ITEM_ID = new Result_GET_DONATION_BY_ITEM_ID();
            try
            {
                oResult_GET_DONATION_BY_ITEM_ID.donations = new List<Donation>();
                oResult_GET_DONATION_BY_ITEM_ID.donations = _blc.GET_DONATION_BY_ITEM_ID(oParams_GET_DONATION_BY_ITEM_ID.ITEM_ID);
                return oResult_GET_DONATION_BY_ITEM_ID;
            }
            catch (Exception e)
            {
                oResult_GET_DONATION_BY_ITEM_ID.errorMsg = e.Message;
                return oResult_GET_DONATION_BY_ITEM_ID;
            }
        }

        [Route("GET_DONATION_BY_ADDRESS_ID")]
        [HttpPost]
        public Result_GET_DONATION_BY_ADDRESS_ID GET_DONATION_BY_ADDRESS_ID(Params_GET_DONATION_BY_ADDRESS_ID oParams_GET_DONATION_BY_ADDRESS_ID)
        {
            Result_GET_DONATION_BY_ADDRESS_ID oResult_GET_DONATION_BY_ADDRESS_ID = new Result_GET_DONATION_BY_ADDRESS_ID();
            try
            {
                oResult_GET_DONATION_BY_ADDRESS_ID.donations = new List<Donation>();
                oResult_GET_DONATION_BY_ADDRESS_ID.donations = _blc.GET_DONATION_BY_ADDRESS_ID(oParams_GET_DONATION_BY_ADDRESS_ID.ADDRESS_ID);
                return oResult_GET_DONATION_BY_ADDRESS_ID;
            }
            catch (Exception e)
            {
                oResult_GET_DONATION_BY_ADDRESS_ID.errorMsg = e.Message;
                return oResult_GET_DONATION_BY_ADDRESS_ID;
            }
        }

        [Route("GET_DONATION_BY_IS_SHIPPED")]
        [HttpGet]
        public Result_GET_DONATION_BY_IS_SHIPPED GET_DONATION_BY_IS_SHIPPED()
        {
            Result_GET_DONATION_BY_IS_SHIPPED oResult_GET_DONATION_BY_IS_SHIPPED = new Result_GET_DONATION_BY_IS_SHIPPED();
            try
            {
                oResult_GET_DONATION_BY_IS_SHIPPED.donations = new List<Donation>();
                oResult_GET_DONATION_BY_IS_SHIPPED.donations = _blc.GET_DONATION_BY_IS_SHIPPED();
                return oResult_GET_DONATION_BY_IS_SHIPPED;
            }
            catch (Exception e)
            {
                oResult_GET_DONATION_BY_IS_SHIPPED.errorMsg = e.Message;
                return oResult_GET_DONATION_BY_IS_SHIPPED;
            }
        }

        [Route("GET_DONATION_BY_IS_NOT_SHIPPED")]
        [HttpGet]
        public Result_GET_DONATION_BY_IS_NOT_SHIPPED GET_DONATION_BY_IS_NOT_SHIPPED()
        {
            Result_GET_DONATION_BY_IS_NOT_SHIPPED oResult_GET_DONATION_BY_IS_NOT_SHIPPED = new Result_GET_DONATION_BY_IS_NOT_SHIPPED();
            try
            {
                oResult_GET_DONATION_BY_IS_NOT_SHIPPED.donations = new List<Donation>();
                oResult_GET_DONATION_BY_IS_NOT_SHIPPED.donations = _blc.GET_DONATION_BY_IS_NOT_SHIPPED();
                return oResult_GET_DONATION_BY_IS_NOT_SHIPPED;
            }
            catch (Exception e)
            {
                oResult_GET_DONATION_BY_IS_NOT_SHIPPED.errorMsg = e.Message;
                return oResult_GET_DONATION_BY_IS_NOT_SHIPPED;
            }
        }

        [Route("EDIT_DONATION")]
        [HttpPost]
        public Result_EDIT_DONATION EDIT_DONATION(Donation i_donation)
        {
            Result_EDIT_DONATION oResult_EDIT_DONATION = new Result_EDIT_DONATION();
            try
            {
                oResult_EDIT_DONATION.donation = new Donation();
                oResult_EDIT_DONATION.donation = i_donation;
                oResult_EDIT_DONATION.donation.DONATION_ID = _blc.EDIT_DONATION(i_donation);

                return oResult_EDIT_DONATION;
            }
            catch (Exception e)
            {
                oResult_EDIT_DONATION.errorMsg = e.Message;
                oResult_EDIT_DONATION.donation = null;

                return oResult_EDIT_DONATION;
            }
        }

        [Route("DELETE_DONATION")]
        [HttpPost]
        public Result_DELETE_DONATION DELETE_DONATION(Int32 DONATION_ID)
        {
            Result_DELETE_DONATION oResult_DELETE_DONATION = new Result_DELETE_DONATION();
            try
            {
                _blc.DELETE_DONATION(DONATION_ID);
                oResult_DELETE_DONATION.Msg = "Donation Deleted!!";
                return oResult_DELETE_DONATION;
            }
            catch (Exception e)
            {
                oResult_DELETE_DONATION.errorMsg = e.Message;
                return oResult_DELETE_DONATION;
            }
        }

        [Route("SHIP_DONATION")]
        [HttpPost]
        public Result_SHIP_DONATION SHIP_DONATION(Params_SHIP_DONATION oParams_SHIP_DONATION)
        {
            Result_SHIP_DONATION oResult_SHIP_DONATION = new Result_SHIP_DONATION();
            try
            {
<<<<<<< HEAD
                _blc.SHIP_DONATION(oParams_SHIP_DONATION.DONATION_ID, oParams_SHIP_DONATION.IS_SHIPPED, oParams_SHIP_DONATION.EMAIL);
=======
                _blc.SHIP_DONATION(oParams_SHIP_DONATION.DONATION_ID, oParams_SHIP_DONATION.IS_SHIPPED);
>>>>>>> origin/temp004

                if (oParams_SHIP_DONATION.IS_SHIPPED == 0)
                {

                    oResult_SHIP_DONATION.Msg = "Donation Unshipped!!";

                }
                else
                {
                    oResult_SHIP_DONATION.Msg = "Donation Shipped!!";

                }
                return oResult_SHIP_DONATION;
            }
            catch (Exception e)
            {
                oResult_SHIP_DONATION.errorMsg = e.Message;
                return oResult_SHIP_DONATION;
            }
        }


        #region category

        [Route("Get_Category")]
        [HttpGet]
        public Result_Get_Category Get_Category()
        {
            Result_Get_Category oResult_Get_Category = new Result_Get_Category();
            try
            {
                oResult_Get_Category.categories = new List<Category>();
                oResult_Get_Category.categories = _blc.Get_Category();
                return oResult_Get_Category;
            }
            catch (Exception e)
            {
                oResult_Get_Category.errorMsg = e.Message;
                return oResult_Get_Category;
            }
        }

        [Route("GET_CATEGORY_BY_ID")]
        [HttpPost]
        public Result_Get_Category_BY_CategoryId GET_CATEGORY_BY_ID(Int32 CAT_ID)
        {
            Result_Get_Category_BY_CategoryId oResult_Get_Category_BY_CategoryId = new Result_Get_Category_BY_CategoryId();
            try
            {
                oResult_Get_Category_BY_CategoryId.category = new Category();
                oResult_Get_Category_BY_CategoryId.category = _blc.GET_CATEGORY_BY_ID(CAT_ID);
                return oResult_Get_Category_BY_CategoryId;
            }
            catch (Exception e)
            {
                oResult_Get_Category_BY_CategoryId.errorMsg = e.Message;
                oResult_Get_Category_BY_CategoryId.category = null;
                return oResult_Get_Category_BY_CategoryId;
            }
        }

        [Route("DELETE_CATEGORY_BY_CATEGORY_ID")]
        [HttpPost]
        public Result_DELETE_CATEGORY_BY_CATEGORY_ID DELETE_CATEGORY_BY_CATEGORY_ID(Int32 CAT_ID)
        {
            Result_DELETE_CATEGORY_BY_CATEGORY_ID oResult_DELETE_CATEGORY_BY_CATEGORY_ID = new Result_DELETE_CATEGORY_BY_CATEGORY_ID();
            try
            {
                _blc.DELETE_CATEGORY(CAT_ID);
                oResult_DELETE_CATEGORY_BY_CATEGORY_ID.Msg = "Category Deleted!!";
                return oResult_DELETE_CATEGORY_BY_CATEGORY_ID;
            }
            catch (Exception e)
            {
                oResult_DELETE_CATEGORY_BY_CATEGORY_ID.errorMsg = e.Message;
                return oResult_DELETE_CATEGORY_BY_CATEGORY_ID;
            }
        }

        [Route("EDIT_CATEGORY")]
        [HttpPost]
        public Result_EDIT_CATEGORY EDIT_CATEGORY(Category i_Category)
        {
            Result_EDIT_CATEGORY oResult_EDIT_CATEGORY = new Result_EDIT_CATEGORY();
            try
            {
                oResult_EDIT_CATEGORY.category = new Category();
                oResult_EDIT_CATEGORY.category = i_Category;
                oResult_EDIT_CATEGORY.category.CATAGORY_ID = _blc.EDIT_CATEGORY(i_Category);

                return oResult_EDIT_CATEGORY;
            }
            catch (Exception e)
            {
                oResult_EDIT_CATEGORY.errorMsg = e.Message;
                oResult_EDIT_CATEGORY.category = null;

                return oResult_EDIT_CATEGORY;
            }
        }

        #endregion


        #region Item


        [Route("Get_ITEMS")]
        [HttpGet]
        public Result_Get_Items Get_ITEMS()
        {
            Result_Get_Items oResult_Get_Items = new Result_Get_Items();
            try
            {
                oResult_Get_Items.items = new List<Item>();
                oResult_Get_Items.items = _blc.Get_ITEMS();
                return oResult_Get_Items;
            }
            catch (Exception e)
            {
                oResult_Get_Items.errorMsg = e.Message;
                return oResult_Get_Items;
            }
        }

        [Route("GET_ITEM_BY_ID")]
        [HttpPost]
        public Result_Get_Item_BY_Item_ID GET_ITEM_BY_ID(Int32 ITEM_ID)
        {
            Result_Get_Item_BY_Item_ID oResult_Get_Item_BY_Item_ID = new Result_Get_Item_BY_Item_ID();
            try
            {
                oResult_Get_Item_BY_Item_ID.item = new Item();
                oResult_Get_Item_BY_Item_ID.item = _blc.GET_ITEM_BY_ID(ITEM_ID);
                return oResult_Get_Item_BY_Item_ID;
            }
            catch (Exception e)
            {
                oResult_Get_Item_BY_Item_ID.errorMsg = e.Message;
                oResult_Get_Item_BY_Item_ID.item = null;
                return oResult_Get_Item_BY_Item_ID;
            }
        }

        [Route("GET_ITEM_BY_CATEGORY_ID")]
        [HttpPost]
        public Result_Get_Items_By_Category GET_ITEM_BY_CATEGORY_ID(Int32 c_Id)
        {
            Result_Get_Items_By_Category oResult_Get_Items_By_Category = new Result_Get_Items_By_Category();
            try
            {
                oResult_Get_Items_By_Category.items = new List<Item>();
                oResult_Get_Items_By_Category.items = _blc.GET_ITEM_BY_CATEGORY_ID(c_Id);
                return oResult_Get_Items_By_Category;
            }
            catch (Exception e)
            {
                oResult_Get_Items_By_Category.errorMsg = e.Message;
                return oResult_Get_Items_By_Category;
            }
        }

        [Route("GET_ITEM_BY_NAME")]
        [HttpPost]
        public Result_Get_Items_By_ItemName GET_ITEM_BY_NAME(String name)
        {
            Result_Get_Items_By_ItemName oResult_Get_Items_By_ItemName = new Result_Get_Items_By_ItemName();
            try
            {
                oResult_Get_Items_By_ItemName.items = new List<Item>();
                oResult_Get_Items_By_ItemName.items = _blc.GET_ITEM_BY_NAME(name);
                return oResult_Get_Items_By_ItemName;
            }
            catch (Exception e)
            {
                oResult_Get_Items_By_ItemName.errorMsg = e.Message;
                return oResult_Get_Items_By_ItemName;
            }
        }

        [Route("DELETE_ITEM_BY_ITEM_ID")]
        [HttpPost]
        public Result_DELETE_ITEM_BY_ITEM_ID DELETE_ITEM_BY_ITEM_ID(Int32 ITEM_ID)
        {
            Result_DELETE_ITEM_BY_ITEM_ID oResult_DELETE_ITEM_BY_ITEM_ID = new Result_DELETE_ITEM_BY_ITEM_ID();
            try
            {
                _blc.DELETE_ITEM(ITEM_ID);
                oResult_DELETE_ITEM_BY_ITEM_ID.Msg = "Item Deleted!!";
                return oResult_DELETE_ITEM_BY_ITEM_ID;
            }
            catch (Exception e)
            {
                oResult_DELETE_ITEM_BY_ITEM_ID.errorMsg = e.Message;
                return oResult_DELETE_ITEM_BY_ITEM_ID;
            }
        }

        [Route("EDIT_ITEM")]
        [HttpPost]
        public Result_EDIT_ITEM EDIT_ITEM(Item i_Item)
        {
            Result_EDIT_ITEM oResult_EDIT_ITEM = new Result_EDIT_ITEM();
            try
            {
                oResult_EDIT_ITEM.item = new Item();
                oResult_EDIT_ITEM.item = i_Item;
                oResult_EDIT_ITEM.item.ITEM_ID = _blc.EDIT_ITEM(i_Item);

                return oResult_EDIT_ITEM;
            }
            catch (Exception e)
            {
                oResult_EDIT_ITEM.errorMsg = e.Message;
                oResult_EDIT_ITEM.item = null;

                return oResult_EDIT_ITEM;
            }
        }

        #endregion

        #region uploaded_file



        [Route("Get_UPLOADED_FILE")]
        [HttpGet]
        public Result_Get_UPLOADED_FILE Get_UPLOADED_FILE()
        {
            Result_Get_UPLOADED_FILE oResult_Get_UPLOADED_FILE = new Result_Get_UPLOADED_FILE();
            try
            {
                oResult_Get_UPLOADED_FILE.uploadFiles = new List<UploadFile>();
                oResult_Get_UPLOADED_FILE.uploadFiles = _blc.Get_UPLOADED_FILE();
                return oResult_Get_UPLOADED_FILE;
            }
            catch (Exception e)
            {
                oResult_Get_UPLOADED_FILE.errorMsg = e.Message;
                return oResult_Get_UPLOADED_FILE;
            }
        }

        [Route("GET_UPLOADED_FILE_BY_ID")]
        [HttpPost]
        public Result_Get_UPLOADED_FILE_BY_ID GET_UPLOADED_FILE_BY_ID(Int32 UPL_ID)
        {
            Result_Get_UPLOADED_FILE_BY_ID oResult_Get_UPLOADED_FILE_BY_ID = new Result_Get_UPLOADED_FILE_BY_ID();
            try
            {
                oResult_Get_UPLOADED_FILE_BY_ID.uploadFile = new UploadFile();
                oResult_Get_UPLOADED_FILE_BY_ID.uploadFile = _blc.GET_UPLOADED_FILE_BY_ID(UPL_ID);
                return oResult_Get_UPLOADED_FILE_BY_ID;
            }
            catch (Exception e)
            {
                oResult_Get_UPLOADED_FILE_BY_ID.errorMsg = e.Message;
                oResult_Get_UPLOADED_FILE_BY_ID.uploadFile = null;
                return oResult_Get_UPLOADED_FILE_BY_ID;
            }
        }

        [Route("GET_UPLOADED_FILE_BY_CATEGORY_ID")]
        [HttpPost]
        public Result_Get_UPLOADED_FILE_BY_ID GET_UPLOADED_FILE_BY_CATEGORY_ID(Int32 UPL_ID)
        {
            Result_Get_UPLOADED_FILE_BY_ID oResult_Get_UPLOADED_FILE_BY_ID = new Result_Get_UPLOADED_FILE_BY_ID();
            try
            {
                oResult_Get_UPLOADED_FILE_BY_ID.uploadFile = new UploadFile();
                oResult_Get_UPLOADED_FILE_BY_ID.uploadFile = _blc.GET_UPLOADED_FILE_BY_CATEGORY_ID(UPL_ID);
                return oResult_Get_UPLOADED_FILE_BY_ID;
            }
            catch (Exception e)
            {
                oResult_Get_UPLOADED_FILE_BY_ID.errorMsg = e.Message;
                oResult_Get_UPLOADED_FILE_BY_ID.uploadFile = null;
                return oResult_Get_UPLOADED_FILE_BY_ID;
            }
        }


        [Route("GET_UPLOADED_FILE_BY_ITEM_ID")]
        [HttpPost]
        public Result_Get_UPLOADED_FILE_BY_ID GET_UPLOADED_FILE_BY_ITEM_ID(Int32 UPL_ID)
        {
            Result_Get_UPLOADED_FILE_BY_ID oResult_Get_UPLOADED_FILE_BY_ID = new Result_Get_UPLOADED_FILE_BY_ID();
            try
            {
                oResult_Get_UPLOADED_FILE_BY_ID.uploadFile = new UploadFile();
                oResult_Get_UPLOADED_FILE_BY_ID.uploadFile = _blc.GET_UPLOADED_FILE_BY_ITEM_ID(UPL_ID);
                return oResult_Get_UPLOADED_FILE_BY_ID;
            }
            catch (Exception e)
            {
                oResult_Get_UPLOADED_FILE_BY_ID.errorMsg = e.Message;
                oResult_Get_UPLOADED_FILE_BY_ID.uploadFile = null;
                return oResult_Get_UPLOADED_FILE_BY_ID;
            }
        }

        [Route("GET_UPLOADED_FILE_BY_DONATION_ID")]
        [HttpGet]
        public Result_Get_UPLOADED_FILE GET_UPLOADED_FILE_BY_DONATION_ID(Int32 UPL_ID)
        {
            Result_Get_UPLOADED_FILE oResult_Get_UPLOADED_FILE = new Result_Get_UPLOADED_FILE();
            try
            {
                oResult_Get_UPLOADED_FILE.uploadFiles = new List<UploadFile>();
                oResult_Get_UPLOADED_FILE.uploadFiles = _blc.GET_UPLOADED_FILE_BY_DONATION_ID(UPL_ID);
                return oResult_Get_UPLOADED_FILE;
            }
            catch (Exception e)
            {
                oResult_Get_UPLOADED_FILE.errorMsg = e.Message;
                return oResult_Get_UPLOADED_FILE;
            }
        }

        [Route("DELETE_UPLOADED_FILE")]
        [HttpPost]
        public Result_DELETE_UPLOADED_FILE_BY_ID DELETE_UPLOADED_FILE(Int32 UPL_ID)
        {
            Result_DELETE_UPLOADED_FILE_BY_ID OResult_DELETE_UPLOADED_FILE_BY_ID = new Result_DELETE_UPLOADED_FILE_BY_ID();
            try
            {
                _blc.DELETE_UPLOADED_FILE(UPL_ID);
                OResult_DELETE_UPLOADED_FILE_BY_ID.Msg = "File was Deleted!!";
                return OResult_DELETE_UPLOADED_FILE_BY_ID;
            }
            catch (Exception e)
            {
                OResult_DELETE_UPLOADED_FILE_BY_ID.errorMsg = e.Message;
                return OResult_DELETE_UPLOADED_FILE_BY_ID;
            }
        }

        [Route("EDIT_UPLOADED_FILE")]
        [HttpPost]
        public Result_EDIT_UPLOADED_FILE EDIT_UPLOADED_FILE(UploadFile i_UploadFile)
        {
            Result_EDIT_UPLOADED_FILE oResult_EDIT_UPLOADED_FILE = new Result_EDIT_UPLOADED_FILE();
            try
            {
                oResult_EDIT_UPLOADED_FILE.uploadFile = new UploadFile();
                oResult_EDIT_UPLOADED_FILE.uploadFile = i_UploadFile;
                oResult_EDIT_UPLOADED_FILE.uploadFile.UPLOADED_FILE_ID = _blc.EDIT_UPLOADED_FILE(i_UploadFile);

                return oResult_EDIT_UPLOADED_FILE;
            }
            catch (Exception e)
            {
                oResult_EDIT_UPLOADED_FILE.errorMsg = e.Message;
                oResult_EDIT_UPLOADED_FILE.uploadFile = null;

                return oResult_EDIT_UPLOADED_FILE;
            }
        }


        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("user.png");
            }
        }
        #endregion


    }

    public partial class Result_Get_Users
    {
        public List<User> users { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_Get_User_BY_USER_ID
    {
        public User user { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_EDIT_USER
    {
        public User user { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_DELETE_USER_BY_USER_ID
    {
        public string Msg { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_DECATIVATE_USER_BY_USER_ID
    {
        public string Msg { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_GET_USER_BY_EMAIL_AND_PASSWORD
    {
        public User user { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_GET_ADDRESS
    {
        public List<Address> addresses { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_GET_ADDRESS_BY_ADDRESS_ID
    {
        public Address address { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_EDIT_ADDRESS
    {
        public Address address { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_DELETE_ADDRESS
    {
        public string Msg { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_GET_ADDRESS_BY_COUNTRY
    {
        public List<Address> addresses { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_GET_DONATIONS
    {
        public List<Donation> donations { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_GET_DONATION_BY_DONATION_ID
    {
        public Donation donation { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_GET_DONATION_BY_USER_ID
    {
        public List<Donation> donations { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_GET_DONATION_BY_ITEM_ID
    {
        public List<Donation> donations { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_GET_DONATION_BY_ADDRESS_ID
    {
        public List<Donation> donations { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_GET_DONATION_BY_IS_SHIPPED
    {
        public List<Donation> donations { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_GET_DONATION_BY_IS_NOT_SHIPPED
    {
        public List<Donation> donations { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_EDIT_DONATION
    {
        public Donation donation { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_DELETE_DONATION
    {
        public string Msg { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_SHIP_DONATION
    {
        public string Msg { get; set; }
        public string errorMsg { get; set; }
    }

    #region category

    public partial class Result_Get_Category
    {
        public List<Category> categories { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_Get_Category_BY_CategoryId
    {
        public Category category { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_DELETE_CATEGORY_BY_CATEGORY_ID
    {
        public string Msg { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_EDIT_CATEGORY
    {
        public Category category { get; set; }
        public string errorMsg { get; set; }
    }

    #endregion

    #region Item
    public partial class Result_Get_Items
    {
        public List<Item> items { get; set; }
        public string errorMsg { get; set; }
    }
    public partial class Result_Get_Item_BY_Item_ID
    {
        public Item item { get; set; }
        public string errorMsg { get; set; }
    }
    public partial class Result_Get_Items_By_Category
    {
        public List<Item> items { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_Get_Items_By_ItemName
    {
        public List<Item> items { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_DELETE_ITEM_BY_ITEM_ID
    {
        public string Msg { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_EDIT_ITEM
    {
        public Item item { get; set; }
        public string errorMsg { get; set; }
    }

    #endregion

    #region uploaded_file

    public partial class Result_Get_UPLOADED_FILE
    {
        public List<UploadFile> uploadFiles { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_Get_UPLOADED_FILE_BY_ID
    {
        public UploadFile uploadFile { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_DELETE_UPLOADED_FILE_BY_ID
    {
        public string Msg { get; set; }
        public string errorMsg { get; set; }
    }

    public partial class Result_EDIT_UPLOADED_FILE
    {
        public UploadFile uploadFile { get; set; }
        public string errorMsg { get; set; }
    }
    #endregion

    public partial class Params_GET_USER_BY_EMAIL_AND_PASSWORD
    {
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
    }

    public partial class Params_DECATIVATE_USER_BY_USER_ID
    {
        public int USER_ID { get; set; }
        public int IS_ACTIVE { get; set; }
    }

    
    public partial class Params_SHIP_DONATION
    {
        public int DONATION_ID { get; set; }
        public int IS_SHIPPED { get; set; }
<<<<<<< HEAD
        public string EMAIL { get; set; }
=======
>>>>>>> origin/temp004
    }

    public partial class Params_GET_DONATION_BY_USER_ID
    {
        public int USER_ID { get; set; }
    }

    public partial class Params_GET_DONATION_BY_ITEM_ID
    {
        public int ITEM_ID { get; set; }
    }

    public partial class Params_GET_DONATION_BY_ADDRESS_ID
    {
        public int ADDRESS_ID { get; set; }
    }

}
