using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using LaPerLa.Utility;
using NUnit.Framework;
using LaPerLa.UnitTest.LaPerLaServiceReference;

namespace LaPerLa.UnitTest
{
    [TestFixture]
    public class LaPerLaUnitTests
    {
        private ServiceClient client = null;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            if (this.client == null)
            {
                this.client = new ServiceClient();
                this.client.Open();
            }
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            if (this.client != null)
            {
                this.client.Close();
            }
        }

        /// <summary>
        /// 测试添加地区信息.
        /// </summary>
        [Test]
        public void AddDistrict()
        {
            var district = new District
            {
                City = "上海",
                State = "上海",
                Country = "中国"
            };

            var addResult = this.client.AddDisctrict(district);
            Assert.Greater(addResult.DistrictId, 0, "AddDistrict failed!");
        }

        /// <summary>
        /// 测试添加职位信息.
        /// </summary>
        [Test]
        public void AddPosition()
        {
            var position = new Position
            {
                DistrictId = 5,
                PositionName = "Store Manager",
                ShopId = 1
            };

            var addResult = this.client.AddPosition(position);
            Assert.Greater(addResult.PositionId, 0, "AddPosition failed!");
        }

        /// <summary>
        /// 测试添加店铺信息.
        /// </summary>
        [Test]
        public void AddShop()
        {
            var shop = new Shop
            {
                DistrictId = 5,
                ShopName = "SK",
                ShopType = ShopType.BoutiqueType
            };

            var addResult = this.client.AddShop(shop);
            Assert.Greater(addResult.ShopId, 0, "AddShop failed!");
        }

        /// <summary>
        /// 测试添加员工信息.
        /// </summary>
        [Test]
        public void AddEmployee()
        {
            var employee = new Employee
            {
                ChineseName = "王丽萨",
                EnglishName = "Lisa Wang",
                PositionId = 1,
                ShopId = 1
            };

            var addResult = this.client.AddEmployee(employee);
            Assert.Greater(addResult.EmployeeId, 0, "AddEmployee failed!");
        }

        /// <summary>
        /// 测试添加规则信息.
        /// </summary>
        [Test]
        public void AddRule()
        {
            var rule = new Rule
            {
                PositionId = 1,
                Bonus = 800,
                OperationMaxValue = 1,
                OperationMinValue = 0.7,
                OperationValue = 0,
                OperationType = OperationType.GreaterAndLessThanType,
                RuleDescription = "70% to 100%",
                RuleOrder = 4,
                RuleType = RuleType.ShopPoolCommissionType,
                ShopId = 1,
            };

            var addResult = this.client.AddRule(rule);
            Assert.Greater(addResult.RuleId, 0, "AddRule failed!");
        }

        /// <summary>
        /// 测试添加员工销售额信息.
        /// </summary>
        [Test]
        public void AddEmployeeSale()
        {
            var employeeSale = new EmployeeSale
            {
                EmployeeId = 1,
                ShopId = 1,
                Week = 1,
                TargetSale = 1000.84,
                ActualSale = 1200.56,
                Days = 1,
                Month = DateTime.Now.ToString("yyyy-MM"),
                Sale = 0.0
            };

            var addResult = this.client.AddEmployeeSale(employeeSale);
            Assert.Greater(addResult.EmployeeSaleId, 0, "AddEmployeeSale failed!");
        }

        /// <summary>
        /// 测试添加员工类型销售额信息.
        /// </summary>
        [Test]
        public void AddEmployeeTypeSale()
        {
            var employeeTypeSale = new EmployeeTypeSale
            {
                EmployeeId = 1,
                ShopId = 1,
                SaleType = SaleType.Below70,
                Month = DateTime.Now.ToString("yyyy-MM"),
                Target = 888.99,
                Actual = 999.88
            };

            var addResult = this.client.AddEmployeeTypeSale(employeeTypeSale);
            Assert.Greater(addResult.EmployeeTypeSaleId, 0, "AddEmployeeTypeSale failed!");
        }

        /// <summary>
        /// 测试添加店铺销售额信息.
        /// </summary>
        [Test]
        public void AddShopSale()
        {
            var shopSale = new ShopSale
            {
                ShopId = 1,
                Month = DateTime.Now.ToString("yyyy-MM"),
                Target = 888.99,
                ActualSalesWithTax = 3845.33,
                Tax = 444.44,
                ActualSalesWithoutTax = 4289.77,
                ActualWeekSale = 555.55,
                TargetWeekSale = 444.66,
                Week = 1,
                ShopPool = 0.8,
                DistrictId = 1
            };

            var addResult = this.client.AddShopSale(shopSale);
            Assert.Greater(addResult.ShopSaleId, 0, "AddShopSale failed!");
        }

