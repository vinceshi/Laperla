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
    public class ShopSaleManager
    {
        private readonly IMetadataAccessHander _metadataAccessHander;
        private static readonly ILog Log = LogManager.GetLogger(typeof(ShopSaleManager));

        public ShopSaleManager()
        {
            if (this._metadataAccessHander == null)
            {
                this._metadataAccessHander = new MetadataRepository();
            }
        }

        /// <summary>
        /// 添加店铺销售额
        /// </summary>
        /// <param name="info">店铺销售额</param>
        /// <returns>新增店铺销售额</returns>
        public ShopSale AddShopSale(ShopSale info)
        {
            try
            {
                var shopSaleInfo = ModelConverter.ConvertShopSaleFromBusiness(info);
                var newShopSaleInfo = this._metadataAccessHander.AddShopSaleInfo(shopSaleInfo);

                return ModelConverter.ConvertShopSaleToBusiness(newShopSaleInfo);
            }
            catch (Exception ex)
            {
                Log.Error("ShopSaleManager-AddShopSale:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 获取当月店铺销售额
        /// </summary>
        /// <param name="shopIds">店铺Id集合</param>
        /// <param name="month">生效月份</param>
        /// <returns>店铺销售额字典</returns>
        public IDictionary<long, IList<ShopSale>> GetCurrentMonthShopSale(IList<long> shopIds, string month)
        {
            try
            {
                var lRet = new Dictionary<long, IList<ShopSale>>();

                foreach (var shopId in shopIds)
                {
                    lRet.Add(shopId, new List<ShopSale>());
                    var infos = this._metadataAccessHander.GetCurrentMonthShopSaleInfo(shopId, month).ToList();

                    if (infos != null)
                    {
                        foreach (var shopSaleInfo in infos.OrderBy(p=>p.Week))
                        {
                            lRet[shopId].Add(ModelConverter.ConvertShopSaleToBusiness(shopSaleInfo));
                        }
                    }
                }

                return lRet;
            }
            catch (Exception ex)
            {
                Log.Error("ShopSaleManager-GetCurrentMonthShopSale:" + ex.Message + "\r\n" + ex.StackTrace);
                return null;
            }
        }
    }
}
