using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaPerLa.BusinessModel;
using LaPerLa.IMetadataAccess;
using LaPerLa.DataAccess.EF;
using LaPerLa.Utility;
using log4net;

namespace LaPerLa.Manager
{
    public class DistrictManager
    {
        private readonly IMetadataAccessHander _metadataAccessHander;
        private static readonly ILog Log = LogManager.GetLogger(typeof(DistrictManager));

        public DistrictManager()
        {
            if (this._metadataAccessHander == null)
            {
                this._metadataAccessHander = new MetadataRepository();
            }
        }

        /// <summary>
        /// 添加地区.
        /// </summary>
        /// <param name="info">地区信息.</param>
        /// <returns>新增的地区信息.</returns>
        public District AddDisctrict(District info)
        {
            try
            {
                var districtInfo = ModelConverter.ConvertDistrictFromBusiness(info);
                var newDistrictInfo = this._metadataAccessHander.AddDistrictInfo(districtInfo);

                return ModelConverter.ConvertDistrictToBusiness(newDistrictInfo);
            }
            catch (Exception ex)
            {
                Log.Error("DistrictManager-AddDisctrict:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 查询所有地区.
        /// </summary>
        /// <returns>所有地区信息.</returns>
        public IList<District> QueryAllDistricts()
        {
            try
            {
                var lRet = new List<District>();
                var infos = this._metadataAccessHander.QueryAllDistrictInfos();

                if (infos != null)
                {
                    lRet.AddRange(infos.Select(ModelConverter.ConvertDistrictToBusiness));
                }

                return lRet;
            }
            catch (Exception ex)
            {
                Log.Error("DistrictManager-QueryAllDistricts:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 根据Id获取地区信息
        /// </summary>
        /// <param name="districtId">地区Id</param>
        /// <returns>地区信息</returns>
        public District GetDistrictById(long districtId)
        {
            try
            {
                var info = this._metadataAccessHander.GetDistrictInfoById(districtId);

                return ModelConverter.ConvertDistrictToBusiness(info);
            }
            catch (Exception ex)
            {
                Log.Error("DistrictManager-GetDistrictById:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }
    }
}
