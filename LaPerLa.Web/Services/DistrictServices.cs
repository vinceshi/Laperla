using LaPerLa.Web.LaPerLaService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaPerLa.Web.Services
{
    /// <summary>
    /// 地区服务
    /// </summary>
    public class DistrictServices
    {
        private static readonly ServiceClient client = new ServiceClient();

        /// <summary>
        /// 获取所有地区信息
        /// </summary>
        /// <returns></returns>
        public static List<District> GetDistricts()
        {
            return client.QueryAllDistricts();
        }

        /// <summary>
        /// 根据地区id来获取地区
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        public static District GetDistrictById(long districtId)
        {
            return client.GetDistrictById(districtId);
        }
        
        /// <summary>
        /// 添加地区
        /// </summary>
        /// <param name="district"></param>
        /// <returns></returns>
        public static bool AddDistrict(District district)
        {
            var newDistrict = client.AddDisctrict(district);
            if (newDistrict.DistrictId > 0)
            {
                return true;
            }
            return false;
        }
    }
}