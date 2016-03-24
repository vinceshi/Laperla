using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaPerLa.IMetadataAccess
{
    public interface IMetadataAccessHander : IDistrictInfo, IPositionInfo, IEmployeeInfo, IEmployeeSaleInfo, IShopInfo, IRuleInfo, IUserInfo, IShopSaleInfo, IEmployeeTypeSaleInfo
    {
    }
}
