using System.Collections.Generic;
using System.ServiceModel;
using LaPerLa.BusinessModel;

namespace LaPerLa.Contract
{
    /// <summary>
    /// 职位接口.
    /// </summary>
    [ServiceContract]
    public interface IPosition
    {
        /// <summary>
        /// 添加职位.
        /// </summary>
        /// <param name="info">职位信息.</param>
        /// <returns>职位Id.</returns>
        [OperationContract]
        Position AddPosition(Position info);

        /// <summary>
        /// 根据职位Ids获取职位信息
        /// </summary>
        /// <param name="positionIds">职位Ids</param>
        /// <returns>职位信息集合</returns>
        [OperationContract]
        IList<Position> GetPositionByIds(IList<long> positionIds);
    }
}
