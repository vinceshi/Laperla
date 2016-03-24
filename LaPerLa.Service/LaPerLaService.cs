using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaPerLa.Contract;
using LaPerLa.BusinessModel;
using LaPerLa.Manager;

namespace LaPerLa.Service
{
    public class LaPerLaService
    {
        private DistrictManager districtManager = null;

        public LaPerLaService()
        {
            if (this.districtManager == null)
            {
                this.districtManager = new DistrictManager();
            }
        }

        /// <summary>
        /// 添加地区.
        /// </summary>
        /// <param name="info">地区信息.</param>
        /// <returns>新增的地区信息.</returns>
        public District AddDisctrict(District info)
        {
            return this.districtManager.AddDisctrict(info);
        }

        /// <summary>
        /// 添加职位.
        /// </summary>
        /// <param name="info">职位信息.</param>
        /// <returns>职位Id.</returns>
        public Position AddPosition(Position info)
        {
            throw new NotImplementedException();
        }
    }
}
