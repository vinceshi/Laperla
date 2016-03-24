using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using LaPerLa.BusinessModel;

namespace LaPerLa.Contract
{
    /// <summary>
    /// 用户接口.
    /// </summary>
    [ServiceContract]
    public interface IUser
    {
        /// <summary>
        /// 登录.
        /// </summary>
        /// <param name="info">用户信息.</param>
        /// <returns>session id.</returns>
        [OperationContract]
        string Login(User info);

        /// <summary>
        /// 登出.
        /// </summary>
        /// <param name="userId">用户Id.</param>
        [OperationContract]
        void Logout(Int64 userId);
    }
}
