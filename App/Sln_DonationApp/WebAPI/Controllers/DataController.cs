using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
        public DataController(IConfiguration config) //in order to use variables inside appsettings.json --its dependency injection
        {
            _config = config;
            _blc = new BLC.BLC(config);
            _blc.ConnectionString = _config.GetConnectionString("DonationAppDB");
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
        public Result_DECATIVATE_USER_BY_USER_ID DECATIVATE_USER_BY_USER_ID(long USER_ID)
        {
            Result_DECATIVATE_USER_BY_USER_ID oResult_DECATIVATE_USER_BY_USER_ID = new Result_DECATIVATE_USER_BY_USER_ID();
            try
            {
                _blc.DECATIVATE_USER_BY_USER_ID(USER_ID);
                oResult_DECATIVATE_USER_BY_USER_ID.Msg = "User Deactivated!!";
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
        public Result_GET_USER_BY_EMAIL_AND_PASSWORD GET_USER_BY_EMAIL_AND_PASSWORD(string EMAIL, string PASSWORD)
        {
            Result_GET_USER_BY_EMAIL_AND_PASSWORD oResult_GET_USER_BY_EMAIL_AND_PASSWORD = new Result_GET_USER_BY_EMAIL_AND_PASSWORD();
            try
            {
                oResult_GET_USER_BY_EMAIL_AND_PASSWORD.user = new User();
                oResult_GET_USER_BY_EMAIL_AND_PASSWORD.user = _blc.GET_USER_BY_EMAIL_AND_PASSWORD(EMAIL, PASSWORD);
                
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
}
