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
    public partial class Pay : System.Web.UI.Page
    {

        private int orderId = 0;

       
        protected void Page_Load(object sender, EventArgs e)
        {
            orderId = Utils.StrToInt(Requests.Query("orderid"));
            if (!IsPostBack)
            {
                string action = Requests.Query("action");
                if (action == "pay")
                {
                    PlaceHolder1.Visible = true;
                }
                else if (action == "payed")
                {
                    PlaceHolder2.Visible = true;
                }
                else { }

                Shopping.Model.Order orderInfo = OrderBLL.GetOrderInfo(orderId);
                if (orderInfo != null)
                {
                    if (orderInfo.Status == (int)OrderEnum.WaitSend)
                    {
                        PlaceHolder2.Visible = true;
                        PlaceHolder1.Visible = false;
                    }

                    txtOrderNo.Text = string.Format("<a href='Member/OrderDetail.aspx?orderid={0}'>{1}</a>", orderInfo.OrderID, orderInfo.OrderNo);
                }
                else
                {
                    WebUtility.Alert("系统错误", "Index.aspx");
                }
            }

        }

      
        protected void subitBtn_Click(object sender, EventArgs e)
        {
            string code = txtCode.Value.Trim();
            if (Utils.GetSession("CheckCode").ToString() != code)
            {
                WebUtility.Alert("验证码错误啦!");
            }
            else
            {
                if (OrderUtils.CheckStock(orderId))
                {
                    if (OrderBLL.UpdateOrderStatus(orderId, (int)OrderEnum.WaitSend))
                    {
                        OrderUtils.UpdateStockByOrderID(orderId);

                        WebUtility.Alert("付款成功!", "Pay.aspx?action=payed&orderid=" + orderId);
                    }
                    else
                    {
                        WebUtility.Alert("付款失败,详情请联系管理员!");
                    }
                }
                else
                {
                    WebUtility.Alert("订单存在无库存商品,无法进行付款操作!");
                }
            }
        }
    }
}