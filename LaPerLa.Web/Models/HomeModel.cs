using LaPerLa.Web.LaPerLaService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaPerLa.Web.Models
{
    public class HomeModel
    {
        public List<District> DistrictList { get; set; }

        public List<Shop> ShopList { get; set; }
    }
}