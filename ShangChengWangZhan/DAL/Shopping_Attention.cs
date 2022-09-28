
using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Shopping.Model;
using Shopping.Common;
using Shopping.Data;

namespace Shopping.Data
{
    
    /// </summary>
    public partial class AttentionProvider : SqlDB<AttentionProvider>
    {
        #region Method
        /// <summary>
        /// 数据库表名
        /// </summary>
        private static string tableName = "Shopping_Attention";
        /// <summary>
        /// 数据库视图名
        /// </summary>
        private static string viewName = "Shopping_View_Attention";
        /// <summary>
        /// 数据查询语句(查询全部数据)
        /// </summary>
        private string select_strsql = "Select * from " + viewName;


        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string insert_strsql = "Insert into " + tableName + " (CommodityID,CommodityName,UserID,CreateTime)values(@CommodityID,@CommodityName,@UserID,@CreateTime)";
        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string count_strsql = "Select Count(*) From " + viewName;
        /// <summary>
        /// 数据更新语句
        /// </summary>
        private string update_strsql = "Update  " + tableName + " Set CommodityID= @CommodityID ,CommodityName= @CommodityName ,UserID= @UserID ,CreateTime= @CreateTime   where AttentionID=@AttentionID  ";
        /// <summary>
        /// 数据删除语句(根据主键删除)
        /// </summary>
        private string delete_strsql = "Delete  From " + tableName + "  where AttentionID=@AttentionID";


        #region  判断是否存在
        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public bool ExistAttention(string condition)
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
        public int AddAttention(Model.Attention model)
        {
            SqlParameter[] parameters = {
			            
             SqlHelper.MakeInParam("@CommodityID", SqlDbType.Int,4,model.CommodityID) ,                        
             SqlHelper.MakeInParam("@CommodityName", SqlDbType.NVarChar,250,model.CommodityName) ,                        
             SqlHelper.MakeInParam("@UserID", SqlDbType.Int,4,model.UserID) ,                        
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
        public bool UpdateAttention(Model.Attention model)
        {
            SqlParameter[] parameters = {
			           		 SqlHelper.MakeInParam("@AttentionID", SqlDbType.Int,4, model.AttentionID) ,            
                       		 SqlHelper.MakeInParam("@CommodityID", SqlDbType.Int,4, model.CommodityID) ,            
                       		 SqlHelper.MakeInParam("@CommodityName", SqlDbType.NVarChar,250, model.CommodityName) ,            
                       		 SqlHelper.MakeInParam("@UserID", SqlDbType.Int,4, model.UserID) ,            
                       		 SqlHelper.MakeInParam("@CreateTime", SqlDbType.DateTime, model.CreateTime)             
              
            
            };

            return SqlHelper.ExecuteNonQuery(CommandType.Text, update_strsql, parameters) > 0 ? true : false;
        }
        #endregion

        #region  删除数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteAttention(int AttentionID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@AttentionID", SqlDbType.Int,4)
			};
            parameters[0].Value = AttentionID;

            return SqlHelper.ExecuteNonQuery(CommandType.Text, delete_strsql, parameters) > 0 ? true : false;

        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteAttentionList(string AttentionIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + tableName + " where AttentionID in (" + AttentionIDlist + ")  ");
            return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString()) > 0 ? true : false;
        }
        #endregion


        #region 获取对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private Model.Attention GetAttentionInfo(SqlDataReader dr)
        {
            Model.Attention model = new Model.Attention();
            model.AttentionID = Utils.StrToInt(dr["AttentionID"]);
            model.CommodityID = Utils.StrToInt(dr["CommodityID"]);
            model.Photo = dr["Photo"].ToString();
            model.CommodityName = dr["CommodityName"].ToString(); model.UserID = Utils.StrToInt(dr["UserID"]);
            model.CreateTime = Utils.StrToDateTime(dr["CreateTime"].ToString());

            return model;
        }
        #endregion

        #region  获取一条数据
        /// <summary>
        /// 根据AttentionID获取一条数据
        /// </summary>
        /// <param name="AttentionID"></param>
        /// <returns></returns>
        public Model.Attention GetAttentionInfo(int AttentionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from " + viewName + " where AttentionID=@AttentionID");
            SqlParameter[] parameters = {
					new SqlParameter("@AttentionID", SqlDbType.Int,4)
			};
            parameters[0].Value = AttentionID;

            SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters);
            while (dr.Read())
            {
                return GetAttentionInfo(dr);
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
        public Model.Attention GetAttentionInfoByCondition(string condition)
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
                return GetAttentionInfo(dr);
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
        public List<Model.Attention> GetAttentionList()
        {
            List<Model.Attention> list = new List<Model.Attention>();
            SqlDataReader dr = SqlHelper.ExecuteReader(select_strsql);
            while (dr.Read())
            {
                list.Add(GetAttentionInfo(dr));
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
        public List<Model.Attention> GetAttentionList(string condition)
        {
            string strSql = select_strsql + " where ";

            if (condition == "")
            {
                condition = "1=1";
            }
            strSql += condition;
            List<Model.Attention> list = new List<Model.Attention>();
            SqlDataReader dr = SqlHelper.ExecuteReader(strSql);
            while (dr.Read())
            {
                list.Add(GetAttentionInfo(dr));
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
        public List<Model.Attention> GetAttentionList(int pagesize, int pageindex, string condition)
        {
            List<Model.Attention> list = new List<Model.Attention>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, "AttentionID", "ASC");
            while (dr.Read())
            {
                list.Add(GetAttentionInfo(dr));
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
        public List<Model.Attention> GetAttentionList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            List<Model.Attention> list = new List<Model.Attention>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, orderby, sorttype);
            while (dr.Read())
            {
                list.Add(GetAttentionInfo(dr));
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
        public int GetAttentionCount(string condition)
        {
            return this.GetCount(viewName, condition);
        }
        #endregion

        #endregion

        #region MethodEx
        #endregion
    }
}