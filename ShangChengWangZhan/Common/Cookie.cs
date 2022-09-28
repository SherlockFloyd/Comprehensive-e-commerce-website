using System;
using System.Web;

namespace Shopping.Common
{
    public class Cookie
    {
        private Cookie()
        {
        }
        /// <summary>
        
        /// </summary>
        public static HttpCookie Get(string name)
        {
            return HttpContext.Current.Request.Cookies[name];
        }

        /// <summary>
        /// 移除Cookies
        /// </summary>
        public static void Remove(string name)
        {
            Remove(Get(name));
        }

        /// <summary>
        /// 移除Cookies
        /// </summary>
        public static void Remove(HttpCookie cookie)
        {
            if (cookie != null)
            {
                cookie.Expires = new DateTime(1982, 6, 11);
                Save(cookie);
            }
        }
        /// <summary>
        /// 保存Cookies
        /// </summary>
        public static void Save(HttpCookie cookie)
        {
            Save(cookie, string.Empty);
        }
        /// <summary>
        /// 保存Cookies
        /// </summary>
        public static void Save(HttpCookie cookie, string domain)
        {
            if (!string.IsNullOrEmpty(domain))
            {
                cookie.Domain = domain;
            }
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 获取一个新的Cookies
        /// </summary>
        public static HttpCookie GetNewCookie(string name)
        {
            return new HttpCookie(name);
        }

        /// <summary>
        /// 取得指定名称的单值Cookie
        /// </summary>
        /// <returns></returns>
        public static string GetCookieValue(string name)
        {
            HttpCookie cookie = Get(name);
            if (cookie == null || cookie.Value == null)
            {
                return string.Empty;

            }
            else
            {
                return Utils.UrlDecode(cookie.Value);
            }
        }

        /// <summary>
        /// 保存指定名称的单值Cookie
        /// </summary>
        /// <returns></returns>
        public static void SetCookieValue(string name, string value)
        {
            HttpCookie cookie = Get(name);
            if (cookie == null)
            {
                cookie = GetNewCookie(name);
            }
            cookie.Value = Utils.UrlEncode(value);
            Save(cookie);
        }

        /// <summary>
        /// 保存指定名称的单值Cookie
        /// </summary>
        /// <returns></returns>
        public static void SetCookieValue(string name, string value, DateTime expires)
        {
            HttpCookie cookie = Get(name);
            if (cookie == null)
            {
                cookie = GetNewCookie(name);
            }
            cookie.Value = value;
            cookie.Expires = expires;
            Save(cookie);
        }
    }
}
