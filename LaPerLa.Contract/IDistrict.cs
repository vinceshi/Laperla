using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaPerLa.BusinessModel;
using System.ServiceModel;

namespace LaPerLa.Contract
{
    /// <summary>
    /// 地区接口.
    /// </summary>
    [ServiceContract]
    public interface IDistrict
    {
        /// <summary>
        /// 添加地区.
        /// </summary>
        /// <param name="info">地区信息.</param>
        /// <returns>新增的地区信息.</returns>
        [OperationContract]
        District AddDisctrict(District info);

        /// <summary>
        /// 查询所有地区.
        /// </summary>
        /// <returns>所有地区信息.</returns>
        [OperationContract]
        IList<District> QueryAllDistricts();

        /// <summary>
        /// 根据Id获取地区信息
        /// </summary>
        /// <param name="districtId">地区Id</param>
        /// <returns>地区信息</returns>
        [OperationContract]
        District GetDistrictById(long districtId);
    }
}
