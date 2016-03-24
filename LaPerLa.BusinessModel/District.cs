using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace LaPerLa.BusinessModel
{
    /// <summary>
    /// 地区业务对象.
    /// </summary>
    [DataContract]
    public class District
    {
        /// <summary>
        /// 自增主键.
        /// </summary>
        [DataMember]
        public Int64 DistrictId { get; set; }

        /// <summary>
        /// 国家.
        /// </summary>
        [DataMember]
        public string Country { get; set; }

        /// <summary>
        /// 省/州
        /// </summary>
        [DataMember]
        public string State { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [DataMember]
        public string City { get; set; }
    }
}
