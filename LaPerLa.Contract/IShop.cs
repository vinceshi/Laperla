using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using LaPerLa.BusinessModel;
using System;

namespace LaPerLa.Contract
{
    /// <summary>
    /// 店铺接口.
    /// </summary>
    [ServiceContract]
    public interface IShop
    {
        /// <summary>
        /// 添加店铺.
        /// </summary>
        /// <param name="info">店铺信息.</param>
        /// <returns>新增的店铺信息.</returns>
        [OperationContract]
        Shop AddShop(Shop info);

        /// <summary>
        /// 根据地区获取所有店铺
        /// </summary>
        /// <param name="districtId">地区Id.</param>
        /// <returns>该地区下所有店铺信息.</returns>
        [OperationContract]
        IList<Shop> GetShopsByDistrictId(long districtId);

        /// <summary>
        /// 计算店铺提成.
        /// </summary>
        /// <param name="districtId">地区Id.</param>
        /// <param name="shopId">店铺Id.</param>
        /// <param name="month">生效月份.</param>
        /// <returns>该店铺该月员工提成.</returns>
        [OperationContract]
        Bonus CaculateBonus(long districtId, long shopId, string month);

        /// <summary>
        /// 新店铺Copy.
        /// 1.新建相同的职位
        /// 2.新建相同的店铺
        /// 3.新建相同的规则
        /// 4.新建相同店铺的销售额
        /// </summary>
        /// <param name="shopId">店铺Id.</param>
        /// <param name="info">新店铺信息.</param>
        /// <returns>新店铺Id.</returns>
        [OperationContract]
        long NewShopCopy(long shopId, Shop info);

        /// <summary>
        /// 获取所有店铺信息
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Shop> GetAllShops();
    }
}
