using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LaPerLa.Model;

namespace LaPerLa.IMetadataAccess
{
    public interface IShopSaleInfo
    {
        /// <summary>
        /// 根据地区Id获取当月店铺销售额信息.
        /// </summary>
        /// <param name="districtId">地区Id.</param>
        /// <param name="month">生效月份.</param>
        /// <returns>店铺销售额信息.</returns>
        IList<ShopSaleInfo> GetCurrentMonthShopSaleInfoByDistrictId(long districtId, string month);

        /// <summary>
        /// 获取当月店铺销售额
        /// </summary>
        /// <param name="shopId">店铺Id</param>
        /// <param name="month">生效月份</param>
        /// <returns>店铺销售额</returns>
        IList<ShopSaleInfo> GetCurrentMonthShopSaleInfo(long shopId, string month);

        /// <summary>
        /// 添加店铺销售额
        /// </summary>
        /// <param name="info">店铺销售额</param>
        /// <returns>新增店铺销售额</returns>
        ShopSaleInfo AddShopSaleInfo(ShopSaleInfo info);
    }
}
