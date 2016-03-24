using LaPerLa.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaPerLa.Web.Controllers
{
    public class DistrictController : Controller
    {
        //
        // GET: /District/

        public ActionResult Index()
        {
            var districtList = DistrictServices.GetDistricts();

            return View(districtList);
        }

    }
}
