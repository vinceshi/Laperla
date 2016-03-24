using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using LaPerLa.Model;

namespace LaPerLa.IMetadataAccess
{
    public interface IRuleInfo
    {
        /// <summary>
        /// 添加规则.
        /// </summary>
        /// <param name="info">规则信息.</param>
        /// <returns>新增的规则信息.</returns>
        RuleInfo AddRuleInfo(RuleInfo info);

        /// <summary>
        /// 获取店铺计算规则.
        /// </summary>
        /// <param name="shopId">店铺Id.</param>
        /// <returns>计算规则信息.</returns>
        IList<RuleInfo> GetRuleInfosByShopId(long shopId);

        /// <summary>
        /// 获取店铺计算规则类型.
        /// </summary>
        /// <param name="shopId">店铺Id.</param>
        /// <returns>计算规则类型.</returns>
        IList<int> GetRuleTypesByShopId(long shopId);
    }
}
