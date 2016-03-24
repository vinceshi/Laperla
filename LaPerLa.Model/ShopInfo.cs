using System;
using System.ComponentModel.DataAnnotations;

namespace LaPerLa.Model
{
    /// <summary>
    /// 店铺数据库对象.
    /// </summary>
    public class ShopInfo
    {
        /// <summary>
        /// 自增主键.
        /// </summary>
        [Key]
        public virtual Int64 ShopId { get; set; }

        /// <summary>
        /// 店铺类型.
        /// </summary>
        public virtual int ShopType { get; set; }

        /// <summary>
        /// 店铺名.
        /// </summary>
        public virtual string ShopName { get; set; }

        /// <summary>
        /// 地区Id.
        /// </summary>
        public virtual Int64 DistrictId { get; set; }
    }
}
