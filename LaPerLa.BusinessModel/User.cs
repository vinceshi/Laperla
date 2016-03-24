using System;
using System.Runtime.Serialization;

namespace LaPerLa.BusinessModel
{
    /// <summary>
    /// 用户业务对象.
    /// </summary>
    [DataContract]
    public class User
    {
        /// <summary>
        /// 自增主键.
        /// </summary>
        [DataMember]
        public Int64 UserId { get; set; }

        /// <summary>
        /// 用户名.
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// 密码.
        /// </summary>
        [DataMember]
        public string Password { get; set; }

        /// <summary>
        /// 最后一次登入时间.
        /// </summary>
        [DataMember]
        public DateTime LastLoginTime { get; set; }
    }
}
