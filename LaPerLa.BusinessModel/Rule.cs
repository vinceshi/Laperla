using System;
using System.IO;
using System.Runtime.Serialization;

namespace LaPerLa.BusinessModel
{
    /// <summary>
    /// 规则业务对象.
    /// </summary>
    [DataContract]
    public class Rule
    {
        /// <summary>
        /// 自增主键.
        /// </summary>
        [DataMember]
        public Int64 RuleId { get; set; }

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

        /// <summary>
        /// 提成计算类型.
        /// </summary>
        [DataMember]
        public int RuleType { get; set; }

        /// <summary>
        /// 规则描述.
        /// </summary>
        [DataMember]
        public string RuleDescription { get; set; }

        /// <summary>
        /// 规则额度.
        /// </summary>
        [DataMember]
        public double Bonus { get; set; }

        /// <summary>
        /// 计算比较类型.
        /// </summary>
        [DataMember]
        public int OperationType { get; set; }

        /// <summary>
        /// 计算比较值.
        /// </summary>
        [DataMember]
        public double OperationValue { get; set; }

        /// <summary>
        /// 计算比较最大值.
        /// </summary>
        [DataMember]
        public double OperationMaxValue { get; set; }

        /// <summary>
        /// 计算比较最小值.
        /// </summary>
        [DataMember]
        public double OperationMinValue { get; set; }

        /// <summary>
        /// 计算规则序列
        /// </summary>
        [DataMember]
        public int RuleOrder { get; set; }
    }
}
