using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Shopping.Common;

using Shopping.Model;
using Shopping.BLL;

namespace Shopping
{
    public class ShoppingCart
    {
       
        public ShoppingCart(Model.OnLineUserInfo onlineUserInfo)
        {
            OnLineUserInfo = onlineUserInfo;
            IsShoppingCart = true;
            this.LoadShopingCartItem();
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="shoppingcart"></param>
        public ShoppingCart(Model.OnLineUserInfo onlineUserInfo, bool shoppingcart)
        {
            OnLineUserInfo = onlineUserInfo;
            IsShoppingCart = shoppingcart;
            this.LoadShopingCartItem();
        }
        /// <summary>
        /// 是否购物车
        /// </summary>
        public bool IsShoppingCart
        {
            set;
            get;
        }

        /// <summary>
        /// 在线用户信息
        /// </summary>
        public Model.OnLineUserInfo OnLineUserInfo
        {
            set;
            get;
        }

        /// <summary>
        /// 总商品数量
        /// </summary>
        public int Total
        {
            get
            {
                int num = 0;

                foreach (Shopping.Model.ShoppingCartItemInfo model in UsableCartItemList)
                {
                    num += model.Quantity;
                }

                return num;
            }
        }

        /// <summary>
        /// 商品总价
        /// </summary>
        public decimal TotalPrice
        {
            get
            {
                decimal num = 0;

                foreach (Model.ShoppingCartItemInfo model in UsableCartItemList)
                {
                    num += model.Price * model.Quantity;
                }

                return Utils.GetPriceByRound(2, num);
            }

        }
        private List<Model.ShoppingCartItemInfo> _UsableCartItemList;
        /// <summary>
        /// 购物车项
        /// </summary>
        public List<Model.ShoppingCartItemInfo> UsableCartItemList
        {
            get
            {
                List<Model.ShoppingCartItemInfo> list = _UsableCartItemList;

                if (!IsShoppingCart)
                {
                    list = list.Where(c => c.IsChecked == 1).ToList();
                }
                return list;
            }
            set { _UsableCartItemList = value; }
        }


        /// <summary>
        /// 加载购物车的项
        /// </summary>
        private void LoadShopingCartItem()
        {
            if (OnLineUserInfo.UserID != -1)
            {

                if (!string.IsNullOrEmpty(OnLineUserInfo.GuestID))
                {
                    List<Model.ShoppingCartItemInfo> list = ShoppingCartItemInfoBLL.GetShoppingCartListByGuestID(OnLineUserInfo.GuestID);

                    foreach (Model.ShoppingCartItemInfo shoppingCartItemInfo in list)
                    {
                        this.AddShoppingCartItem(shoppingCartItemInfo.CommodityID);
                    }

                    ShoppingCartItemInfoBLL.DeleteShoppingCartByGuestID(OnLineUserInfo.GuestID);
                }
                this._UsableCartItemList = ShoppingCartItemInfoBLL.GetShoppingCartListByUserID(OnLineUserInfo.UserID);
            }
            else
            {
                this._UsableCartItemList = ShoppingCartItemInfoBLL.GetShoppingCartListByGuestID(OnLineUserInfo.GuestID);
            }
        }
        /// <summary>
        /// 添加购物车项
        /// </summary>
        /// <param name="CommodityInfo"></param>
        /// <returns></returns>
        public string AddShoppingCartItem(int CommodityID)
        {
            string result = "";

            Shopping.Model.Commodity CommodityInfo = Shopping.BLL.CommodityBLL.GetCommodityInfo(CommodityID);
            if (CommodityInfo == null)
            {
                result = "商品不存在!";
            }
            else
            {
                if (CommodityInfo.Stock <= 0)
                {
                    result = "库存不足!";
                }
                else
                {

                    Model.ShoppingCartItemInfo model = ShoppingCartItemInfoBLL.GetShoppingCartInfoByCommodityID(OnLineUserInfo, CommodityInfo.CommodityID);


                    if (model != null)
                    {
                        if (OnLineUserInfo.UserID != -1)
                        {
                            model.UserID = OnLineUserInfo.UserID;
                        }
                        else
                        {
                            model.GuestID = OnLineUserInfo.GuestID;
                        }
                        model.Quantity += 1;
                        ShoppingCartItemInfoBLL.UpdateShoppingCart(model);
                    }
                    else
                    {
                        
                        model = new Model.ShoppingCartItemInfo();
                        if (OnLineUserInfo.UserID != -1)
                        {
                            model.UserID = OnLineUserInfo.UserID;
                        }
                        else
                        {
                            model.GuestID = OnLineUserInfo.GuestID;
                        }
                        model.CommodityID = CommodityInfo.CommodityID;
                        model.Price = CommodityInfo.Price;
                        model.Quantity = 1;
                        ShoppingCartItemInfoBLL.AddShoppingCart(model);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 加一
        /// </summary>
        /// <param name="shoppingcartId"></param>
        public string Add(int shoppingcartId)
        {
            string result = "";
            ShoppingCartItemInfo shoppingCartItemInfo = ShoppingCartItemInfoBLL.GetShoppingCartInfo(shoppingcartId);

            if (shoppingCartItemInfo != null)
            {
                if (Shopping.BLL.CommodityBLL.CheckStock(shoppingCartItemInfo.CommodityID, shoppingCartItemInfo.Quantity + 1) <= 0)
                {
                    result = "库存不足!";
                }
                else
                {
                    shoppingCartItemInfo.Quantity += 1;
                    ShoppingCartItemInfoBLL.UpdateShoppingCart(shoppingCartItemInfo);
                }
            }
            else
            {
                result = "不存在的购物车项!";
            }
            return result;
        }

        /// <summary>
        /// 减一
        /// </summary>
        /// <param name="shoppingCartId"></param>
        /// <returns></returns>
        public string Minus(int shoppingcartId)
        {
            string result = "";

            ShoppingCartItemInfo shoppingCartItemInfo = ShoppingCartItemInfoBLL.GetShoppingCartInfo(shoppingcartId);

            if (shoppingCartItemInfo != null)
            {
                if (shoppingCartItemInfo.Quantity - 1 <= 0)
                {
                    result = "最少选购一件!";
                }
                else
                {

                    if (Shopping.BLL.CommodityBLL.CheckStock(shoppingCartItemInfo.CommodityID, shoppingCartItemInfo.Quantity + 1) <= 0)
                    {
                        result = "库存不足!";
                    }
                    else
                    {
                        shoppingCartItemInfo.Quantity -= 1;
                        ShoppingCartItemInfoBLL.UpdateShoppingCart(shoppingCartItemInfo);
                    }
                }
            }
            else
            {
                result = "不存在的购物车项!";
            }
            return result;
        }

        /// <summary>
        /// 修改购物车项的数量
        /// </summary>
        /// <param name="shoppingcartId"></param>
        /// <param name="quantityId"></param>
        /// <returns></returns>
        public string ChangeQuantity(int shoppingcartId, int quantity)
        {
            string result = "";

            ShoppingCartItemInfo shoppingCartItemInfo = ShoppingCartItemInfoBLL.GetShoppingCartInfo(shoppingcartId);

            if (shoppingCartItemInfo != null)
            {
                if (!Utils.IsNumber(quantity.ToString()) || quantity <= 0)
                {
                    result = "数量必须为数字而且必须大于0!";
                }

                else
                {

                    if (Shopping.BLL.CommodityBLL.CheckStock(shoppingCartItemInfo.CommodityID, quantity) <= 0)
                    {
                        result = "库存不足!";
                    }
                    else
                    {
                        shoppingCartItemInfo.Quantity = quantity;
                        ShoppingCartItemInfoBLL.UpdateShoppingCart(shoppingCartItemInfo);
                    }
                }
            }
            else
            {
                result = "不存在的购物车项!";
            }
            return result;
        }

        /// <summary>
        /// 删除购物车的项
        /// </summary>
        /// <param name="shoppingcartID"></param>
        /// <returns></returns>
        public string Remove(int shoppingcartID)
        {
            return (ShoppingCartItemInfoBLL.DeleteShoppingCart(shoppingcartID) ? "" : "移除失败!");
        }

        /// <summary>
        /// 批量删除购物车的项
        /// </summary>
        /// <param name="shoppingcartIds"></param>
        /// <returns></returns>
        public string BatchRemove(string shoppingcartIds)
        {
            return ShoppingCartItemInfoBLL.DeleteShoppingCartList(shoppingcartIds) ? "" : "删除失败";
        }

        /// <summary>
        /// 清除已经提交订单的购物车项
        /// </summary>
        public void RemoveShoppingCart()
        {
            ShoppingCartItemInfoBLL.ClearShoppingCart(OnLineUserInfo.UserID, 1);
        }
    }
}
