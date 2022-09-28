using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Shopping.Common;

using Shopping;
using Shopping.Model;
using Shopping.BLL;


namespace Shopping.Web
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        Shopping.ShoppingCart shoppingcartInfo;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Shopping.Model.OnLineUserInfo onLineUserInfo = Shopping.OnLineUser.GetOnLineUserInfo();
            shoppingcartInfo = new Shopping.ShoppingCart(onLineUserInfo);
            
            if (shoppingcartInfo.UsableCartItemList.Count <= 0)
            {
                errorMsg.Visible = true;
                subitBtn.Enabled = false;
                subitBtn.CssClass = "btn1";
            }
            else
            {
                repeater.DataSource = shoppingcartInfo.UsableCartItemList;
                repeater.DataBind();
            }
        }

       
        protected void repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ShoppingCartItemInfo info = (ShoppingCartItemInfo)e.Item.DataItem;
                Literal stockTip1 = (Literal)e.Item.FindControl("stockTip");

                if (info != null)
                {
                    string stoc = "";
                    if (info.Stock <= 0)
                    {
                        stoc = "<img src='icons/exclamation.gif' /><font color='red'>无库存</font>";
                    }
                    stockTip1.Text = stoc;
                }
            }
        }
       
        protected void subitBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShoppingCartEx.aspx");
        }
    }
}