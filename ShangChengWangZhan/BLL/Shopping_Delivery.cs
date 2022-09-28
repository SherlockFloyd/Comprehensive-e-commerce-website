
using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;


using Shopping.DAL;

namespace Shopping
{

    /// 主要完成对DAL层的调用
    /// </summary>
    public class DeliveryBLL
    {
        #region #Method
        /// <summary>
        /// 全局变量
        /// </summary>
        private static DeliveryProvider DAL = DeliveryProvider.GetInstance();


        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static bool ExistDelivery(string condition)
        {
            return DAL.ExistDelivery(condition);
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static int AddDelivery(Model.Delivery model)
        {
            return DAL.AddDelivery(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static bool UpdateDelivery(Model.Delivery model)
        {
            return DAL.UpdateDelivery(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteDelivery(int DeliveryID)
        {
            return DAL.DeleteDelivery(DeliveryID);
        }



        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteDeliveryList(string DeliveryIDlist)
        {
            return DAL.DeleteDeliveryList(DeliveryIDlist);
        }


        /// <summary>
        /// 根据DeliveryID获取一条数据
        /// </summary>
        /// <param name="DeliveryID"></param>
        /// <returns></returns>
        public static Model.Delivery GetDeliveryInfo(int DeliveryID)
        {
            return DAL.GetDeliveryInfo(DeliveryID);
        }
        /// <summary>
        /// 根据DeliveryID获取一条数据
        /// </summary>
        /// <param name="DeliveryID"></param>
        /// <returns></returns>
        public static Model.Delivery GetDeliveryInfo(int DeliveryID, int UserID)
        {
            return DAL.GetDeliveryInfoByCondition("DeliveryID=" + DeliveryID + " AND UserID=" + UserID);
        }
        /// <summary>
        /// 根据过滤条件获取一条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static Model.Delivery GetDeliveryInfoByCondition(string condition)
        {
            return DAL.GetDeliveryInfoByCondition(condition);
        }

        /// <summary>
        /// 获取全部的数据列表
        /// </summary>
        /// <returns></returns>
        public static List<Model.Delivery> GetDeliveryList()
        {
            return DAL.GetDeliveryList();
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.Delivery> GetDeliveryList(string condition)
        {
            return DAL.GetDeliveryList(condition);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.Delivery> GetDeliveryList(int pagesize, int pageindex, string condition)
        {
            return DAL.GetDeliveryList(pagesize, pageindex, condition);
        }

        /// <summary>
        /// 根据DeliveryID数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="sorttype">排序类型（ASC，DESC）</param>
        /// <returns></returns>
        public static List<Model.Delivery> GetDeliveryList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            return DAL.GetDeliveryList(pagesize, pageindex, condition, orderby, sorttype);
        }


        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="tableName">表名或视图名</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int GetDeliveryCount(string condition)
        {
            return DAL.GetDeliveryCount(condition);
        }
        #endregion

        #region MethodEx
        /// <summary>
        /// 设置默认地址
        /// </summary>
        /// <param name="delivertyID"></param>
        public static bool SetDefaultDelivery(int delivertyID,int userID)
        {
            return DAL.SetDefaultDelivery(delivertyID, userID);
        }
        #endregion
    }
}