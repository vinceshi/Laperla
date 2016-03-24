using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaPerLa.BusinessModel
{
    /// <summary>
    /// 员工类型销售额业务对象
    /// </summary>
    public class EmployeeTypeSale
    {
        /// <summary>
        /// 自增主键.
        /// </summary>
        public Int64 EmployeeTypeSaleId { get; set; }

        /// <summary>
        /// 员工Id.
        /// </summary>
        public Int64 EmployeeId { get; set; }

        /// <summary>
        /// 店铺Id.
        /// </summary>
        public Int64 ShopId { get; set; }

        /// <summary>
        /// 目标周销售额.
        /// </summary>
        public double Target { get; set; }

        /// <summary>
        /// 实际周销售额.
        /// </summary>
        public double Actual { get; set; }

        /// <summary>
        /// 生效月份
        /// </summary>
        public string Month { get; set; }

        /// <summary>
        /// 销售类型
        /// </summary>
        public int SaleType { get; set; }
    }
}
