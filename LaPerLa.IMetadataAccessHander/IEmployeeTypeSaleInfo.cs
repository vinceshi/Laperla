using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LaPerLa.Model;

namespace LaPerLa.IMetadataAccess
{
    /// <summary>
    /// 员工类型销售额接口
    /// </summary>
    public interface IEmployeeTypeSaleInfo
    {
        /// <summary>
        /// 根据类型获取员工类型销售额信息
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="saleType">销售类型</param>
        /// <param name="month">生效月份</param>
        /// <returns>员工类型销售额</returns>
        EmployeeTypeSaleInfo GetEmployeeTypeSaleInfoByType(long employeeId, int saleType, string month);

        /// <summary>
        /// 添加员工类型销售额信息
        /// </summary>
        /// <param name="info">员工类型销售额信息</param>
        /// <returns>新增的员工类型销售额信息</returns>
        EmployeeTypeSaleInfo AddEmployeeTypeSaleInfo(EmployeeTypeSaleInfo info);
    }
}
