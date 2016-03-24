using LaPerLa.BusinessModel;
using LaPerLa.Model;

namespace LaPerLa.Utility
{
    public static class ModelConverter
    {
        /// <summary>
        /// 地区业务对象转换为数据库对象.
        /// </summary>
        /// <param name="info">地区业务对象.</param>
        /// <returns>地区数据库对象.</returns>
        public static DistrictInfo ConvertDistrictFromBusiness(District info)
        {
            if(info == null)
            {
                return null;
            }

            var dRet = new DistrictInfo
            {
                DistrictId = info.DistrictId,
                Country = info.Country,
                City = info.City,
                State = info.State
            };

            return dRet;
        }

        /// <summary>
        /// 地区数据库对象转换为数据库业务对象.
        /// </summary>
        /// <param name="info">地区数据库对象.</param>
        /// <returns>地区业务对象.</returns>
        public static District ConvertDistrictToBusiness(DistrictInfo info)
        {
            if(info == null || info.DistrictId <= 0)
            {
                return null;
            }

            var dRet = new District
            {
                DistrictId = info.DistrictId,
                Country = info.Country,
                City = info.City,
                State = info.State
            };

            return dRet;
        }

        /// <summary>
        /// 职位业务对象转换为数据库对象.
        /// </summary>
        /// <param name="info">职位业务对象.</param>
        /// <returns>职位数据库对象.</returns>
        public static PositionInfo ConvertPositionFromBusiness(Position info)
        {
            if (info == null)
            {
                return null;
            }

            var pRet = new PositionInfo
            {
                PositionId = info.PositionId,
                DistrictId = info.DistrictId,
                ShopId = info.ShopId,
                PositionName = info.PositionName
            };

            return pRet;
        }

        /// <summary>
        /// 职位数据库对象转换业务对象.
        /// </summary>
        /// <param name="info">职位数据库对象.</param>
        /// <returns>职位业务对象.</returns>
        public static Position ConvertPositionToBusiness(PositionInfo info)
        {
            if (info == null)
            {
                return null;
            }

            var pRet = new Position
            {
                PositionId = info.PositionId,
                DistrictId = info.DistrictId,
                ShopId = info.ShopId,
                PositionName = info.PositionName
            };

            return pRet;
        }

        /// <summary>
        /// 店铺业务对象转换为数据库对象.
        /// </summary>
        /// <param name="info">店铺业务对象.</param>
        /// <returns>店铺数据库对象.</returns>
        public static ShopInfo ConvertShopFromBusiness(Shop info)
        {
            if (info == null)
            {
                return null;
            }

            var sRet = new ShopInfo
            {
                ShopId = info.ShopId,
                DistrictId = info.DistrictId,
                ShopName = info.ShopName,
                ShopType = info.ShopType
            };

            return sRet;
        }

        /// <summary>
        /// 店铺数据库对象转换为业务对象.
        /// </summary>
        /// <param name="info">店铺数据库对象.</param>
        /// <returns>店铺业务对象.</returns>
        public static Shop ConvertShopToBusiness(ShopInfo info)
        {
            if (info == null)
            {
                return null;
            }

            var sRet = new Shop
            {
                ShopId = info.ShopId,
                DistrictId = info.DistrictId,
                ShopName = info.ShopName,
                ShopType = info.ShopType
            };

            return sRet;
        }

        /// <summary>
        /// 员工业务对象转换为数据库对象.
        /// </summary>
        /// <param name="info">员工业务对象.</param>
        /// <returns>员工数据库对象.</returns>
        public static EmployeeInfo ConvertEmployeeFromBusiness(Employee info)
        {
            if (info == null)
            {
                return null;
            }

            var eRet = new EmployeeInfo
            {
                EmployeeId = info.EmployeeId,
                ChineseName = info.ChineseName,
                EnglishName = info.EnglishName,
                PositionId = info.PositionId,
                ShopId = info.ShopId
            };

            return eRet;
        }

