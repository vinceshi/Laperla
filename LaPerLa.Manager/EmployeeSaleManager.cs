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
    public class EmployeeSaleManager
    {
        private readonly IMetadataAccessHander _metadataAccessHander;
        private static readonly ILog Log = LogManager.GetLogger(typeof(EmployeeSaleManager));

        public EmployeeSaleManager()
        {
            if (this._metadataAccessHander == null)
            {
                this._metadataAccessHander = new MetadataRepository();
            }
        }

        /// <summary>
        /// 添加员工销售额.
        /// </summary>
        /// <param name="info">员工销售额信息.</param>
        /// <returns>新增的员工销售额信息.</returns>
        public EmployeeSale AddEmployeeSale(EmployeeSale info)
        {
            try
            {
                var employeeSaleInfo = ModelConverter.ConvertEmployeeSaleFromBusiness(info);
                var newEmployeeSaleInfo = this._metadataAccessHander.AddEmployeeSaleInfo(employeeSaleInfo);
                return ModelConverter.ConvertEmployeeSaleToBusiness(newEmployeeSaleInfo);
            }
            catch (Exception ex)
            {
                Log.Error("EmployeeSaleManager-AddEmployeeSale:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 根据员工Ids获取员工销售额.
        /// </summary>
        /// <param name="employeeIds">员工Ids.</param>
        /// <param name="month">月份</param>
        /// <returns>员工销售额信息.</returns>
        public IList<EmployeeSale> GetEmployeeSalesByEmployeeIds(IList<long> employeeIds, string month)
        {
            try
            {
                var lRet = new List<EmployeeSale>();
                var infos = this._metadataAccessHander.GetEmployeeSaleInfosByEmployeeIds(employeeIds, month);

                if (infos != null)
                {
                    lRet.AddRange(infos.Select(ModelConverter.ConvertEmployeeSaleToBusiness));
                }

                return lRet;
            }
            catch (Exception ex)
            {
                Log.Error("EmployeeSaleManager-GetEmployeeSalesByEmployeeIds:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 根据员工Id获取员工销售额.
        /// </summary>
        /// <param name="employeeIds">员工Id</param>
        /// <returns>员工销售额信息.</returns>
        public IList<EmployeeSale> GetCurrentMonthEmployeeSaleInfo(long employeeId, string month)
        {
            try
            {
                var lRet = new List<EmployeeSale>();
                var infos = this._metadataAccessHander.GetCurrentMonthEmployeeSaleInfo(employeeId, month);

                if (infos != null)
                {
                    lRet.AddRange(infos.Select(ModelConverter.ConvertEmployeeSaleToBusiness));
                }

                return lRet;
            }
            catch (Exception ex)
            {
                Log.Error("EmployeeSaleManager-GetCurrentMonthEmployeeSaleInfo:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }
    }
}
