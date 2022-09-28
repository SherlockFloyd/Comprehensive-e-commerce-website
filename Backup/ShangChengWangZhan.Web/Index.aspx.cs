using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Shopping.BLL;

namespace Shopping.Web
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                noticeRepeater.DataSource = NewsBLL.GetNoticeList(7, 1, "", "CreateTime", "DESC");
                //noticeRepeater.DataBind();
                noticeRepeater.DataBind();

                newRepeater.DataSource = CommodityBLL.GetCommodityList(10, " OnSale=2 ", "CreateTime", "DESC");
                newRepeater.DataBind();
            }
        }
    }
}