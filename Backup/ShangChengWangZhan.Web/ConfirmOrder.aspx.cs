using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Shopping.Common;

using Shopping;

namespace Shopping.Web
{
    public partial class ConfirmOrder : System.Web.UI.Page
    {

        private Shopping.ShoppingCart cart;
        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Shopping.Model.OnLineUserInfo onlineUserInfo = Shopping.OnLineUser.GetOnLineUserInfo(true);

            if (onlineUserInfo == null)
            {
                Response.Redirect("Login.aspx?returnurl=ShoppingCart.aspx");
            }

            bool checkRsl = true;

            Shopping.BLL.ShoppingCartItemInfoBLL.CheckShoppingCart(onlineUserInfo, out checkRsl);

            //if (!checkRsl)
            //{
            //    WebUtility.Alert("不能结算自己发布的商品!", "ShoppingCart.aspx");
            //}

            Shopping.Model.User userInfo = Shopping.UserBLL.GetUserInfo(onlineUserInfo.UserID);

            if (onlineUserInfo == null)
            {
                Response.Redirect("Login.aspx?returnurl=ShoppingCart.aspx");
            }
            else
            {
                //txthavePoint.Value = onlineUserInfo.Point.ToString();
                //havePoint.Text = onlineUserInfo.Point.ToString();
                Literal1.Text = "0.00";

                decimal totalprice = 0.0M;
                cart = new Shopping.ShoppingCart(onlineUserInfo, false);

                //if (cart.Total <= 0)
                //{
                //    Response.Redirect("ShoppingCart.aspx");
                //}

                #region 绑定数据
                if (!IsPostBack)
                {
                    txtshippeople.Value = userInfo.UserName;
                    txtshipaddress.Value = userInfo.Address;
                    txtshipmobile.Value = userInfo.Phone;

                    totalprice = cart.TotalPrice;

                    int shopid = Utils.StrToInt(Requests.Query("shopid"));

                    List<Model.ShoppingCartItemInfo> sciiList = cart.UsableCartItemList.Where(c => c.IsChecked == 1).ToList();
                    if (shopid > 0)
                    {
                        sciiList = sciiList.Where(c => c.ShopID == shopid).ToList();
                    }

                    repeater.DataSource = sciiList;
                    repeater.DataBind();

                    txtQuantity.Text = cart.Total.ToString();

                    txtTotalPrice.Text = totalprice.ToString();
                    txtRealPay.Text = totalprice.ToString();

                    List<Model.Delivery> deliveryList = Shopping.DeliveryBLL.GetDeliveryList("UserID=" + userInfo.UserID);

                    if (deliveryList.Count <= 0)
                    {
                        delivery_0.Checked = true;
                    }
                    else
                    {
                        txtDeliveryList.DataSource = deliveryList;
                        txtDeliveryList.DataBind();
                    }

                }
                #endregion

                #region 提交订单
                if (IsPostBack)
                {
                    int deliveryID = Utils.StrToInt(Requests.Form("delivery"));
                    Model.Delivery deliveryInfo = null;
                    string shippeople = "";
                    string shipaddress = "";
                    string shipmobile = "";
                    string remark = comments.Value.Trim();
                    if (deliveryID == 0)
                    {
                        shippeople = txtshippeople.Value.Trim();
                        shipaddress = txtshipaddress.Value.Trim();
                        shipmobile = txtshipmobile.Value.Trim();
                        deliveryInfo = new Shopping.Model.Delivery()
                        {
                            Address = shipaddress,
                            CreateTime = DateTime.Now,
                            IsDefault = 0,
                            Name = shippeople,
                            Tel = shipmobile,
                            UserID = userInfo.UserID
                        };
                        deliveryID = DeliveryBLL.AddDelivery(deliveryInfo);
                    }
                    else
                    {
                        deliveryInfo =DeliveryBLL.GetDeliveryInfo(deliveryID);

                        if (deliveryInfo != null)
                        {
                            shippeople = deliveryInfo.Name;
                            shipaddress = deliveryInfo.Address;
                            shipmobile = deliveryInfo.Tel;
                        }
                    }

                    //int point = 0;// Utils.StrToInt(usePoint.Value);
                    int couponID = 0;
                    string couponNo = "";
                    decimal saveByCoupon = 0;

                    int orderID = OrderUtils.Send(userInfo.UserID, userInfo.UserName, remark, shippeople, shipaddress, shipmobile, couponID, couponNo, saveByCoupon, cart);
                    if (orderID > 0)
                    {
                        Response.Redirect("CompleteOrder.aspx?orderid=" + orderID);
                    }
                    else
                    {
                        WebUtility.Alert("订单提交失败!"); return;
                    }
                }
                #endregion
            }
        }

        #region 加载收货地址

        #endregion
    }
}