        /// <summary>
        /// 员工数据库对象转换为业务对象.
        /// </summary>
        /// <param name="info">员工数据库对象.</param>
        /// <returns>员工业务对象.</returns>
        public static Employee ConvertEmployeeToBusiness(EmployeeInfo info)
        {
            if (info == null)
            {
                return null;
            }

            var eRet = new Employee
            {
                EmployeeId = info.EmployeeId,
                ChineseName = info.ChineseName,
                EnglishName = info.EnglishName,
                PositionId = info.PositionId,
                ShopId = info.ShopId
            };

            return eRet;
        }

        /// <summary>
        /// 员工销售额业务对象转换为数据库对象.
        /// </summary>
        /// <param name="info">员工销售额业务对象.</param>
        /// <returns>员工销售额数据库对象.</returns>
        public static EmployeeSaleInfo ConvertEmployeeSaleFromBusiness(EmployeeSale info)
        {
            if (info == null)
            {
                return null;
            }

            var eRet = new EmployeeSaleInfo
            {
                EmployeeSaleId = info.EmployeeSaleId,
                EmployeeId = info.EmployeeId,
                Days = info.Days,
                Sale = info.Sale,
                TargetSale = info.TargetSale,
                ActualSale = info.ActualSale,
                ShopId = info.ShopId,
                Week = info.Week,
                Month = info.Month
            };

            return eRet;
        }

        /// <summary>
        /// 员工销售额数据库对象转换为业务对象.
        /// </summary>
        /// <param name="info">员工销售额数据库对象.</param>
        /// <returns>员工销售额业务对象.</returns>
        public static EmployeeSale ConvertEmployeeSaleToBusiness(EmployeeSaleInfo info)
        {
            if (info == null)
            {
                return null;
            }

            var eRet = new EmployeeSale
            {
                EmployeeSaleId = info.EmployeeSaleId,
                EmployeeId = info.EmployeeId,
                Days = info.Days,
                Sale = info.Sale,
                TargetSale = info.TargetSale,
                ActualSale = info.ActualSale,
                ShopId = info.ShopId,
                Week = info.Week,
                Month = info.Month
            };

            return eRet;
        }

        /// <summary>
        /// 规则业务对象转换为数据库对象.
        /// </summary>
        /// <param name="info">规则销售额业务对象.</param>
        /// <returns>规则销售额数据库对象.</returns>
        public static RuleInfo ConvertRuleFromBusiness(Rule info)
        {
            if (info == null)
            {
                return null;
            }

            var rRet = new RuleInfo
            {
                RuleId = info.RuleId,
                Bonus = info.Bonus,
                PositionId = info.PositionId,
                RuleDescription = info.RuleDescription,
                RuleType = info.RuleType,
                ShopId = info.ShopId,
                RuleOrder = info.RuleOrder,
                OperationMaxValue = info.OperationMaxValue,
                OperationMinValue = info.OperationMinValue,
                OperationType = info.OperationType,
                OperationValue = info.OperationValue
            };

            return rRet;
        }

        /// <summary>
        /// 规则数据库对象转换为业务对象.
        /// </summary>
        /// <param name="info">规则销售额数据库对象.</param>
        /// <returns>规则销售额业务对象.</returns>
        public static Rule ConvertRuleToBusiness(RuleInfo info)
        {
            if (info == null)
            {
                return null;
            }

            var rRet = new Rule
            {
                RuleId = info.RuleId,
                Bonus = info.Bonus,
                PositionId = info.PositionId,
                RuleDescription = info.RuleDescription,
                RuleType = info.RuleType,
                ShopId = info.ShopId,
                OperationMaxValue = info.OperationMaxValue,
                OperationMinValue = info.OperationMinValue,
                OperationType = info.OperationType,
                OperationValue = info.OperationValue
            };

            return rRet;
        }

