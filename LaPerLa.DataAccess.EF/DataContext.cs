using LaPerLa.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LaPerLa.DataAccess.EF
{
    /// <summary>
    /// 数据库上下文.
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        /// <summary>
        /// 用户数据库对象.
        /// </summary>
        public IDbSet<UserInfo> UserInfo { get; set; }

        /// <summary>
        /// 地区数据库对象.
        /// </summary>
        public IDbSet<DistrictInfo> DistrictInfo { get; set; }

        /// <summary>
        /// 员工数据库对象.
        /// </summary>
        public IDbSet<EmployeeInfo> EmployeeInfo { get; set; }
 
        /// <summary>
        /// 员工销售额数据库对象.
        /// </summary>
        public IDbSet<EmployeeSaleInfo> EmployeeSaleInfo { get; set; }
 
        /// <summary>
        /// 职位数据库对象.
        /// </summary>
        public IDbSet<PositionInfo> PositionInfo { get; set; }
 
        /// <summary>
        /// 规则数据库对象.
        /// </summary>
        public IDbSet<RuleInfo> RuleInfo { get; set; }
 
        /// <summary>
        /// 店铺数据库对象.
        /// </summary>
        public IDbSet<ShopInfo> ShopInfo { get; set; }

        /// <summary>
        /// 店铺销售额数据库对象.
        /// </summary>
        public IDbSet<ShopSaleInfo> ShopSaleInfo { get; set; }

        /// <summary>
        /// 员工类型销售额数据库对象
        /// </summary>
        public IDbSet<EmployeeTypeSaleInfo> EmployeeTypeSaleInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
