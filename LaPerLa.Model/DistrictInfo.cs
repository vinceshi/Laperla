using System;
using System.ComponentModel.DataAnnotations;

namespace LaPerLa.Model
{
    /// <summary>
    /// 地区数据库对象.
    /// </summary>
    public class DistrictInfo
    {
        /// <summary>
        /// 自增主键.
        /// </summary>
        [Key]
        public virtual Int64 DistrictId { get; set; }

        /// <summary>
        /// 国家.
        /// </summary>
        public virtual string Country { get; set; }

        /// <summary>
        /// 省/州
        /// </summary>
        public virtual string State { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public virtual string City { get; set; }
    }
}
