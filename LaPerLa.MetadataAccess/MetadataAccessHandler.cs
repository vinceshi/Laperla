using System;
using System.Collections.Generic;
using LaPerLa.Model;
using LaPerLa.IMetadataAccess;
using NHibernate;
using log4net;

namespace LaPerLa.MetadataAccess
{
    public class MetadataAccessHandler : IMetadataAccessHander
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MetadataAccessHandler));

        /// <summary>
        /// 添加地区.
        /// </summary>
        /// <param name="info">地区信息.</param>
        /// <returns>新增的地区信息.</returns>
        public Int64 AddDistrictInfo(DistrictInfo info)
        {
            try
            {
                using(ISession session = NHibernateHelper.OpenSession())
                {
                    using(var tran = session.BeginTransaction())
                    {
                        var districtId = (Int64)session.Save(info);
                        tran.Commit();
                        return districtId;
                    }
                }
            }
            catch(Exception ex)
            {
                Log.Error("MetadataAccessHandler-AddDistrictInfo:" + ex.Message + "\r\n" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// 添加职位.
        /// </summary>
        /// <param name="info">职位信息.</param>
        /// <returns>职位Id.</returns>
        public long AddPositionInfo(PositionInfo info)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (var tran = session.BeginTransaction())
                    {
                        var positionId = (Int64)session.Save(info);
                        tran.Commit();
                        return positionId;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("MetadataAccessHandler-AddPositionInfo:" + ex.Message + "\r\n" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// 添加员工.
        /// </summary>
        /// <param name="info">员工信息.</param>
        /// <returns>新增的员工信息.</returns>
        public long AddEmployeeInfo(EmployeeInfo info)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (var tran = session.BeginTransaction())
                    {
                        var employeeId = (Int64)session.Save(info);
                        tran.Commit();
                        return employeeId;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("MetadataAccessHandler-AddEmployeeInfo:" + ex.Message + "\r\n" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// 添加员工销售额.
        /// </summary>
        /// <param name="info">员工销售额信息.</param>
        /// <returns>新增的员工销售额信息.</returns>
        public long AddEmployeeSaleInfo(EmployeeSaleInfo info)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (var tran = session.BeginTransaction())
                    {
                        var employeeSaleId = (Int64)session.Save(info);
                        tran.Commit();
                        return employeeSaleId;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("MetadataAccessHandler-AddEmployeeSaleInfo:" + ex.Message + "\r\n" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// 添加店铺.
        /// </summary>
        /// <param name="info">店铺信息.</param>
        /// <returns>新增的店铺信息.</returns>
        public long AddShopInfo(ShopInfo info)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (var tran = session.BeginTransaction())
                    {
                        var shopId = (Int64)session.Save(info);
                        tran.Commit();
                        return shopId;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("MetadataAccessHandler-AddShopInfo:" + ex.Message + "\r\n" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// 添加规则.
        /// </summary>
        /// <param name="info">规则信息.</param>
        /// <returns>新增的规则信息.</returns>
        public long AddRuleInfo(RuleInfo info)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (var tran = session.BeginTransaction())
                    {
                        var ruleId = (Int64)session.Save(info);
                        tran.Commit();
                        return ruleId;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("MetadataAccessHandler-AddRuleInfo:" + ex.Message + "\r\n" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// 登录.
        /// </summary>
        /// <param name="info">用户信息.</param>
        /// <returns>session id.</returns>
        public Int64 Login(UserInfo info)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var userIds = session.QueryOver<UserInfo>()
                        .Select(u => u.UserId)
                        .Where(u => info.UserName == u.UserName && u.Password == info.Password).List<Int64>();

                    if (userIds != null && userIds.Count == 1)
                    {
                        return userIds[0];
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                Log.Error("MetadataAccessHandler-AddRuleInfo:" + ex.Message + "\r\n" + ex.StackTrace);
                return 0;
            }
        }


        /// <summary>
        /// 查询所有地区.
        /// </summary>
        /// <returns>所有地区信息.</returns>
        public IList<DistrictInfo> QueryAllDistrictInfos()
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var infos = session.QueryOver<DistrictInfo>().OrderBy(info=>info.City).Asc.List();
                    return infos;
                }
            }
            catch (Exception ex)
            {
                Log.Error("MetadataAccessHandler-QueryAllDistrictInfos:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 根据地区获取所有店铺
        /// </summary>
        /// <param name="districtId">地区Id.</param>
        /// <returns>该地区下所有店铺信息.</returns>
        public IList<ShopInfo> GetShopInfosByDistrictId(long districtId)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var infos = session.QueryOver<ShopInfo>().Where(info=>info.DistrictId == districtId).OrderBy(info => info.ShopName).Asc.List();
                    return infos;
                }
            }
            catch (Exception ex)
            {
                Log.Error("MetadataAccessHandler-GetShopInfosByDistrictId:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }


        /// <summary>
        /// 根据店铺获取所有员工.
        /// </summary>
        /// <param name="shopId">店铺Id.</param>
        /// <returns>该店铺下所有员工信息.</returns>
        public IList<EmployeeInfo> GetEmployeeInfosByShopId(long shopId)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var infos = session.QueryOver<EmployeeInfo>().Where(info => info.ShopId == shopId).OrderBy(info => info.EnglishName).Asc.List();
                    return infos;
                }
            }
            catch (Exception ex)
            {
                Log.Error("MetadataAccessHandler-GetEmployeeInfosByShopId:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }


        /// <summary>
        /// 根据员工Ids获取员工销售额.
        /// </summary>
        /// <param name="employeeIds">员工Ids.</param>
        /// <returns>员工销售额信息.</returns>
        public IList<EmployeeSaleInfo> GetEmployeeSaleInfosByEmployeeIds(IList<long> employeeIds)
        {
            if (employeeIds == null || employeeIds.Count == 0)
            {
                return null;
            }

            IList<EmployeeSaleInfo> lRet = new List<EmployeeSaleInfo>();

            try
            {
                foreach (var employeeId in employeeIds)
                {
                    using (ISession session = NHibernateHelper.OpenSession())
                    {
                        var infos = session.QueryOver<EmployeeSaleInfo>().Where(info => info.EmployeeId == employeeId).OrderBy(info => info.Week).Asc.List();

                        if (infos != null && infos.Count > 0)
                        {
                            foreach (var employeeSaleInfo in infos)
                            {
                                lRet.Add(employeeSaleInfo);
                            }
                        }
                    }
                }

                return lRet;
            }
            catch (Exception ex)
            {
                Log.Error("MetadataAccessHandler-GetEmployeeSaleInfosByEmployeeIds:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }


        public void Add(UserInfo info)
        {
            throw new NotImplementedException();
        }

        public UserInfo Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
