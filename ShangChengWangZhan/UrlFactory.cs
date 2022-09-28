using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Shopping.Model;
using Shopping.Common;

namespace Shopping
{
    public class UrlFactory
    {

        public static string GetCommodityDetailAspxRewrite(ListPageUrlInfo listPageUrlInfo, int page)
        {
            string url = "list.aspx?";
            string param = "";
            if (listPageUrlInfo.CateID > 0)
            {
                if (param != "")
                    param += "&";
                param += "cateid=" + listPageUrlInfo.CateID;
            }
         
            if (listPageUrlInfo.KeyWord != "")
            {
                if (param != "")
                    param += "&";
                param += "k=" + listPageUrlInfo.KeyWord;
            }
            if (listPageUrlInfo.IsHot == 1)
            {
                if (param != "")
                    param += "&";
                param += "h=1";
            }
            //if (param != "")
            //    param += "&";
            //param += "h=1";

            if (listPageUrlInfo.IsNew == 1)
            {
                if (param != "")
                    param += "&";
                param += "n=1";
            }

            if (listPageUrlInfo.OrderType > 0)
            {
                if (param != "")
                    param += "&";
                param += "o="+(int)listPageUrlInfo.OrderType;
            }
            return url + param;
        }
    }
}
