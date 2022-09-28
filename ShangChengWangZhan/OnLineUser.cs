using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Shopping.Common;
using Shopping.Data;

namespace Shopping
{
    public class OnLineUser
    {
      
        private static Model.OnLineUserInfo GetOnlineUserInfoFromCookie()
        {
            int userId = -1;
            string guestId = "";
            string userName = "";
            string password = "";
            int point = 0;
            Model.OnLineUserInfo onLineUserInfo = new Model.OnLineUserInfo();

            HttpCookie cookie = Cookie.Get("user");

            if (cookie != null)
            {
                userId = Utils.StrToInt(cookie.Values["UserID"]);
                userName = Utils.UrlDecode(cookie.Values["UserName"]);
                password = Utils.UrlDecode(cookie.Values["Password"]);
                guestId = Utils.UrlDecode(cookie.Values["GuestID"]);
                point = Utils.StrToInt(cookie.Values["Point"]);

                if (userId <= 0)
                {
                    userId = -1;
                }

                if (userName == "" || password == "")
                {
                    userId = -1;
                }
            }

            onLineUserInfo.UserID = userId;
            onLineUserInfo.UserName = userName;
            onLineUserInfo.GuestID = guestId;
            onLineUserInfo.Password = password;
            onLineUserInfo.Point = point;

            return onLineUserInfo;
        }

        /// <summary>
        /// 获取用户实体
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private static Model.OnLineUserInfo GetOnLineUserInfo(SqlDataReader dr)
        {
            Model.OnLineUserInfo onlineUserInfo = new Model.OnLineUserInfo();
            onlineUserInfo.UserID = Utils.StrToInt(dr["UserID"].ToString());
            onlineUserInfo.UserName = dr["UserName"].ToString();
            onlineUserInfo.Password = dr["Password"].ToString();
            onlineUserInfo.Point = Utils.StrToInt(dr["Point"].ToString());
            return onlineUserInfo;
        }

        /// <summary>
        /// 根据用户ID和密码获取用户实体
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private static Model.OnLineUserInfo GetOnLineUserInfo(int userID, string password)
        {
            Model.OnLineUserInfo onlineUserInfo = new Model.OnLineUserInfo();
            string strSql = string.Format("SELECT Top 1 * FROM Shopping_User WHere UserID={0} AND Password='{1}'", userID, password);

            SqlDataReader dr = SqlHelper.ExecuteReader(strSql);

            if (dr.Read())
            {
                onlineUserInfo = GetOnLineUserInfo(dr);
            }

            dr.Close();
            dr.Dispose();

            return onlineUserInfo;
        }
        /// <summary>
        /// 取得在线用户信息
        /// </summary>
        /// <returns></returns>
        public static Model.OnLineUserInfo GetOnLineUserInfo()
        {
            Model.OnLineUserInfo onlineuser = GetOnlineUserInfoFromCookie();

            //cookie里的userid大于0，并且需要通过数据库判断
            if (onlineuser.UserID != -1)
            {
                onlineuser = GetOnLineUserInfo(onlineuser.UserID, onlineuser.Password);

                if (onlineuser == null)
                {
                    onlineuser.UserID = -1;
                }
            }

            if (onlineuser.UserID == -1)
            {
                RemoveOnlineUserInfo();
                onlineuser.UserID = -1;
                onlineuser.UserName = "";
                onlineuser.Password = "";
                onlineuser.Point = 0;
            }

            if (string.IsNullOrEmpty(onlineuser.GuestID))
            {
                string guestid = Cookie.GetCookieValue("GuestID");
                if (!string.IsNullOrEmpty(guestid))
                {
                    onlineuser.GuestID = guestid;
                }
                else
                {
                    guestid = Utils.MD5_32(Utils.GetRandomString(Utils.GetRandomSeed(), 10, "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"));
                    onlineuser.GuestID = guestid;
                    Cookie.SetCookieValue("GuestID", onlineuser.GuestID, DateTime.Now.AddYears(10));
                }
            }

            return onlineuser;
        }
         /// <summary>
        /// 取得在线用户信息
        /// </summary>
        /// <param name="isCheck"></param>
        /// <returns></returns>
        public static Model.OnLineUserInfo GetOnLineUserInfo(bool isCheck)
        {
            Model.OnLineUserInfo onlineUserInfo = GetOnLineUserInfo();
            if (isCheck)
            {
                if (onlineUserInfo.UserID == -1)
                {
                    onlineUserInfo = null;
                    RemoveOnlineUserInfo();
                }
                
            }

            return onlineUserInfo;
        }

        /// <summary>
        /// 删除Cookie信息
        /// </summary>
        public static void RemoveOnlineUserInfo()
        {
            HttpCookie cookie = Cookie.Get("user");
            if (cookie != null)
            {
                Cookie.Remove(cookie);
            }
        }


    }
}
