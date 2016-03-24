using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LaPerLa.BusinessModel
{
    /// <summary>
    /// 员工提成业务对象.
    /// </summary>
    [DataContract]
    public class Bonus
    {
        /// <summary>
        /// 地区Id.
        /// </summary>
        [DataMember]
        public long DistrictId { get; set; }

        /// <summary>
        /// 店铺Id.
        /// </summary>
        [DataMember]
        public long ShopId { get; set; }

        /// <summary>
        /// 员工实际满足规则.
        /// </summary>
        [DataMember]
        public IDictionary<long, IDictionary<long, IList<Rule>>> EmployeeRule { get; set; }

        /// <summary>
        /// 店铺销售额
        /// </summary>
        [DataMember]
        public IDictionary<long, ShopSale> ShopSaleList { get; set; }

        /// <summary>
        /// 城市集合比
        /// </summary>
        [DataMember]
        public double CityPool { get; set; }
    }
}
