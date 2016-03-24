using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaPerLa.Web.Controllers
{
    public class UserController : Controller
    {
        //IUserInfo _userInfo;

        //public UserController(IUserInfo userInfo)
        //{
        //    _userInfo = userInfo;
        //}

        public UserController()
        { 
        }

        //
        // GET: /UserInfo/
        public ActionResult Index()
        {
            return View();
        }
    }
}
