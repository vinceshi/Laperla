using System;
using System.Collections.Generic;
using LaPerLa.Model;

namespace LaPerLa.IMetadataAccess
{
    public interface IShopInfo
    {
        /// <summary>
        /// 添加店铺.
        /// </summary>
        /// <param name="info">店铺信息.</param>
        /// <returns>新增的店铺信息.</returns>
        ShopInfo AddShopInfo(ShopInfo info);

        /// <summary>
        /// 根据地区获取所有店铺
        /// </summary>
        /// <param name="districtId">地区Id.</param>
        /// <returns>该地区下所有店铺信息.</returns>
        IList<ShopInfo> GetShopInfosByDistrictId(long districtId);

        /// <summary>
        /// 根据Id获取店铺信息.
        /// </summary>
        /// <param name="shopId">店铺Id.</param>
        /// <returns>店铺信息.</returns>
        ShopInfo GetShopInfoByShopId(long shopId);

        /// <summary>
        /// 获取所有店铺信息
        /// </summary>
        /// <returns></returns>
        IList<ShopInfo> GetAllShops();
    }
}
