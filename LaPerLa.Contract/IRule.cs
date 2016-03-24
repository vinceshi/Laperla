using System.Collections.Generic;
using System.ServiceModel;
using LaPerLa.BusinessModel;

namespace LaPerLa.Contract
{
    /// <summary>
    /// 规则接口.
    /// </summary>
    [ServiceContract]
    public interface IRule
    {
        /// <summary>
        /// 添加规则.
        /// </summary>
        /// <param name="info">规则信息.</param>
        /// <returns>新增的规则信息.</returns>
        [OperationContract]
        Rule AddRule(Rule info);

        /// <summary>
        /// 获取店铺计算规则.
        /// </summary>
        /// <param name="shopId">店铺Id.</param>
        /// <returns>计算规则信息.</returns>
        [OperationContract]
        IList<Rule> GetRulesByShopId(long shopId);
    }
}
