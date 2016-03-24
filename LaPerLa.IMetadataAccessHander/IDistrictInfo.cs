using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaPerLa.Model;

namespace LaPerLa.IMetadataAccess
{
    /// <summary>
    /// 地区表接口.
    /// </summary>
    public interface IDistrictInfo
    {
        /// <summary>
        /// 添加地区.
        /// </summary>
        /// <param name="info">地区信息.</param>
        /// <returns>新增的地区信息.</returns>
        DistrictInfo AddDistrictInfo(DistrictInfo info);

        /// <summary>
        /// 查询所有地区.
        /// </summary>
        /// <returns>所有地区信息.</returns>
        IList<DistrictInfo> QueryAllDistrictInfos();

        /// <summary>
        /// 根据Id获取地区信息
        /// </summary>
        /// <param name="districtId">地区Id</param>
        /// <returns>地区信息</returns>
        DistrictInfo GetDistrictInfoById(long districtId);
    }
}
