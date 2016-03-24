using System;
using System.Runtime.Serialization;

namespace LaPerLa.BusinessModel
{
    [DataContract]
    public class Shop
    {
        /// <summary>
        /// 自增主键.
        /// </summary>
        [DataMember]
        public Int64 ShopId { get; set; }

        /// <summary>
        /// 店铺类型.
        /// </summary>
        [DataMember]
        public int ShopType { get; set; }

        /// <summary>
        /// 店铺名.
        /// </summary>
        [DataMember]
        public string ShopName { get; set; }

        /// <summary>
        /// 地区Id.
        /// </summary>
        [DataMember]
        public Int64 DistrictId { get; set; }
    }
}
