using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using LaPerLa.BusinessModel;

namespace LaPerLa.Contract
{
    /// <summary>
    /// 员工接口.
    /// </summary>
    [ServiceContract]
    public interface IEmployee
    {
        /// <summary>
        /// 添加员工.
        /// </summary>
        /// <param name="info">员工信息.</param>
        /// <returns>新增的员工信息.</returns>
        [OperationContract]
        Employee AddEmployee(Employee info);

        /// <summary>
        /// 根据店铺获取所有员工.
        /// </summary>
        /// <param name="shopId">店铺Id.</param>
        /// <returns>该店铺下所有员工信息.</returns>
        [OperationContract]
        IList<Employee> GetEmployeesByShopId(long shopId);
    }
}
