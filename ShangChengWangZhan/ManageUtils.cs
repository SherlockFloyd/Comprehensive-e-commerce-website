using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Shopping.Common;

namespace Shopping
{
    public class ManageUtils
    {
       
        public static void SaveAdminCookie(string name, string password)
        {
            HttpCookie cookie = Cookie.Get("admin");
            if (cookie == null)
            {
                cookie = new HttpCookie("admin");
            }
            cookie.Values["name"] = name;
            cookie.Values["key"] = password;
            Cookie.Save(cookie);
        }

        /// <summary>
        /// 删除Cookie信息
        /// </summary>
        public static void RemoveCookie()
        {
            HttpCookie cookie = Cookie.Get("admin");
            Cookie.Remove(cookie);
        }
    }
}
