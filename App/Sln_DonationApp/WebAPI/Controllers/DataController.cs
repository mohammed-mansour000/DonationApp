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
            _blc = new BLC.BLC();
            _blc.ConnectionString = _config.GetConnectionString("DonationAppDB");
        }

        [Route("Get_Users")]
        [HttpGet]
        public Result_Get_Users Get_Users()
        {
            Result_Get_Users oResult_Get_Users = new Result_Get_Users();
            try
            {
                oResult_Get_Users.users = _blc.Get_Users();
                return oResult_Get_Users;
            }
            catch (Exception e)
            {
                oResult_Get_Users.errorMsg = e.Message;
                return oResult_Get_Users;
            }
           
            
        }
    }

    public partial class Result_Get_Users
    {
        public List<User> users { get; set; }
        public string errorMsg { get; set; }
    }
}
