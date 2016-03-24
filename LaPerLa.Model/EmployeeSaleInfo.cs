using System;
using System.ComponentModel.DataAnnotations;

namespace LaPerLa.Model
{
    /// <summary>
    /// 员工销售额数据库对象.
    /// </summary>
    public class EmployeeSaleInfo
    {
        /// <summary>
        /// 自增主键.
        /// </summary>
        [Key]
        public virtual Int64 EmployeeSaleId { get; set; }

        /// <summary>
        /// 员工Id.
        /// </summary>
        public virtual Int64 EmployeeId { get; set; }

        /// <summary>
        /// 店铺Id.
        /// </summary>
        public virtual Int64 ShopId { get; set; }

        /// <summary>
        /// 周序列.
        /// </summary>
        public virtual int Week { get; set; }

        /// <summary>
        /// 目标周销售额.
        /// </summary>
        public virtual double TargetSale { get; set; }

        /// <summary>
        /// 实际周销售额.
        /// </summary>
        public virtual double ActualSale { get; set; }

        /// <summary>
        /// 销售额.
        /// </summary>
        public virtual double Sale { get; set; }

        /// <summary>
        /// 出勤天数.
        /// </summary>
        public virtual int Days { get; set; }

        /// <summary>
        /// 生效月份
        /// </summary>
        public virtual string Month { get; set; }
    }
}
