using LaPerLa.Web.LaPerLaService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaPerLa.Web.Services
{
    public class RuleServices
    {
        private static readonly ServiceClient client = new ServiceClient();

        public static List<Rule> GetRulesByShopId(long shopId)
        {
            return client.GetRulesByShopId(shopId);
        }
    }
}