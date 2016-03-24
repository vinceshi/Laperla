using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LaPerLa.BusinessModel;

namespace LaPerLa.Manager
{
    public static class SessionManager
    {
        private static Dictionary<Int64, string>  UserSessions = new Dictionary<long, string>();

        /// <summary>
        /// 添加用户Session.
        /// </summary>
        /// <param name="userId">用户Id.</param>
        /// <returns>session id.</returns>
        public static string AddOrUpdateSession(Int64 userId)
        {
            if (UserSessions.ContainsKey(userId))
            {
                return UserSessions[userId];
            }

            string sessionId = Guid.NewGuid().ToString("N");
            UserSessions.Add(userId, sessionId);

            return sessionId;
        }

        /// <summary>
        /// 移除用户session.
        /// </summary>
        /// <param name="userId">用户Id.</param>
        public static void RemoveSession(Int64 userId)
        {
            if (UserSessions.ContainsKey(userId))
            {
                UserSessions.Remove(userId);
            }
        }
    }
}
