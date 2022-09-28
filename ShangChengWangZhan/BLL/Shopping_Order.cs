
using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Shopping.Common;
using Shopping.Data;
using Shopping.DAL;

namespace Shopping.BLL
{

    
    /// </summary>
    public class OrderBLL
    {

        /// <summary>
        /// 全局变量
        /// </summary>
        private static OrderProvider DAL = OrderProvider.GetInstance();


        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static bool ExistOrder(string condition)
        {
            return DAL.ExistOrder(condition);
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static int AddOrder(Model.Order model)
        {
            return DAL.AddOrder(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static bool UpdateOrder(Model.Order model)
        {
            return DAL.UpdateOrder(model);
        }
        /// <summary>
        /// 订单状态操作
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        public static bool UpdateOrderStatus(int orderId, int orderStatus)
        {
            return DAL.UpdateOrderStatus(orderId, orderStatus);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteOrder(int OrderID)
        {
            return DAL.DeleteOrder(OrderID);
        }



        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteOrderList(string OrderIDlist)
        {
            return DAL.DeleteOrderList(OrderIDlist);
        }


        /// <summary>
        /// 根据OrderID获取一条数据
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public static Model.Order GetOrderInfo(int OrderID)
        {
            return DAL.GetOrderInfo(OrderID);
        }

        /// <summary>
        /// 根据用户ID和订单ID获取订单信息
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static Model.Order GetOrderInfo(int OrderID, int UserID)
        {
            return GetOrderInfoByCondition("UserID=" + UserID + " AND OrderID=" + OrderID);
        }


        /// <summary>
        /// 根据过滤条件获取一条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static Model.Order GetOrderInfoByCondition(string condition)
        {
            return DAL.GetOrderInfoByCondition(condition);
        }

        /// <summary>
        /// 获取全部的数据列表
        /// </summary>
        /// <returns></returns>
        public static List<Model.Order> GetOrderList()
        {
            return DAL.GetOrderList();
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.Order> GetOrderList(string condition)
        {
            return DAL.GetOrderList(condition);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.Order> GetOrderList(int pagesize, int pageindex, string condition)
        {
            return DAL.GetOrderList(pagesize, pageindex, condition);
        }

        /// <summary>
        /// 根据OrderID数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="sorttype">排序类型（ASC，DESC）</param>
        /// <returns></returns>
        public static List<Model.Order> GetOrderList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            return DAL.GetOrderList(pagesize, pageindex, condition, orderby, sorttype);
        }


        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="tableName">表名或视图名</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int GetOrderCount(string condition)
        {
            return DAL.GetOrderCount(condition);
        }

      
    }
}