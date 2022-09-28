
using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;


using Shopping.DAL;

namespace Shopping
{

    //
    /// </summary>
    public class UsePointLogBLL
    {
        #region #Method
        /// <summary>
        /// 全局变量
        /// </summary>
        private static UsePointLogProvider DAL = UsePointLogProvider.GetInstance();


        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static bool ExistUsePointLog(string condition)
        {
            return DAL.ExistUsePointLog(condition);
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static int AddUsePointLog(Model.UsePointLog model)
        {
            return DAL.AddUsePointLog(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static bool UpdateUsePointLog(Model.UsePointLog model)
        {
            return DAL.UpdateUsePointLog(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteUsePointLog(int LogID)
        {
            return DAL.DeleteUsePointLog(LogID);
        }



        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteUsePointLogList(string LogIDlist)
        {
            return DAL.DeleteUsePointLogList(LogIDlist);
        }


        /// <summary>
        /// 根据LogID获取一条数据
        /// </summary>
        /// <param name="LogID"></param>
        /// <returns></returns>
        public static Model.UsePointLog GetUsePointLogInfo(int LogID)
        {
            return DAL.GetUsePointLogInfo(LogID);
        }

        /// <summary>
        /// 根据过滤条件获取一条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static Model.UsePointLog GetUsePointLogInfoByCondition(string condition)
        {
            return DAL.GetUsePointLogInfoByCondition(condition);
        }

        /// <summary>
        /// 获取全部的数据列表
        /// </summary>
        /// <returns></returns>
        public static List<Model.UsePointLog> GetUsePointLogList()
        {
            return DAL.GetUsePointLogList();
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.UsePointLog> GetUsePointLogList(string condition)
        {
            return DAL.GetUsePointLogList(condition);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.UsePointLog> GetUsePointLogList(int pagesize, int pageindex, string condition)
        {
            return DAL.GetUsePointLogList(pagesize, pageindex, condition);
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
        public static List<Model.UsePointLog> GetUsePointLogList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            return DAL.GetUsePointLogList(pagesize, pageindex, condition, orderby, sorttype);
        }


        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="tableName">表名或视图名</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int GetUsePointLogCount(string condition)
        {
            return DAL.GetUsePointLogCount(condition);
        }
        #endregion

        #region MethodEx

        /// <summary>
        /// 添加一条积分使用记录并且更新用户账户的积分总数
        /// </summary>
        public static void CreateUserPointLog(int userId, int point, int orderId, string message)
        {


            Model.UsePointLog model = new Model.UsePointLog()
            {
                IP = Shopping.Common.Requests.GetIP(),
                Point = point,
                Message = message,
                UserID = userId,
                OrderID = orderId,
                Status = 1,
                UpdateTime = DateTime.Now
            };

            if (model.Point != 0)
            {
                if (AddUsePointLog(model) > 0)
                {
                    UserBLL.UpdateUserPoint(userId, point);
                }
            }
        }
        #endregion
    }
}