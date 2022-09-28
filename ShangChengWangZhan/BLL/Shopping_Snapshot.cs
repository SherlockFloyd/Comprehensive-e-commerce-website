
using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Shopping.Common;
using Shopping.Data;
using Shopping.DAL;
using Shopping.Model;

namespace Shopping.BLL
{

   
    /// </summary>
    public class SnapshotBLL
    {
        #region #Method
        /// <summary>
        /// 全局变量
        /// </summary>
        private static SnapshotProvider DAL = SnapshotProvider.GetInstance();


        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static bool ExistSnapshot(string condition)
        {
            return DAL.ExistSnapshot(condition);
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static int AddSnapshot(Model.Snapshot model)
        {
            return DAL.AddSnapshot(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static bool UpdateSnapshot(Model.Snapshot model)
        {
            return DAL.UpdateSnapshot(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteSnapshot(int SnapshotID)
        {
            return DAL.DeleteSnapshot(SnapshotID);
        }



        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteSnapshotList(string SnapshotIDlist)
        {
            return DAL.DeleteSnapshotList(SnapshotIDlist);
        }


        /// <summary>
        /// 根据SnapshotID获取一条数据
        /// </summary>
        /// <param name="SnapshotID"></param>
        /// <returns></returns>
        public static Model.Snapshot GetSnapshotInfo(int SnapshotID)
        {
            return DAL.GetSnapshotInfo(SnapshotID);
        }
        /// <summary>
        /// 根据SnapshotID获取一条数据
        /// </summary>
        /// <param name="SnapshotID"></param>
        /// <returns></returns>
        public static Model.Snapshot GetSnapshotInfo(int SnapshotID, int UserID)
        {
            string condition = string.Format("SnapshotID={0} AND UserID={1}", SnapshotID, UserID);
            return DAL.GetSnapshotInfoByCondition(condition);
        }
        /// <summary>
        /// 根据过滤条件获取一条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static Model.Snapshot GetSnapshotInfoByCondition(string condition)
        {
            return DAL.GetSnapshotInfoByCondition(condition);
        }

        /// <summary>
        /// 获取全部的数据列表
        /// </summary>
        /// <returns></returns>
        public static List<Model.Snapshot> GetSnapshotList()
        {
            return DAL.GetSnapshotList();
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.Snapshot> GetSnapshotList(string condition)
        {
            return DAL.GetSnapshotList(condition);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.Snapshot> GetSnapshotList(int pagesize, int pageindex, string condition)
        {
            return DAL.GetSnapshotList(pagesize, pageindex, condition);
        }

        /// <summary>
        /// 根据SnapshotID数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="sorttype">排序类型（ASC，DESC）</param>
        /// <returns></returns>
        public static List<Model.Snapshot> GetSnapshotList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            return DAL.GetSnapshotList(pagesize, pageindex, condition, orderby, sorttype);
        }


        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="tableName">表名或视图名</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int GetSnapshotCount(string condition)
        {
            return DAL.GetSnapshotCount(condition);
        }
        #endregion

        #region MethodEx

        /// <summary>
        /// 根据订单ID获取快照列表信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<Snapshot> GetSnapshotList(int orderId, int userID)
        {
            return GetSnapshotList("OrderID=" + orderId + " AND UserID=" + userID);
        }

        /// <summary>
        /// 根据订单ID获取快照列表信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static List<Snapshot> GetSnapshotListByOrderID(int orderId)
        {
            return GetSnapshotList("OrderID=" + orderId);
        }

        #endregion
    }
}