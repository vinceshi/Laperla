using System;
using System.Collections.Generic;
using LaPerLa.Model;

namespace LaPerLa.IMetadataAccess
{
    public interface IEmployeeInfo
    {
        /// <summary>
        /// 添加员工.
        /// </summary>
        /// <param name="info">员工信息.</param>
        /// <returns>新增的员工信息.</returns>
        EmployeeInfo AddEmployeeInfo(EmployeeInfo info);

        /// <summary>
        /// 根据店铺获取所有员工.
        /// </summary>
        /// <param name="shopId">店铺Id.</param>
        /// <returns>该店铺下所有员工信息.</returns>
        IList<EmployeeInfo> GetEmployeeInfosByShopId(long shopId);
    }
}
