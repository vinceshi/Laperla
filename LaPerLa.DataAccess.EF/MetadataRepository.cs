using LaPerLa.IMetadataAccess;
using LaPerLa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using LaPerLa.Utility;
using log4net;

namespace LaPerLa.DataAccess.EF
{
    public class MetadataRepository : IDisposable, IMetadataAccessHander
    {
        private DataContext _context = new DataContext();
        private static readonly ILog Log = LogManager.GetLogger(typeof(MetadataRepository));

        public Int64 Login(UserInfo info)
        {
            try
            {
                var userInfo = _context.UserInfo.Where(u => u.UserName == info.UserName && u.Password == info.Password).ToList();

                if (userInfo.Count() == 1)
                {
                    return userInfo[0].UserId;
                }
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-Login:" + ex.Message + "\r\n" + ex.StackTrace);
                return 0;
            }

            return 0;
        }

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="id">用户Id.</param>
        /// <returns>用户信息.</returns>
        public UserInfo Get(int id)
        {
            try
            {
                var info = _context.UserInfo.Find(id);
                return info;
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-Get:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userInfo"></param>
        public void Add(UserInfo userInfo)
        {
            try
            {
                _context.UserInfo.Add(userInfo);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-Add:" + ex.Message + "\r\n" + ex.StackTrace);
            }
            
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public DistrictInfo AddDistrictInfo(DistrictInfo info)
        {
            try
            {
                var dRet = _context.DistrictInfo.Add(info);
                _context.SaveChanges();
                return dRet;
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-AddDistrictInfo:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        public IList<DistrictInfo> QueryAllDistrictInfos()
        {
            try
            {
                return _context.DistrictInfo.ToList();
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-QueryAllDistrictInfos:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        public PositionInfo AddPositionInfo(PositionInfo info)
        {
            try
            {
                var pRet = _context.PositionInfo.Add(info);
                _context.SaveChanges();
                return pRet;
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-AddPositionInfo:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        public EmployeeInfo AddEmployeeInfo(EmployeeInfo info)
        {
            try
            {
                var eRet = _context.EmployeeInfo.Add(info);
                _context.SaveChanges();
                return eRet;
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-AddEmployeeInfo:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        public IList<EmployeeInfo> GetEmployeeInfosByShopId(long shopId)
        {
            try
            {
                return _context.EmployeeInfo.Where(info => info.ShopId == shopId).ToList();
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-GetEmployeeInfosByShopId:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        public EmployeeSaleInfo AddEmployeeSaleInfo(EmployeeSaleInfo info)
        {
            try
            {
                var rRet = _context.EmployeeSaleInfo.Add(info);
                _context.SaveChanges();
                return rRet;
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-AddEmployeeSaleInfo:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 根据员工Ids获取员工销售额.
        /// </summary>
        /// <param name="employeeIds">员工Ids.</param>
        /// <param name="month">月份</param>
        /// <returns>员工销售额信息.</returns>
        public IList<EmployeeSaleInfo> GetEmployeeSaleInfosByEmployeeIds(IList<long> employeeIds, string month)
        {
            try
            {
                if (employeeIds == null || employeeIds.Count == 0)
                {
                    return null;
                }

                var lRet = _context.EmployeeSaleInfo.Where(p=> employeeIds.Contains(p.EmployeeId) && p.Month == month).ToList();             

                return lRet;
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-GetEmployeeSaleInfosByEmployeeIds:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        public ShopInfo AddShopInfo(ShopInfo info)
        {
            try
            {
                var sRet = _context.ShopInfo.Add(info);
                _context.SaveChanges();
                return sRet;
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-AddShopInfo:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        public IList<ShopInfo> GetShopInfosByDistrictId(long districtId)
        {
            try
            {
                return _context.ShopInfo.Where(info => info.DistrictId == districtId).ToList();
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-GetShopInfosByDistrictId:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 添加规则.
        /// </summary>
        /// <param name="info">规则信息.</param>
        /// <returns>新增的规则信息.</returns>
        public RuleInfo AddRuleInfo(RuleInfo info)
        {
            try
            {
                var rRet = _context.RuleInfo.Add(info);
                _context.SaveChanges();
                return rRet;
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-AddRuleInfo:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 获取当月店铺信息.
        /// </summary>
        /// <param name="shopId">店铺Id.</param>
        /// <param name="month">月份.</param>
        /// <returns>当月店铺信息.</returns>
        public ShopSaleInfo GetCurrentMonthShopSaleInfo(long shopId, string month)
        {
            try
            {
                return _context.ShopSaleInfo.FirstOrDefault(info => info.ShopId == shopId && info.Month == month);
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-GetCurrentMonthShopSaleInfo:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }


        /// <summary>
        /// 获取当月地区下所有店铺销售额信息.
        /// </summary>
        /// <param name="districtId">地区Id.</param>
        /// <param name="month">月份.</param>
        /// <returns>当月所有店铺销售额信息.</returns>
        public IList<ShopSaleInfo> GetCurrentMonthShopSaleInfoByDistrictId(long districtId, string month)
        {
            try
            {
                return _context.ShopSaleInfo.Where(info => info.DistrictId == districtId && info.Month == month).ToList();
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-GetCurrentMonthShopSaleInfoByDistrictId:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }


        /// <summary>
        /// 获取店铺计算规则.
        /// </summary>
        /// <param name="shopId">店铺Id.</param>
        /// <returns>计算规则信息.</returns>
        public IList<RuleInfo> GetRuleInfosByShopId(long shopId)
        {
            try
            {
                return _context.RuleInfo.Where(info => info.ShopId == shopId).OrderBy(info => info.RuleOrder).ToList();
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-GetRuleInfosByShopId:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }


        /// <summary>
        /// 获取店铺计算规则类型.
        /// </summary>
        /// <param name="shopId">店铺Id.</param>
        /// <returns>计算规则类型.</returns>
        public IList<int> GetRuleTypesByShopId(long shopId)
        {
            try
            {
                return _context.RuleInfo.Where(info => info.ShopId == shopId).Select(u => u.RuleType).Distinct().ToList();
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-GetRuleTypesByShopId:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 根据Id获取店铺信息.
        /// </summary>
        /// <param name="shopId">店铺Id.</param>
        /// <returns>店铺信息.</returns>
        public ShopInfo GetShopInfoByShopId(long shopId)
        {
            try
            {
                return _context.ShopInfo.Find(shopId);
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-GetShopInfoByShopId:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }


        /// <summary>
        /// 根据员工Id获取当月销售类别总额
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="saleType">销售类型</param>
        /// <param name="month">生效月份</param>
        /// <returns>总额</returns>
        public double GetSumEmployeeSaleInfoByEmployeeId(long employeeId, int saleType, string month)
        {
            try
            {
                if (saleType == SaleType.TargetType)
                {
                    return
                        _context.EmployeeSaleInfo.Where(
                            e => e.EmployeeId == employeeId && e.Month == month).Sum(e => e.TargetSale);
                }
                
                if (saleType == SaleType.AchievementType)
                {
                    return
                        _context.EmployeeSaleInfo.Where(
                            e => e.EmployeeId == employeeId && e.Month == month).Sum(e => e.ActualSale);
                }

                return -1;
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-GetSumEmployeeSaleInfoByEmployeeId:" + ex.Message + "\r\n" + ex.StackTrace);
                return -1;
            }
        }


        /// <summary>
        /// 获取当月员工销售额
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="month">生效月份</param>
        /// <returns>员工销售额</returns>
        public IList<EmployeeSaleInfo> GetCurrentMonthEmployeeSaleInfo(long employeeId, string month)
        {
            try
            {
                return _context.EmployeeSaleInfo.Where(info => info.EmployeeId == employeeId && info.Month == month).ToList();
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-GetCurrentMonthEmployeeSaleInfo:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 获取当月店铺销售额
        /// </summary>
        /// <param name="shopId">店铺Id</param>
        /// <param name="month">生效月份</param>
        /// <returns>店铺销售额</returns>
        IList<ShopSaleInfo> IShopSaleInfo.GetCurrentMonthShopSaleInfo(long shopId, string month)
        {
            try
            {
                return _context.ShopSaleInfo.Where(info => info.ShopId == shopId && info.Month == month).OrderBy(info=>info.Week).ToList();
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-GetCurrentMonthShopSaleInfo:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 根据类型获取员工类型销售额信息
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="saleType">销售类型</param>
        /// <param name="month">生效月份</param>
        /// <returns>员工类型销售额</returns>
        public EmployeeTypeSaleInfo GetEmployeeTypeSaleInfoByType(long employeeId, int saleType, string month)
        {
            try
            {

                var infos = _context.EmployeeTypeSaleInfo.Where(info => info.EmployeeId == employeeId && info.SaleType == saleType && info.Month == month)
                        .ToList();

                if (infos.Count == 1)
                {
                    return infos[0];
                }

                return new EmployeeTypeSaleInfo();
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-GetEmployeeTypeSaleInfoByType:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 添加店铺销售额
        /// </summary>
        /// <param name="info">店铺销售额</param>
        /// <returns>新增店铺销售额</returns>
        public ShopSaleInfo AddShopSaleInfo(ShopSaleInfo info)
        {
            try
            {
                var sRet = _context.ShopSaleInfo.Add(info);
                _context.SaveChanges();
                return sRet;
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-AddShopSaleInfo:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 添加员工类型销售额信息
        /// </summary>
        /// <param name="info">员工类型销售额信息</param>
        /// <returns>新增的员工类型销售额信息</returns>
        public EmployeeTypeSaleInfo AddEmployeeTypeSaleInfo(EmployeeTypeSaleInfo info)
        {
            try
            {
                var eRet = _context.EmployeeTypeSaleInfo.Add(info);
                _context.SaveChanges();
                return eRet;
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-AddEmployeeTypeSaleInfo:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }


        /// <summary>
        /// 根据职位Id获取职位信息
        /// </summary>
        /// <param name="positionId">职位Id</param>
        /// <returns>该职位信息</returns>
        public PositionInfo GetPositionInfoById(long positionId)
        {
            try
            {
                return _context.PositionInfo.Find(positionId);
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-GetPositionInfoById:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 根据职位Ids获取职位信息
        /// </summary>
        /// <param name="positionIds"></param>
        /// <returns></returns>
        public IList<PositionInfo> GetPositionInfoByIds(IList<long> positionIds)
        {
            try
            {
                return _context.PositionInfo.Where(p => positionIds.Contains(p.PositionId)).ToList();
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-GetPositionInfoById:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 根据Id获取地区信息
        /// </summary>
        /// <param name="districtId">地区Id</param>
        /// <returns>地区信息</returns>
        public DistrictInfo GetDistrictInfoById(long districtId)
        {
            try
            {
                return _context.DistrictInfo.Find(districtId);
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-GetDistrictInfoById:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 获取所有的店信息
        /// </summary>
        /// <returns></returns>
        public IList<ShopInfo> GetAllShops()
        {
            try
            {
                return _context.ShopInfo.ToList();
            }
            catch (Exception ex)
            {
                Log.Error("MetadataRepository-GetAllShops:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }
    }
}
