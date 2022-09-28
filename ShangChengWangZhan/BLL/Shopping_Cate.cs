
using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Shopping.DAL;

namespace Shopping.BLL
{

   
    public class CateBLL
    {

        /// <summary>
        /// 全局变量
        /// </summary>
        private static CateProvider DAL = CateProvider.GetInstance();


        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static bool ExistCate(string condition)
        {
            return DAL.ExistCate(condition);
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static int AddCate(Model.Cate model)
        {
            return DAL.AddCate(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static bool UpdateCate(Model.Cate model)
        {
            return DAL.UpdateCate(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteCate(int CateID)
        {
            return DAL.DeleteCate(CateID);
        }



        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteCateList(string CateIDlist)
        {
            return DAL.DeleteCateList(CateIDlist);
        }


        /// <summary>
        /// 根据CateID获取一条数据
        /// </summary>
        /// <param name="CateID"></param>
        /// <returns></returns>
        public static Model.Cate GetCateInfo(int CateID)
        {
            return DAL.GetCateInfo(CateID);
        }

        /// <summary>
        /// 根据过滤条件获取一条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static Model.Cate GetCateInfoByCondition(string condition)
        {
            return DAL.GetCateInfoByCondition(condition);
        }

        /// <summary>
        /// 获取全部的数据列表
        /// </summary>
        /// <returns></returns>
        public static List<Model.Cate> GetCateList()
        {
            return DAL.GetCateList();
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.Cate> GetCateList(string condition)
        {
            return DAL.GetCateList(condition);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.Cate> GetCateList(int pagesize, int pageindex, string condition)
        {
            return DAL.GetCateList(pagesize, pageindex, condition);
        }

        /// <summary>
        /// 根据CateID数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="sorttype">排序类型（ASC，DESC）</param>
        /// <returns></returns>
        public static List<Model.Cate> GetCateList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            return DAL.GetCateList(pagesize, pageindex, condition, orderby, sorttype);
        }


        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="tableName">表名或视图名</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int GetCateCount(string condition)
        {
            return DAL.GetCateCount(condition);
        }

 
         

    }
}