using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shopping.Common;


using Shopping.BLL;
using Shopping;

namespace Shopping
{
    /// <summary>
    /// 订单操作[公用类]
    /// </summary>
    public class OrderUtils
    {
        #region 获取订单状态名称

        /// <summary>
        /// 获取订单状态名称
        /// </summary>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        public static string GetOrderStatusName(object orderStatus)
        {
            string name = string.Empty;

            switch (((int)orderStatus))
            {
                case ((int)OrderEnum.WaitPay):
                    name = "尚未付款(等待)";
                    break;
                case ((int)OrderEnum.WaitSend):
                    name = "等待处理";
                    break;
                case ((int)OrderEnum.Send):
                    name = "已确认(配送中)";
                    break;
                case ((int)OrderEnum.Cancel):
                    name = "已取消";
                    break;
                case ((int)OrderEnum.Success):
                    name = "成功";
                    break;
            }

            return name;
        }
        #endregion

        #region 更新订单库存

        /// <summary>
        /// 更新库存[]
        /// </summary>
        /// <param name="orderID"></param>
        public static void UpdateStockByOrderID(int orderID)
        {
            List<Model.Snapshot> snapShotList = SnapshotBLL.GetSnapshotListByOrderID(orderID);

            foreach (Model.Snapshot snapshotInfo in snapShotList)
            {
                Shopping.BLL.CommodityBLL.UpdateCommodityStock(snapshotInfo.CommodityID, snapshotInfo.Quantity, (int)StockChangeTypeEnum.Sale);
            }
        }
        #endregion



        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public static bool CancelOrder(int orderID)
        {
            bool result = false;

            Model.Order orderInfo = BLL.OrderBLL.GetOrderInfo(orderID);

            if (orderInfo != null)
            {
                orderInfo.Status = (int)OrderEnum.Cancel;

                if (BLL.OrderBLL.UpdateOrder(orderInfo))
                {
                    //if (orderInfo.UserPoint > 0)
                    //{

                    //    UsePointLogBLL.CreateUserPointLog(orderInfo.UserID, orderInfo.UserPoint, orderInfo.OrderID, "订单:" + orderInfo.OrderNo + "取消返还");
                    //}
                    result = true;
                }
            }

            return result;
        }
        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        public static bool CancelOrder(Model.Order orderInfo)
        {
            bool result = false;

            if (orderInfo != null)
            {
                orderInfo.Status = (int)OrderEnum.Cancel;

                if (OrderBLL.UpdateOrder(orderInfo))
                {
                    //if (orderInfo.UserPoint > 0)
                    //{

                    //    UsePointLogBLL.CreateUserPointLog(orderInfo.UserID, orderInfo.UserPoint, orderInfo.OrderID, "订单:" + orderInfo.OrderNo + "取消返还");
                    //}
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// 确认收货
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public static bool ConfirmReceipt(Model.Order orderInfo, out string result)
        {
            bool flag = true;
            result = "";

            if (orderInfo == null)
            {
                result = "订单不存在!";
                flag = false;
            }
            else
            {
                orderInfo.Status = (int)OrderEnum.Success;

                //确认收货成功
                if (OrderBLL.UpdateOrder(orderInfo))
                {
                    int orderPoint = 0;

                    List<Model.Snapshot> snapshotInfoList = SnapshotBLL.GetSnapshotList(orderInfo.OrderID, orderInfo.UserID);

                    foreach (Model.Snapshot snapshotInfo in snapshotInfoList)
                    {
                        orderPoint += snapshotInfo.Point;
                    }

                    //UsePointLogBLL.CreateUserPointLog(orderInfo.UserID, orderPoint, orderInfo.OrderID, "订单:" + orderInfo.OrderNo);

                    flag = true;
                    result = "确认成功!";
                }
                else
                {
                    result = "确认收货失败,请联系在线客服!";
                    flag = false;
                }

            }
            return flag;
        }

        /// <summary>
        /// 订单提交
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="userName">会员名</param>
        /// <param name="remark">备注</param>
        /// <param name="shippeople">收货人</param>
        /// <param name="shipaddress">收货地址</param>
        /// <param name="shipmobile">手机号码</param>
        /// <param name="point">使用积分</param>
        /// <param name="shoppingCartInfo">购物车</param>
        /// <returns></returns>
        public static int Send(int userID, string userName, string remark, string shippeople, string shipaddress, string shipmobile, int couponId, string couponNo, decimal saveByCoupon, ShoppingCart shoppingCartInfo)
        {


            decimal totalPrice = shoppingCartInfo.TotalPrice;
            decimal realprice = 0;
            decimal saveprice = 0;

            //if (point > 0)
            //{
            //    saveprice = Utils.StrToDecimal(point) / 100;
            //}

            if (couponId > 0 && couponNo != "")
            {
                saveprice += saveByCoupon;
            }

            realprice = totalPrice - saveprice;

            Model.Order orderInfo = new Model.Order()
            {
                OrderNo = DateTime.Now.ToString("yyyyMMddHHmmss") + Utils.GetRandomString(4, 4, "0123456789"),
                OrderTime = DateTime.Now,
                ShipAddress = shipaddress,
                ShipMobile = shipmobile,
                ShipPeopele = shippeople,
                Status = (int)OrderEnum.WaitPay,
                TotalPrice = totalPrice,
                UserID = userID,
                UserName = userName,
                //UserPoint = point,
                Remark = remark,
                RealPay = realprice,
                PaidTime = DateTime.Now,
                CouponID = couponId,
                CouponNo = couponNo,
                SavingByCoupon = saveByCoupon,
                ShopID = shoppingCartInfo.UsableCartItemList[0].ShopID
            };

            int orderID = OrderBLL.AddOrder(orderInfo);


            if (orderID > 0)
            {
                try
                {
                    //创建快照
                    foreach (Model.ShoppingCartItemInfo shoppingcartInfo in shoppingCartInfo.UsableCartItemList)
                    {
                        Model.Snapshot snapshotInfo = new Model.Snapshot();
                        snapshotInfo.CommodityID = shoppingcartInfo.CommodityID;
                        snapshotInfo.IsGrade = 0;
                        snapshotInfo.OrderID = orderID;
                        snapshotInfo.Price = shoppingcartInfo.Price;
                        snapshotInfo.Quantity = shoppingcartInfo.Quantity;
                        snapshotInfo.TotalPrice = Utils.GetPriceByRound(2, shoppingcartInfo.Price * shoppingcartInfo.Quantity);
                        SnapshotBLL.AddSnapshot(snapshotInfo);
                    }
                    //清空购物篮
                    shoppingCartInfo.RemoveShoppingCart();

                    //增加一条积分使用记录
                    //if (orderInfo.UserPoint > 0)
                    //{
                    //    UsePointLogBLL.CreateUserPointLog(userID, -point, orderID, "订单:" + orderInfo.OrderNo + "使用");
                    //}
                }
                catch
                {
                    //创建快照等出错，删除订单
                    OrderBLL.DeleteOrder(orderID);
                    orderID = 0;
                }
            }
            else
            {
                //订单没有生成成功
            }
            return orderID;
        }

        /// <summary>
        /// 检查库存
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        public static bool CheckStock(Model.Order orderInfo)
        {
            bool flag = true;

            List<Model.Snapshot> snapShot = SnapshotBLL.GetSnapshotListByOrderID(orderInfo.OrderID);

            foreach (Model.Snapshot snapshotInfo in snapShot)
            {
                if (snapshotInfo.Stock <= 0)
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }
        /// <summary>
        /// 检查库存
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static bool CheckStock(int orderId)
        {
            bool flag = true;

            List<Model.Snapshot> snapShot = SnapshotBLL.GetSnapshotListByOrderID(orderId);

            foreach (Model.Snapshot snapshotInfo in snapShot)
            {
                if (snapshotInfo.Stock <= 0)
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }
    }
}
