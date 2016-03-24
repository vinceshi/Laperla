using System;
using System.ComponentModel.DataAnnotations;

namespace LaPerLa.Model
{
    /// <summary>
    /// 职位数据库对象.
    /// </summary>
    public class PositionInfo
    {
        /// <summary>
        /// 自增主键.
        /// </summary>
        [Key]
        public virtual Int64 PositionId { get; set; }

        /// <summary>
        /// 店铺Id.
        /// </summary>
        public virtual Int64 ShopId { get; set; }

        /// <summary>
        /// 地区Id.
        /// </summary>
        public virtual Int64 DistrictId { get; set; }

        /// <summary>
        /// 职位名.
        /// </summary>
        public virtual string PositionName { get; set; }
    }
}
