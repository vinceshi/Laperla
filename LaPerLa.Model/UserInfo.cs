using System;
using System.ComponentModel.DataAnnotations;

namespace LaPerLa.Model
{
    /// <summary>
    /// 用户数据库对象.
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 自增主键.
        /// </summary>
        [Key]
        public virtual Int64 UserId { get; set; }

        /// <summary>
        /// 用户名.
        /// </summary>
        public virtual string UserName { get; set; }

        /// <summary>
        /// 密码.
        /// </summary>
        public virtual string Password { get; set; }

        /// <summary>
        /// 最后一次登入时间.
        /// </summary>
        public virtual DateTime LastLoginTime { get; set; }
    }
}
