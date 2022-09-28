using System;
using System.Web;
using System.Text.RegularExpressions;
using System.Data;
using System.Text;

namespace Shopping.Common
{
  
    /// </summary>
    public class Requests
    {

        /// <summary>
        /// 判断当前页面是否接收到了Post请求
        /// </summary>
        /// <returns>是否接收到了Post请求</returns>
        public static bool IsPost()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("POST");
        }
        /// <summary>
        /// 判断当前页面是否接收到了Get请求
        /// </summary>
        /// <returns>是否接收到了Get请求</returns>
        public static bool IsGet()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("GET");
        }

        /// <summary>
        /// 获取当前请求的原始 URL(URL 中域信息之后的部分,包括查询字符串(如果存在))
        /// </summary>
        /// <returns>原始 URL</returns>
        public static string GetRawUrl()
        {
            return HttpContext.Current.Request.RawUrl;
        }

        /// <summary>
        /// 取得上一页地址
        /// </summary>
        /// <returns></returns>
        public static string GetPrevUrl()
        {
            string retVal = null;

            try
            {
                retVal = HttpContext.Current.Request.UrlReferrer.ToString();
            }
            catch { }

            if (retVal == null)
                return "";

            return retVal;
        }

        /// <summary>
        /// 得到主机头
        /// </summary>
        /// <returns></returns>
        public static string GetHost()
        {
            return HttpContext.Current.Request.Url.Host;
        }

        /// <summary>
        /// 获得当前页面客户端的IP
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            string result = "0.0.0.0";

            try
            {
                result = HttpContext.Current.Request.Headers["Cdn-Src-Ip"];
                if (null == result || result == String.Empty)
                {
                    result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                }

                if (null == result || result == String.Empty)
                {
                    result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }

                if (null == result || result == String.Empty)
                {
                    result = HttpContext.Current.Request.UserHostAddress;
                }

                if (null == result || result == String.Empty || !Utils.IsIP(result))
                {
                    return "0.0.0.0";
                }
            }
            catch
            { }

            return result;
        }


        /// <summary>
        /// 获得指定Url参数值
        /// </summary>
        /// <param name="name">Url参数名</param>
        /// <returns></returns>
        public static string Query(string name)
        {
            string value = HttpContext.Current.Request.QueryString[name];
            return value == null ? string.Empty : value;
        }

        /// <summary>
        /// 获得指定表单名参数值
        /// </summary>
        /// <param name="name">表单参数名</param>
        /// <returns></returns>
        public static string Form(string name)
        {
            string value = HttpContext.Current.Request.Form[name];
            return value == null ? string.Empty : value;

        }

        /// <summary>
        /// 获得指定参数名参数值
        /// </summary>
        /// <param name="str">参数名</param>
        /// <returns></returns>
        public static string All(string str)
        {
            string requestValue = Form(str);
            if (requestValue != string.Empty)
            {
                return requestValue;
            }
            else
            {
                requestValue = Query(str);
                if (requestValue != string.Empty)
                {
                    return requestValue;
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// 获得当前页面的名称
        /// </summary>
        /// <returns>当前页面的名称</returns>
        public static string GetPageName()
        {
            string[] urlArr = HttpContext.Current.Request.Url.AbsolutePath.Split('/');
            return urlArr[urlArr.Length - 1].ToLower();
        }

        /// <summary>
        /// 判断当前访问是否来自浏览器软件
        /// </summary>
        /// <returns>当前访问是否来自浏览器软件</returns>
        public static bool IsBrowserGet()
        {
            string[] BrowserName = { "ie", "opera", "netscape", "mozilla" };
            string curBrowser = HttpContext.Current.Request.Browser.Type.ToLower();
            for (int i = 0; i < BrowserName.Length; i++)
            {
                if (curBrowser.IndexOf(BrowserName[i]) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断是否来自搜索引擎链接
        /// </summary>
        /// <returns>是否来自搜索引擎链接</returns>
        public static string GetSearchEngine(string refUrl, DataTable dt)
        {
            System.Collections.ArrayList al = new System.Collections.ArrayList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                al.Add(dt.Rows[i]["Name"].ToString());
            }
            dt.Dispose();

            for (int i = 0; i < al.Count; i++)
            {
                if (refUrl.IndexOf(al[i].ToString()) >= 0)
                {
                    return al[i].ToString();
                }
            }
            return "";
        }

        /// <summary>
        /// 获取来自搜索引擎搜索的关键字
        /// <param name="refUrl">来源页</param>
        /// <param name="dt">搜索引擎正则表</param>
        /// </summary>
        public static string GetSearchKeyword(string refUrl, DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            string se = GetSearchEngine(refUrl, dt);

            if (se == "") return "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ht.Add(dt.Rows[i]["Name"], dt.Rows[i]["Encoding"]);
                if (sb.Length == 0)
                {
                    sb.Append(dt.Rows[i]["RegularExpressions"].ToString());
                }
                else
                {
                    sb.Append("|" + dt.Rows[i]["RegularExpressions"].ToString());
                }

            }
            dt.Dispose();

            string encoding = ht[se].ToString();

            MatchCollection matches = System.Text.RegularExpressions.Regex.Matches(refUrl, sb.ToString(), RegexOptions.IgnoreCase);
            if (matches.Count > 0)
            {
                for (int i = 1; i < matches[0].Groups.Count; i++)
                {
                    if (matches[0].Groups[i].Value != "")
                    {
                        return HttpUtility.UrlDecode(matches[0].Groups[i].Value, System.Text.Encoding.GetEncoding(encoding));
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// 返回当前页面是否是跨站提交
        /// </summary>
        /// <returns>当前页面是否是跨站提交</returns>
        public static bool IsCrossSitePost()
        {

            // 如果不是提交则为true
            if (Requests.IsPost())
            {
                return true;
            }
            return IsCrossSitePost(Requests.GetPrevUrl(), Requests.GetHost());
        }

        /// <summary>
        /// 是否跨站提交
        /// </summary>
        /// <param name="urlReferrer"></param>
        /// <param name="host"></param>
        /// <returns></returns>
        public static bool IsCrossSitePost(string urlReferrer, string host)
        {
            if (urlReferrer.Length < 7)
            {
                return true;
            }
            // 移除http://
            string tmpReferrer = urlReferrer.Remove(0, 7);
            if (tmpReferrer.IndexOf(":") > -1)
                tmpReferrer = tmpReferrer.Substring(0, tmpReferrer.IndexOf(":"));
            else
                tmpReferrer = tmpReferrer.Substring(0, tmpReferrer.IndexOf('/'));
            return tmpReferrer != host;
        }

    }
}
