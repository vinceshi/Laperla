using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaPerLa.IMetadataAccess;
using log4net;
using LaPerLa.DataAccess.EF;
using LaPerLa.Utility;
using LaPerLa.BusinessModel;

namespace LaPerLa.Manager
{
    public class EmployeeTypeSaleManager
    {
        private readonly IMetadataAccessHander _metadataAccessHander;
        private static readonly ILog Log = LogManager.GetLogger(typeof(EmployeeTypeSaleManager));

        public EmployeeTypeSaleManager()
        {
            if (this._metadataAccessHander == null)
            {
                this._metadataAccessHander = new MetadataRepository();
            }
        }
        /// <summary>
        /// 添加员工类型销售额信息
        /// </summary>
        /// <param name="info">员工类型销售额信息</param>
        /// <returns>新增的员工类型销售额信息</returns>
        public EmployeeTypeSale AddEmployeeTypeSale(EmployeeTypeSale info)
        {
            try
            {
                var employeeTypeSaleInfo = ModelConverter.ConvertEmployeeTypeSaleFromBusiness(info);
                var newEmployeeTypeSaleInfo = this._metadataAccessHander.AddEmployeeTypeSaleInfo(employeeTypeSaleInfo);

                return ModelConverter.ConvertEmployeeTypeSaleToBusiness(newEmployeeTypeSaleInfo);
            }
            catch (Exception ex)
            {
                Log.Error("EmployeeTypeSaleManager-AddEmployeeTypeSale:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }
    }
}
