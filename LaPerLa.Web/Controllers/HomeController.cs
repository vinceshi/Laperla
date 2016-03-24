using LaPerLa.Web.Models;
using LaPerLa.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaPerLa.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var districtList = DistrictServices.GetDistricts();
            var shopList = ShopServices.GetAllShops();
            var model = new HomeModel()
            {
                DistrictList = districtList,
                ShopList = shopList
            };
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 统计数据
        /// </summary>
        /// <param name="districtId"></param>
        /// <param name="shopId"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public ActionResult Statistics(long districtId, long shopId, DateTime month)
        {
            StatisticsModel statisticsModel = null;
            if (districtId > 0)
            {
                var district = DistrictServices.GetDistrictById(districtId);
                if (district != null)
                {
                    statisticsModel = new StatisticsModel();
                    var shopList = ShopServices.GetShopsByDistrictId(district.DistrictId);
                    statisticsModel.ShopList = shopList;
                    var shopDict = ShopServices.GetCurrentMonthShopSale(shopList.Select(p => p.ShopId).ToList(), month);
                    statisticsModel.ShopDict = shopDict;
                    var shop = shopList.Find(p => p.ShopId == shopId);
                    if (shop != null)
                    {
                        statisticsModel.District = district;
                        statisticsModel.Shop = shop;
                        var bonus = ShopServices.CaculateBonus(district.DistrictId, shop.DistrictId, month);
                        statisticsModel.Bonus = bonus;
                        var employeeList = EmployeeServices.GetEmployees(shop.ShopId);
                        statisticsModel.EmployeeList = employeeList;
                        var ruleList = RuleServices.GetRulesByShopId(shop.ShopId);
                        statisticsModel.RuleList = ruleList;

                        if (employeeList != null && employeeList.Count > 0)
                        {
                            var employeeSaleList = EmployeeServices.GetEmployeeSales(employeeList.Select(p => p.EmployeeId).ToList(), month);
                            statisticsModel.EmployeeSaleList = employeeSaleList;
                            var positionList = EmployeeServices.GetPositionByIds(employeeList.Select(p => p.PositionId).ToList());
                            statisticsModel.PositionList = positionList;
                        }
                    }
                }
            }
            return View(statisticsModel);
        }

        /// <summary>
        /// 下载excel
        /// </summary>
        /// <param name="strHtml"></param>
        /// <param name="name"></param>
        [ValidateInput(false)]
        public void DownExcel(string strHtml, string name)
        {
            //输出的应用类型
            Response.ContentType = "application/vnd.ms-excel";
            //设定编码方式，若输出的excel有乱码，可优先从编码方面解决
            Response.Charset = "gb2312";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            //filenames是自定义的文件名
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + string.Format("{0}.xlsx", name));
            //content是步骤1的html，注意是string类型
            Response.Write(GetExcel(strHtml));
            Response.End();
        }

        public string GetExcel(string strHtml)
        {
            return string.Format("<html xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\"><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\"><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name></x:Name><x:WorksheetOptions><x:Selected/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body>{0}</body></html>", strHtml);
        }
    }
}
