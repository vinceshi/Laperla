using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LaPerLa.BusinessModel;
using LaPerLa.DataAccess.EF;
using LaPerLa.IMetadataAccess;
using LaPerLa.Utility;
using log4net;

namespace LaPerLa.Manager
{
    public class PositionManager
    {
        private readonly IMetadataAccessHander _metadataAccessHander;
        private static readonly ILog Log = LogManager.GetLogger(typeof(PositionManager));

        public PositionManager()
        {
            if (this._metadataAccessHander == null)
            {
                this._metadataAccessHander = new MetadataRepository();
            }
        }

        /// <summary>
        /// 添加职位.
        /// </summary>
        /// <param name="info">职位信息.</param>
        /// <returns>职位Id.</returns>
        public Position AddPosition(Position info)
        {
            try
            {
                var positionInfo = ModelConverter.ConvertPositionFromBusiness(info);
                var newPositionInfo = this._metadataAccessHander.AddPositionInfo(positionInfo);
                return ModelConverter.ConvertPositionToBusiness(newPositionInfo);
            }
            catch (Exception ex)
            {
                Log.Error("PositionManager-AddPosition:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 根据职位Ids获取职位信息
        /// </summary>
        /// <param name="positionIds">职位Ids</param>
        /// <returns>职位信息集合</returns>
        public IList<Position> GetPositionByIds(IList<long> positionIds)
        {
            try
            {
                var lRet = new List<Position>();
                var positionList = this._metadataAccessHander.GetPositionInfoByIds(positionIds);
                foreach (var info in positionList)
                { 
                    if (info != null)
                    {
                        lRet.Add(ModelConverter.ConvertPositionToBusiness(info));
                    }
                }
                return lRet;
            }
            catch (Exception ex)
            {
                Log.Error("PositionManager-GetPositionByIds:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }
    }
}
