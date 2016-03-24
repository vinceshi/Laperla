using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace LaPerLa.Contract
{
    [ServiceContract]
    public interface IService : IDistrict, IPosition, IEmployee, IEmployeeSale, IShop, IUser, IRule, IShopSale
    {
    }
}
