using System;
using System.ComponentModel.DataAnnotations;

namespace LaPerLa.Model
{
    /// <summary>
    /// 员工数据库对象.
    /// </summary>
    public class EmployeeInfo
    {
        /// <summary>
        /// 自增主键.
        /// </summary>
        [Key]
        public virtual Int64 EmployeeId { get; set; }

        /// <summary>
        /// 中文名.
        /// </summary>
        public virtual string ChineseName { get; set; }

        /// <summary>
        /// 英文名.
        /// </summary>
        public virtual string EnglishName { get; set; }

        /// <summary>
        /// 职位Id.
        /// </summary>
        public virtual Int64 PositionId { get; set; }

        /// <summary>
        /// 店铺Id.
        /// </summary>
        public virtual Int64 ShopId { get; set; }
    }
}
