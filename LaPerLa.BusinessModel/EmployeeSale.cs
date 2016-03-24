using System;
using System.Runtime.Serialization;

namespace LaPerLa.BusinessModel
{
    /// <summary>
    /// 员工销售额业务对象.
    /// </summary>
    [DataContract]
    public class EmployeeSale
    {
        /// <summary>
        /// 自增主键.
        /// </summary>
        [DataMember]
        public Int64 EmployeeSaleId { get; set; }

        /// <summary>
        /// 员工Id.
        /// </summary>
        [DataMember]
        public Int64 EmployeeId { get; set; }

        /// <summary>
        /// 店铺Id.
        /// </summary>
        [DataMember]
        public Int64 ShopId { get; set; }

        /// <summary>
        /// 周序列.
        /// </summary>
        [DataMember]
        public int Week { get; set; }

        /// <summary>
        /// 目标周销售额.
        /// </summary>
        [DataMember]
        public double TargetSale { get; set; }

        /// <summary>
        /// 实际周销售额.
        /// </summary>
        [DataMember]
        public double ActualSale { get; set; }

        /// <summary>
        /// 销售额.
        /// </summary>
        [DataMember]
        public double Sale { get; set; }

        /// <summary>
        /// 出勤天数.
        /// </summary>
        [DataMember]
        public int Days { get; set; }

        /// <summary>
        /// 生效月份
        /// </summary>
        [DataMember]
        public string Month { get; set; }
    }
}
