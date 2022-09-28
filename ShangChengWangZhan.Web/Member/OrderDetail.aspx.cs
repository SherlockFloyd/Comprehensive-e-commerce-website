using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Shopping.Common;
using Shopping;
using Shopping.BLL;

namespace Shopping.Web.Member
{
    public partial class OrderDetail : MemberPage
    {
        /// <summary>
        /// 全局变量[订单ID]
        /// </summary>
        protected int orderId = 0;
        private Shopping.Model.Order orderInfo;
        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            orderId = Utils.StrToInt(Requests.Query("orderid"));
            orderInfo = OrderBLL.GetOrderInfo(orderId, onlineUserInfo.UserID);
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
            if (orderInfo != null)
            {
                //绑定会员基本信息
                // username.Text = orderInfo.UserName;
                orderno.Text = orderInfo.OrderNo;
                txtTotalPrice.Text = orderInfo.TotalPrice.ToString();
                orderprice.Text = orderInfo.RealPay.ToString("f2");
                ordertime.Text = orderInfo.OrderTime.ToString("yyyy-MM-dd HH:mm:ss");
                orderstatus.Text = OrderUtils.GetOrderStatusName(orderInfo.Status);
                shipaddress.Text = orderInfo.ShipAddress;
                shippeople.Text = orderInfo.ShipPeopele;
                shipmobile.Text = orderInfo.ShipMobile;
                //txtSaveByCouponPrice.Text = orderInfo.SavingByCoupon.ToString();

                //绑定订单的购物清单
                repeater.DataSource = SnapshotBLL.GetSnapshotList(orderInfo.OrderID, onlineUserInfo.UserID);
                repeater.DataBind();

                int userPoint = orderInfo.UserPoint;
                decimal saveprice = 0;

                saveprice = Utils.StrToDecimal(userPoint) / 100;

                //if (userPoint > 0)
                //{
                //    PlaceHolder11.Visible = true;
                //    userpoint.Text = userPoint.ToString();
                //}

                //if (orderInfo.CouponID > 0 && orderInfo.CouponNo != "" && orderInfo.SavingByCoupon > 0)
                //{
                //    PlaceHolder13.Visible = true;
                //    saveprice = saveprice + orderInfo.SavingByCoupon;
                //}

                //if (saveprice > 0)
                //{
                //    PlaceHolder12.Visible = true;
                //    couponprice.Text = saveprice.ToString("f2");
                //}

                if (orderInfo.Status == (int)OrderEnum.Send)
                {
                    btnPlaceHolder.Visible = true;
                     
                }

                if (orderInfo.Status == (int)OrderEnum.WaitPay)
                {
                    payLink.Text = string.Format("<a class=\"pay b-1\" href=\"/Pay.aspx?action=pay&orderid={0}\">付款</a><br/>", orderInfo.OrderID);
                    PlaceHolder1.Visible = true;
                    txtOrderIntro.Text = "需付";
                }

                if (orderInfo.Status == (int)OrderEnum.Success || orderInfo.Status == (int)OrderEnum.Send)
                {
                    txtOrderIntro.Text = "已付";
                }

                //Model.User mjUserInfo = UserBLL.GetUserInfo(orderInfo.ShopID);
                //if (mjUserInfo != null)
                //{
                //    txtshopname.Text = mjUserInfo.RealName;
                //    txtcontact.Text = mjUserInfo.Phone;
                //}
            }
            else
            {
                Response.Redirect("OrderList.aspx");
            }
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        protected void repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal statusIntro = (Literal)e.Item.FindControl("txtOrderStatusIntro");
                Shopping.Model.Snapshot snapshot = (Shopping.Model.Snapshot)e.Item.DataItem;
                string result = "<font color=\"red\">无法评价!</font>";
                if (snapshot != null)
                {
                    if (snapshot.Status == (int)OrderEnum.Success)
                    {
                        if (snapshot.IsGrade == 1)
                        {
                            result = "已评价!";
                        }
                        else
                        {
                            result = string.Format("<a class=\"b-1\" href=\"PostRate.aspx?snapshotid={0}\">评价</a>", snapshot.SnapshotID);
                        }
                    }
                    else
                    {
                        if (snapshot.Status == (int)OrderEnum.WaitPay)
                        {
                            result = string.Format("<a class=\"pay b-1\" href=\"/Pay.aspx?action=pay&orderid={0}\">付款</a><br/>", snapshot.OrderID);
                        }
                    }
                }
                statusIntro.Text = result;
            }
        }
        /// <summary>
        /// 确认收货事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void subitBtn_Click(object sender, EventArgs e)
        {
            string result = "";

            bool flag = OrderUtils.ConfirmReceipt(orderInfo, out result);

            if (flag)
            {
                WebUtility.Alert("成功收货!", Requests.GetPrevUrl());
            }
            else
            {
                WebUtility.Alert(result);
            }
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            if (OrderUtils.CancelOrder(orderInfo))
            {
                WebUtility.Alert("订单取消成功!");
            }
            else
            {
                WebUtility.Alert("订单取消失败!");
            }

        }

    }
}