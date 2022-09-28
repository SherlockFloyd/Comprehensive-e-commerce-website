using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Shopping.Common;

using Shopping.BLL;
using Shopping.Model;


namespace Shopping.Web.Ajax
{
    public partial class Ajax_ShoppingCart : System.Web.UI.Page
    {
        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Response.Expires = 0;//清除缓存
            string action = Requests.All("action");
            string result = "";
            Model.OnLineUserInfo onlineUserInfo = OnLineUser.GetOnLineUserInfo();
            Shopping.ShoppingCart shoppingCartInfo = new Shopping.ShoppingCart(onlineUserInfo);
            try
            {
                int shoppingcartId = Utils.StrToInt(Requests.All("s"));

                switch (action)
                {
                    case "buy":
                    case "addCommoditytocart":
                        {
                            int Commodityid = Utils.StrToInt(Requests.All("Commodityid"));
                            result = shoppingCartInfo.AddShoppingCartItem(Commodityid);
                        }
                        break;

                    case "minus":
                        {
                            result = shoppingCartInfo.Minus(shoppingcartId);
                        }
                        break;
                    case "add":
                        {
                            result = shoppingCartInfo.Add(shoppingcartId);
                        }
                        break;
                    case "remove":
                        {
                            result = shoppingCartInfo.Remove(shoppingcartId);
                        }
                        break;
                    case "batch":
                        {
                            string shoppingcartIds = Requests.All("ids").Remove(0, 1);
                            result = shoppingCartInfo.BatchRemove(shoppingcartIds);
                        }
                        break;
                    case "gettotalprice":
                        {
                            Model.ShoppingCartItemInfo info = ShoppingCartItemInfoBLL.GetShoppingCartInfo(shoppingcartId);
                            if (info != null)
                            {

                                int quantity = info.Quantity;
                                decimal price = info.Price;
                               // decimal totalPrice = 0;
                                //decimal realPrice = 0;
                                int IsChecked = Utils.StrToInt(Requests.All("ischecked"));

                                if (info.Stock <= 0)
                                {
                                    quantity = 0;
                                    price = 0;
                                }

                                if (IsChecked == 0)
                                {
                                    quantity = 0;
                                    price = 0;
                                }

                                info.IsChecked = IsChecked;

                                ShoppingCartItemInfoBLL.UpdateShoppingCart(info);

                                result = "[{\"quantity\":\"" + quantity + "\",\"price\":\"" + price + "\"}]";
                            }
                        }
                        break;
                    case "changequantity":
                        {
                            int quantity = Utils.StrToInt(Requests.All("q"));
                            result = shoppingCartInfo.ChangeQuantity(shoppingcartId, quantity);
                        }
                        break;
                    case "changecheckstaus":
                        {
                            int isChecked = Utils.StrToInt(Requests.All("ischecked"));
                            Model.ShoppingCartItemInfo info = ShoppingCartItemInfoBLL.GetShoppingCartInfo(shoppingcartId);
                            if (info != null)
                            {
                                info.IsChecked = isChecked;
                                ShoppingCartItemInfoBLL.UpdateShoppingCart(info);
                            }
                            result = "";
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            Response.Write(result);
            Response.End();
        }






    }
}