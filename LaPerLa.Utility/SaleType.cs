using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaPerLa.Utility
{
    /// <summary>
    /// 销售类型.
    /// </summary>
    public static class SaleType
    {
        /// <summary>
        /// 目标周销售额
        /// </summary>
        public static int TargetType = 0;

        /// <summary>
        /// 实际周销售额
        /// </summary>
        public static int AchievementType = 1;

        /// <summary>
        /// 3折以下
        /// </summary>
        public static int Below70 = 2;

        /// <summary>
        /// 3折以上
        /// </summary>
        public static int Above70 = 3;
    }
}
