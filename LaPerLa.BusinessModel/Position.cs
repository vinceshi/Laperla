using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LaPerLa.BusinessModel
{
    /// <summary>
    /// 职位业务对象.
    /// </summary>
    [DataContract]
    public class Position
    {
        /// <summary>
        /// 自增主键.
        /// </summary>
        [DataMember]
        public Int64 PositionId { get; set; }

        /// <summary>
        /// 店铺Id.
        /// </summary>
        [DataMember]
        public Int64 ShopId { get; set; }

        /// <summary>
        /// 地区Id.
        /// </summary>
        [DataMember]
        public Int64 DistrictId { get; set; }

        /// <summary>
        /// 职位名.
        /// </summary>
        [DataMember]
        public string PositionName { get; set; }
    }
}
