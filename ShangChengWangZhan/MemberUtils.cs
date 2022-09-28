using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Shopping.Common;

using Shopping.Model;


namespace Shopping
{


    public class MemberUtils
    {
       
      
        public static void SaveUserCookie(Model.User userInfo)
        {
            HttpCookie cookie = Cookie.Get("user");
            if (cookie == null)
            {
                cookie = new HttpCookie("user");
            }
            cookie.Values["UserID"] = userInfo.UserID.ToString();
            cookie.Values["UserName"] = userInfo.UserName;
            cookie.Values["Password"] = userInfo.Password;
            Cookie.Save(cookie);
        }
        /// <summary>
        /// 删除用户Cookie信息
        /// </summary>
        public static void RemoveUserCookie()
        {
            HttpCookie cookie = Cookie.Get("user");
            Cookie.Remove(cookie);
        }
        
 
    }
}