        /// <summary>
        /// 用户业务对象转换为数据库对象.
        /// </summary>
        /// <param name="info">用户业务对象.</param>
        /// <returns>用户数据库对象.</returns>
        public static UserInfo ConvertUserFromBusiness(User info)
        {
            if (info == null)
            {
                return null;
            }

            var uRet = new UserInfo
            {
                UserId = info.UserId,
                LastLoginTime = info.LastLoginTime,
                Password = info.Password,
                UserName = info.UserName
            };

            return uRet;
        }

        /// <summary>
        /// 店铺销售额业务对象转换为数据库对象.
        /// </summary>
        /// <param name="info">店铺销售额业务对象.</param>
        /// <returns>店铺销售额数据库对象.</returns>
        public static ShopSaleInfo ConvertShopSaleFromBusiness(ShopSale info)
        {
            if (info == null)
            {
                return null;
            }

            var sRet = new ShopSaleInfo
            {
                ShopId = info.ShopId,
                ActualSalesWithTax = info.ActualSalesWithTax,
                ActualSalesWithoutTax = info.ActualSalesWithoutTax,
                Month = info.Month,
                ShopPool = info.ShopPool,
                Target = info.Target,
                Tax = info.Tax,
                DistrictId = info.DistrictId,
                ShopSaleId = info.ShopSaleId,
                TargetWeekSale = info.TargetWeekSale,
                ActualWeekSale = info.ActualWeekSale,
                Week = info.Week
            };

            return sRet;
        }

        /// <summary>
        /// 店铺销售额数据库对象转换为业务对象.
        /// </summary>
        /// <param name="info">店铺销售额数据库对象.</param>
        /// <returns>店铺销售额业务对象.</returns>
        public static ShopSale ConvertShopSaleToBusiness(ShopSaleInfo info)
        {
            if (info == null)
            {
                return null;
            }

            var sRet = new ShopSale
            {
                ShopId = info.ShopId,
                ActualSalesWithTax = info.ActualSalesWithTax,
                ActualSalesWithoutTax = info.ActualSalesWithoutTax,
                Month = info.Month,
                ShopPool = info.ShopPool,
                Target = info.Target,
                Tax = info.Tax,
                DistrictId = info.DistrictId,
                ShopSaleId = info.ShopSaleId,
                TargetWeekSale = info.TargetWeekSale,
                ActualWeekSale = info.ActualWeekSale,
                Week = info.Week
            };

            return sRet;
        }

        /// <summary>
        /// 员工类型销售额业务对象转换为数据库对象.
        /// </summary>
        /// <param name="info">员工类型销售额业务对象.</param>
        /// <returns>员工类型销售额数据库对象.</returns>
        public static EmployeeTypeSaleInfo ConvertEmployeeTypeSaleFromBusiness(EmployeeTypeSale info)
        {
            if (info == null)
            {
                return null;
            }

            var eRet = new EmployeeTypeSaleInfo
            {
                EmployeeTypeSaleId = info.EmployeeTypeSaleId,
                EmployeeId = info.EmployeeId,
                Month = info.Month,
                SaleType = info.SaleType,
                Target = info.Target,
                Actual = info.Actual,
                ShopId = info.ShopId
            };

            return eRet;
        }

        /// <summary>
        /// 员工类型销售额数据库对象转换为业务对象.
        /// </summary>
        /// <param name="info">员工类型销售额数据库对象.</param>
        /// <returns>员工类型销售额业务对象.</returns>
        public static EmployeeTypeSale ConvertEmployeeTypeSaleToBusiness(EmployeeTypeSaleInfo info)
        {
            if (info == null)
            {
                return null;
            }

            var eRet = new EmployeeTypeSale
            {
                EmployeeTypeSaleId = info.EmployeeTypeSaleId,
                EmployeeId = info.EmployeeId,
                Month = info.Month,
                SaleType = info.SaleType,
                Target = info.Target,
                Actual = info.Actual,
                ShopId = info.ShopId
            };

            return eRet;
        }
    }
}
