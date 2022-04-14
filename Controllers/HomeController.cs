using Newtonsoft.Json.Linq;
using Recruiting_API.DAC;
using Recruiting_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Recruiting_API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }

    public class newRegistrationnController : ApiController
    {
        public String Post(JObject jObject)
        {

            Cls_testapi _in = new Cls_testapi();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string data = json.data; ;
            return _in.insertNewRecord1(data);
        }
    }

    public class UserprofileController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_testapi _in = new Cls_testapi();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string firstnmae = json.firstname;
            string lastname = json.lastname;
            string email = json.email;
            string regioin = json.region;
            string reportingto = json.reportingto;
            string role = json.role;
            string designation = json.designation;
            string username = json.username;
            string password = json.password;
            string userid = json.userid;
            string profilestatus = json.profilestatuse;
            
            _json.d = _in.insertNewFeed(firstnmae, lastname, email, regioin, reportingto, role, designation,
                username, password, userid, profilestatus);
            _close = new CloseSQLConnection();
            return _json;
        }
    }

    

}
