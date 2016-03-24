using LaPerLa.Web.LaPerLaService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaPerLa.Web.Models
{
    public class StatisticsModel
    {
        public District District { get; set; }

        public Shop Shop { get; set; }

        public Dictionary<long, List<ShopSale>> ShopDict { get; set; }

        public List<Shop> ShopList { get; set; }

        public List<Employee> EmployeeList { get; set; }

        public List<Position> PositionList { get; set; }

        public Bonus Bonus { get; set; }

        public List<EmployeeSale> EmployeeSaleList { get; set; }

        public List<Rule> RuleList { get; set; }
    }
}