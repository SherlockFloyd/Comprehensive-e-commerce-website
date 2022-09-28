
using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Shopping.DAL;

namespace Shopping.BLL
{

    /// </summary>
    public class ShoppingCartItemInfoBLL
    {

        /// <summary>
        /// 全局变量
        /// </summary>
        private static ShoppingCartItemInfoProvider DAL = ShoppingCartItemInfoProvider.GetInstance();


        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static bool ExistShoppingCart(string condition)
        {
            return DAL.ExistShoppingCart(condition);
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static int AddShoppingCart(Model.ShoppingCartItemInfo model)
        {
            return DAL.AddShoppingCart(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static bool UpdateShoppingCart(Model.ShoppingCartItemInfo model)
        {
            return DAL.UpdateShoppingCart(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteShoppingCart(int ShoppingCartID)
        {
            return DAL.DeleteShoppingCart(ShoppingCartID);
        }



        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteShoppingCartList(string ShoppingCartIDlist)
        {
            return DAL.DeleteShoppingCartList(ShoppingCartIDlist);
        }
        /// <summary>
        /// 根据用户ID清除购物车项
        /// </summary>
        /// <param name="userID"></param>
        public static void ClearShoppingCart(int userID, int IsChecked)
        {
            DAL.ClearShoppingCart(userID, IsChecked);
        }

        /// <summary>
        /// 根据ShoppingCartID获取一条数据
        /// </summary>
        /// <param name="ShoppingCartID"></param>
        /// <returns></returns>
        public static Model.ShoppingCartItemInfo GetShoppingCartInfo(int ShoppingCartID)
        {
            return DAL.GetShoppingCartInfo(ShoppingCartID);
        }

        /// <summary>
        /// 根据会员在线信息和ShoppingCartID获取购物车信息
        /// </summary>
        /// <param name="onlineUserInfo"></param>
        /// <param name="shoppingcartID"></param>
        /// <returns></returns>
        public static Model.ShoppingCartItemInfo GetShoppingCartInfoByShoppingCartID(Shopping.Model.OnLineUserInfo onlineUserInfo, int shoppingcartID)
        {
            StringBuilder condition = new StringBuilder();

            if (onlineUserInfo.UserID > 0)
            {
                condition.AppendFormat(" UserID={0}", onlineUserInfo.UserID);
            }
            else
            {
                condition.AppendFormat(" GuestID='{0}'", onlineUserInfo.GuestID);
            }

            condition.AppendFormat(" AND ShoppingCartID={0}", shoppingcartID);

            return GetShoppingCartInfoByCondition(condition.ToString());
        }
        /// <summary>
        /// 根据会员在线信息和CommodityID获取购物车信息
        /// </summary>
        /// <param name="onlineUserInfo"></param>
        /// <param name="shoppingcartID"></param>
        /// <returns></returns>
        public static Model.ShoppingCartItemInfo GetShoppingCartInfoByCommodityID(Shopping.Model.OnLineUserInfo onlineUserInfo, int CommodityID)
        {
            Model.ShoppingCartItemInfo shoppingCartItemInfo;
            StringBuilder condition = new StringBuilder();

            if (onlineUserInfo.UserID != -1)
            {
                condition.AppendFormat(" UserID={0}", onlineUserInfo.UserID);
            }
            else
            {
                condition.AppendFormat(" GuestID='{0}'", onlineUserInfo.GuestID);
            }

            condition.AppendFormat(" AND CommodityID={0}", CommodityID);

            shoppingCartItemInfo = GetShoppingCartInfoByCondition(condition.ToString());

            return shoppingCartItemInfo;
        }


        /// <summary>
        /// 根据过滤条件获取一条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static Model.ShoppingCartItemInfo GetShoppingCartInfoByCondition(string condition)
        {
            return DAL.GetShoppingCartInfoByCondition(condition);
        }

        /// <summary>
        /// 获取全部的数据列表
        /// </summary>
        /// <returns></returns>
        public static List<Model.ShoppingCartItemInfo> GetShoppingCartList()
        {
            return DAL.GetShoppingCartList();
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.ShoppingCartItemInfo> GetShoppingCartList(string condition)
        {
            return DAL.GetShoppingCartList(condition);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.ShoppingCartItemInfo> GetShoppingCartList(int pagesize, int pageindex, string condition)
        {
            return DAL.GetShoppingCartList(pagesize, pageindex, condition);
        }

        /// <summary>
        /// 根据ShoppingCartID数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="sorttype">排序类型（ASC，DESC）</param>
        /// <returns></returns>
        public static List<Model.ShoppingCartItemInfo> GetShoppingCartList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            return DAL.GetShoppingCartList(pagesize, pageindex, condition, orderby, sorttype);
        }


        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="tableName">表名或视图名</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int GetShoppingCartCount(string condition)
        {
            return DAL.GetShoppingCartCount(condition);
        }

        /// <summary>
        /// 获取全部的数据列表
        /// </summary>
        /// <returns></returns>
        public static List<Model.ShoppingCartItemInfo> GetShoppingCartListByUserID(int userID)
        {
            return DAL.GetShoppingCartList("UserID=" + userID);
        }
        /// <summary>
        /// 获取全部的数据列表
        /// </summary>
        /// <returns></returns>
        public static List<Model.ShoppingCartItemInfo> GetShoppingCartListByGuestID(string GuestID)
        {
            return DAL.GetShoppingCartList("GuestID='" + GuestID + "'");
        }

        /// <summary>
        /// 删除游客购物车的项
        /// </summary>
        /// <param name="guestID"></param>
        /// <returns></returns>
        public static bool DeleteShoppingCartByGuestID(string guestID)
        {
            return DAL.DeleteShoppingCartByGuestID(guestID);
        }

        /// <summary>
        /// 检查购物车是否有自己发布的商品 有则删除
        /// </summary>
        /// <returns></returns>
        public static void CheckShoppingCart(Model.OnLineUserInfo onlineUserInfo,out bool result)
        {
            result = true;
            List<Model.ShoppingCartItemInfo> list = ShoppingCartItemInfoBLL.GetShoppingCartListByUserID(onlineUserInfo.UserID);

            foreach (Model.ShoppingCartItemInfo info in list)
            {
                Model.Commodity commodityInfo = CommodityBLL.GetCommodityInfo(info.CommodityID);

                if (commodityInfo != null)
                {
                    if (commodityInfo.UserID == onlineUserInfo.UserID)
                    {
                        result = false;
                        ShoppingCartItemInfoBLL.DeleteShoppingCart(info.ShoppingCartID);
                    }
                }
            }
            
        }
    }
}