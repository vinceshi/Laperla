using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LaPerLa.Model;

namespace LaPerLa.IMetadataAccess
{
    public interface IPositionInfo
    {
        /// <summary>
        /// 添加职位.
        /// </summary>
        /// <param name="info">职位信息.</param>
        /// <returns>职位Id.</returns>
        PositionInfo AddPositionInfo(PositionInfo info);

        /// <summary>
        /// 根据职位Id获取职位信息
        /// </summary>
        /// <param name="positionId">职位Id</param>
        /// <returns>该职位信息</returns>
        PositionInfo GetPositionInfoById(long positionId);

        /// <summary>
        /// 根据职位Ids获取职位信息
        /// </summary>
        /// <param name="positionIds">职位Ids</param>
        /// <returns>该职位信息</returns>
        IList<PositionInfo> GetPositionInfoByIds(IList<long> positionIds);
    }
}