        /// <summary>
        /// 测试计算提成
        /// </summary>
        [Test]
        public void BonusCalculate()
        {
            //// 准备数据
            //// 地区
            //var district = new District
            //{
            //    City = "北京",
            //    State = "北京",
            //    Country = "中国"
            //};

            //var addDistrict = this.client.AddDisctrict(district);
            //Assert.Greater(addDistrict.DistrictId, 0, "AddDistrict2 failed!");

            //// 店铺
            //var shop1 = new Shop
            //{
            //    DistrictId = addDistrict.DistrictId,
            //    ShopName = "SK",
            //    ShopType = ShopType.BoutiqueType
            //};

            //var addShop1 = this.client.AddShop(shop1);
            //Assert.Greater(addShop1.ShopId, 0, "AddShop failed!");

            //var shop2 = new Shop
            //{
            //    DistrictId = addDistrict.DistrictId,
            //    ShopName = "PVG",
            //    ShopType = ShopType.BoutiqueType
            //};

            //var addShop2 = this.client.AddShop(shop2);
            //Assert.Greater(addShop2.ShopId, 0, "AddShop2 failed!");

            //var shop3 = new Shop
            //{
            //    DistrictId = addDistrict.DistrictId,
            //    ShopName = "OP",
            //    ShopType = ShopType.BoutiqueType
            //};

            //var addShop3 = this.client.AddShop(shop3);
            //Assert.Greater(addShop3.ShopId, 0, "AddShop3 failed!");

            //var shop4 = new Shop
            //{
            //    DistrictId = addDistrict.DistrictId,
            //    ShopName = "CW",
            //    ShopType = ShopType.BoutiqueType
            //};

            //var addShop4 = this.client.AddShop(shop4);
            //Assert.Greater(addShop4.ShopId, 0, "AddShop4 failed!");

            //var shop5 = new Shop
            //{
            //    DistrictId = addDistrict.DistrictId,
            //    ShopName = "OL",
            //    ShopType = ShopType.OutletType
            //};

            //var addShop5 = this.client.AddShop(shop5);
            //Assert.Greater(addShop5.ShopId, 0, "AddShop5 failed!");

            //// 职位
            //var position = new Position
            //{
            //    DistrictId = addDistrict.DistrictId,
            //    PositionName = "Shop Manager",
            //    ShopId = 0
            //};

            //var addPosition = this.client.AddPosition(position);
            //Assert.Greater(addPosition.PositionId, 0, " AddPosition failed!");

            //var position2 = new Position
            //{
            //    DistrictId = addDistrict.DistrictId,
            //    PositionName = "SIC",
            //    ShopId = 0
            //};

            //var addPosition2 = this.client.AddPosition(position2);
            //Assert.Greater(addPosition2.PositionId, 0, " AddPosition2 failed!");

            //var position3 = new Position
            //{
            //    DistrictId = addDistrict.DistrictId,
            //    PositionName = "Supervisor",
            //    ShopId = 0
            //};

            //var addPosition3 = this.client.AddPosition(position3);
            //Assert.Greater(addPosition3.PositionId, 0, " AddPosition3 failed!");

            //var position4 = new Position
            //{
            //    DistrictId = addDistrict.DistrictId,
            //    PositionName = "Senior Sales Associate",
            //    ShopId = 0
            //};

            //var addPosition4 = this.client.AddPosition(position4);
            //Assert.Greater(addPosition4.PositionId, 0, " AddPosition4 failed!");

            //var position5 = new Position
            //{
            //    DistrictId = addDistrict.DistrictId,
            //    PositionName = "Sales Associate",
            //    ShopId = 0
            //};

            //var addPosition5 = this.client.AddPosition(position5);
            //Assert.Greater(addPosition5.PositionId, 0, " AddPosition5 failed!");

            //// 员工
            //var employee = new Employee
            //{
            //    ChineseName = "Liz",
            //    EnglishName = "Liz",
            //    PositionId = addPosition.PositionId,
            //    ShopId = addShop1.ShopId
            //};

            //var addEmployee = this.client.AddEmployee(employee);
            //Assert.Greater(addEmployee.EmployeeId, 0, "AddEmployee failed!");

            //var employee2 = new Employee
            //{
            //    ChineseName = "Ellen",
            //    EnglishName = "Ellen",
            //    PositionId = addPosition2.PositionId,
            //    ShopId = addShop1.ShopId
            //};

            //var addEmployee2 = this.client.AddEmployee(employee2);
            //Assert.Greater(addEmployee2.EmployeeId, 0, "AddEmployee2 failed!");

            //var employee3 = new Employee
            //{
            //    ChineseName = "Nissa Li",
            //    EnglishName = "Nissa Li",
            //    PositionId = addPosition4.PositionId,
            //    ShopId = addShop1.ShopId
            //};

            //var addEmployee3 = this.client.AddEmployee(employee3);
            //Assert.Greater(addEmployee3.EmployeeId, 0, "AddEmployee3 failed!");

            //var employee4 = new Employee
            //{
            //    ChineseName = "Carol Chen",
            //    EnglishName = "Carol Chen",
            //    PositionId = addPosition4.PositionId,
            //    ShopId = addShop1.ShopId
            //};

            //var addEmployee4 = this.client.AddEmployee(employee4);
            //Assert.Greater(addEmployee4.EmployeeId, 0, "AddEmployee4 failed!");

            //var employee5 = new Employee
            //{
            //    ChineseName = "Summer Wang",
            //    EnglishName = "Summer Wang",
            //    PositionId = addPosition4.PositionId,
            //    ShopId = addShop1.ShopId
            //};

            //var addEmployee5 = this.client.AddEmployee(employee5);
            //Assert.Greater(addEmployee5.EmployeeId, 0, "AddEmployee5 failed!");

            //var employee6 = new Employee
            //{
            //    ChineseName = "Anna",
            //    EnglishName = "Anna",
            //    PositionId = addPosition4.PositionId,
            //    ShopId = addShop1.ShopId
            //};

            //var addEmployee6 = this.client.AddEmployee(employee6);
            //Assert.Greater(addEmployee6.EmployeeId, 0, "AddEmployee6 failed!");

            //var employee7 = new Employee
            //{
            //    ChineseName = "Lisa Wang",
            //    EnglishName = "Lisa Wang",
            //    PositionId = addPosition5.PositionId,
            //    ShopId = addShop1.ShopId
            //};

            //var addEmployee7 = this.client.AddEmployee(employee7);
            //Assert.Greater(addEmployee7.EmployeeId, 0, "AddEmployee7 failed!");
            
            //// 店铺销售额
            //var shopSale = new ShopSale
            //{
            //    ShopId = addShop1.ShopId,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Target = 643500.00,
            //    ActualSalesWithTax = 559049.50,
            //    Tax = 0,
            //    ActualSalesWithoutTax = 559049.50,
            //    ActualWeekSale = 47648,
            //    TargetWeekSale = 25313,
            //    Week = 22,
            //    ShopPool = 0,
            //    DistrictId = addDistrict.DistrictId
            //};

            //var addShopSale = this.client.AddShopSale(shopSale);
            //Assert.Greater(addShopSale.ShopSaleId, 0, "AddShopSale failed!");

            //var shopSale2 = new ShopSale
            //{
            //    ShopId = addShop1.ShopId,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Target = 643500.00,
            //    ActualSalesWithTax = 559049.50,
            //    Tax = 0,
            //    ActualSalesWithoutTax = 559049.50,
            //    ActualWeekSale = 66551,
            //    TargetWeekSale = 155451,
            //    Week = 23,
            //    ShopPool = 0,
            //    DistrictId = addDistrict.DistrictId
            //};

            //var addShopSale2 = this.client.AddShopSale(shopSale2);
            //Assert.Greater(addShopSale2.ShopSaleId, 0, "AddShopSale2 failed!");

            //var shopSale3 = new ShopSale
            //{
            //    ShopId = addShop1.ShopId,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Target = 643500.00,
            //    ActualSalesWithTax = 559049.50,
            //    Tax = 0,
            //    ActualSalesWithoutTax = 559049.50,
            //    ActualWeekSale = 80023,
            //    TargetWeekSale = 148221,
            //    Week = 24,
            //    ShopPool = 0,
            //    DistrictId = addDistrict.DistrictId
            //};

            //var addShopSale3 = this.client.AddShopSale(shopSale3);
            //Assert.Greater(addShopSale3.ShopSaleId, 0, "AddShopSale3 failed!");

            //var shopSale4 = new ShopSale
            //{
            //    ShopId = addShop1.ShopId,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Target = 643500.00,
            //    ActualSalesWithTax = 559049.50,
            //    Tax = 0,
            //    ActualSalesWithoutTax = 559049.50,
            //    ActualWeekSale = 148284,
            //    TargetWeekSale = 148221,
            //    Week = 25,
            //    ShopPool = 0,
            //    DistrictId = addDistrict.DistrictId
            //};

            //var addShopSale4 = this.client.AddShopSale(shopSale4);
            //Assert.Greater(addShopSale4.ShopSaleId, 0, "AddShopSale4 failed!");

            //var shopSale5 = new ShopSale
            //{
            //    ShopId = addShop1.ShopId,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Target = 643500.00,
            //    ActualSalesWithTax = 559049.50,
            //    Tax = 0,
            //    ActualSalesWithoutTax = 559049.50,
            //    ActualWeekSale = 211889,
            //    TargetWeekSale = 148221,
            //    Week = 26,
            //    ShopPool = 0,
            //    DistrictId = addDistrict.DistrictId
            //};

            //var addShopSale5 = this.client.AddShopSale(shopSale5);
            //Assert.Greater(addShopSale5.ShopSaleId, 0, "AddShopSale5 failed!");

            //var shopSale6 = new ShopSale
            //{
            //    ShopId = addShop1.ShopId,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Target = 643500.00,
            //    ActualSalesWithTax = 559049.50,
            //    Tax = 0,
            //    ActualSalesWithoutTax = 559049.50,
            //    ActualWeekSale = 4655,
            //    TargetWeekSale = 18073,
            //    Week = 27,
            //    ShopPool = 0,
            //    DistrictId = addDistrict.DistrictId
            //};

            //var addShopSale6 = this.client.AddShopSale(shopSale6);
            //Assert.Greater(addShopSale6.ShopSaleId, 0, "AddShopSale6 failed!");

            //// 店铺2销售额
            //var shopSale7 = new ShopSale
            //{
            //    ShopId = addShop2.ShopId,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Target = 105300.00,
            //    ActualSalesWithTax = 142452.00,
            //    Tax = 0,
            //    ActualSalesWithoutTax = 142452.00,
            //    ActualWeekSale = 0,
            //    TargetWeekSale = 4141,
            //    Week = 22,
            //    ShopPool = 0,
            //    DistrictId = addDistrict.DistrictId
            //};

            //var addShopSale7 = this.client.AddShopSale(shopSale7);
            //Assert.Greater(addShopSale7.ShopSaleId, 0, "AddShopSale7 failed!");

            //var shopSale8 = new ShopSale
            //{
            //    ShopId = addShop2.ShopId,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Target = 105300.00,
            //    ActualSalesWithTax = 142452.00,
            //    Tax = 0,
            //    ActualSalesWithoutTax = 142452.00,
            //    ActualWeekSale = 46087,
            //    TargetWeekSale = 25438,
            //    Week = 23,
            //    ShopPool = 0,
            //    DistrictId = addDistrict.DistrictId
            //};

            //var addShopSale8 = this.client.AddShopSale(shopSale8);
            //Assert.Greater(addShopSale8.ShopSaleId, 0, "AddShopSale8 failed!");

            //var shopSale9 = new ShopSale
            //{
            //    ShopId = addShop2.ShopId,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Target = 105300.00,
            //    ActualSalesWithTax = 142452.00,
            //    Tax = 0,
            //    ActualSalesWithoutTax = 142452.00,
            //    ActualWeekSale = 34487,
            //    TargetWeekSale = 24254,
            //    Week = 24,
            //    ShopPool = 0,
            //    DistrictId = addDistrict.DistrictId
            //};

            //var addShopSale9 = this.client.AddShopSale(shopSale9);
            //Assert.Greater(addShopSale9.ShopSaleId, 0, "AddShopSale9 failed!");

            //var shopSale10 = new ShopSale
            //{
            //    ShopId = addShop2.ShopId,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Target = 105300.00,
            //    ActualSalesWithTax = 142452.00,
            //    Tax = 0,
            //    ActualSalesWithoutTax = 142452.00,
            //    ActualWeekSale = 28085,
            //    TargetWeekSale = 24254,
            //    Week = 25,
            //    ShopPool = 0,
            //    DistrictId = addDistrict.DistrictId
            //};

            //var addShopSale10 = this.client.AddShopSale(shopSale10);
            //Assert.Greater(addShopSale10.ShopSaleId, 0, "AddShopSale10 failed!");

            //var shopSale11 = new ShopSale
            //{
            //    ShopId = addShop2.ShopId,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Target = 105300.00,
            //    ActualSalesWithTax = 142452.00,
            //    Tax = 0,
            //    ActualSalesWithoutTax = 142452.00,
            //    ActualWeekSale = 33793,
            //    TargetWeekSale = 24254,
            //    Week = 26,
            //    ShopPool = 0,
            //    DistrictId = addDistrict.DistrictId
            //};

            //var addShopSale11 = this.client.AddShopSale(shopSale11);
            //Assert.Greater(addShopSale11.ShopSaleId, 0, "AddShopSale11 failed!");

            //var shopSale12 = new ShopSale
            //{
            //    ShopId = addShop2.ShopId,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Target = 105300.00,
            //    ActualSalesWithTax = 142452.00,
            //    Tax = 0,
            //    ActualSalesWithoutTax = 142452.00,
            //    ActualWeekSale = 0,
            //    TargetWeekSale = 2959,
            //    Week = 27,
            //    ShopPool = 0,
            //    DistrictId = addDistrict.DistrictId
            //};

            //var addShopSale12 = this.client.AddShopSale(shopSale12);
            //Assert.Greater(addShopSale12.ShopSaleId, 0, "AddShopSale12 failed!");

            //// 员工销售额
            //var employeeSale = new EmployeeSale
            //{
            //    EmployeeId = addEmployee.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 22,
            //    TargetSale = 0,
            //    ActualSale = 0,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale = this.client.AddEmployeeSale(employeeSale);
            //Assert.Greater(addEmployeeSale.EmployeeSaleId, 0, "AddEmployeeSale failed!");

            //var employeeSale2 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 23,
            //    TargetSale = 0,
            //    ActualSale = 0,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale2 = this.client.AddEmployeeSale(employeeSale2);
            //Assert.Greater(addEmployeeSale2.EmployeeSaleId, 0, "AddEmployeeSale2 failed!");

            //var employeeSale3 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 24,
            //    TargetSale = 0,
            //    ActualSale = 0,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale3 = this.client.AddEmployeeSale(employeeSale3);
            //Assert.Greater(addEmployeeSale3.EmployeeSaleId, 0, "AddEmployeeSale3 failed!");

            //var employeeSale4 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 25,
            //    TargetSale = 0,
            //    ActualSale = 0,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale4 = this.client.AddEmployeeSale(employeeSale4);
            //Assert.Greater(addEmployeeSale4.EmployeeSaleId, 0, "AddEmployeeSale4 failed!");

            //var employeeSale5 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 26,
            //    TargetSale = 0,
            //    ActualSale = 0,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale5 = this.client.AddEmployeeSale(employeeSale5);
            //Assert.Greater(addEmployeeSale5.EmployeeSaleId, 0, "AddEmployeeSale5 failed!");

            //var employeeSale6 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 27,
            //    TargetSale = 0,
            //    ActualSale = 0,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale6 = this.client.AddEmployeeSale(employeeSale6);
            //Assert.Greater(addEmployeeSale6.EmployeeSaleId, 0, "AddEmployeeSale6 failed!");

            //var employeeSale11 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee2.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 22,
            //    TargetSale = 0,
            //    ActualSale = 0,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale11 = this.client.AddEmployeeSale(employeeSale11);
            //Assert.Greater(addEmployeeSale11.EmployeeSaleId, 0, "AddEmployeeSale11 failed!");

            //var employeeSale12 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee2.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 23,
            //    TargetSale = 0,
            //    ActualSale = 0,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale12 = this.client.AddEmployeeSale(employeeSale12);
            //Assert.Greater(addEmployeeSale12.EmployeeSaleId, 0, "AddEmployeeSale12 failed!");

            //var employeeSale13 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee2.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 24,
            //    TargetSale = 23057,
            //    ActualSale = 0,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale13 = this.client.AddEmployeeSale(employeeSale13);
            //Assert.Greater(addEmployeeSale13.EmployeeSaleId, 0, "AddEmployeeSale13 failed!");

            //var employeeSale14 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee2.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 25,
            //    TargetSale = 23057,
            //    ActualSale = 23654,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale14 = this.client.AddEmployeeSale(employeeSale14);
            //Assert.Greater(addEmployeeSale14.EmployeeSaleId, 0, "AddEmployeeSale14 failed!");

            //var employeeSale15 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee2.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 26,
            //    TargetSale = 23057,
            //    ActualSale = 46142,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale15 = this.client.AddEmployeeSale(employeeSale15);
            //Assert.Greater(addEmployeeSale15.EmployeeSaleId, 0, "AddEmployeeSale15 failed!");

            //var employeeSale16 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee2.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 27,
            //    TargetSale = 2812,
            //    ActualSale = 2205,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale16 = this.client.AddEmployeeSale(employeeSale16);
            //Assert.Greater(addEmployeeSale16.EmployeeSaleId, 0, "AddEmployeeSale16 failed!");

            //var employeeSale21 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee3.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 22,
            //    TargetSale = 5423,
            //    ActualSale = 0,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale21 = this.client.AddEmployeeSale(employeeSale21);
            //Assert.Greater(addEmployeeSale21.EmployeeSaleId, 0, "AddEmployeeSale21 failed!");

            //var employeeSale22 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee3.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 23,
            //    TargetSale = 33311,
            //    ActualSale = 1806,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale22 = this.client.AddEmployeeSale(employeeSale22);
            //Assert.Greater(addEmployeeSale22.EmployeeSaleId, 0, "AddEmployeeSale22 failed!");

            //var employeeSale23 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee3.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 24,
            //    TargetSale = 26350,
            //    ActualSale = 20195,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale23 = this.client.AddEmployeeSale(employeeSale23);
            //Assert.Greater(addEmployeeSale23.EmployeeSaleId, 0, "AddEmployeeSale23 failed!");

            //var employeeSale24 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee3.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 25,
            //    TargetSale = 26350,
            //    ActualSale = 29784,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale24 = this.client.AddEmployeeSale(employeeSale24);
            //Assert.Greater(addEmployeeSale24.EmployeeSaleId, 0, "AddEmployeeSale24 failed!");

            //var employeeSale25 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee3.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 26,
            //    TargetSale = 26350,
            //    ActualSale = 25305,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale25 = this.client.AddEmployeeSale(employeeSale25);
            //Assert.Greater(addEmployeeSale25.EmployeeSaleId, 0, "AddEmployeeSale25 failed!");

            //var employeeSale26 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee3.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 27,
            //    TargetSale = 3213,
            //    ActualSale = 2450,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale26 = this.client.AddEmployeeSale(employeeSale26);
            //Assert.Greater(addEmployeeSale26.EmployeeSaleId, 0, "AddEmployeeSale26 failed!");

            //var employeeSale31 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee4.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 22,
            //    TargetSale = 5429,
            //    ActualSale = 38428,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale31 = this.client.AddEmployeeSale(employeeSale31);
            //Assert.Greater(addEmployeeSale31.EmployeeSaleId, 0, "AddEmployeeSale31 failed!");

            //var employeeSale32 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee4.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 23,
            //    TargetSale = 33311,
            //    ActualSale = 5557,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale32 = this.client.AddEmployeeSale(employeeSale32);
            //Assert.Greater(addEmployeeSale32.EmployeeSaleId, 0, "AddEmployeeSale32 failed!");

            //var employeeSale33 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee4.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 24,
            //    TargetSale = 26350,
            //    ActualSale = 26050,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale33 = this.client.AddEmployeeSale(employeeSale33);
            //Assert.Greater(addEmployeeSale33.EmployeeSaleId, 0, "AddEmployeeSale33 failed!");

            //var employeeSale34 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee4.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 25,
            //    TargetSale = 26350,
            //    ActualSale = 20149,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale34 = this.client.AddEmployeeSale(employeeSale34);
            //Assert.Greater(addEmployeeSale34.EmployeeSaleId, 0, "AddEmployeeSale34 failed!");

            //var employeeSale35 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee4.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 26,
            //    TargetSale = 26350,
            //    ActualSale = 6740,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale35 = this.client.AddEmployeeSale(employeeSale35);
            //Assert.Greater(addEmployeeSale35.EmployeeSaleId, 0, "AddEmployeeSale35 failed!");

            //var employeeSale36 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee4.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 27,
            //    TargetSale = 3213,
            //    ActualSale = 0,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale36 = this.client.AddEmployeeSale(employeeSale36);
            //Assert.Greater(addEmployeeSale36.EmployeeSaleId, 0, "AddEmployeeSale36 failed!");

            //var employeeSale41 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee5.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 22,
            //    TargetSale = 5423,
            //    ActualSale = 7170,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale41 = this.client.AddEmployeeSale(employeeSale41);
            //Assert.Greater(addEmployeeSale41.EmployeeSaleId, 0, "AddEmployeeSale41 failed!");

            //var employeeSale42 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee5.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 23,
            //    TargetSale = 33311,
            //    ActualSale = 6438,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale42 = this.client.AddEmployeeSale(employeeSale42);
            //Assert.Greater(addEmployeeSale42.EmployeeSaleId, 0, "AddEmployeeSale42 failed!");

            //var employeeSale43 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee5.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 24,
            //    TargetSale = 26350,
            //    ActualSale = 1882,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale43 = this.client.AddEmployeeSale(employeeSale43);
            //Assert.Greater(addEmployeeSale43.EmployeeSaleId, 0, "AddEmployeeSale43 failed!");

            //var employeeSale44 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee5.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 25,
            //    TargetSale = 26350,
            //    ActualSale = 26375,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale44 = this.client.AddEmployeeSale(employeeSale44);
            //Assert.Greater(addEmployeeSale44.EmployeeSaleId, 0, "AddEmployeeSale44 failed!");

            //var employeeSale45 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee5.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 26,
            //    TargetSale = 26350,
            //    ActualSale = 7435,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale45 = this.client.AddEmployeeSale(employeeSale45);
            //Assert.Greater(addEmployeeSale45.EmployeeSaleId, 0, "AddEmployeeSale45 failed!");

            //var employeeSale46 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee5.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 27,
            //    TargetSale = 3213,
            //    ActualSale = 0,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale46 = this.client.AddEmployeeSale(employeeSale46);
            //Assert.Greater(addEmployeeSale46.EmployeeSaleId, 0, "AddEmployeeSale46 failed!");

            //var employeeSale51 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee6.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 22,
            //    TargetSale = 4519,
            //    ActualSale = 2050,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale51 = this.client.AddEmployeeSale(employeeSale51);
            //Assert.Greater(addEmployeeSale51.EmployeeSaleId, 0, "AddEmployeeSale51 failed!");

            //var employeeSale52 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee6.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 23,
            //    TargetSale = 27759,
            //    ActualSale = 22285,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale52 = this.client.AddEmployeeSale(employeeSale52);
            //Assert.Greater(addEmployeeSale52.EmployeeSaleId, 0, "AddEmployeeSale52 failed!");

            //var employeeSale53 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee6.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 24,
            //    TargetSale = 23057,
            //    ActualSale = 27013,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale53 = this.client.AddEmployeeSale(employeeSale53);
            //Assert.Greater(addEmployeeSale53.EmployeeSaleId, 0, "AddEmployeeSale53 failed!");

            //var employeeSale54 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee6.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 25,
            //    TargetSale = 23057,
            //    ActualSale = 16139,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale54 = this.client.AddEmployeeSale(employeeSale54);
            //Assert.Greater(addEmployeeSale54.EmployeeSaleId, 0, "AddEmployeeSale54 failed!");

            //var employeeSale55 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee6.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 26,
            //    TargetSale = 23057,
            //    ActualSale = 47575,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale55 = this.client.AddEmployeeSale(employeeSale55);
            //Assert.Greater(addEmployeeSale55.EmployeeSaleId, 0, "AddEmployeeSale55 failed!");

            //var employeeSale56 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee6.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 27,
            //    TargetSale = 2811,
            //    ActualSale = 0,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale56 = this.client.AddEmployeeSale(employeeSale56);
            //Assert.Greater(addEmployeeSale56.EmployeeSaleId, 0, "AddEmployeeSale56 failed!");

            //var employeeSale61 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee7.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 22,
            //    TargetSale = 4519,
            //    ActualSale = 0,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale61 = this.client.AddEmployeeSale(employeeSale61);
            //Assert.Greater(addEmployeeSale61.EmployeeSaleId, 0, "AddEmployeeSale61 failed!");

            //var employeeSale62 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee7.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 23,
            //    TargetSale = 27759,
            //    ActualSale = 30465,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale62 = this.client.AddEmployeeSale(employeeSale62);
            //Assert.Greater(addEmployeeSale62.EmployeeSaleId, 0, "AddEmployeeSale62 failed!");

            //var employeeSale63 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee7.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 24,
            //    TargetSale = 23057,
            //    ActualSale = 4883,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale63 = this.client.AddEmployeeSale(employeeSale63);
            //Assert.Greater(addEmployeeSale63.EmployeeSaleId, 0, "AddEmployeeSale63 failed!");

            //var employeeSale64 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee7.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 25,
            //    TargetSale = 23057,
            //    ActualSale = 11019,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale64 = this.client.AddEmployeeSale(employeeSale64);
            //Assert.Greater(addEmployeeSale64.EmployeeSaleId, 0, "AddEmployeeSale64 failed!");

            //var employeeSale65 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee7.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 26,
            //    TargetSale = 23057,
            //    ActualSale = 23305,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale65 = this.client.AddEmployeeSale(employeeSale65);
            //Assert.Greater(addEmployeeSale65.EmployeeSaleId, 0, "AddEmployeeSale65 failed!");

            //var employeeSale66 = new EmployeeSale
            //{
            //    EmployeeId = addEmployee7.EmployeeId,
            //    ShopId = addShop1.ShopId,
            //    Week = 27,
            //    TargetSale = 2811,
            //    ActualSale = 0,
            //    Days = 0,
            //    Month = DateTime.Now.ToString("2014-06"),
            //    Sale = 0.0
            //};

            //var addEmployeeSale66 = this.client.AddEmployeeSale(employeeSale66);
            //Assert.Greater(addEmployeeSale66.EmployeeSaleId, 0, "AddEmployeeSale66 failed!");

            //// 员工类型销售额

            //// 规则
            //IList<Shop> shopList = new List<Shop>
            //{
            //    addShop1,
            //    addShop2,
            //    addShop3,
            //    addShop4
            //};

            //foreach (var shop in shopList)
            //{
            //    // ShopPoolCommissionType
            //    var rule = new Rule
            //    {
            //        PositionId = addPosition.PositionId,
            //        Bonus = 0,
            //        OperationMaxValue = 1,
            //        OperationMinValue = 0.7,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "70% to 100%",
            //        RuleOrder = 4,
            //        RuleType = RuleType.ShopPoolCommissionType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule = this.client.AddRule(rule);
            //    Assert.Greater(addRule.RuleId, 0, "AddRule failed!");

            //    var rule2 = new Rule
            //    {
            //        PositionId = addPosition.PositionId,
            //        Bonus = 3000,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 3,
            //        RuleType = RuleType.ShopPoolCommissionType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule2 = this.client.AddRule(rule2);
            //    Assert.Greater(addRule2.RuleId, 0, "AddRule2 failed!");

            //    var rule3 = new Rule
            //    {
            //        PositionId = addPosition.PositionId,
            //        Bonus = 5000,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.ShopPoolCommissionType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule3 = this.client.AddRule(rule3);
            //    Assert.Greater(addRule3.RuleId, 0, "AddRule3 failed!");

            //    var rule4 = new Rule
            //    {
            //        PositionId = addPosition.PositionId,
            //        Bonus = 12000,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1.2,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "120%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.ShopPoolCommissionType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule4 = this.client.AddRule(rule4);
            //    Assert.Greater(addRule4.RuleId, 0, "AddRule4 failed!");

            //    var rule11 = new Rule
            //    {
            //        PositionId = addPosition2.PositionId,
            //        Bonus = 800,
            //        OperationMaxValue = 1,
            //        OperationMinValue = 0.7,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "70% to 100%",
            //        RuleOrder = 4,
            //        RuleType = RuleType.ShopPoolCommissionType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule11 = this.client.AddRule(rule11);
            //    Assert.Greater(addRule11.RuleId, 0, "AddRule11 failed!");

            //    var rule12 = new Rule
            //    {
            //        PositionId = addPosition2.PositionId,
            //        Bonus = 1000,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 3,
            //        RuleType = RuleType.ShopPoolCommissionType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule12 = this.client.AddRule(rule12);
            //    Assert.Greater(addRule12.RuleId, 0, "AddRule12 failed!");

            //    var rule13 = new Rule
            //    {
            //        PositionId = addPosition2.PositionId,
            //        Bonus = 1150,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.ShopPoolCommissionType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule13 = this.client.AddRule(rule13);
            //    Assert.Greater(addRule13.RuleId, 0, "AddRule13 failed!");

            //    var rule14 = new Rule
            //    {
            //        PositionId = addPosition2.PositionId,
            //        Bonus = 1500,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1.2,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "120%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.ShopPoolCommissionType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule14 = this.client.AddRule(rule14);
            //    Assert.Greater(addRule14.RuleId, 0, "AddRule14 failed!");

            //    var rule21 = new Rule
            //    {
            //        PositionId = addPosition3.PositionId,
            //        Bonus = 600,
            //        OperationMaxValue = 1,
            //        OperationMinValue = 0.7,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "70% to 100%",
            //        RuleOrder = 4,
            //        RuleType = RuleType.ShopPoolCommissionType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule21 = this.client.AddRule(rule21);
            //    Assert.Greater(addRule21.RuleId, 0, "AddRule21 failed!");

            //    var rule22 = new Rule
            //    {
            //        PositionId = addPosition3.PositionId,
            //        Bonus = 800,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 3,
            //        RuleType = RuleType.ShopPoolCommissionType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule22 = this.client.AddRule(rule22);
            //    Assert.Greater(addRule22.RuleId, 0, "AddRule22 failed!");

            //    var rule23 = new Rule
            //    {
            //        PositionId = addPosition3.PositionId,
            //        Bonus = 865,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.ShopPoolCommissionType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule23 = this.client.AddRule(rule23);
            //    Assert.Greater(addRule23.RuleId, 0, "AddRule23 failed!");

            //    var rule24 = new Rule
            //    {
            //        PositionId = addPosition3.PositionId,
            //        Bonus = 1500,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1.2,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "120%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.ShopPoolCommissionType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule24 = this.client.AddRule(rule24);
            //    Assert.Greater(addRule24.RuleId, 0, "AddRule24 failed!");

            //    var rule31 = new Rule
            //    {
            //        PositionId = addPosition4.PositionId,
            //        Bonus = 400,
            //        OperationMaxValue = 1,
            //        OperationMinValue = 0.7,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "70% to 100%",
            //        RuleOrder = 4,
            //        RuleType = RuleType.ShopPoolCommissionType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule31 = this.client.AddRule(rule31);
            //    Assert.Greater(addRule31.RuleId, 0, "AddRule31 failed!");

            //    var rule32 = new Rule
            //    {
            //        PositionId = addPosition4.PositionId,
            //        Bonus = 550,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 3,
            //        RuleType = RuleType.ShopPoolCommissionType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule32 = this.client.AddRule(rule32);
            //    Assert.Greater(addRule32.RuleId, 0, "AddRule32 failed!");

            //    var rule33 = new Rule
            //    {
            //        PositionId = addPosition4.PositionId,
            //        Bonus = 550,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.ShopPoolCommissionType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule33 = this.client.AddRule(rule33);
            //    Assert.Greater(addRule33.RuleId, 0, "AddRule33 failed!");

            //    var rule34 = new Rule
            //    {
            //        PositionId = addPosition4.PositionId,
            //        Bonus = 1500,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1.2,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "120%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.ShopPoolCommissionType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule34 = this.client.AddRule(rule34);
            //    Assert.Greater(addRule34.RuleId, 0, "AddRule34 failed!");

            //    var rule41 = new Rule
            //    {
            //        PositionId = addPosition5.PositionId,
            //        Bonus = 300,
            //        OperationMaxValue = 1,
            //        OperationMinValue = 0.7,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "70% to 100%",
            //        RuleOrder = 4,
            //        RuleType = RuleType.ShopPoolCommissionType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule41 = this.client.AddRule(rule41);
            //    Assert.Greater(addRule41.RuleId, 0, "AddRule41 failed!");

            //    var rule42 = new Rule
            //    {
            //        PositionId = addPosition5.PositionId,
            //        Bonus = 400,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 3,
            //        RuleType = RuleType.ShopPoolCommissionType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule42 = this.client.AddRule(rule42);
            //    Assert.Greater(addRule42.RuleId, 0, "AddRule42 failed!");

            //    var rule43 = new Rule
            //    {
            //        PositionId = addPosition5.PositionId,
            //        Bonus = 450,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.ShopPoolCommissionType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule43 = this.client.AddRule(rule43);
            //    Assert.Greater(addRule43.RuleId, 0, "AddRule43 failed!");

            //    var rule44 = new Rule
            //    {
            //        PositionId = addPosition5.PositionId,
            //        Bonus = 1500,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1.2,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "120%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.ShopPoolCommissionType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule44 = this.client.AddRule(rule44);
            //    Assert.Greater(addRule44.RuleId, 0, "AddRule44 failed!");

            //    // CityPoolType
            //    var rule5 = new Rule
            //    {
            //        PositionId = addPosition.PositionId,
            //        Bonus = 0,
            //        OperationMaxValue = 0.99,
            //        OperationMinValue = 0.8,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "80% to 99%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.CityPoolType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule5 = this.client.AddRule(rule5);
            //    Assert.Greater(addRule5.RuleId, 0, "AddRule5 failed!");

            //    var rule6 = new Rule
            //    {
            //        PositionId = addPosition.PositionId,
            //        Bonus = 2000,
            //        OperationMaxValue = 10,
            //        OperationMinValue = 1,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "100% or Above",
            //        RuleOrder = 1,
            //        RuleType = RuleType.CityPoolType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule6 = this.client.AddRule(rule6);
            //    Assert.Greater(addRule6.RuleId, 0, "AddRule6 failed!");

            //    var rule15 = new Rule
            //    {
            //        PositionId = addPosition2.PositionId,
            //        Bonus = 900,
            //        OperationMaxValue = 0.99,
            //        OperationMinValue = 0.8,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "80% to 99%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.CityPoolType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule15 = this.client.AddRule(rule15);
            //    Assert.Greater(addRule15.RuleId, 0, "AddRule15 failed!");

            //    var rule16 = new Rule
            //    {
            //        PositionId = addPosition2.PositionId,
            //        Bonus = 1000,
            //        OperationMaxValue = 10,
            //        OperationMinValue = 1,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "100% or Above",
            //        RuleOrder = 1,
            //        RuleType = RuleType.CityPoolType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule16 = this.client.AddRule(rule16);
            //    Assert.Greater(addRule16.RuleId, 0, "AddRule16 failed!");

            //    var rule25 = new Rule
            //    {
            //        PositionId = addPosition3.PositionId,
            //        Bonus = 600,
            //        OperationMaxValue = 0.99,
            //        OperationMinValue = 0.8,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "80% to 99%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.CityPoolType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule25 = this.client.AddRule(rule25);
            //    Assert.Greater(addRule25.RuleId, 0, "AddRule25 failed!");

            //    var rule26 = new Rule
            //    {
            //        PositionId = addPosition3.PositionId,
            //        Bonus = 800,
            //        OperationMaxValue = 10,
            //        OperationMinValue = 1,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "100% or Above",
            //        RuleOrder = 1,
            //        RuleType = RuleType.CityPoolType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule26 = this.client.AddRule(rule26);
            //    Assert.Greater(addRule26.RuleId, 0, "AddRule26 failed!");

            //    var rule35 = new Rule
            //    {
            //        PositionId = addPosition4.PositionId,
            //        Bonus = 500,
            //        OperationMaxValue = 0.99,
            //        OperationMinValue = 0.8,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "80% to 99%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.CityPoolType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule35 = this.client.AddRule(rule35);
            //    Assert.Greater(addRule35.RuleId, 0, "AddRule35 failed!");

            //    var rule36 = new Rule
            //    {
            //        PositionId = addPosition4.PositionId,
            //        Bonus = 500,
            //        OperationMaxValue = 10,
            //        OperationMinValue = 1,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "100% or Above",
            //        RuleOrder = 1,
            //        RuleType = RuleType.CityPoolType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule36 = this.client.AddRule(rule36);
            //    Assert.Greater(addRule36.RuleId, 0, "AddRule36 failed!");

            //    var rule45 = new Rule
            //    {
            //        PositionId = addPosition5.PositionId,
            //        Bonus = 400,
            //        OperationMaxValue = 0.99,
            //        OperationMinValue = 0.8,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "80% to 99%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.CityPoolType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule45 = this.client.AddRule(rule45);
            //    Assert.Greater(addRule45.RuleId, 0, "AddRule45 failed!");

            //    var rule46 = new Rule
            //    {
            //        PositionId = addPosition5.PositionId,
            //        Bonus = 400,
            //        OperationMaxValue = 10,
            //        OperationMinValue = 1,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "100% or Above",
            //        RuleOrder = 1,
            //        RuleType = RuleType.CityPoolType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule46 = this.client.AddRule(rule46);
            //    Assert.Greater(addRule46.RuleId, 0, "AddRule46 failed!");

            //    // IndividualTargetDiscountType
            //    var rule7 = new Rule
            //    {
            //        PositionId = addPosition.PositionId,
            //        Bonus = 0,
            //        OperationMaxValue = 0.99,
            //        OperationMinValue = 0.8,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "80% to 99%",
            //        RuleOrder = 3,
            //        RuleType = RuleType.IndividualTargetDiscountType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule7 = this.client.AddRule(rule7);
            //    Assert.Greater(addRule7.RuleId, 0, "AddRule7 failed!");

            //    var rule8 = new Rule
            //    {
            //        PositionId = addPosition.PositionId,
            //        Bonus = 0,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.IndividualTargetDiscountType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule8 = this.client.AddRule(rule8);
            //    Assert.Greater(addRule8.RuleId, 0, "AddRule8 failed!");

            //    var rule9 = new Rule
            //    {
            //        PositionId = addPosition.PositionId,
            //        Bonus = 0,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "Above 100%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.IndividualTargetDiscountType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule9 = this.client.AddRule(rule9);
            //    Assert.Greater(addRule9.RuleId, 0, "AddRule9 failed!");

            //    var rule17 = new Rule
            //    {
            //        PositionId = addPosition2.PositionId,
            //        Bonus = 0.004,
            //        OperationMaxValue = 0.99,
            //        OperationMinValue = 0.8,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "80% to 99%",
            //        RuleOrder = 3,
            //        RuleType = RuleType.IndividualTargetDiscountType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule17 = this.client.AddRule(rule17);
            //    Assert.Greater(addRule17.RuleId, 0, "AddRule17 failed!");

            //    var rule18 = new Rule
            //    {
            //        PositionId = addPosition2.PositionId,
            //        Bonus = 0.009,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.IndividualTargetDiscountType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule18 = this.client.AddRule(rule18);
            //    Assert.Greater(addRule18.RuleId, 0, "AddRule18 failed!");

            //    var rule19 = new Rule
            //    {
            //        PositionId = addPosition2.PositionId,
            //        Bonus = 0.011,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "Above 100%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.IndividualTargetDiscountType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule19 = this.client.AddRule(rule19);
            //    Assert.Greater(addRule19.RuleId, 0, "AddRule19 failed!");

            //    var rule27 = new Rule
            //    {
            //        PositionId = addPosition3.PositionId,
            //        Bonus = 0.004,
            //        OperationMaxValue = 0.99,
            //        OperationMinValue = 0.8,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "80% to 99%",
            //        RuleOrder = 3,
            //        RuleType = RuleType.IndividualTargetDiscountType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule27 = this.client.AddRule(rule27);
            //    Assert.Greater(addRule27.RuleId, 0, "AddRule27 failed!");

            //    var rule28 = new Rule
            //    {
            //        PositionId = addPosition3.PositionId,
            //        Bonus = 0.009,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.IndividualTargetDiscountType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule28 = this.client.AddRule(rule28);
            //    Assert.Greater(addRule28.RuleId, 0, "AddRule28 failed!");

            //    var rule29 = new Rule
            //    {
            //        PositionId = addPosition3.PositionId,
            //        Bonus = 0.011,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "Above 100%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.IndividualTargetDiscountType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule29 = this.client.AddRule(rule29);
            //    Assert.Greater(addRule29.RuleId, 0, "AddRule29 failed!");

            //    var rule37 = new Rule
            //    {
            //        PositionId = addPosition4.PositionId,
            //        Bonus = 0.004,
            //        OperationMaxValue = 0.99,
            //        OperationMinValue = 0.8,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "80% to 99%",
            //        RuleOrder = 3,
            //        RuleType = RuleType.IndividualTargetDiscountType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule37 = this.client.AddRule(rule37);
            //    Assert.Greater(addRule37.RuleId, 0, "AddRule37 failed!");

            //    var rule38 = new Rule
            //    {
            //        PositionId = addPosition4.PositionId,
            //        Bonus = 0.009,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.IndividualTargetDiscountType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule38 = this.client.AddRule(rule38);
            //    Assert.Greater(addRule38.RuleId, 0, "AddRule38 failed!");

            //    var rule39 = new Rule
            //    {
            //        PositionId = addPosition4.PositionId,
            //        Bonus = 0.011,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "Above 100%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.IndividualTargetDiscountType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule39 = this.client.AddRule(rule39);
            //    Assert.Greater(addRule39.RuleId, 0, "AddRule39 failed!");

            //    var rule47 = new Rule
            //    {
            //        PositionId = addPosition5.PositionId,
            //        Bonus = 0.004,
            //        OperationMaxValue = 0.99,
            //        OperationMinValue = 0.8,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "80% to 99%",
            //        RuleOrder = 3,
            //        RuleType = RuleType.IndividualTargetDiscountType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule47 = this.client.AddRule(rule47);
            //    Assert.Greater(addRule47.RuleId, 0, "AddRule47 failed!");

            //    var rule48 = new Rule
            //    {
            //        PositionId = addPosition5.PositionId,
            //        Bonus = 0.009,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.IndividualTargetDiscountType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule48 = this.client.AddRule(rule48);
            //    Assert.Greater(addRule48.RuleId, 0, "AddRule48 failed!");

            //    var rule49 = new Rule
            //    {
            //        PositionId = addPosition5.PositionId,
            //        Bonus = 0.011,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "Above 100%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.IndividualTargetDiscountType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule49 = this.client.AddRule(rule49);
            //    Assert.Greater(addRule49.RuleId, 0, "AddRule49 failed!");

            //    // IndividualTargetFullType
            //    var rule111 = new Rule
            //    {
            //        PositionId = addPosition.PositionId,
            //        Bonus = 0,
            //        OperationMaxValue = 0.7,
            //        OperationMinValue = 1,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "70% to 100%",
            //        RuleOrder = 3,
            //        RuleType = RuleType.IndividualTargetFullType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule111 = this.client.AddRule(rule111);
            //    Assert.Greater(addRule111.RuleId, 0, "AddRule111 failed!");

            //    var rule112 = new Rule
            //    {
            //        PositionId = addPosition.PositionId,
            //        Bonus = 0,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.IndividualTargetFullType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule112 = this.client.AddRule(rule112);
            //    Assert.Greater(addRule112.RuleId, 0, "AddRule112 failed!");

            //    var rule113 = new Rule
            //    {
            //        PositionId = addPosition.PositionId,
            //        Bonus = 0,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "Above 100%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.IndividualTargetFullType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule113 = this.client.AddRule(rule113);
            //    Assert.Greater(addRule113.RuleId, 0, "AddRule113 failed!");

            //    var rule121 = new Rule
            //    {
            //        PositionId = addPosition2.PositionId,
            //        Bonus = 0.008,
            //        OperationMaxValue = 0.7,
            //        OperationMinValue = 1,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "70% to 100%",
            //        RuleOrder = 3,
            //        RuleType = RuleType.IndividualTargetFullType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule121 = this.client.AddRule(rule121);
            //    Assert.Greater(addRule121.RuleId, 0, "AddRule121 failed!");

            //    var rule122 = new Rule
            //    {
            //        PositionId = addPosition2.PositionId,
            //        Bonus = 0.018,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.IndividualTargetFullType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule122 = this.client.AddRule(rule122);
            //    Assert.Greater(addRule122.RuleId, 0, "AddRule122 failed!");

            //    var rule123 = new Rule
            //    {
            //        PositionId = addPosition2.PositionId,
            //        Bonus = 0.02,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "Above 100%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.IndividualTargetFullType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule123 = this.client.AddRule(rule123);
            //    Assert.Greater(addRule123.RuleId, 0, "AddRule123 failed!");

            //    var rule131 = new Rule
            //    {
            //        PositionId = addPosition3.PositionId,
            //        Bonus = 0.008,
            //        OperationMaxValue = 0.7,
            //        OperationMinValue = 1,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "70% to 100%",
            //        RuleOrder = 3,
            //        RuleType = RuleType.IndividualTargetFullType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule131 = this.client.AddRule(rule131);
            //    Assert.Greater(addRule131.RuleId, 0, "AddRule131 failed!");

            //    var rule132 = new Rule
            //    {
            //        PositionId = addPosition3.PositionId,
            //        Bonus = 0.018,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.IndividualTargetFullType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule132 = this.client.AddRule(rule132);
            //    Assert.Greater(addRule132.RuleId, 0, "AddRule132 failed!");

            //    var rule133 = new Rule
            //    {
            //        PositionId = addPosition3.PositionId,
            //        Bonus = 0.02,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "Above 100%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.IndividualTargetFullType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule133 = this.client.AddRule(rule133);
            //    Assert.Greater(addRule133.RuleId, 0, "AddRule133 failed!");

            //    var rule141 = new Rule
            //    {
            //        PositionId = addPosition4.PositionId,
            //        Bonus = 0.008,
            //        OperationMaxValue = 0.7,
            //        OperationMinValue = 1,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "70% to 100%",
            //        RuleOrder = 3,
            //        RuleType = RuleType.IndividualTargetFullType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule141 = this.client.AddRule(rule141);
            //    Assert.Greater(addRule141.RuleId, 0, "AddRule141 failed!");

            //    var rule142 = new Rule
            //    {
            //        PositionId = addPosition4.PositionId,
            //        Bonus = 0.018,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.IndividualTargetFullType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule142 = this.client.AddRule(rule142);
            //    Assert.Greater(addRule142.RuleId, 0, "AddRule142 failed!");

            //    var rule143 = new Rule
            //    {
            //        PositionId = addPosition4.PositionId,
            //        Bonus = 0.02,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "Above 100%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.IndividualTargetFullType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule143 = this.client.AddRule(rule143);
            //    Assert.Greater(addRule143.RuleId, 0, "AddRule143 failed!");

            //    var rule151 = new Rule
            //    {
            //        PositionId = addPosition5.PositionId,
            //        Bonus = 0.008,
            //        OperationMaxValue = 0.7,
            //        OperationMinValue = 1,
            //        OperationValue = 0,
            //        OperationType = OperationType.GreaterAndLessThanType,
            //        RuleDescription = "70% to 100%",
            //        RuleOrder = 3,
            //        RuleType = RuleType.IndividualTargetFullType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule151 = this.client.AddRule(rule151);
            //    Assert.Greater(addRule151.RuleId, 0, "AddRule151 failed!");

            //    var rule152 = new Rule
            //    {
            //        PositionId = addPosition5.PositionId,
            //        Bonus = 0.018,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.IndividualTargetFullType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule152 = this.client.AddRule(rule152);
            //    Assert.Greater(addRule152.RuleId, 0, "AddRule152 failed!");

            //    var rule153 = new Rule
            //    {
            //        PositionId = addPosition5.PositionId,
            //        Bonus = 0.02,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "Above 100%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.IndividualTargetFullType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule153 = this.client.AddRule(rule153);
            //    Assert.Greater(addRule153.RuleId, 0, "AddRule153 failed!");

            //    // IndividualWeeklyType
            //    var rule161 = new Rule
            //    {
            //        PositionId = addPosition.PositionId,
            //        Bonus = 0,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.IndividualWeeklyType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule161 = this.client.AddRule(rule161);
            //    Assert.Greater(addRule161.RuleId, 0, "AddRule161 failed!");

            //    var rule162 = new Rule
            //    {
            //        PositionId = addPosition.PositionId,
            //        Bonus = 0,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "Above 100%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.IndividualWeeklyType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule162 = this.client.AddRule(rule162);
            //    Assert.Greater(addRule162.RuleId, 0, "AddRule162 failed!");

            //    var rule171 = new Rule
            //    {
            //        PositionId = addPosition2.PositionId,
            //        Bonus = 500,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.IndividualWeeklyType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule171 = this.client.AddRule(rule171);
            //    Assert.Greater(addRule171.RuleId, 0, "AddRule171 failed!");

            //    var rule172 = new Rule
            //    {
            //        PositionId = addPosition2.PositionId,
            //        Bonus = 700,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "Above 100%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.IndividualWeeklyType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule172 = this.client.AddRule(rule172);
            //    Assert.Greater(addRule172.RuleId, 0, "AddRule172 failed!");

            //    var rule181 = new Rule
            //    {
            //        PositionId = addPosition3.PositionId,
            //        Bonus = 400,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.IndividualWeeklyType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule181 = this.client.AddRule(rule181);
            //    Assert.Greater(addRule181.RuleId, 0, "AddRule181 failed!");

            //    var rule182 = new Rule
            //    {
            //        PositionId = addPosition3.PositionId,
            //        Bonus = 600,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "Above 100%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.IndividualWeeklyType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule182 = this.client.AddRule(rule182);
            //    Assert.Greater(addRule182.RuleId, 0, "AddRule182 failed!");

            //    var rule191 = new Rule
            //    {
            //        PositionId = addPosition4.PositionId,
            //        Bonus = 300,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.IndividualWeeklyType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule191 = this.client.AddRule(rule191);
            //    Assert.Greater(addRule191.RuleId, 0, "AddRule191 failed!");

            //    var rule192 = new Rule
            //    {
            //        PositionId = addPosition4.PositionId,
            //        Bonus = 500,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "Above 100%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.IndividualWeeklyType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule192 = this.client.AddRule(rule192);
            //    Assert.Greater(addRule192.RuleId, 0, "AddRule192 failed!");

            //    var rule201 = new Rule
            //    {
            //        PositionId = addPosition5.PositionId,
            //        Bonus = 200,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.IndividualWeeklyType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule201 = this.client.AddRule(rule201);
            //    Assert.Greater(addRule201.RuleId, 0, "AddRule201 failed!");

            //    var rule202 = new Rule
            //    {
            //        PositionId = addPosition5.PositionId,
            //        Bonus = 400,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "Above 100%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.IndividualWeeklyType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule202 = this.client.AddRule(rule202);
            //    Assert.Greater(addRule202.RuleId, 0, "AddRule202 failed!");

            //    // ShopPoolWeeklyType
            //    var rule211 = new Rule
            //    {
            //        PositionId = addPosition.PositionId,
            //        Bonus = 600,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.ShopPoolWeeklyType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule211 = this.client.AddRule(rule211);
            //    Assert.Greater(addRule211.RuleId, 0, "AddRule211 failed!");

            //    var rule222 = new Rule
            //    {
            //        PositionId = addPosition.PositionId,
            //        Bonus = 800,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "Above 100%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.ShopPoolWeeklyType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule222 = this.client.AddRule(rule222);
            //    Assert.Greater(addRule222.RuleId, 0, "AddRule222 failed!");

            //    var rule231 = new Rule
            //    {
            //        PositionId = addPosition2.PositionId,
            //        Bonus = 100,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.ShopPoolWeeklyType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule231 = this.client.AddRule(rule231);
            //    Assert.Greater(addRule231.RuleId, 0, "AddRule231 failed!");

            //    var rule232 = new Rule
            //    {
            //        PositionId = addPosition2.PositionId,
            //        Bonus = 200,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "Above 100%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.ShopPoolWeeklyType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule232 = this.client.AddRule(rule232);
            //    Assert.Greater(addRule232.RuleId, 0, "AddRule232 failed!");

            //    var rule241 = new Rule
            //    {
            //        PositionId = addPosition3.PositionId,
            //        Bonus = 100,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.ShopPoolWeeklyType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule241 = this.client.AddRule(rule241);
            //    Assert.Greater(addRule241.RuleId, 0, "AddRule241 failed!");

            //    var rule242 = new Rule
            //    {
            //        PositionId = addPosition3.PositionId,
            //        Bonus = 200,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "Above 100%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.ShopPoolWeeklyType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule242 = this.client.AddRule(rule242);
            //    Assert.Greater(addRule242.RuleId, 0, "AddRule242 failed!");

            //    var rule251 = new Rule
            //    {
            //        PositionId = addPosition4.PositionId,
            //        Bonus = 100,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.ShopPoolWeeklyType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule251 = this.client.AddRule(rule251);
            //    Assert.Greater(addRule251.RuleId, 0, "AddRule251 failed!");

            //    var rule252 = new Rule
            //    {
            //        PositionId = addPosition4.PositionId,
            //        Bonus = 200,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "Above 100%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.ShopPoolWeeklyType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule252 = this.client.AddRule(rule252);
            //    Assert.Greater(addRule252.RuleId, 0, "AddRule252 failed!");

            //    var rule261 = new Rule
            //    {
            //        PositionId = addPosition5.PositionId,
            //        Bonus = 100,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "100%",
            //        RuleOrder = 2,
            //        RuleType = RuleType.ShopPoolWeeklyType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule261 = this.client.AddRule(rule261);
            //    Assert.Greater(addRule261.RuleId, 0, "AddRule261 failed!");

            //    var rule262 = new Rule
            //    {
            //        PositionId = addPosition5.PositionId,
            //        Bonus = 200,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 1,
            //        OperationType = OperationType.GreaterThanType,
            //        RuleDescription = "Above 100%",
            //        RuleOrder = 1,
            //        RuleType = RuleType.ShopPoolWeeklyType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule262 = this.client.AddRule(rule262);
            //    Assert.Greater(addRule262.RuleId, 0, "AddRule262 failed!");

            //    // FullAttendenceType
            //    var rule271 = new Rule
            //    {
            //        PositionId = addPosition.PositionId,
            //        Bonus = 0,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 0,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "",
            //        RuleOrder = 1,
            //        RuleType = RuleType.FullAttendenceType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule271 = this.client.AddRule(rule271);
            //    Assert.Greater(addRule271.RuleId, 0, "AddRule271 failed!");

            //    var rule281 = new Rule
            //    {
            //        PositionId = addPosition2.PositionId,
            //        Bonus = 300,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 0,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "",
            //        RuleOrder = 1,
            //        RuleType = RuleType.FullAttendenceType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule281 = this.client.AddRule(rule281);
            //    Assert.Greater(addRule281.RuleId, 0, "AddRule281 failed!");

            //    var rule291 = new Rule
            //    {
            //        PositionId = addPosition3.PositionId,
            //        Bonus = 300,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 0,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "",
            //        RuleOrder = 1,
            //        RuleType = RuleType.FullAttendenceType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule291 = this.client.AddRule(rule291);
            //    Assert.Greater(addRule291.RuleId, 0, "AddRule291 failed!");

            //    var rule301 = new Rule
            //    {
            //        PositionId = addPosition4.PositionId,
            //        Bonus = 300,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 0,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "",
            //        RuleOrder = 1,
            //        RuleType = RuleType.FullAttendenceType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule301 = this.client.AddRule(rule301);
            //    Assert.Greater(addRule301.RuleId, 0, "AddRule301 failed!");

            //    var rule311 = new Rule
            //    {
            //        PositionId = addPosition5.PositionId,
            //        Bonus = 300,
            //        OperationMaxValue = 0,
            //        OperationMinValue = 0,
            //        OperationValue = 0,
            //        OperationType = OperationType.Equal,
            //        RuleDescription = "",
            //        RuleOrder = 1,
            //        RuleType = RuleType.FullAttendenceType,
            //        ShopId = shop.ShopId
            //    };

            //    var addRule311 = this.client.AddRule(rule311);
            //    Assert.Greater(addRule311.RuleId, 0, "AddRule311 failed!");
            //}

            //// OUTLET.ShopPoolCommissionType
            //var rule321 = new Rule
            //{
            //    PositionId = addPosition2.PositionId,
            //    Bonus = 800,
            //    OperationMaxValue = 1,
            //    OperationMinValue = 0.7,
            //    OperationValue = 0,
            //    OperationType = OperationType.GreaterAndLessThanType,
            //    RuleDescription = "70% to 100%",
            //    RuleOrder = 4,
            //    RuleType = RuleType.ShopPoolCommissionType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule321 = this.client.AddRule(rule321);
            //Assert.Greater(addRule321.RuleId, 0, "AddRule321 failed!");

            //var rule322 = new Rule
            //{
            //    PositionId = addPosition2.PositionId,
            //    Bonus = 1200,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.Equal,
            //    RuleDescription = "100%",
            //    RuleOrder = 3,
            //    RuleType = RuleType.ShopPoolCommissionType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule322 = this.client.AddRule(rule322);
            //Assert.Greater(addRule322.RuleId, 0, "AddRule322 failed!");

            //var rule323 = new Rule
            //{
            //    PositionId = addPosition2.PositionId,
            //    Bonus = 1350,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.GreaterThanType,
            //    RuleDescription = "Above 100%",
            //    RuleOrder = 2,
            //    RuleType = RuleType.ShopPoolCommissionType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule323 = this.client.AddRule(rule323);
            //Assert.Greater(addRule323.RuleId, 0, "AddRule323 failed!");

            //var rule324 = new Rule
            //{
            //    PositionId = addPosition2.PositionId,
            //    Bonus = 1500,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1.2,
            //    OperationType = OperationType.GreaterThanType,
            //    RuleDescription = "Above 120%",
            //    RuleOrder = 1,
            //    RuleType = RuleType.ShopPoolCommissionType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule324 = this.client.AddRule(rule324);
            //Assert.Greater(addRule324.RuleId, 0, "AddRule324 failed!");

            //var rule331 = new Rule
            //{
            //    PositionId = addPosition3.PositionId,
            //    Bonus = 600,
            //    OperationMaxValue = 1,
            //    OperationMinValue = 0.7,
            //    OperationValue = 0,
            //    OperationType = OperationType.GreaterAndLessThanType,
            //    RuleDescription = "70% to 100%",
            //    RuleOrder = 4,
            //    RuleType = RuleType.ShopPoolCommissionType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule331 = this.client.AddRule(rule331);
            //Assert.Greater(addRule331.RuleId, 0, "AddRule331 failed!");

            //var rule332 = new Rule
            //{
            //    PositionId = addPosition3.PositionId,
            //    Bonus = 900,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.Equal,
            //    RuleDescription = "100%",
            //    RuleOrder = 3,
            //    RuleType = RuleType.ShopPoolCommissionType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule332 = this.client.AddRule(rule332);
            //Assert.Greater(addRule332.RuleId, 0, "AddRule332 failed!");

            //var rule333 = new Rule
            //{
            //    PositionId = addPosition3.PositionId,
            //    Bonus = 1000,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.GreaterThanType,
            //    RuleDescription = "Above 100%",
            //    RuleOrder = 2,
            //    RuleType = RuleType.ShopPoolCommissionType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule333 = this.client.AddRule(rule333);
            //Assert.Greater(addRule333.RuleId, 0, "AddRule333 failed!");

            //var rule334 = new Rule
            //{
            //    PositionId = addPosition3.PositionId,
            //    Bonus = 1500,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1.2,
            //    OperationType = OperationType.GreaterThanType,
            //    RuleDescription = "Above 120%",
            //    RuleOrder = 1,
            //    RuleType = RuleType.ShopPoolCommissionType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule334 = this.client.AddRule(rule334);
            //Assert.Greater(addRule334.RuleId, 0, "AddRule334 failed!");

            //var rule341 = new Rule
            //{
            //    PositionId = addPosition4.PositionId,
            //    Bonus = 400,
            //    OperationMaxValue = 1,
            //    OperationMinValue = 0.7,
            //    OperationValue = 0,
            //    OperationType = OperationType.GreaterAndLessThanType,
            //    RuleDescription = "70% to 100%",
            //    RuleOrder = 4,
            //    RuleType = RuleType.ShopPoolCommissionType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule341 = this.client.AddRule(rule341);
            //Assert.Greater(addRule341.RuleId, 0, "AddRule341 failed!");

            //var rule342 = new Rule
            //{
            //    PositionId = addPosition4.PositionId,
            //    Bonus = 700,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.Equal,
            //    RuleDescription = "100%",
            //    RuleOrder = 3,
            //    RuleType = RuleType.ShopPoolCommissionType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule342 = this.client.AddRule(rule342);
            //Assert.Greater(addRule342.RuleId, 0, "AddRule342 failed!");

            //var rule343 = new Rule
            //{
            //    PositionId = addPosition4.PositionId,
            //    Bonus = 800,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.GreaterThanType,
            //    RuleDescription = "Above 100%",
            //    RuleOrder = 2,
            //    RuleType = RuleType.ShopPoolCommissionType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule343 = this.client.AddRule(rule343);
            //Assert.Greater(addRule343.RuleId, 0, "AddRule343 failed!");

            //var rule344 = new Rule
            //{
            //    PositionId = addPosition4.PositionId,
            //    Bonus = 1500,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1.2,
            //    OperationType = OperationType.GreaterThanType,
            //    RuleDescription = "Above 120%",
            //    RuleOrder = 1,
            //    RuleType = RuleType.ShopPoolCommissionType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule344 = this.client.AddRule(rule344);
            //Assert.Greater(addRule344.RuleId, 0, "AddRule344 failed!");

            //var rule351 = new Rule
            //{
            //    PositionId = addPosition5.PositionId,
            //    Bonus = 300,
            //    OperationMaxValue = 1,
            //    OperationMinValue = 0.7,
            //    OperationValue = 0,
            //    OperationType = OperationType.GreaterAndLessThanType,
            //    RuleDescription = "70% to 100%",
            //    RuleOrder = 4,
            //    RuleType = RuleType.ShopPoolCommissionType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule351 = this.client.AddRule(rule351);
            //Assert.Greater(addRule351.RuleId, 0, "AddRule351 failed!");

            //var rule352 = new Rule
            //{
            //    PositionId = addPosition5.PositionId,
            //    Bonus = 500,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.Equal,
            //    RuleDescription = "100%",
            //    RuleOrder = 3,
            //    RuleType = RuleType.ShopPoolCommissionType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule352 = this.client.AddRule(rule352);
            //Assert.Greater(addRule352.RuleId, 0, "AddRule352 failed!");

            //var rule353 = new Rule
            //{
            //    PositionId = addPosition5.PositionId,
            //    Bonus = 600,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.GreaterThanType,
            //    RuleDescription = "Above 100%",
            //    RuleOrder = 2,
            //    RuleType = RuleType.ShopPoolCommissionType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule353 = this.client.AddRule(rule353);
            //Assert.Greater(addRule353.RuleId, 0, "AddRule353 failed!");

            //var rule354 = new Rule
            //{
            //    PositionId = addPosition5.PositionId,
            //    Bonus = 1500,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1.2,
            //    OperationType = OperationType.GreaterThanType,
            //    RuleDescription = "Above 120%",
            //    RuleOrder = 1,
            //    RuleType = RuleType.ShopPoolCommissionType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule354 = this.client.AddRule(rule354);
            //Assert.Greater(addRule354.RuleId, 0, "AddRule354 failed!");

            //// IndividualTargetBelow70Type
            //var rule361 = new Rule
            //{
            //    PositionId = addPosition2.PositionId,
            //    Bonus = 0.004,
            //    OperationMaxValue = 0.99,
            //    OperationMinValue = 0.8,
            //    OperationValue = 0,
            //    OperationType = OperationType.GreaterAndLessThanType,
            //    RuleDescription = "80% to 99%",
            //    RuleOrder = 3,
            //    RuleType = RuleType.IndividualTargetBelow70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule361 = this.client.AddRule(rule361);
            //Assert.Greater(addRule361.RuleId, 0, "AddRule361 failed!");

            //var rule362 = new Rule
            //{
            //    PositionId = addPosition2.PositionId,
            //    Bonus = 0.006,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.Equal,
            //    RuleDescription = "100%",
            //    RuleOrder = 2,
            //    RuleType = RuleType.IndividualTargetBelow70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule362 = this.client.AddRule(rule362);
            //Assert.Greater(addRule362.RuleId, 0, "AddRule362 failed!");

            //var rule363 = new Rule
            //{
            //    PositionId = addPosition2.PositionId,
            //    Bonus = 0.008,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.GreaterThanType,
            //    RuleDescription = "Above 100%",
            //    RuleOrder = 1,
            //    RuleType = RuleType.IndividualTargetBelow70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule363 = this.client.AddRule(rule363);
            //Assert.Greater(addRule363.RuleId, 0, "AddRule363 failed!");

            //var rule371 = new Rule
            //{
            //    PositionId = addPosition3.PositionId,
            //    Bonus = 0.004,
            //    OperationMaxValue = 0.99,
            //    OperationMinValue = 0.8,
            //    OperationValue = 0,
            //    OperationType = OperationType.GreaterAndLessThanType,
            //    RuleDescription = "80% to 99%",
            //    RuleOrder = 3,
            //    RuleType = RuleType.IndividualTargetBelow70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule371 = this.client.AddRule(rule371);
            //Assert.Greater(addRule371.RuleId, 0, "AddRule371 failed!");

            //var rule372 = new Rule
            //{
            //    PositionId = addPosition3.PositionId,
            //    Bonus = 0.006,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.Equal,
            //    RuleDescription = "100%",
            //    RuleOrder = 2,
            //    RuleType = RuleType.IndividualTargetBelow70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule372 = this.client.AddRule(rule372);
            //Assert.Greater(addRule372.RuleId, 0, "AddRule372 failed!");

            //var rule373 = new Rule
            //{
            //    PositionId = addPosition3.PositionId,
            //    Bonus = 0.008,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.GreaterThanType,
            //    RuleDescription = "Above 100%",
            //    RuleOrder = 1,
            //    RuleType = RuleType.IndividualTargetBelow70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule373 = this.client.AddRule(rule373);
            //Assert.Greater(addRule373.RuleId, 0, "AddRule373 failed!");

            //var rule381 = new Rule
            //{
            //    PositionId = addPosition4.PositionId,
            //    Bonus = 0.004,
            //    OperationMaxValue = 0.99,
            //    OperationMinValue = 0.8,
            //    OperationValue = 0,
            //    OperationType = OperationType.GreaterAndLessThanType,
            //    RuleDescription = "80% to 99%",
            //    RuleOrder = 3,
            //    RuleType = RuleType.IndividualTargetBelow70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule381 = this.client.AddRule(rule381);
            //Assert.Greater(addRule381.RuleId, 0, "AddRule381 failed!");

            //var rule382 = new Rule
            //{
            //    PositionId = addPosition4.PositionId,
            //    Bonus = 0.006,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.Equal,
            //    RuleDescription = "100%",
            //    RuleOrder = 2,
            //    RuleType = RuleType.IndividualTargetBelow70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule382 = this.client.AddRule(rule382);
            //Assert.Greater(addRule382.RuleId, 0, "AddRule382 failed!");

            //var rule383 = new Rule
            //{
            //    PositionId = addPosition4.PositionId,
            //    Bonus = 0.008,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.GreaterThanType,
            //    RuleDescription = "Above 100%",
            //    RuleOrder = 1,
            //    RuleType = RuleType.IndividualTargetBelow70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule383 = this.client.AddRule(rule383);
            //Assert.Greater(addRule383.RuleId, 0, "AddRule383 failed!");

            //var rule391 = new Rule
            //{
            //    PositionId = addPosition5.PositionId,
            //    Bonus = 0.004,
            //    OperationMaxValue = 0.99,
            //    OperationMinValue = 0.8,
            //    OperationValue = 0,
            //    OperationType = OperationType.GreaterAndLessThanType,
            //    RuleDescription = "80% to 99%",
            //    RuleOrder = 3,
            //    RuleType = RuleType.IndividualTargetBelow70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule391 = this.client.AddRule(rule391);
            //Assert.Greater(addRule391.RuleId, 0, "AddRule391 failed!");

            //var rule392 = new Rule
            //{
            //    PositionId = addPosition5.PositionId,
            //    Bonus = 0.006,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.Equal,
            //    RuleDescription = "100%",
            //    RuleOrder = 2,
            //    RuleType = RuleType.IndividualTargetBelow70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule392 = this.client.AddRule(rule392);
            //Assert.Greater(addRule392.RuleId, 0, "AddRule392 failed!");

            //var rule393 = new Rule
            //{
            //    PositionId = addPosition5.PositionId,
            //    Bonus = 0.008,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.GreaterThanType,
            //    RuleDescription = "Above 100%",
            //    RuleOrder = 1,
            //    RuleType = RuleType.IndividualTargetBelow70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule393 = this.client.AddRule(rule393);
            //Assert.Greater(addRule393.RuleId, 0, "AddRule393 failed!");

            //// OUTLET.IndividualTargetAbove70Type
            //var rule401 = new Rule
            //{
            //    PositionId = addPosition2.PositionId,
            //    Bonus = 0.011,
            //    OperationMaxValue = 1,
            //    OperationMinValue = 0.7,
            //    OperationValue = 0,
            //    OperationType = OperationType.GreaterAndLessThanType,
            //    RuleDescription = "70% to 100%",
            //    RuleOrder = 3,
            //    RuleType = RuleType.IndividualTargetAbove70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule401 = this.client.AddRule(rule401);
            //Assert.Greater(addRule401.RuleId, 0, "AddRule401 failed!");

            //var rule402 = new Rule
            //{
            //    PositionId = addPosition2.PositionId,
            //    Bonus = 0.021,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.Equal,
            //    RuleDescription = "100%",
            //    RuleOrder = 2,
            //    RuleType = RuleType.IndividualTargetAbove70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule402 = this.client.AddRule(rule402);
            //Assert.Greater(addRule402.RuleId, 0, "AddRule402 failed!");

            //var rule403 = new Rule
            //{
            //    PositionId = addPosition2.PositionId,
            //    Bonus = 0.023,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.GreaterThanType,
            //    RuleDescription = "Above 100%",
            //    RuleOrder = 1,
            //    RuleType = RuleType.IndividualTargetAbove70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule403 = this.client.AddRule(rule403);
            //Assert.Greater(addRule403.RuleId, 0, "AddRule403 failed!");

            //var rule411 = new Rule
            //{
            //    PositionId = addPosition3.PositionId,
            //    Bonus = 0.011,
            //    OperationMaxValue = 1,
            //    OperationMinValue = 0.7,
            //    OperationValue = 0,
            //    OperationType = OperationType.GreaterAndLessThanType,
            //    RuleDescription = "70% to 100%",
            //    RuleOrder = 3,
            //    RuleType = RuleType.IndividualTargetAbove70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule411 = this.client.AddRule(rule411);
            //Assert.Greater(addRule411.RuleId, 0, "AddRule411 failed!");

            //var rule412 = new Rule
            //{
            //    PositionId = addPosition3.PositionId,
            //    Bonus = 0.021,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.Equal,
            //    RuleDescription = "100%",
            //    RuleOrder = 2,
            //    RuleType = RuleType.IndividualTargetAbove70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule412 = this.client.AddRule(rule412);
            //Assert.Greater(addRule412.RuleId, 0, "AddRule412 failed!");

            //var rule413 = new Rule
            //{
            //    PositionId = addPosition3.PositionId,
            //    Bonus = 0.023,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.GreaterThanType,
            //    RuleDescription = "Above 100%",
            //    RuleOrder = 1,
            //    RuleType = RuleType.IndividualTargetAbove70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule413 = this.client.AddRule(rule413);
            //Assert.Greater(addRule413.RuleId, 0, "AddRule413 failed!");

            //var rule421 = new Rule
            //{
            //    PositionId = addPosition4.PositionId,
            //    Bonus = 0.011,
            //    OperationMaxValue = 1,
            //    OperationMinValue = 0.7,
            //    OperationValue = 0,
            //    OperationType = OperationType.GreaterAndLessThanType,
            //    RuleDescription = "70% to 100%",
            //    RuleOrder = 3,
            //    RuleType = RuleType.IndividualTargetAbove70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule421 = this.client.AddRule(rule421);
            //Assert.Greater(addRule421.RuleId, 0, "AddRule421 failed!");

            //var rule422 = new Rule
            //{
            //    PositionId = addPosition4.PositionId,
            //    Bonus = 0.021,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.Equal,
            //    RuleDescription = "100%",
            //    RuleOrder = 2,
            //    RuleType = RuleType.IndividualTargetAbove70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule422 = this.client.AddRule(rule422);
            //Assert.Greater(addRule422.RuleId, 0, "AddRule422 failed!");

            //var rule423 = new Rule
            //{
            //    PositionId = addPosition4.PositionId,
            //    Bonus = 0.023,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.GreaterThanType,
            //    RuleDescription = "Above 100%",
            //    RuleOrder = 1,
            //    RuleType = RuleType.IndividualTargetAbove70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule423 = this.client.AddRule(rule423);
            //Assert.Greater(addRule423.RuleId, 0, "AddRule423 failed!");

            //var rule431 = new Rule
            //{
            //    PositionId = addPosition5.PositionId,
            //    Bonus = 0.011,
            //    OperationMaxValue = 1,
            //    OperationMinValue = 0.7,
            //    OperationValue = 0,
            //    OperationType = OperationType.GreaterAndLessThanType,
            //    RuleDescription = "70% to 100%",
            //    RuleOrder = 3,
            //    RuleType = RuleType.IndividualTargetAbove70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule431 = this.client.AddRule(rule431);
            //Assert.Greater(addRule431.RuleId, 0, "AddRule431 failed!");

            //var rule432 = new Rule
            //{
            //    PositionId = addPosition5.PositionId,
            //    Bonus = 0.021,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.Equal,
            //    RuleDescription = "100%",
            //    RuleOrder = 2,
            //    RuleType = RuleType.IndividualTargetAbove70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule432 = this.client.AddRule(rule432);
            //Assert.Greater(addRule432.RuleId, 0, "AddRule432 failed!");

            //var rule433 = new Rule
            //{
            //    PositionId = addPosition5.PositionId,
            //    Bonus = 0.023,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.GreaterThanType,
            //    RuleDescription = "Above 100%",
            //    RuleOrder = 1,
            //    RuleType = RuleType.IndividualTargetAbove70Type,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule433 = this.client.AddRule(rule433);
            //Assert.Greater(addRule433.RuleId, 0, "AddRule433 failed!");

            //// OUTLET.ShopPoolWeeklyType
            //var rule443 = new Rule
            //{
            //    PositionId = addPosition2.PositionId,
            //    Bonus = 500,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.Equal,
            //    RuleDescription = "100%",
            //    RuleOrder = 2,
            //    RuleType = RuleType.ShopPoolWeeklyType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule443 = this.client.AddRule(rule443);
            //Assert.Greater(addRule443.RuleId, 0, "AddRule443 failed!");

            //var rule444 = new Rule
            //{
            //    PositionId = addPosition2.PositionId,
            //    Bonus = 700,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.GreaterThanType,
            //    RuleDescription = "Above 100%",
            //    RuleOrder = 1,
            //    RuleType = RuleType.ShopPoolWeeklyType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule444 = this.client.AddRule(rule444);
            //Assert.Greater(addRule444.RuleId, 0, "AddRule444 failed!");

            //var rule453 = new Rule
            //{
            //    PositionId = addPosition3.PositionId,
            //    Bonus = 400,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.Equal,
            //    RuleDescription = "100%",
            //    RuleOrder = 2,
            //    RuleType = RuleType.ShopPoolWeeklyType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule453 = this.client.AddRule(rule453);
            //Assert.Greater(addRule453.RuleId, 0, "AddRule453 failed!");

            //var rule454 = new Rule
            //{
            //    PositionId = addPosition3.PositionId,
            //    Bonus = 600,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.GreaterThanType,
            //    RuleDescription = "Above 100%",
            //    RuleOrder = 1,
            //    RuleType = RuleType.ShopPoolWeeklyType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule454 = this.client.AddRule(rule454);
            //Assert.Greater(addRule454.RuleId, 0, "AddRule454 failed!");

            //var rule463 = new Rule
            //{
            //    PositionId = addPosition4.PositionId,
            //    Bonus = 300,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.Equal,
            //    RuleDescription = "100%",
            //    RuleOrder = 2,
            //    RuleType = RuleType.ShopPoolWeeklyType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule463 = this.client.AddRule(rule463);
            //Assert.Greater(addRule463.RuleId, 0, "AddRule463 failed!");

            //var rule464 = new Rule
            //{
            //    PositionId = addPosition4.PositionId,
            //    Bonus = 600,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.GreaterThanType,
            //    RuleDescription = "Above 100%",
            //    RuleOrder = 1,
            //    RuleType = RuleType.ShopPoolWeeklyType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule464 = this.client.AddRule(rule464);
            //Assert.Greater(addRule464.RuleId, 0, "AddRule464 failed!");

            //var rule473 = new Rule
            //{
            //    PositionId = addPosition5.PositionId,
            //    Bonus = 200,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.Equal,
            //    RuleDescription = "100%",
            //    RuleOrder = 2,
            //    RuleType = RuleType.ShopPoolWeeklyType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule473 = this.client.AddRule(rule473);
            //Assert.Greater(addRule473.RuleId, 0, "AddRule473 failed!");

            //var rule474 = new Rule
            //{
            //    PositionId = addPosition5.PositionId,
            //    Bonus = 400,
            //    OperationMaxValue = 0,
            //    OperationMinValue = 0,
            //    OperationValue = 1,
            //    OperationType = OperationType.GreaterThanType,
            //    RuleDescription = "Above 100%",
            //    RuleOrder = 1,
            //    RuleType = RuleType.ShopPoolWeeklyType,
            //    ShopId = addShop5.ShopId
            //};

            //var addRule474 = this.client.AddRule(rule474);
            //Assert.Greater(addRule474.RuleId, 0, "AddRule474 failed!");

            // 计算场景
            var bonus = this.client.CaculateBonus(1, 1, "2014-10");
            Assert.IsNotNull(bonus, "Calculate bonus failed!");
        }
    }
}
