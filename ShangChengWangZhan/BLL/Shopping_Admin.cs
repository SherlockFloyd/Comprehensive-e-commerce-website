
using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Shopping.DAL;
using Shopping.Common;

namespace Shopping.BLL
{

    /// <summary>
    ///	管理员信息表
    ///	BLL逻辑层 Shopping_Admin
    /// 主要完成对DAL层的调用
    /// </summary>
    public class AdminBLL
    {
        /// <summary>
        /// 全局变量
        /// </summary>
        private static AdminProvider DAL = AdminProvider.GetInstance();

        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static bool ExistAdmin(string condition)
        {
            return DAL.ExistAdmin(condition);
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static int AddAdmin(Model.Admin model)
        {
            return DAL.AddAdmin(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static bool UpdateAdmin(Model.Admin model)
        {
            return DAL.UpdateAdmin(model);
        }

        /// <summary>
        /// 更新管理员登录信息
        /// </summary>
        /// <param name="adminInfo"></param>
        public static void UpdateAdminLoginInfo(Model.Admin adminInfo)
        {
            adminInfo.LoginIP = Requests.GetIP();
            adminInfo.LoginTime = DateTime.Now;
            adminInfo.LoginTimes += 1;
            adminInfo.LastLoginTime = adminInfo.LoginTime;
            adminInfo.LastLoginIP = adminInfo.LastLoginIP;
            UpdateAdmin(adminInfo);
        }
        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool UpdatePwd(int adminID, string password)
        {
            return DAL.UpdatePwd(adminID, password);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteAdmin(int AdminID)
        {
            return DAL.DeleteAdmin(AdminID);
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteAdminList(string AdminIDlist)
        {
            return DAL.DeleteAdminList(AdminIDlist);
        }

        /// <summary>
        /// 根据AdminID获取一条数据
        /// </summary>
        /// <param name="AdminID"></param>
        /// <returns></returns>
        public static Model.Admin GetAdminInfo(int AdminID)
        {
            return DAL.GetAdminInfo(AdminID);
        }

        /// <summary>
        /// 根据过滤条件获取一条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static Model.Admin GetAdminInfoByCondition(string condition)
        {
            return DAL.GetAdminInfoByCondition(condition);
        }

        /// <summary>
        /// 获取全部的数据列表
        /// </summary>
        /// <returns></returns>
        public static List<Model.Admin> GetAdminList()
        {
            return DAL.GetAdminList();
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.Admin> GetAdminList(string condition)
        {
            return DAL.GetAdminList(condition);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.Admin> GetAdminList(int pagesize, int pageindex, string condition)
        {
            return DAL.GetAdminList(pagesize, pageindex, condition);
        }

        /// <summary>
        /// 根据AdminID数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="sorttype">排序类型（ASC，DESC）</param>
        /// <returns></returns>
        public static List<Model.Admin> GetAdminList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            return DAL.GetAdminList(pagesize, pageindex, condition, orderby, sorttype);
        }


        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="tableName">表名或视图名</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int GetAdminCount(string condition)
        {
            return DAL.GetAdminCount(condition);
        }
    }
}