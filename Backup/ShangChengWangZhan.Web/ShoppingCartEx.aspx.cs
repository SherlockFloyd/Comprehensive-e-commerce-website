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
    public partial class ShoppingCartEx : System.Web.UI.Page
    {
        List<Model.ShoppingCartItemInfo> sciiList;
        public int i = 1;
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
            sciiList = Shopping.BLL.ShoppingCartItemInfoBLL.GetShoppingCartListByUserID(onlineUserInfo.UserID).Where(c => c.IsChecked == 1).ToList();
            if (!IsPostBack)
            {
                #region 绑定数据



                List<Model.User> uList = new List<Model.User>();
                List<int> uIntList = new List<int>();
                foreach (Model.ShoppingCartItemInfo sciiInfo in sciiList)
                {
                    Model.Commodity commodityInfo = CommodityBLL.GetCommodityInfo(sciiInfo.CommodityID);
                    if (commodityInfo != null)
                    {
                        Model.User userInfo = UserBLL.GetUserInfo(commodityInfo.UserID);
                        if (userInfo != null)
                        {
                            if (!uIntList.Contains(userInfo.UserID))
                            {
                                uIntList.Add(userInfo.UserID);
                            }
                        }
                    }
                }
                //uList = UserBLL.GetUserList("UserID in(" + string.Join(",", uIntList.ToArray()) + ")");
                //if (uList.Count == 1)
                //{
                Response.Redirect("ConfirmOrder.aspx");
                //}
                //else
                //{
                //    repeater.DataSource = uList;
                //    repeater.DataBind();
                //}
                #endregion
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        protected void repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Repeater rDRepeater = (Repeater)e.Item.FindControl("repeater1");

                Model.User userInfo = (Model.User)e.Item.DataItem;
                if (userInfo != null)
                {
                    List<Model.ShoppingCartItemInfo> cSCIIList = sciiList.Where(c => c.ShopID == userInfo.UserID).ToList();

                    rDRepeater.DataSource = cSCIIList; rDRepeater.DataBind();
                }
            }
        }
        /// <summary>
        /// 按钮事件 跳转到结算页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void subitBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConfirmOrder.aspx?shopid=" + Requests.Form("shopid"));
        }
    }
}