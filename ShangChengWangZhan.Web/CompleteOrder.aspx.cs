using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Shopping.Common;
using Shopping.BLL;

namespace Shopping.Web
{
    public partial class CompleteOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int orderId = Utils.StrToInt(Requests.Query("orderid"));
            if (!IsPostBack)
            {

                Shopping.Model.Order orderInfo = OrderBLL.GetOrderInfo(orderId);
                if (orderInfo != null)
                {
                    txtOrderNo.Text = orderInfo.OrderNo;
                    payLiteral.Text = string.Format("<a class=\"pay\" href=\"Pay.aspx?action=pay&orderid={0}\">付款</a>", orderInfo.OrderID);
                }
            }
        }
    }
}