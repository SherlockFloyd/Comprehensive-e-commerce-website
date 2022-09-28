
using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Shopping.Common;
using Shopping.Data;
using Shopping.Model;

namespace Shopping.DAL
{
    
    /// </summary>
    public partial class NoticeProvider : SqlDB<NoticeProvider>
    {
        /// <summary>
        /// 数据库表名
        /// </summary>
        private static string tableName = "Shopping_Notice";
        /// <summary>
        /// 数据库视图名
        /// </summary>
        private static string viewName = tableName;
        /// <summary>
        /// 数据查询语句(查询全部数据)
        /// </summary>
        private string select_strsql = "Select * from " + viewName;


        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string insert_strsql = "Insert into " + tableName + " (Title,Content,CreateTime,AdminID)values(@Title,@Content,@CreateTime,@AdminID)";
        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string count_strsql = "Select Count(*) From " + viewName;
        /// <summary>
        /// 数据更新语句
        /// </summary>
        private string update_strsql = "Update  " + tableName + " Set Title= @Title ,Content= @Content ,CreateTime= @CreateTime ,AdminID= @AdminID   where NoticeID=@NoticeID  ";
        /// <summary>
        /// 数据删除语句(根据主键删除)
        /// </summary>
        private string delete_strsql = "Delete  From " + tableName + "  where NoticeID=@NoticeID";


        #region  判断是否存在
        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public bool ExistNotice(string condition)
        {
            return this.GetCount(tableName, condition) > 0 ? true : false;
        }
        #endregion


        #region 添加一条记录
        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public int AddNotice(Model.Notice model)
        {
            SqlParameter[] parameters = {
			            
             SqlHelper.MakeInParam("@Title", SqlDbType.NVarChar,250,model.Title) ,                        
             SqlHelper.MakeInParam("@Content", SqlDbType.NText,model.Content) ,                        
             SqlHelper.MakeInParam("@CreateTime", SqlDbType.DateTime,model.CreateTime) ,                        
             SqlHelper.MakeInParam("@AdminID", SqlDbType.Int,4,model.AdminID)               
            };

            int resultId = 0;
            SqlHelper.ExecuteNonQuery(out resultId, CommandType.Text, insert_strsql, parameters);
            return resultId;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public bool UpdateNotice(Model.Notice model)
        {
            SqlParameter[] parameters = {
			           		 SqlHelper.MakeInParam("@NoticeID", SqlDbType.Int,4, model.NoticeID) ,            
                       		 SqlHelper.MakeInParam("@Title", SqlDbType.NVarChar,250, model.Title) ,            
                       		 SqlHelper.MakeInParam("@Content", SqlDbType.NText, model.Content) ,            
                       		 SqlHelper.MakeInParam("@CreateTime", SqlDbType.DateTime, model.CreateTime) ,            
                       		 SqlHelper.MakeInParam("@AdminID", SqlDbType.Int,4, model.AdminID)             
              
            
            };

            return SqlHelper.ExecuteNonQuery(CommandType.Text, update_strsql, parameters) > 0 ? true : false;
        }
        #endregion

        #region  删除数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteNotice(int NoticeID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@NoticeID", SqlDbType.Int,4)
			};
            parameters[0].Value = NoticeID;

            return SqlHelper.ExecuteNonQuery(CommandType.Text, delete_strsql, parameters) > 0 ? true : false;

        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteNoticeList(string NoticeIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + tableName + " where NoticeID in (" + NoticeIDlist + ")  ");
            return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString()) > 0 ? true : false;
        }
        #endregion


        #region 获取对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private Model.Notice GetNoticeInfo(SqlDataReader dr)
        {
            Model.Notice model = new Model.Notice();
            model.NoticeID = Utils.StrToInt(dr["NoticeID"]);


            model.Title = dr["Title"].ToString();

            model.Content = dr["Content"].ToString();
            model.CreateTime = Utils.StrToDateTime(dr["CreateTime"].ToString());

            model.AdminID = Utils.StrToInt(dr["AdminID"]);


            return model;
        }
        #endregion

        #region  获取一条数据
        /// <summary>
        /// 根据NoticeID获取一条数据
        /// </summary>
        /// <param name="NoticeID"></param>
        /// <returns></returns>
        public Model.Notice GetNoticeInfo(int NoticeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from " + viewName + " where NoticeID=@NoticeID");

            SqlParameter[] parameters = {
					new SqlParameter("@NoticeID", SqlDbType.Int,4)
			};
            parameters[0].Value = NoticeID;

            SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters);
            while (dr.Read())
            {
                return GetNoticeInfo(dr);
            }
            dr.Close();
            dr.Dispose();
            return null;
        }
        /// <summary>
        /// 根据过滤条件获取一条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public Model.Notice GetNoticeInfoByCondition(string condition)
        {
            if (condition == "")
            {
                return null;
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From " + viewName + " where " + condition);

            SqlDataReader dr = SqlHelper.ExecuteReader(strSql.ToString());
            while (dr.Read())
            {
                return GetNoticeInfo(dr);
            }
            dr.Close();
            dr.Dispose();
            return null;
        }
        #endregion

        #region 获取数据列表
        /// <summary>
        /// 获取全部的数据列表
        /// </summary>
        /// <returns></returns>
        public List<Model.Notice> GetNoticeList()
        {
            List<Model.Notice> list = new List<Model.Notice>();
            SqlDataReader dr = SqlHelper.ExecuteReader(select_strsql);
            while (dr.Read())
            {
                list.Add(GetNoticeInfo(dr));
            }
            dr.Close();
            dr.Dispose();
            return list;
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public List<Model.Notice> GetNoticeList(string condition)
        {
            string strSql = select_strsql + " where ";

            if (condition == "")
            {
                condition = "1=1";
            }
            strSql += condition;
            List<Model.Notice> list = new List<Model.Notice>();
            SqlDataReader dr = SqlHelper.ExecuteReader(strSql);
            while (dr.Read())
            {
                list.Add(GetNoticeInfo(dr));
            }
            dr.Close();
            dr.Dispose();
            return list;
        }

        /// <summary>
        /// 获取数据列表[默认ASC排序]
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public List<Model.Notice> GetNoticeList(int pagesize, int pageindex, string condition)
        {
            List<Model.Notice> list = new List<Model.Notice>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, "NoticeID", "ASC");
            while (dr.Read())
            {
                list.Add(GetNoticeInfo(dr));
            }
            dr.Close();
            dr.Dispose();
            return list;
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="sorttype">排序类型（ASC，DESC）</param>
        /// <returns></returns>
        public List<Model.Notice> GetNoticeList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            List<Model.Notice> list = new List<Model.Notice>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, orderby, sorttype);
            while (dr.Read())
            {
                list.Add(GetNoticeInfo(dr));
            }
            dr.Close();
            dr.Dispose();
            return list;
        }
        #endregion

        #region 获取数据总数
        /// <summary>
        /// 获取数据总数
        /// </summary>
        /// <param name="tableName">表名或视图名</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public int GetNoticeCount(string condition)
        {
            return this.GetCount(viewName, condition);
        }
        #endregion

    }
}