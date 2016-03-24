using LaPerLa.Web.LaPerLaService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaPerLa.Web.Services
{
    /// <summary>
    /// 员工
    /// </summary>
    public class EmployeeServices
    {
        private static readonly ServiceClient client = new ServiceClient();

        /// <summary>
        /// 获取所有地区信息
        /// </summary>
        /// <returns></returns>
        public static List<Employee> GetEmployees(long shopId)
        {
            return client.GetEmployeesByShopId(shopId);
        }

        /// <summary>
        /// 获取销售情况
        /// </summary>
        /// <param name="EmployeesId"></param>
        /// <returns></returns>
        public static List<EmployeeSale> GetEmployeeSales(List<long> EmployeesId, DateTime month)
        {
            return client.GetEmployeeSalesByEmployeeIds(EmployeesId, month.ToString("yyyy-MM"));
        }

        //public static List<EmployeeSale> GetEmployeeSales(List<long> EmployeesId)
        //{
        //    return client.ge(EmployeesId);
        //}

        /// <summary>
        /// 获取职位
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        public static List<Position> GetPositionByIds(List<long> positionId)
        {
            return client.GetPositionByIds(positionId);
        }
    }
}