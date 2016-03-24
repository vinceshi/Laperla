using System.Collections.Generic;
using LaPerLa.Contract;
using LaPerLa.BusinessModel;
using LaPerLa.Manager;
using log4net;
using log4net.Config;
using System;

namespace LaPerLa.Host
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class LaPerLaService : IService
    {
        private readonly DistrictManager _districtManager;
        private readonly PositionManager _positionManager;
        private readonly UserManager _userManager;
        private readonly ShopManager _shopManager;
        private readonly EmployeeManager _employeeManager;
        private readonly EmployeeSaleManager _employeeSaleManager;
        private readonly RuleManager _ruleManager;
        private readonly ShopSaleManager _shopSaleManager;
        private readonly EmployeeTypeSaleManager _employeeTypeSaleManager;
        private static readonly ILog Log = LogManager.GetLogger(typeof(LaPerLaService));

        public LaPerLaService()
        {
            if (this._districtManager == null)
            {
                this._districtManager = new DistrictManager();
            }

            if (this._positionManager == null)
            {
                this._positionManager = new PositionManager();
            }

            if (this._userManager == null)
            {
                this._userManager = new UserManager();
            }

            if (this._shopManager == null)
            {
                this._shopManager = new ShopManager();
            }

            if (this._employeeManager == null)
            {
                this._employeeManager = new EmployeeManager();
            }

            if (this._employeeSaleManager == null)
            {
                this._employeeSaleManager = new EmployeeSaleManager();
            }

            if (this._ruleManager == null)
            {
                this._ruleManager = new RuleManager();
            }

            if (this._shopSaleManager == null)
            {
                this._shopSaleManager = new ShopSaleManager();
            }

            if (this._employeeTypeSaleManager == null)
            {
                this._employeeTypeSaleManager = new EmployeeTypeSaleManager();
            }

            BasicConfigurator.Configure();

            Log.Info("Entering LaPerLaService.");
        }

        /// <summary>
        /// 添加地区.
        /// </summary>
        /// <param name="info">地区信息.</param>
        /// <returns>新增的地区信息.</returns>
        public District AddDisctrict(District info)
        {
            return this._districtManager.AddDisctrict(info);
        }

        /// <summary>
        /// 添加职位.
        /// </summary>
        /// <param name="info">职位信息.</param>
        /// <returns>职位Id.</returns>
        public Position AddPosition(Position info)
        {
            return this._positionManager.AddPosition(info);
        }

        /// <summary>
        /// 添加员工.
        /// </summary>
        /// <param name="info">员工信息.</param>
        /// <returns>新增的员工信息.</returns>
        public Employee AddEmployee(Employee info)
        {
            return this._employeeManager.AddEmployee(info);
        }

        /// <summary>
        /// 添加员工销售额.
        /// </summary>
        /// <param name="info">员工销售额信息.</param>
        /// <returns>新增的员工销售额信息.</returns>
        public EmployeeSale AddEmployeeSale(EmployeeSale info)
        {
            return this._employeeSaleManager.AddEmployeeSale(info);
        }

        /// <summary>
        /// 添加店铺.
        /// </summary>
        /// <param name="info">店铺信息.</param>
        /// <returns>新增的店铺信息.</returns>
        public Shop AddShop(Shop info)
        {
            return this._shopManager.AddShop(info);
        }

        /// <summary>
        /// 登录.
        /// </summary>
        /// <param name="info">用户信息.</param>
        /// <returns>session id.</returns>
        public string Login(User info)
        {
            return this._userManager.Login(info);
        }

        /// <summary>
        /// 添加规则.
        /// </summary>
        /// <param name="info">规则信息.</param>
        /// <returns>新增的规则信息.</returns>
        public Rule AddRule(Rule info)
        {
            return this._ruleManager.AddRule(info);
        }

        /// <summary>
        /// 登出.
        /// </summary>
        /// <param name="userId">用户Id.</param>
        public void Logout(long userId)
        {
            this._userManager.Logout(userId);
        }

        /// <summary>
        /// 查询所有地区.
        /// </summary>
        /// <returns>所有地区信息.</returns>
        public IList<District> QueryAllDistricts()
        {
            return this._districtManager.QueryAllDistricts();
        }

        /// <summary>
        /// 根据地区获取所有店铺
        /// </summary>
        /// <param name="districtId">地区Id.</param>
        /// <returns>该地区下所有店铺信息.</returns>
        public IList<Shop> GetShopsByDistrictId(long districtId)
        {
            return this._shopManager.GetShopsByDistrictId(districtId);
        }

        /// <summary>
        /// 根据店铺获取所有员工.
        /// </summary>
        /// <param name="shopId">店铺Id.</param>
        /// <returns>该店铺下所有员工信息.</returns>
        public IList<Employee> GetEmployeesByShopId(long shopId)
        {
            return this._employeeManager.GetEmployeesByShopId(shopId);
        }

        /// <summary>
        /// 根据员工Ids获取员工销售额.
        /// </summary>
        /// <param name="employeeIds">员工Ids.</param>
        /// <param name="month">月份</param>
        /// <returns>员工销售额信息.</returns>
        public IList<EmployeeSale> GetEmployeeSalesByEmployeeIds(IList<long> employeeIds, string month)
        {
            return this._employeeSaleManager.GetEmployeeSalesByEmployeeIds(employeeIds, month);
        }

        /// <summary>
        /// 计算店铺提成.
        /// </summary>
        /// <param name="districtId">地区Id.</param>
        /// <param name="shopId">店铺Id.</param>
        /// <param name="month">生效月份.</param>
        /// <returns>该店铺该月员工提成.</returns>
        public Bonus CaculateBonus(long districtId, long shopId, string month)
        {
            return this._shopManager.CaculateBonus(districtId, shopId, month);
        }

        /// <summary>
        /// 新店铺Copy.
        /// </summary>
        /// <param name="shopId">店铺Id.</param>
        /// <param name="info">新店铺信息.</param>
        /// <returns>新店铺Id.</returns>
        public long NewShopCopy(long shopId, Shop info)
        {
            return this._shopManager.NewShopCopy(shopId, info);
        }

        /// <summary>
        /// 添加店铺销售额
        /// </summary>
        /// <param name="info">店铺销售额</param>
        /// <returns>新增店铺销售额</returns>
        public ShopSale AddShopSale(ShopSale info)
        {
            return this._shopSaleManager.AddShopSale(info);
        }

        /// <summary>
        /// 添加员工类型销售额信息
        /// </summary>
        /// <param name="info">员工类型销售额信息</param>
        /// <returns>新增的员工类型销售额信息</returns>
        public EmployeeTypeSale AddEmployeeTypeSale(EmployeeTypeSale info)
        {
            return this._employeeTypeSaleManager.AddEmployeeTypeSale(info);
        }


        /// <summary>
        /// 根据职位Ids获取职位信息
        /// </summary>
        /// <param name="positionIds">职位Ids</param>
        /// <returns>职位信息集合</returns>
        public IList<Position> GetPositionByIds(IList<long> positionIds)
        {
            return this._positionManager.GetPositionByIds(positionIds);
        }

        /// <summary>
        /// 获取店铺计算规则.
        /// </summary>
        /// <param name="shopId">店铺Id.</param>
        /// <returns>计算规则信息.</returns>
        public IList<Rule> GetRulesByShopId(long shopId)
        {
            return this._ruleManager.GetRulesByShopId(shopId);
        }

        /// <summary>
        /// 获取当月店铺销售额
        /// </summary>
        /// <param name="shopIds">店铺Id集合</param>
        /// <param name="month">生效月份</param>
        /// <returns>店铺销售额字典</returns>
        public IDictionary<long, IList<ShopSale>> GetCurrentMonthShopSale(IList<long> shopIds, string month)
        {
            return this._shopSaleManager.GetCurrentMonthShopSale(shopIds, month);
        }

        /// <summary>
        /// 根据Id获取地区信息
        /// </summary>
        /// <param name="districtId">地区Id</param>
        /// <returns>地区信息</returns>
        public District GetDistrictById(long districtId)
        {
            return this._districtManager.GetDistrictById(districtId);
        }

        /// <summary>
        /// 获取所有店铺
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Shop> GetAllShops()
        {
            return this._shopManager.GetAllShops();
        }
    }
}
