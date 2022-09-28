
using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Shopping.DAL;
using Shopping.Common;

namespace Shopping.BLL
{

    
    /// </summary>
    public class TimerServiceLogBLL
    {
        #region #Method
        /// <summary>
        /// 全局变量
        /// </summary>
        private static TimerServiceLogProvider DAL = TimerServiceLogProvider.GetInstance();


        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static bool ExistTimerServiceLog(string condition)
        {
            return DAL.ExistTimerServiceLog(condition);
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static int AddTimerServiceLog(Model.TimerServiceLog model)
        {
            return DAL.AddTimerServiceLog(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static bool UpdateTimerServiceLog(Model.TimerServiceLog model)
        {
            return DAL.UpdateTimerServiceLog(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteTimerServiceLog(int LogID)
        {
            return DAL.DeleteTimerServiceLog(LogID);
        }



        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteTimerServiceLogList(string LogIDlist)
        {
            return DAL.DeleteTimerServiceLogList(LogIDlist);
        }


        /// <summary>
        /// 根据LogID获取一条数据
        /// </summary>
        /// <param name="LogID"></param>
        /// <returns></returns>
        public static Model.TimerServiceLog GetTimerServiceLogInfo(int LogID)
        {
            return DAL.GetTimerServiceLogInfo(LogID);
        }

        /// <summary>
        /// 根据过滤条件获取一条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static Model.TimerServiceLog GetTimerServiceLogInfoByCondition(string condition)
        {
            return DAL.GetTimerServiceLogInfoByCondition(condition);
        }

        /// <summary>
        /// 获取全部的数据列表
        /// </summary>
        /// <returns></returns>
        public static List<Model.TimerServiceLog> GetTimerServiceLogList()
        {
            return DAL.GetTimerServiceLogList();
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.TimerServiceLog> GetTimerServiceLogList(string condition)
        {
            return DAL.GetTimerServiceLogList(condition);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.TimerServiceLog> GetTimerServiceLogList(int pagesize, int pageindex, string condition)
        {
            return DAL.GetTimerServiceLogList(pagesize, pageindex, condition);
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
        public static List<Model.TimerServiceLog> GetTimerServiceLogList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            return DAL.GetTimerServiceLogList(pagesize, pageindex, condition, orderby, sorttype);
        }


        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="tableName">表名或视图名</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int GetTimerServiceLogCount(string condition)
        {
            return DAL.GetTimerServiceLogCount(condition);
        }
        #endregion

        #region MethodEx
        /// <summary>
        /// 更新结束时间
        /// </summary>
        /// <param name="LogID"></param>
        /// <returns></returns>
        public static bool UpdateEndTime(int LogID)
        {
            return DAL.UpdateEndTime(LogID);
        }
        #endregion
    }
}