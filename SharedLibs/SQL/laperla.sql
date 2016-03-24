-- --------------------------------------------------------
-- 主机:                           tangniemysql.mysql.rds.aliyuncs.com
-- 服务器版本:                        5.5.18 - Source distribution
-- 服务器操作系统:                      Linux
-- HeidiSQL 版本:                  8.3.0.4694
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- 导出 laperla 的数据库结构
DROP DATABASE IF EXISTS `laperla`;
CREATE DATABASE IF NOT EXISTS `laperla` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `laperla`;


-- 导出  表 laperla.districtinfo 结构
DROP TABLE IF EXISTS `districtinfo`;
CREATE TABLE IF NOT EXISTS `districtinfo` (
  `DistrictId` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `Country` varchar(45) NOT NULL COMMENT '国家',
  `State` varchar(45) NOT NULL COMMENT '省',
  `City` varchar(45) NOT NULL COMMENT '城市',
  `DataChange_CreateTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' COMMENT '创建时间',
  `DataChange_LastTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '最后更新时间',
  PRIMARY KEY (`DistrictId`),
  KEY `Index_DataChange_LastTime` (`DataChange_LastTime`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='地区表';

-- 数据导出被取消选择。


-- 导出  表 laperla.employeeinfo 结构
DROP TABLE IF EXISTS `employeeinfo`;
CREATE TABLE IF NOT EXISTS `employeeinfo` (
  `EmployeeId` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `ChineseName` varchar(45) DEFAULT NULL COMMENT '中文名',
  `EnglishName` varchar(45) DEFAULT NULL COMMENT '英文名',
  `PositionId` bigint(20) NOT NULL COMMENT '职位Id',
  `ShopId` bigint(20) NOT NULL DEFAULT '0' COMMENT '店铺Id',
  `DataChange_CreateTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' COMMENT '创建时间',
  `DataChange_LastTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '最后更新时间',
  PRIMARY KEY (`EmployeeId`),
  KEY `Index_DataChange_LastTime` (`DataChange_LastTime`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='员工表';

-- 数据导出被取消选择。


-- 导出  表 laperla.employeesaleinfo 结构
DROP TABLE IF EXISTS `employeesaleinfo`;
CREATE TABLE IF NOT EXISTS `employeesaleinfo` (
  `EmployeeSaleId` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `EmployeeId` bigint(20) NOT NULL DEFAULT '0' COMMENT '员工Id',
  `ShopId` bigint(20) NOT NULL DEFAULT '0' COMMENT '店铺Id',
  `Week` int(11) NOT NULL DEFAULT '0' COMMENT '周序列',
  `TargetSale` double NOT NULL DEFAULT '0' COMMENT '目标周销售额',
  `ActualSale` double NOT NULL DEFAULT '0' COMMENT '实际周销售额',
  `Sale` double NOT NULL DEFAULT '0' COMMENT '销售额',
  `Days` int(11) NOT NULL DEFAULT '0' COMMENT '缺勤天数',
  `Month` varchar(50) NOT NULL DEFAULT '0000-00' COMMENT '生效月份 ',
  `DataChange_CreateTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' COMMENT '创建时间',
  `DataChange_LastTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '最后更新时间',
  PRIMARY KEY (`EmployeeSaleId`),
  KEY `Index_DataChange_LastTime` (`DataChange_LastTime`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='员工销售额表';

-- 数据导出被取消选择。


-- 导出  表 laperla.employeetypesaleinfo 结构
DROP TABLE IF EXISTS `employeetypesaleinfo`;
CREATE TABLE IF NOT EXISTS `employeetypesaleinfo` (
  `EmployeeTypeSaleId` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `EmployeeId` bigint(20) NOT NULL DEFAULT '0' COMMENT '员工Id',
  `ShopId` bigint(20) NOT NULL DEFAULT '0' COMMENT '店铺Id',
  `SaleType` tinyint(4) NOT NULL DEFAULT '0' COMMENT '销售类型',
  `Target` double NOT NULL DEFAULT '0' COMMENT '目标销售额',
  `Actual` double NOT NULL DEFAULT '0' COMMENT '实际销售额',
  `Month` varchar(50) NOT NULL DEFAULT '0000-00' COMMENT '生效月份 ',
  `DataChange_CreateTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' COMMENT '创建时间',
  `DataChange_LastTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '最后更新时间',
  PRIMARY KEY (`EmployeeTypeSaleId`),
  KEY `Index_DataChange_LastTime` (`DataChange_LastTime`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT COMMENT='员工类型销售额表';

-- 数据导出被取消选择。


-- 导出  表 laperla.positioninfo 结构
DROP TABLE IF EXISTS `positioninfo`;
CREATE TABLE IF NOT EXISTS `positioninfo` (
  `PositionId` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `ShopId` bigint(20) NOT NULL DEFAULT '0' COMMENT '店铺Id',
  `DistrictId` bigint(20) NOT NULL DEFAULT '0' COMMENT '地区Id',
  `PositionName` varchar(100) NOT NULL DEFAULT 'Default' COMMENT '职位名',
  `DataChange_CreateTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' COMMENT '创建时间',
  `DataChange_LastTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '最后更新时间',
  PRIMARY KEY (`PositionId`),
  KEY `Index_DataChange_LastTime` (`DataChange_LastTime`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='职位表';

-- 数据导出被取消选择。


-- 导出  表 laperla.ruleinfo 结构
DROP TABLE IF EXISTS `ruleinfo`;
CREATE TABLE IF NOT EXISTS `ruleinfo` (
  `RuleId` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `PositionId` bigint(20) NOT NULL DEFAULT '0' COMMENT '职位Id',
  `ShopId` bigint(20) NOT NULL DEFAULT '0' COMMENT '店铺Id',
  `RuleType` tinyint(4) NOT NULL DEFAULT '0' COMMENT '规则类型',
  `RuleOrder` tinyint(4) NOT NULL DEFAULT '0' COMMENT '计算序列',
  `RuleDescription` varchar(200) DEFAULT NULL COMMENT '规则描述',
  `Bonus` double NOT NULL DEFAULT '0' COMMENT '提成金额',
  `OperationType` tinyint(4) NOT NULL DEFAULT '0' COMMENT '计算操作类型',
  `OperationValue` double NOT NULL DEFAULT '0' COMMENT '比较值',
  `OperationMaxValue` double NOT NULL DEFAULT '0' COMMENT '比较最大值',
  `OperationMinValue` double NOT NULL DEFAULT '0' COMMENT '比较最小值',
  `DataChange_CreateTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' COMMENT '创建时间',
  `DataChange_LastTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '最后更新时间',
  PRIMARY KEY (`RuleId`),
  KEY `Index_DataChange_LastTime` (`DataChange_LastTime`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='提成规则表';

-- 数据导出被取消选择。


-- 导出  表 laperla.shopinfo 结构
DROP TABLE IF EXISTS `shopinfo`;
CREATE TABLE IF NOT EXISTS `shopinfo` (
  `ShopId` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `ShopName` varchar(200) NOT NULL COMMENT '店铺名',
  `ShopType` tinyint(4) NOT NULL DEFAULT '0' COMMENT '店铺类别',
  `DistrictId` bigint(20) NOT NULL DEFAULT '0',
  `DataChange_CreateTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' COMMENT '创建时间',
  `DataChange_LastTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '最后更新时间',
  PRIMARY KEY (`ShopId`),
  KEY `Index_DataChange_LastTime` (`DataChange_LastTime`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='店铺表';

-- 数据导出被取消选择。


-- 导出  表 laperla.shopsaleinfo 结构
DROP TABLE IF EXISTS `shopsaleinfo`;
CREATE TABLE IF NOT EXISTS `shopsaleinfo` (
  `ShopSaleId` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `Target` decimal(10,0) NOT NULL DEFAULT '0' COMMENT '目标销售额',
  `ShopId` bigint(20) NOT NULL DEFAULT '0' COMMENT '店铺Id',
  `ActualSalesWithTax` double NOT NULL DEFAULT '0' COMMENT '实际销售额含税',
  `Tax` double NOT NULL DEFAULT '0' COMMENT '税',
  `ActualSalesWithoutTax` double NOT NULL DEFAULT '0' COMMENT '实际销售额不含税',
  `ShopPool` double NOT NULL DEFAULT '0' COMMENT '店铺集合比',
  `Month` varchar(50) NOT NULL DEFAULT '0000-00' COMMENT '生效月份',
  `DistrictId` bigint(20) NOT NULL DEFAULT '0' COMMENT '地区Id',
  `Week` int(11) NOT NULL COMMENT '周序列',
  `TargetWeekSale` double NOT NULL DEFAULT '0' COMMENT '周目标销售额',
  `ActualWeekSale` double NOT NULL DEFAULT '0' COMMENT '周实际销售额',
  `DataChange_CreateTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' COMMENT '创建时间',
  `DataChange_LastTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '最后更新时间',
  PRIMARY KEY (`ShopSaleId`),
  KEY `Index_DataChange_LastTime` (`DataChange_LastTime`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='店铺销售额表';

-- 数据导出被取消选择。


-- 导出  表 laperla.userinfo 结构
DROP TABLE IF EXISTS `userinfo`;
CREATE TABLE IF NOT EXISTS `userinfo` (
  `UserId` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `UserName` varchar(45) NOT NULL COMMENT '用户账号',
  `Password` varchar(45) NOT NULL COMMENT '密码',
  `LastLoginTime` datetime NOT NULL DEFAULT '0000-00-00 00:00:00' COMMENT '最后一次登入时间',
  `DataChange_CreateTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' COMMENT '创建时间',
  `DataChange_LastTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '最后更新时间',
  PRIMARY KEY (`UserId`),
  KEY `Index_DataChange_LastTime` (`DataChange_LastTime`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户表';

-- 数据导出被取消选择。
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
