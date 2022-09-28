using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Shopping.Common;

namespace Shopping.Web.Ajax
{
    public partial class Ajax_ConfirmOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            this.Response.Expires = 0;//清除缓存
            string action = Requests.All("action");
            string result = "";
            switch (action)
            {
                case "checkuserpoint":
                    {
                        decimal point = Utils.StrToDecimal(Requests.All("point"));
                        decimal savePrice = 0;
                        decimal totalprice = 0;
                        Model.OnLineUserInfo onlineUserInfo =OnLineUser.GetOnLineUserInfo();

                        if (onlineUserInfo != null)
                        {
                            Shopping.ShoppingCart shoppingCartInfo = new Shopping.ShoppingCart(onlineUserInfo, false);

                            decimal maxPoint = Utils.StrToDecimal(onlineUserInfo.Point);
                            totalprice = shoppingCartInfo.TotalPrice;
                            if (maxPoint < point)
                            {
                                result = "[{\"retid\":\"-1\",\"totalprice\":\"" + totalprice.ToString("f2") + "\",\"save\":\"0.00\"}]";
                            }
                            else
                            {
                                savePrice = point / 100;
                                totalprice = totalprice - savePrice;
                                result = "[{\"retid\":\"1\",\"totalprice\":\"" + totalprice.ToString("f2") + "\",\"save\":\"" + savePrice.ToString("f2") + "\"}]";
                            }
                        }
                    }
                    break;
                case "checkCoupon":
                    {
                        string couponNo = Requests.All("couponno");
                    }
                    break;
            }

            Response.Write(result);
            Response.End();
        }
    }
}