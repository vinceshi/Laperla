using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LaPerLa.BusinessModel;
using System.ServiceModel;

namespace LaPerLa.Contract
{
    /// <summary>
    /// 店铺销售额业务接口
    /// </summary>
    [ServiceContract]
    public interface IShopSale
    {
        /// <summary>
        /// 添加店铺销售额
        /// </summary>
        /// <param name="info">店铺销售额</param>
        /// <returns>新增店铺销售额</returns>
        [OperationContract]
        ShopSale AddShopSale(ShopSale info);

        /// <summary>
        /// 获取当月店铺销售额
        /// </summary>
        /// <param name="shopIds">店铺Id集合</param>
        /// <param name="month">生效月份</param>
        /// <returns>店铺销售额字典</returns>
        [OperationContract]
        IDictionary<long, IList<ShopSale>> GetCurrentMonthShopSale(IList<long> shopIds, string month);
    }
}
