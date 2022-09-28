
using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Shopping.Model;
using Shopping.Common;
using Shopping.Data;

namespace Shopping.DAL
{
  
    /// 主要完成对数据库的基本操作
    /// </summary>
    public partial class CateProvider : SqlDB<CateProvider>
    {
        #region Method
        /// <summary>
        /// 数据库表名
        /// </summary>
        private static string tableName = "Shopping_Cate";
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
        private string insert_strsql = "Insert into " + tableName + " (Name,CreateTime)values(@Name,@CreateTime)";
        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string count_strsql = "Select Count(*) From " + viewName;
        /// <summary>
        /// 数据更新语句
        /// </summary>
        private string update_strsql = "Update  " + tableName + " Set Name= @Name ,CreateTime= @CreateTime   where CateID=@CateID  ";
        /// <summary>
        /// 数据删除语句(根据主键删除)
        /// </summary>
        private string delete_strsql = "Delete  From " + tableName + "  where CateID=@CateID";


        #region  判断是否存在
        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public bool ExistCate(string condition)
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
        public int AddCate(Model.Cate model)
        {
            SqlParameter[] parameters = {
			            
             SqlHelper.MakeInParam("@Name", SqlDbType.NVarChar,200,model.Name) ,                        
             SqlHelper.MakeInParam("@CreateTime", SqlDbType.DateTime,model.CreateTime)               
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
        public bool UpdateCate(Model.Cate model)
        {
            SqlParameter[] parameters = {
			           		 SqlHelper.MakeInParam("@CateID", SqlDbType.Int,4, model.CateID) ,            
                       		 SqlHelper.MakeInParam("@Name", SqlDbType.NVarChar,200, model.Name) ,            
                       		 SqlHelper.MakeInParam("@CreateTime", SqlDbType.DateTime, model.CreateTime)             
              
            
            };

            return SqlHelper.ExecuteNonQuery(CommandType.Text, update_strsql, parameters) > 0 ? true : false;
        }
        #endregion

        #region  删除数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteCate(int CateID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@CateID", SqlDbType.Int,4)
			};
            parameters[0].Value = CateID;

            return SqlHelper.ExecuteNonQuery(CommandType.Text, delete_strsql, parameters) > 0 ? true : false;

        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteCateList(string CateIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + tableName + " where CateID in (" + CateIDlist + ")  ");
            return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString()) > 0 ? true : false;
        }
        #endregion


        #region 获取对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private Model.Cate GetCateInfo(SqlDataReader dr)
        {
            Model.Cate model = new Model.Cate();
            model.CateID = Utils.StrToInt(dr["CateID"]);

            model.Name = dr["Name"].ToString(); model.CreateTime = Utils.StrToDateTime(dr["CreateTime"].ToString());

            return model;
        }
        #endregion

        #region  获取一条数据
        /// <summary>
        /// 根据CateID获取一条数据
        /// </summary>
        /// <param name="CateID"></param>
        /// <returns></returns>
        public Model.Cate GetCateInfo(int CateID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from " + viewName + " where CateID=@CateID");
            SqlParameter[] parameters = {
					new SqlParameter("@CateID", SqlDbType.Int,4)
			};
            parameters[0].Value = CateID;

            SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters);
            while (dr.Read())
            {
                return GetCateInfo(dr);
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
        public Model.Cate GetCateInfoByCondition(string condition)
        {
            if (condition == "")
            {
                return null;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select TOP 1 * From " + viewName + " where " + condition);
            SqlDataReader dr = SqlHelper.ExecuteReader(strSql.ToString());
            while (dr.Read())
            {
                return GetCateInfo(dr);
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
        public List<Model.Cate> GetCateList()
        {
            List<Model.Cate> list = new List<Model.Cate>();
            SqlDataReader dr = SqlHelper.ExecuteReader(select_strsql);
            while (dr.Read())
            {
                list.Add(GetCateInfo(dr));
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
        public List<Model.Cate> GetCateList(string condition)
        {
            string strSql = select_strsql + " where ";

            if (condition == "")
            {
                condition = "1=1";
            }
            strSql += condition;
            List<Model.Cate> list = new List<Model.Cate>();
            SqlDataReader dr = SqlHelper.ExecuteReader(strSql);
            while (dr.Read())
            {
                list.Add(GetCateInfo(dr));
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
        public List<Model.Cate> GetCateList(int pagesize, int pageindex, string condition)
        {
            List<Model.Cate> list = new List<Model.Cate>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, "CateID", "ASC");
            while (dr.Read())
            {
                list.Add(GetCateInfo(dr));
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
        public List<Model.Cate> GetCateList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            List<Model.Cate> list = new List<Model.Cate>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, orderby, sorttype);
            while (dr.Read())
            {
                list.Add(GetCateInfo(dr));
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
        public int GetCateCount(string condition)
        {
            return this.GetCount(viewName, condition);
        }
        #endregion

        #endregion

        #region MethodEx
        #endregion
    }
}