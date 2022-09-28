
using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;


using Shopping.DAL;

namespace Shopping
{

   
    /// </summary>
    public class UserBLL
    {

        /// <summary>
        /// 全局变量
        /// </summary>
        private static UserProvider DAL = UserProvider.GetInstance();


        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static bool ExistUser(string condition)
        {
            return DAL.ExistUser(condition);
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static int AddUser(Model.User model)
        {
            return DAL.AddUser(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static bool UpdateUser(Model.User model)
        {
            return DAL.UpdateUser(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteUser(int UserID)
        {
            return DAL.DeleteUser(UserID);
        }



        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteUserList(string UserIDlist)
        {
            return DAL.DeleteUserList(UserIDlist);
        }


        /// <summary>
        /// 根据UserID获取一条数据
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static Model.User GetUserInfo(int UserID)
        {
            return DAL.GetUserInfo(UserID);
        }

        /// <summary>
        /// 根据UserName获取一条数据
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static Model.User GetUserByUserName(string userName)
        {
            return GetUserInfoByCondition("UserName='" + userName + "'");
        }

        /// <summary>
        /// 根据过滤条件获取一条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static Model.User GetUserInfoByCondition(string condition)
        {
            return DAL.GetUserInfoByCondition(condition);
        }

        /// <summary>
        /// 获取全部的数据列表
        /// </summary>
        /// <returns></returns>
        public static List<Model.User> GetUserList()
        {
            return DAL.GetUserList();
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.User> GetUserList(string condition)
        {
            return DAL.GetUserList(condition);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.User> GetUserList(int pagesize, int pageindex, string condition)
        {
            return DAL.GetUserList(pagesize, pageindex, condition);
        }

        /// <summary>
        /// 根据UserID数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="sorttype">排序类型（ASC，DESC）</param>
        /// <returns></returns>
        public static List<Model.User> GetUserList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            return DAL.GetUserList(pagesize, pageindex, condition, orderby, sorttype);
        }


        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="tableName">表名或视图名</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int GetUserCount(string condition)
        {
            return DAL.GetUserCount(condition);
        }


         /// <summary>
        /// 更新积分
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static bool UpdateUserPoint(int userID, int point)
        {
            return DAL.UpdateUserPoint(userID,point);
        }
    }
}