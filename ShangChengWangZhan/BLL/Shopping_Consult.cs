
using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Shopping.Model;
using Shopping.Data;


namespace Shopping
{

  
    public class ConsultBLL
    {
        #region #Method
        /// <summary>
        /// 全局变量
        /// </summary>
        private static ConsultProvider DAL = ConsultProvider.GetInstance();


        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static bool ExistConsult(string condition)
        {
            return DAL.ExistConsult(condition);
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static int AddConsult(Model.Consult model)
        {
            return DAL.AddConsult(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static bool UpdateConsult(Model.Consult model)
        {
            return DAL.UpdateConsult(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteConsult(int ConsultID)
        {
            return DAL.DeleteConsult(ConsultID);
        }



        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteConsultList(string ConsultIDlist)
        {
            return DAL.DeleteConsultList(ConsultIDlist);
        }


        /// <summary>
        /// 根据ConsultID获取一条数据
        /// </summary>
        /// <param name="ConsultID"></param>
        /// <returns></returns>
        public static Model.Consult GetConsultInfo(int ConsultID)
        {
            return DAL.GetConsultInfo(ConsultID);
        }
        /// <summary>
        /// 根据ConsultID获取一条数据
        /// </summary>
        /// <param name="ConsultID"></param>
        /// <returns></returns>
        public static Model.Consult GetConsultInfo(int ConsultID, int UserID)
        {
            return DAL.GetConsultInfoByCondition("ConsultID=" + ConsultID + " AND UserID=" + UserID);
        }
        /// <summary>
        /// 根据过滤条件获取一条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static Model.Consult GetConsultInfoByCondition(string condition)
        {
            return DAL.GetConsultInfoByCondition(condition);
        }

        /// <summary>
        /// 获取全部的数据列表
        /// </summary>
        /// <returns></returns>
        public static List<Model.Consult> GetConsultList()
        {
            return DAL.GetConsultList();
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.Consult> GetConsultList(string condition)
        {
            return DAL.GetConsultList(condition);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.Consult> GetConsultList(int pagesize, int pageindex, string condition)
        {
            return DAL.GetConsultList(pagesize, pageindex, condition);
        }

        /// <summary>
        /// 根据ConsultID数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="sorttype">排序类型（ASC，DESC）</param>
        /// <returns></returns>
        public static List<Model.Consult> GetConsultList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            return DAL.GetConsultList(pagesize, pageindex, condition, orderby, sorttype);
        }


        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="tableName">表名或视图名</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int GetConsultCount(string condition)
        {
            return DAL.GetConsultCount(condition);
        }
        #endregion

        #region MethodEx
        #endregion
    }
}