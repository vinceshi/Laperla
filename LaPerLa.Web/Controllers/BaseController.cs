using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaPerLa.Web.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
        public JsonResult JsonResult(object data)
        {
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}
