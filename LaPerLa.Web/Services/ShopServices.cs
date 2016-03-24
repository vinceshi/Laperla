using LaPerLa.Web.LaPerLaService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaPerLa.Web.Services
{
    /// <summary>
    /// 商铺
    /// </summary>
    public class ShopServices
    {
        private static readonly ServiceClient client = new ServiceClient();

        /// <summary>
        /// 获取所有地区信息
        /// </summary>
        /// <returns></returns>
        public static List<Shop> GetShopsByDistrictId(long districtId)
        {
            return client.GetShopsByDistrictId(districtId);
        }

        /// <summary>
        /// 获取月度奖金设置
        /// </summary>
        /// <param name="districtId"></param>
        /// <param name="shopId"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static Bonus CaculateBonus(long districtId, long shopId, DateTime dt)
        {
            return client.CaculateBonus(districtId, shopId, dt.ToString("yyyy-MM"));
        }

        /// <summary>
        /// 获取销售额
        /// </summary>
        /// <param name="shopIds"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static Dictionary<long, List<ShopSale>> GetCurrentMonthShopSale(List<long> shopIds, DateTime dt)
        {
            return client.GetCurrentMonthShopSale(shopIds, dt.ToString("yyyy-MM"));
        }

        /// <summary>
        /// 获取所有店铺信息
        /// </summary>
        /// <returns></returns>
        public static List<Shop> GetAllShops()
        {
            return client.GetAllShops();
        }
    }
}