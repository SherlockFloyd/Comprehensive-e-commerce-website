
using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Shopping.Model;
using Shopping.DAL;


namespace Shopping.BLL
{

    ///sitLog
    /// 主要完成对DAL层的调用
    /// </summary>
    public class VisitLogBLL
    {
        #region #Method
        /// <summary>
        /// 全局变量
        /// </summary>
        private static VisitLogProvider DAL = VisitLogProvider.GetInstance();


        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static bool ExistVisitLog(string condition)
        {
            return DAL.ExistVisitLog(condition);
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static int AddVisitLog(Model.VisitLog model)
        {
            return DAL.AddVisitLog(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static bool UpdateVisitLog(Model.VisitLog model)
        {
            return DAL.UpdateVisitLog(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteVisitLog(int LogID)
        {
            return DAL.DeleteVisitLog(LogID);
        }



        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteVisitLogList(string LogIDlist)
        {
            return DAL.DeleteVisitLogList(LogIDlist);
        }


        /// <summary>
        /// 根据LogID获取一条数据
        /// </summary>
        /// <param name="LogID"></param>
        /// <returns></returns>
        public static Model.VisitLog GetVisitLogInfo(int LogID)
        {
            return DAL.GetVisitLogInfo(LogID);
        }

        /// <summary>
        /// 根据过滤条件获取一条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static Model.VisitLog GetVisitLogInfoByCondition(string condition)
        {
            return DAL.GetVisitLogInfoByCondition(condition);
        }

        /// <summary>
        /// 获取全部的数据列表
        /// </summary>
        /// <returns></returns>
        public static List<Model.VisitLog> GetVisitLogList()
        {
            return DAL.GetVisitLogList();
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.VisitLog> GetVisitLogList(string condition)
        {
            return DAL.GetVisitLogList(condition);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.VisitLog> GetVisitLogList(int pagesize, int pageindex, string condition)
        {
            return DAL.GetVisitLogList(pagesize, pageindex, condition);
        }

        /// <summary>
        /// 根据LogID数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="sorttype">排序类型（ASC，DESC）</param>
        /// <returns></returns>
        public static List<Model.VisitLog> GetVisitLogList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            return DAL.GetVisitLogList(pagesize, pageindex, condition, orderby, sorttype);
        }


        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="tableName">表名或视图名</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int GetVisitLogCount(string condition)
        {
            return DAL.GetVisitLogCount(condition);
        }
        #endregion

        #region MethodEx


        /// <summary>
        /// 删除本地游客的访问记录
        /// </summary>
        /// <param name="GuestID"></param>
        /// <returns></returns>
        public static bool DeleteVisitLogByGuestID(string GuestID)
        {
            return DAL.DeleteVisitLogByGuestID(GuestID);
        }

        /// <summary>
        /// 获取访问记录列表
        /// </summary>
        /// <param name="top"></param>
        /// <param name="GuestID"></param>
        /// <returns></returns>
        public static List<Model.VisitLog> GetVisitLogListByGuestID(int top, string GuestID)
        {
            return DAL.GetVisitLogListByGuestID(top, GuestID);
        }

        /// <summary>
        /// 获取访问记录列表
        /// </summary>
        /// <param name="top"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static List<Model.VisitLog> GetVisitLogListByUserID(int top, int UserID)
        {
            return DAL.GetVisitLogListByUserID(top, UserID);
        }
        /// <summary>
        /// 获取看过此商品的人还看过的商品信息
        /// </summary>
        /// <param name="CommodityID"></param>
        /// <returns></returns>
        public static DataTable GetVisitLogOther(int top, int CommodityID)
        {
            return DAL.GetVisitLogOther(top, CommodityID);
        }
        #endregion
    }
}