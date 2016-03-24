using System;
using LaPerLa.Model;

namespace LaPerLa.IMetadataAccess
{
    public interface IUserInfo
    {
        /// <summary>
        /// 登录.
        /// </summary>
        /// <param name="info">用户信息.</param>
        /// <returns>session id.</returns>
        Int64 Login(UserInfo info);

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="info"></param>
        void Add(UserInfo info);

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="id">用户Id.</param>
        /// <returns>用户信息.</returns>
        UserInfo Get(int id);
    }
}
