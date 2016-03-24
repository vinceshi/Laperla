using System;
using System.ComponentModel.DataAnnotations;

namespace LaPerLa.Model
{
    /// <summary>
    /// 员工类型销售额数据库对象.
    /// </summary>
    public class EmployeeTypeSaleInfo
    {
        /// <summary>
        /// 自增主键.
        /// </summary>
        [Key]
        public virtual Int64 EmployeeTypeSaleId { get; set; }

        /// <summary>
        /// 员工Id.
        /// </summary>
        public virtual Int64 EmployeeId { get; set; }

        /// <summary>
        /// 店铺Id.
        /// </summary>
        public virtual Int64 ShopId { get; set; }

        /// <summary>
        /// 目标周销售额.
        /// </summary>
        public virtual double Target { get; set; }

        /// <summary>
        /// 实际周销售额.
        /// </summary>
        public virtual double Actual { get; set; }

        /// <summary>
        /// 生效月份
        /// </summary>
        public virtual string Month { get; set; }

        /// <summary>
        /// 销售类型
        /// </summary>
        public int SaleType { get; set; }
    }
}
