using System;
using System.ComponentModel.DataAnnotations;

namespace LaPerLa.Model
{
    /// <summary>
    /// 规则数据库对象.
    /// </summary>
    public class RuleInfo
    {
        /// <summary>
        /// 自增主键.
        /// </summary>
        [Key]
        public virtual Int64 RuleId { get; set; }

        /// <summary>
        /// 职位Id.
        /// </summary>
        public virtual Int64 PositionId { get; set; }

        /// <summary>
        /// 店铺Id.
        /// </summary>
        public virtual Int64 ShopId { get; set; }

        /// <summary>
        /// 店铺类型.
        /// </summary>
        public virtual int RuleType { get; set; }

        /// <summary>
        /// 规则描述.
        /// </summary>
        public virtual string RuleDescription { get; set; }

        /// <summary>
        /// 规则额度.
        /// </summary>
        public virtual double Bonus { get; set; }

        /// <summary>
        /// 计算比较类型.
        /// </summary>
        public virtual int OperationType { get; set; }

        /// <summary>
        /// 计算比较值.
        /// </summary>
        public virtual double OperationValue { get; set; }

        /// <summary>
        /// 计算比较最大值.
        /// </summary>
        public double OperationMaxValue { get; set; }

        /// <summary>
        /// 计算比较最小值.
        /// </summary>
        public double OperationMinValue { get; set; }

        /// <summary>
        /// 计算规则序列
        /// </summary>
        public int RuleOrder { get; set; }
    }
}
