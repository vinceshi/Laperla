using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaPerLa.BusinessModel
{
    public class ShopSale
    {
        /// <summary>
        /// 自增主键.
        /// </summary>
        public long ShopSaleId { get; set; }

        /// <summary>
        /// 店铺Id.
        /// </summary>
        public long ShopId { get; set; }

        /// <summary>
        /// 目标销售额.
        /// </summary>
        public double Target { get; set; }

        /// <summary>
        /// 实际销售额含税.
        /// </summary>
        public double ActualSalesWithTax { get; set; }

        /// <summary>
        /// 税.
        /// </summary>
        public double Tax { get; set; }

        /// <summary>
        /// 实际销售额不含税.
        /// </summary>
        public double ActualSalesWithoutTax { get; set; }

        /// <summary>
        /// 店铺集合比.
        /// </summary>
        public double ShopPool { get; set; }

        /// <summary>
        /// 生效月份.
        /// </summary>
        public string Month { get; set; }

        /// <summary>
        /// 地区Id.
        /// </summary>
        public long DistrictId { get; set; }

        /// <summary>
        /// 周序列
        /// </summary>
        public int Week { get; set; }

        /// <summary>
        /// 周目标销售额
        /// </summary>
        public double TargetWeekSale { get; set; }

        /// <summary>
        /// 周实际销售额
        /// </summary>
        public double ActualWeekSale { get; set; }
    }
}
