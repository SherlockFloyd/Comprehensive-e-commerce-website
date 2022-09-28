
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
    public class NewsBLL
    {

        /// <summary>
        /// 全局变量
        /// </summary>
        private static NewsProvider DAL = NewsProvider.GetInstance();


        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static bool ExistNotice(string condition)
        {
            return DAL.ExistNotice(condition);
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static int AddNotice(Model.News model)
        {
            return DAL.AddNotice(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static bool UpdateNotice(Model.News model)
        {
            return DAL.UpdateNotice(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteNotice(int NoticeID)
        {
            return DAL.DeleteNotice(NoticeID);
        }



        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteNoticeList(string NoticeIDlist)
        {
            return DAL.DeleteNoticeList(NoticeIDlist);
        }


        /// <summary>
        /// 根据NoticeID获取一条数据
        /// </summary>
        /// <param name="NoticeID"></param>
        /// <returns></returns>
        public static Model.News GetNoticeInfo(int NoticeID)
        {
            return DAL.GetNoticeInfo(NoticeID);
        }

        /// <summary>
        /// 根据过滤条件获取一条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static Model.News GetNoticeInfoByCondition(string condition)
        {
            return DAL.GetNoticeInfoByCondition(condition);
        }

        /// <summary>
        /// 获取全部的数据列表
        /// </summary>
        /// <returns></returns>
        public static List<Model.News> GetNoticeList()
        {
            return DAL.GetNoticeList();
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.News> GetNoticeList(string condition)
        {
            return DAL.GetNoticeList(condition);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.News> GetNoticeList(int pagesize, int pageindex, string condition)
        {
            return DAL.GetNoticeList(pagesize, pageindex, condition);
        }

        /// <summary>
        /// 根据NoticeID数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="sorttype">排序类型（ASC，DESC）</param>
        /// <returns></returns>
        public static List<Model.News> GetNoticeList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            return DAL.GetNoticeList(pagesize, pageindex, condition, orderby, sorttype);
        }


        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="tableName">表名或视图名</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int GetNoticeCount(string condition)
        {
            return DAL.GetNoticeCount(condition);
        }
    }
}