using System;
using System.Runtime.Serialization;

namespace LaPerLa.BusinessModel
{
    /// <summary>
    /// 员工业务对象.
    /// </summary>
    [DataContract]
    public class Employee
    {
        /// <summary>
        /// 自增主键.
        /// </summary>
        [DataMember]
        public Int64 EmployeeId { get; set; }

        /// <summary>
        /// 中文名.
        /// </summary>
        [DataMember]
        public string ChineseName { get; set; }

        /// <summary>
        /// 英文名.
        /// </summary>
        [DataMember]
        public string EnglishName { get; set; }

        /// <summary>
        /// 职位Id.
        /// </summary>
        [DataMember]
        public Int64 PositionId { get; set; }

        /// <summary>
        /// 店铺Id.
        /// </summary>
        [DataMember]
        public Int64 ShopId { get; set; }
    }
}
