using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaPerLa.Web.Controllers
{
    public class ImportController : Controller
    {
        //
        // GET: /Import/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Upload()
        {
            return Json(new { files = new List<Excel>() { new Excel() { name = "123" } } }, JsonRequestBehavior.AllowGet);
        }
    }

    public class Excel
    {
        public string name { get; set; }
    }
}
