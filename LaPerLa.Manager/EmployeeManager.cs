using System;
using System.Collections.Generic;
using System.Linq;
using LaPerLa.BusinessModel;
using LaPerLa.IMetadataAccess;
using LaPerLa.DataAccess.EF;
using LaPerLa.Utility;
using log4net;

namespace LaPerLa.Manager
{
    public class EmployeeManager
    {
        private readonly IMetadataAccessHander _metadataAccessHander;
        private static readonly ILog Log = LogManager.GetLogger(typeof(EmployeeManager));

        public EmployeeManager()
        {
            if (this._metadataAccessHander == null)
            {
                this._metadataAccessHander = new MetadataRepository();
            }
        }

        /// <summary>
        /// 添加员工.
        /// </summary>
        /// <param name="info">员工信息.</param>
        /// <returns>新增的员工信息.</returns>
        public Employee AddEmployee(Employee info)
        {
            try
            {
                var employeeInfo = ModelConverter.ConvertEmployeeFromBusiness(info);
                var newEmployeeInfo = this._metadataAccessHander.AddEmployeeInfo(employeeInfo);
                return ModelConverter.ConvertEmployeeToBusiness(newEmployeeInfo);
            }
            catch (Exception ex)
            {
                Log.Error("EmployeeManager-AddEmployee:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 根据店铺获取所有员工.
        /// </summary>
        /// <param name="shopId">店铺Id.</param>
        /// <returns>该店铺下所有员工信息.</returns>
        public IList<Employee> GetEmployeesByShopId(long shopId)
        {
            try
            {
                var lRet = new List<Employee>();
                var infos = this._metadataAccessHander.GetEmployeeInfosByShopId(shopId);

                if (infos != null)
                {
                    lRet.AddRange(infos.Select(ModelConverter.ConvertEmployeeToBusiness));
                }

                return lRet;
            }
            catch (Exception ex)
            {
                Log.Error("EmployeeManager-GetEmployeesByShopId:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }
    }
}
