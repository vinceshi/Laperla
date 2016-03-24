using System;
using System.Collections.Generic;
using LaPerLa.Model;

namespace LaPerLa.IMetadataAccess
{
    public interface IEmployeeSaleInfo
    {
        /// <summary>
        /// 添加员工销售额.
        /// </summary>
        /// <param name="info">员工销售额信息.</param>
        /// <returns>新增的员工销售额信息.</returns>
        EmployeeSaleInfo AddEmployeeSaleInfo(EmployeeSaleInfo info);

        /// <summary>
        /// 根据员工Ids获取员工销售额.
        /// </summary>
        /// <param name="employeeIds">员工Ids.</param>
        /// <param name="month">月份</param>
        /// <returns>员工销售额信息.</returns>
        IList<EmployeeSaleInfo> GetEmployeeSaleInfosByEmployeeIds(IList<long> employeeIds, string month);

        /// <summary>
        /// 根据员工Id获取当月销售类别总额
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="saleType">销售类型</param>
        /// <param name="month">生效月份</param>
        /// <returns>总额</returns>
        double GetSumEmployeeSaleInfoByEmployeeId(long employeeId, int saleType, string month);

        /// <summary>
        /// 获取当月员工销售额
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="month">生效月份</param>
        /// <returns>员工销售额</returns>
        IList<EmployeeSaleInfo> GetCurrentMonthEmployeeSaleInfo(long employeeId, string month);
    }
}
