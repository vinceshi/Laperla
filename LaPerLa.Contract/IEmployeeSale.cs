using System.Collections.Generic;
using System.ServiceModel;
using LaPerLa.BusinessModel;

namespace LaPerLa.Contract
{
    /// <summary>
    /// 员工销售额接口.
    /// </summary>
    [ServiceContract]
    public interface IEmployeeSale
    {
        /// <summary>
        /// 添加员工销售额.
        /// </summary>
        /// <param name="info">员工销售额信息.</param>
        /// <returns>新增的员工销售额信息.</returns>
        [OperationContract]
        EmployeeSale AddEmployeeSale(EmployeeSale info);

        /// <summary>
        /// 根据员工Ids获取员工销售额.
        /// </summary>
        /// <param name="employeeIds">员工Ids.</param>
        /// <param name="month">月份</param>
        /// <returns>员工销售额信息.</returns>
        [OperationContract]
        IList<EmployeeSale> GetEmployeeSalesByEmployeeIds(IList<long> employeeIds, string month);

        /// <summary>
        /// 添加员工类型销售额信息
        /// </summary>
        /// <param name="info">员工类型销售额信息</param>
        /// <returns>新增的员工类型销售额信息</returns>
        [OperationContract]
        EmployeeTypeSale AddEmployeeTypeSale(EmployeeTypeSale info);
    }
}
