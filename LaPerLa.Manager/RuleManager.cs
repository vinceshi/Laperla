using System;
using System.Collections.Generic;
using System.Linq;
using LaPerLa.BusinessModel;
using LaPerLa.DataAccess.EF;
using LaPerLa.IMetadataAccess;
using LaPerLa.Utility;
using log4net;

namespace LaPerLa.Manager
{
    public class RuleManager
    {
        private readonly IMetadataAccessHander _metadataAccessHander;
        private static readonly ILog Log = LogManager.GetLogger(typeof(RuleManager));

        public RuleManager()
        {
            if (this._metadataAccessHander == null)
            {
                this._metadataAccessHander = new MetadataRepository();
            }
        }

        /// <summary>
        /// 添加规则.
        /// </summary>
        /// <param name="info">规则信息.</param>
        /// <returns>新增的规则信息.</returns>
        public Rule AddRule(Rule info)
        {
            try
            {
                var ruleInfo = ModelConverter.ConvertRuleFromBusiness(info);
                var newRuleInfo = this._metadataAccessHander.AddRuleInfo(ruleInfo);
                return ModelConverter.ConvertRuleToBusiness(newRuleInfo);
            }
            catch (Exception ex)
            {
                Log.Error("RuleManager-AddRule:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 获取店铺计算规则.
        /// </summary>
        /// <param name="shopId">店铺Id.</param>
        /// <returns>计算规则信息.</returns>
        public IList<Rule> GetRulesByShopId(long shopId)
        {
            try
            {
                var lRet = new List<Rule>();
                var infos = this._metadataAccessHander.GetRuleInfosByShopId(shopId);

                if (infos != null)
                {
                    lRet.AddRange(infos.Select(ModelConverter.ConvertRuleToBusiness));
                }

                return lRet;
            }
            catch (Exception ex)
            {
                Log.Error("RuleManager-GetRulesByShopId:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }
    }
}
