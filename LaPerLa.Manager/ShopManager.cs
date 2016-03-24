using System;
using System.Collections.Generic;
using System.Linq;
using LaPerLa.BusinessModel;
using LaPerLa.DataAccess.EF;
using LaPerLa.IMetadataAccess;
using LaPerLa.Model;
using LaPerLa.Utility;
using log4net;

namespace LaPerLa.Manager
{
    public class ShopManager
    {
        private readonly IMetadataAccessHander _metadataAccessHander;
        private static readonly ILog Log = LogManager.GetLogger(typeof(ShopManager));

        public ShopManager()
        {
            if (this._metadataAccessHander == null)
            {
                this._metadataAccessHander = new MetadataRepository();
            }
        }

        /// <summary>
        /// 添加店铺.
        /// </summary>
        /// <param name="info">店铺信息.</param>
        /// <returns>新增的店铺信息.</returns>
        public Shop AddShop(Shop info)
        {
            try
            {
                var shopInfo = ModelConverter.ConvertShopFromBusiness(info);
                var newShopInfo = this._metadataAccessHander.AddShopInfo(shopInfo);
                return ModelConverter.ConvertShopToBusiness(newShopInfo);
            }
            catch (Exception ex)
            {
                Log.Error("ShopManager-AddShop:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 根据地区获取所有店铺
        /// </summary>
        /// <param name="districtId">地区Id.</param>
        /// <returns>该地区下所有店铺信息.</returns>
        public IList<Shop> GetShopsByDistrictId(long districtId)
        {
            try
            {
                var lRet = new List<Shop>();
                var infos = this._metadataAccessHander.GetShopInfosByDistrictId(districtId);

                if (infos != null)
                {
                    lRet.AddRange(infos.Select(ModelConverter.ConvertShopToBusiness));
                }

                return lRet;
            }
            catch (Exception ex)
            {
                Log.Error("ShopManager-GetShopsByDistrictId:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 根据地区获取所有店铺
        /// </summary>
        /// <param name="districtId">地区Id.</param>
        /// <returns>该地区下所有店铺信息.</returns>
        public IEnumerable<Shop> GetAllShops()
        {
            try
            {
                var lRet = new List<Shop>();
                var infos = this._metadataAccessHander.GetAllShops();

                if (infos != null)
                {
                    lRet.AddRange(infos.Select(ModelConverter.ConvertShopToBusiness));
                }

                return lRet;
            }
            catch (Exception ex)
            {
                Log.Error("ShopManager-GetAllShops:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 计算店铺提成.
        /// </summary>
        /// <param name="districtId">地区Id.</param>
        /// <param name="shopId">店铺Id.</param>
        /// <param name="month">生效月份.</param>
        /// <returns>该店铺该月员工提成.</returns>
        public Bonus CaculateBonus(long districtId, long shopId, string month)
        {
            try
            {
                var bRet = new Bonus
                {
                    DistrictId = districtId,
                    ShopId = shopId,
                    EmployeeRule = new Dictionary<long, IDictionary<long, IList<Rule>>>(),
                    ShopSaleList = new Dictionary<long, ShopSale>()
                };

                // 计算shop pool and city pool
                var shopSaleInfos = this._metadataAccessHander.GetCurrentMonthShopSaleInfoByDistrictId(districtId, month);
                var shopSaleList = new Dictionary<long, ShopSaleInfo>();

                foreach (var info in shopSaleInfos)
                {
                    if (shopSaleList.ContainsKey(info.ShopId))
                    {
                        continue;
                    }

                    shopSaleList.Add(info.ShopId, info);
                }

                double curShopPool = 0;
                double cityPool = 0;
                double totalTarget = 0;
                double totalActualSalesWithTax = 0;

                foreach (var shopSaleInfo in shopSaleList)
                {
                    var info = shopSaleInfo.Value;

                    if (shopSaleInfo.Key == shopId)
                    {
                        if (info.Target != 0)
                        {
                            curShopPool = info.ActualSalesWithTax / info.Target;
                        }

                        totalTarget += info.Target;
                        totalActualSalesWithTax += info.ActualSalesWithTax;
                    }

                    info.ShopPool = info.ActualSalesWithTax / info.Target;
                    bRet.ShopSaleList.Add(shopSaleInfo.Key, ModelConverter.ConvertShopSaleToBusiness(info));
                }

                if (totalTarget != 0)
                {
                    cityPool = totalActualSalesWithTax / totalTarget;
                    bRet.CityPool = cityPool;
                }

                // 计算店铺满足的规则
                var ruleDictionaries = new Dictionary<int, IList<RuleInfo>>();

                var ruleInfos = this._metadataAccessHander.GetRuleInfosByShopId(shopId);
                var ruleTypes = this._metadataAccessHander.GetRuleTypesByShopId(shopId);

                foreach (var ruleType in ruleTypes)
                {
                    ruleDictionaries.Add(ruleType, new List<RuleInfo>());

                    foreach (var ruleInfo in ruleInfos)
                    {
                        if (ruleInfo.RuleType == ruleType)
                        {
                            ruleDictionaries[ruleType].Add(ruleInfo);
                        }
                    }
                }
                
                // 数据库不支持的话需要实现ruleorder排序

                // 获取店铺员工及其职位
                var employeeInfos = this._metadataAccessHander.GetEmployeeInfosByShopId(shopId);

                // 以员工为第一维度
                foreach (var employeeInfo in employeeInfos)
                {
                    var dictionary = new Dictionary<long, IList<Rule>>();

                    if (bRet.EmployeeRule.ContainsKey(employeeInfo.EmployeeId))
                    {
                        continue;
                    }

                    bRet.EmployeeRule.Add(employeeInfo.EmployeeId, dictionary);

                    foreach (var ruleDictionary in ruleDictionaries)
                    {
                        if (dictionary.ContainsKey(ruleDictionary.Key))
                        {
                            continue;
                        }

                        dictionary.Add(ruleDictionary.Key, new List<Rule>());

                        if (ruleDictionary.Key == RuleType.ShopPoolCommissionType)
                        {
                            foreach (var ruleInfo in ruleDictionary.Value)
                            {
                                if (ruleInfo.PositionId == employeeInfo.PositionId)
                                {
                                    // 区分针对该条rule要做何种比较
                                    if (ruleInfo.OperationType == OperationType.GreaterEqualThanType)
                                    {
                                        if (curShopPool >= ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.GreaterThanType)
                                    {
                                        if (curShopPool > ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.LessEqualThanType)
                                    {
                                        if (curShopPool <= ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.LessThanType)
                                    {
                                        if (curShopPool < ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.GreaterAndLessThanType)
                                    {
                                        if (curShopPool > ruleInfo.OperationMinValue && curShopPool < ruleInfo.OperationMaxValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.Equal)
                                    {
                                        if (curShopPool == ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }
                                }
                            }
                        }
                        else if (ruleDictionary.Key == RuleType.CityPoolType)
                        {
                            foreach (var ruleInfo in ruleDictionary.Value)
                            {
                                if (ruleInfo.PositionId == employeeInfo.PositionId)
                                {
                                    // 区分针对该条rule要做何种比较
                                    if (ruleInfo.OperationType == OperationType.GreaterEqualThanType)
                                    {
                                        if (cityPool >= ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.GreaterThanType)
                                    {
                                        if (cityPool > ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.LessEqualThanType)
                                    {
                                        if (cityPool <= ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.LessThanType)
                                    {
                                        if (cityPool < ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.GreaterAndLessThanType)
                                    {
                                        if (cityPool > ruleInfo.OperationMinValue && cityPool < ruleInfo.OperationMaxValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.Equal)
                                    {
                                        if (cityPool == ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }
                                }
                            }
                        }
                        else if (ruleDictionary.Key == RuleType.IndividualTargetFullType)
                        {
                            foreach (var ruleInfo in ruleDictionary.Value)
                            {
                                if (ruleInfo.PositionId == employeeInfo.PositionId)
                                {
                                    var actualSale = this._metadataAccessHander.GetSumEmployeeSaleInfoByEmployeeId(
                                            employeeInfo.EmployeeId, SaleType.AchievementType, month);

                                    var targetSale =
                                        this._metadataAccessHander.GetSumEmployeeSaleInfoByEmployeeId(
                                            employeeInfo.EmployeeId, SaleType.TargetType, month);

                                    double individualFull = actualSale/targetSale;

                                    // 区分针对该条rule要做何种比较
                                    if (ruleInfo.OperationType == OperationType.GreaterEqualThanType)
                                    {
                                        if (individualFull >= ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = actualSale * ruleInfo.Bonus;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.GreaterThanType)
                                    {
                                        if (individualFull > ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = actualSale * ruleInfo.Bonus;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.LessEqualThanType)
                                    {
                                        if (individualFull <= ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = actualSale * ruleInfo.Bonus;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.LessThanType)
                                    {
                                        if (individualFull < ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = actualSale * ruleInfo.Bonus;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.GreaterAndLessThanType)
                                    {
                                        if (individualFull > ruleInfo.OperationMinValue && individualFull < ruleInfo.OperationMaxValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = actualSale * ruleInfo.Bonus;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.Equal)
                                    {
                                        if (individualFull == ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = actualSale * ruleInfo.Bonus;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }
                                }
                            }
                        }
                        else if (ruleDictionary.Key == RuleType.IndividualTargetDiscountType)
                        {
                            foreach (var ruleInfo in ruleDictionary.Value)
                            {
                                if (ruleInfo.PositionId == employeeInfo.PositionId)
                                {
                                    var targetSale =
                                        this._metadataAccessHander.GetSumEmployeeSaleInfoByEmployeeId(
                                            employeeInfo.EmployeeId, SaleType.TargetType, month);

                                    // 区分针对该条rule要做何种比较
                                    if (ruleInfo.OperationType == OperationType.GreaterEqualThanType)
                                    {
                                        if (targetSale >= ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = targetSale * ruleInfo.Bonus;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.GreaterThanType)
                                    {
                                        if (targetSale > ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = targetSale * ruleInfo.Bonus;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.LessEqualThanType)
                                    {
                                        if (targetSale <= ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = targetSale * ruleInfo.Bonus;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.LessThanType)
                                    {
                                        if (targetSale < ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = targetSale * ruleInfo.Bonus;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.GreaterAndLessThanType)
                                    {
                                        if (targetSale > ruleInfo.OperationMinValue && targetSale < ruleInfo.OperationMaxValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = targetSale * ruleInfo.Bonus;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.Equal)
                                    {
                                        if (targetSale == ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = targetSale * ruleInfo.Bonus;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }
                                }
                            }
                        }
                        else if (ruleDictionary.Key == RuleType.IndividualWeeklyType)
                        {
                            var currentShopSaleList = shopSaleInfos.Where(shopSaleInfo => shopSaleInfo.ShopId == shopId).ToList();

                            foreach (var ruleInfo in ruleDictionary.Value)
                            {
                                if (ruleInfo.PositionId == employeeInfo.PositionId)
                                {
                                    var weekSales =
                                        this._metadataAccessHander.GetCurrentMonthEmployeeSaleInfo(
                                            employeeInfo.EmployeeId, month).ToList();

                                    foreach (var weekSale in weekSales.OrderBy(p=>p.Week))
                                    {
                                        var rule = new Rule();

                                        double weekCur = 0.0;

                                        foreach (var shopSaleInfo in currentShopSaleList)
                                        {
                                            if (shopSaleInfo.Week == weekSale.Week)
                                            {
                                                weekCur = weekSale.ActualSale / weekSale.TargetSale;
                                                break;
                                            }
                                        }

                                        // 区分针对该条rule要做何种比较
                                        if (ruleInfo.OperationType == OperationType.GreaterEqualThanType)
                                        {
                                            if (weekCur >= ruleInfo.OperationValue)
                                            {
                                                rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                                rule.Bonus = ruleInfo.Bonus * weekSale.Days / 7;
                                                dictionary[ruleDictionary.Key].Add(rule);
                                            }
                                            else
                                            {
                                                // 如果最低优先级需要计算的规则都不满足，则提成为0
                                                if (ruleInfo.RuleOrder == 1)
                                                {
                                                    dictionary[ruleDictionary.Key].Add(rule);
                                                }
                                            }

                                            continue;
                                        }

                                        if (ruleInfo.OperationType == OperationType.GreaterThanType)
                                        {
                                            if (weekCur > ruleInfo.OperationValue)
                                            {
                                                rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                                rule.Bonus = ruleInfo.Bonus * weekSale.Days / 7;
                                                dictionary[ruleDictionary.Key].Add(rule);
                                            }
                                            else
                                            {
                                                // 如果最低优先级需要计算的规则都不满足，则提成为0
                                                if (ruleInfo.RuleOrder == 1)
                                                {
                                                    dictionary[ruleDictionary.Key].Add(rule);
                                                }
                                            }

                                            continue;
                                        }

                                        if (ruleInfo.OperationType == OperationType.LessEqualThanType)
                                        {
                                            if (weekCur <= ruleInfo.OperationValue)
                                            {
                                                rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                                rule.Bonus = ruleInfo.Bonus * weekSale.Days / 7;
                                                dictionary[ruleDictionary.Key].Add(rule);
                                            }
                                            else
                                            {
                                                // 如果最低优先级需要计算的规则都不满足，则提成为0
                                                if (ruleInfo.RuleOrder == 1)
                                                {
                                                    dictionary[ruleDictionary.Key].Add(rule);
                                                }
                                            }

                                            continue;
                                        }

                                        if (ruleInfo.OperationType == OperationType.LessThanType)
                                        {
                                            if (weekCur < ruleInfo.OperationValue)
                                            {
                                                rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                                rule.Bonus = ruleInfo.Bonus * weekSale.Days / 7;
                                                dictionary[ruleDictionary.Key].Add(rule);
                                            }
                                            else
                                            {
                                                // 如果最低优先级需要计算的规则都不满足，则提成为0
                                                if (ruleInfo.RuleOrder == 1)
                                                {
                                                    dictionary[ruleDictionary.Key].Add(rule);
                                                }
                                            }

                                            continue;
                                        }

                                        if (ruleInfo.OperationType == OperationType.GreaterAndLessThanType)
                                        {
                                            if (weekCur > ruleInfo.OperationMinValue && weekCur < ruleInfo.OperationMaxValue)
                                            {
                                                rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                                rule.Bonus = ruleInfo.Bonus * weekSale.Days / 7;
                                                dictionary[ruleDictionary.Key].Add(rule);
                                            }
                                            else
                                            {
                                                // 如果最低优先级需要计算的规则都不满足，则提成为0
                                                if (ruleInfo.RuleOrder == 1)
                                                {
                                                    dictionary[ruleDictionary.Key].Add(rule);
                                                }
                                            }

                                            continue;
                                        }

                                        if (ruleInfo.OperationType == OperationType.Equal)
                                        {
                                            if (weekCur == ruleInfo.OperationValue)
                                            {
                                                rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                                rule.Bonus = ruleInfo.Bonus * weekSale.Days / 7;
                                                dictionary[ruleDictionary.Key].Add(rule);
                                            }
                                            else
                                            {
                                                // 如果最低优先级需要计算的规则都不满足，则提成为0
                                                if (ruleInfo.RuleOrder == 1)
                                                {
                                                    dictionary[ruleDictionary.Key].Add(rule);
                                                }
                                            }

                                            continue;
                                        }

                                        dictionary[ruleDictionary.Key].Add(rule);
                                    }
                                }
                            }
                        }
                        else if (ruleDictionary.Key == RuleType.ShopPoolWeeklyType)
                        {
                            var shopSales =
                                        this._metadataAccessHander.GetCurrentMonthShopSaleInfo(
                                            shopId, month);

                            foreach (var ruleInfo in ruleDictionary.Value)
                            {
                                if (ruleInfo.PositionId == employeeInfo.PositionId)
                                {
                                    foreach (var shopSale in shopSales)
                                    {
                                        var rule = new Rule();                                       

                                        double shopCur = shopSale.ActualSalesWithTax / shopSale.Target;
                                        // 区分针对该条rule要做何种比较
                                        if (ruleInfo.OperationType == OperationType.GreaterEqualThanType)
                                        {
                                            if (shopCur >= ruleInfo.OperationValue)
                                            {
                                                rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                                rule.Bonus = ruleInfo.Bonus / 7;
                                                dictionary[ruleDictionary.Key].Add(rule);
                                            }
                                            else
                                            {
                                                // 如果最低优先级需要计算的规则都不满足，则提成为0
                                                if (ruleInfo.RuleOrder == 1)
                                                {
                                                    dictionary[ruleDictionary.Key].Add(rule);
                                                }
                                            }

                                            continue;
                                        }

                                        if (ruleInfo.OperationType == OperationType.GreaterThanType)
                                        {
                                            if (shopCur > ruleInfo.OperationValue)
                                            {
                                                rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                                rule.Bonus = ruleInfo.Bonus / 7;
                                                dictionary[ruleDictionary.Key].Add(rule);
                                            }
                                            else
                                            {
                                                // 如果最低优先级需要计算的规则都不满足，则提成为0
                                                if (ruleInfo.RuleOrder == 1)
                                                {
                                                    dictionary[ruleDictionary.Key].Add(rule);
                                                }
                                            }

                                            continue;
                                        }

                                        if (ruleInfo.OperationType == OperationType.LessEqualThanType)
                                        {
                                            if (shopCur <= ruleInfo.OperationValue)
                                            {
                                                rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                                rule.Bonus = ruleInfo.Bonus / 7;
                                                dictionary[ruleDictionary.Key].Add(rule);
                                            }
                                            else
                                            {
                                                // 如果最低优先级需要计算的规则都不满足，则提成为0
                                                if (ruleInfo.RuleOrder == 1)
                                                {
                                                    dictionary[ruleDictionary.Key].Add(rule);
                                                }
                                            }

                                            continue;
                                        }

                                        if (ruleInfo.OperationType == OperationType.LessThanType)
                                        {
                                            if (shopCur < ruleInfo.OperationValue)
                                            {
                                                rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                                rule.Bonus = ruleInfo.Bonus / 7;
                                                dictionary[ruleDictionary.Key].Add(rule);
                                            }
                                            else
                                            {
                                                // 如果最低优先级需要计算的规则都不满足，则提成为0
                                                if (ruleInfo.RuleOrder == 1)
                                                {
                                                    dictionary[ruleDictionary.Key].Add(rule);
                                                }
                                            }

                                            continue;
                                        }

                                        if (ruleInfo.OperationType == OperationType.GreaterAndLessThanType)
                                        {
                                            if (shopCur > ruleInfo.OperationMinValue && shopCur < ruleInfo.OperationMaxValue)
                                            {
                                                rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                                rule.Bonus = ruleInfo.Bonus / 7;
                                                dictionary[ruleDictionary.Key].Add(rule);
                                            }
                                            else
                                            {
                                                // 如果最低优先级需要计算的规则都不满足，则提成为0
                                                if (ruleInfo.RuleOrder == 1)
                                                {
                                                    dictionary[ruleDictionary.Key].Add(rule);
                                                }
                                            }

                                            continue;
                                        }

                                        if (ruleInfo.OperationType == OperationType.Equal)
                                        {
                                            if (shopCur == ruleInfo.OperationValue)
                                            {
                                                rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                                rule.Bonus = ruleInfo.Bonus / 7;
                                                dictionary[ruleDictionary.Key].Add(rule);
                                            }
                                            else
                                            {
                                                // 如果最低优先级需要计算的规则都不满足，则提成为0
                                                if (ruleInfo.RuleOrder == 1)
                                                {
                                                    dictionary[ruleDictionary.Key].Add(rule);
                                                }
                                            }

                                            continue;
                                        }

                                        dictionary[ruleDictionary.Key].Add(rule);
                                    }
                                }
                            }
                        }
                        else if (ruleDictionary.Key == RuleType.FullAttendenceType)
                        {
                            foreach (var ruleInfo in ruleDictionary.Value)
                            {
                                if (ruleInfo.PositionId == employeeInfo.PositionId)
                                {
                                    var infos = this._metadataAccessHander.GetEmployeeSaleInfosByEmployeeIds(new List<long> { employeeInfo.EmployeeId }, month).ToList();

                                    if (infos != null && infos.Count > 0)
                                    {
                                        if (infos[0].Days == 0)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = ruleInfo.OperationValue;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }
                                    }
                                }
                            }
                        }
                        else if (ruleDictionary.Key == RuleType.IndividualTargetBelow70Type)
                        {
                            foreach (var ruleInfo in ruleDictionary.Value)
                            {
                                if (ruleInfo.PositionId == employeeInfo.PositionId)
                                {
                                    var below70Sale =
                                        this._metadataAccessHander.GetEmployeeTypeSaleInfoByType(
                                            employeeInfo.EmployeeId, SaleType.Below70, month);

                                    var targetSale =
                                        this._metadataAccessHander.GetSumEmployeeSaleInfoByEmployeeId(
                                            employeeInfo.EmployeeId, SaleType.TargetType, month);

                                    var actualSale =
                                        this._metadataAccessHander.GetSumEmployeeSaleInfoByEmployeeId(
                                            employeeInfo.EmployeeId, SaleType.AchievementType, month);

                                    var curSale = actualSale / targetSale;

                                    // 区分针对该条rule要做何种比较
                                    if (ruleInfo.OperationType == OperationType.GreaterEqualThanType)
                                    {
                                        if (curSale >= ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = below70Sale.Actual * ruleInfo.OperationValue;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.GreaterThanType)
                                    {
                                        if (curSale > ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = below70Sale.Actual * ruleInfo.OperationValue;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.LessEqualThanType)
                                    {
                                        if (curSale <= ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = below70Sale.Actual * ruleInfo.OperationValue;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.LessThanType)
                                    {
                                        if (curSale < ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = below70Sale.Actual * ruleInfo.OperationValue;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.GreaterAndLessThanType)
                                    {
                                        if (curSale > ruleInfo.OperationMinValue && curSale < ruleInfo.OperationMaxValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = below70Sale.Actual * ruleInfo.OperationValue;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.Equal)
                                    {
                                        if (curSale == ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = below70Sale.Actual * ruleInfo.OperationValue;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }
                                }
                            }
                        }
                        else if (ruleDictionary.Key == RuleType.IndividualTargetAbove70Type)
                        {
                            foreach (var ruleInfo in ruleDictionary.Value)
                            {
                                if (ruleInfo.PositionId == employeeInfo.PositionId)
                                {
                                    var above70Sale =
                                        this._metadataAccessHander.GetEmployeeTypeSaleInfoByType(
                                            employeeInfo.EmployeeId, SaleType.Above70, month);

                                    var targetSale =
                                        this._metadataAccessHander.GetSumEmployeeSaleInfoByEmployeeId(
                                            employeeInfo.EmployeeId, SaleType.TargetType, month);

                                    var actualSale =
                                        this._metadataAccessHander.GetSumEmployeeSaleInfoByEmployeeId(
                                            employeeInfo.EmployeeId, SaleType.AchievementType, month);

                                    var curSale = actualSale / targetSale;

                                    // 区分针对该条rule要做何种比较
                                    if (ruleInfo.OperationType == OperationType.GreaterEqualThanType)
                                    {
                                        if (curSale >= ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = above70Sale.Actual * ruleInfo.OperationValue;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.GreaterThanType)
                                    {
                                        if (curSale > ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = above70Sale.Actual * ruleInfo.OperationValue;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.LessEqualThanType)
                                    {
                                        if (curSale <= ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = above70Sale.Actual * ruleInfo.OperationValue;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.LessThanType)
                                    {
                                        if (curSale < ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = above70Sale.Actual * ruleInfo.OperationValue;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.GreaterAndLessThanType)
                                    {
                                        if (curSale > ruleInfo.OperationMinValue && curSale < ruleInfo.OperationMaxValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = above70Sale.Actual * ruleInfo.OperationValue;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }

                                    if (ruleInfo.OperationType == OperationType.Equal)
                                    {
                                        if (curSale == ruleInfo.OperationValue)
                                        {
                                            var rule = ModelConverter.ConvertRuleToBusiness(ruleInfo);
                                            rule.Bonus = above70Sale.Actual * ruleInfo.OperationValue;
                                            dictionary[ruleDictionary.Key].Add(rule);
                                        }

                                        break;
                                    }
                                }
                            }
                        }
                        else if (ruleDictionary.Key == RuleType.TransportationSubsidyType)
                        {
                        }
                    }
                }

                return bRet;
            }
            catch (Exception ex)
            {
                Log.Error("ShopManager-CaculateBonus:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 新店铺Copy.
        /// </summary>
        /// <param name="shopId">店铺Id.</param>
        /// <param name="info">新店铺信息.</param>
        /// <returns>新店铺Id.</returns>
        public long NewShopCopy(long shopId, Shop info)
        {
            try
            {
                var fromShop = this._metadataAccessHander.GetShopInfoByShopId(shopId);

                if(fromShop != null)
                {
                    info.DistrictId = fromShop.DistrictId;
                }

                var toShopInfo = ModelConverter.ConvertShopFromBusiness(info);
                var newShopInfo = this._metadataAccessHander.AddShopInfo(toShopInfo);

                if (newShopInfo == null)
                {
                    return 0;
                }

                var ruleInfos = this._metadataAccessHander.GetRuleInfosByShopId(shopId);

                if (ruleInfos != null)
                {
                    foreach (var ruleInfo in ruleInfos)
                    {
                        ruleInfo.ShopId = newShopInfo.ShopId;
                        this._metadataAccessHander.AddRuleInfo(ruleInfo);
                    }
                }

                return newShopInfo.ShopId;
            }
            catch (Exception ex)
            {
                Log.Error("ShopManager-NewShopCopy:" + ex.Message + "\r\n" + ex.StackTrace);
                return 0;
            }
        }
    }
}
