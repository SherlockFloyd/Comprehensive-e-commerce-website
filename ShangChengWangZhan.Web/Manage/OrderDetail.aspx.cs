using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Shopping;
using Shopping.Model;
using Shopping.BLL;
using Shopping.Common;

namespace Shopping.Web.Manage
{
    public partial class OrderDetail : ManagePage
    {
        private static Shopping.Model.Order orderInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            int orderID = Utils.StrToInt(Requests.Query("orderid"));

            orderInfo = OrderBLL.GetOrderInfo(orderID);

            if (orderInfo != null)
            {
                username.Text = orderInfo.UserName;
                orderno.Text = orderInfo.OrderNo;
                orderprice.Text = orderInfo.TotalPrice.ToString();
                ordertime.Text = orderInfo.OrderTime.ToString();

                orderstatus.Text =OrderUtils.GetOrderStatusName(orderInfo.Status);

                if (orderInfo.Status == (int)OrderEnum.WaitSend)
                {
                    PlaceHolder2.Visible = true;
                }

                shipaddress.Text = orderInfo.ShipAddress;
                shippeople.Text = orderInfo.ShipPeopele;
                shipmobile.Text = orderInfo.ShipMobile;

                repeater.DataSource = SnapshotBLL.GetSnapshotList("OrderID=" + orderInfo.OrderID);
                repeater.DataBind();
            }
        }

        /// <summary>
        /// 确认发货事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void subitBtn_Click(object sender, EventArgs e)
        {
            //if (OrderBLL.UpdateOrderStatus(orderInfo.OrderID, ((int)OrderEnum.Send)))
            //{
            //    WebUtility.Alert("处理成功!", Requests.GetPrevUrl());
            //}
            //else
            //{
            //    WebUtility.Alert("处理失败!");
            //}

            if (OrderBLL.UpdateOrderStatus(orderInfo.OrderID, ((int)OrderEnum.Send)))
            {
                ShowOK("发货成功!", "OrderList.aspx");
            }
            else
            {
                ShowError("发货失败!");
            }
        }
    }
}