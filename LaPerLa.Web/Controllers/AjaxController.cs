using LaPerLa.Web.LaPerLaService;
using LaPerLa.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaPerLa.Web.Controllers
{
    public class AjaxController : BaseController
    {
        LaPerLaService.ServiceClient serviceClient = new LaPerLaService.ServiceClient();

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public JsonResult Login(string username, string pwd)
        {
            if (string.IsNullOrEmpty(username))
            {
                return JsonResult(new { result = 0, err = "用户名不能为空" });
            }
            if (string.IsNullOrEmpty(pwd))
            {
               return JsonResult(new { result = 0, err = "用户密码不能为空" });
            }

            LaPerLaService.User user = new LaPerLaService.User()
            {
                UserName = username,
                Password = pwd
            };
            string result = serviceClient.Login(user);
            if (string.IsNullOrEmpty(result))
            {
                return Json(new { result = 0, err = "登录失败，用户名或者密码错误！请重试，或者联系系统管理员" });
            }
            return Json(new { result = 1 });
        }

        /// <summary>
        /// 获取商铺选择项
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        public JsonResult ChooseShop(long districtId)
        {
            List<Shop> shopList = null;
            if (districtId > 0)
            {
                shopList = ShopServices.GetShopsByDistrictId(districtId);
            }
            return Json(new { result = 1, data = shopList.Select(p => new { key = p.ShopId, value = p.ShopName }) });
        }

    }
}
