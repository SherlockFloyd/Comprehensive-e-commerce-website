using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using Shopping.Common;
using Shopping.Model;
using Shopping.BLL;

namespace Shopping.Web.Ajax
{
    public partial class Ajax_GetRateList : System.Web.UI.Page
    {
        /// <summary>
        /// 载入输入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ////this.Response.Expires = 0;//清除缓存
            ////int CommodityId = Utils.StrToInt(Requests.All("Commodityid"));
            ////Response.Write(GetRate(CommodityId));
            ////Response.End();
        }
        
    }
}