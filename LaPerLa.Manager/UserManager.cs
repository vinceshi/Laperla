using System;
using LaPerLa.BusinessModel;
using LaPerLa.DataAccess.EF;
using LaPerLa.IMetadataAccess;
using LaPerLa.Utility;
using log4net;
using System.Security.Cryptography;
using System.Text;

namespace LaPerLa.Manager
{
    public class UserManager
    {
        private readonly IMetadataAccessHander _metadataAccessHander;
        private static readonly ILog Log = LogManager.GetLogger(typeof(UserManager));

        public UserManager()
        {
            if (this._metadataAccessHander == null)
            {
                this._metadataAccessHander = new MetadataRepository();
            }
        }

        /// <summary>
        /// 登录.
        /// </summary>
        /// <param name="info">用户信息.</param>
        /// <returns>session id.</returns>
        public string Login(User info)
        {
            try
            {
                var userInfo = ModelConverter.ConvertUserFromBusiness(info);
                userInfo.Password = HashString(userInfo.Password);
                var userId = this._metadataAccessHander.Login(userInfo);

                if (userId > 0)
                {
                    return SessionManager.AddOrUpdateSession(userId);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                Log.Error("UserManager-Login:" + ex.Message + "\r\n" + ex.StackTrace);
                return string.Empty;
            }
        }

        /// <summary>
        /// 登出.
        /// </summary>
        /// <param name="userId">用户Id.</param>
        public void Logout(Int64 userId)
        {
            try
            {
                SessionManager.RemoveSession(userId);
            }
            catch (Exception ex)
            {
                Log.Error("UserManager-Logout:" + ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        /// <summary> 
        /// 使用utf8编码将字符串散列 
        /// </summary> 
        /// <param name="sourceString">要散列的字符串</param> 
        /// <returns>散列后的字符串</returns> 
        public static string HashString(string sourceString)
        {
            return HashString(Encoding.UTF8, sourceString);
        }

        /// <summary> 
        /// 使用指定的编码将字符串散列 
        /// </summary> 
        /// <param name="encode">编码</param> 
        /// <param name="sourceString">要散列的字符串</param> 
        /// <returns>散列后的字符串</returns> 
        public static string HashString(Encoding encode, string sourceString)
        {
            var md5 = MD5.Create();
            byte[] source = md5.ComputeHash(encode.GetBytes(sourceString));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < source.Length; i++)
            {
                sBuilder.Append(source[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
