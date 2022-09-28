
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
  
    /// </summary>
    public partial class RateProvider : SqlDB<RateProvider>
    {
        /// <summary>
        /// 数据库表名
        /// </summary>
        private static string tableName = "Shopping_Rate";
        /// <summary>
        /// 数据库视图名
        /// </summary>
        private static string viewName = "Shopping_View_Rate";
        /// <summary>
        /// 数据查询语句(查询全部数据)
        /// </summary>
        private string select_strsql = "Select * from " + viewName;


        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string insert_strsql = "Insert into " + tableName + " (SnapshotID,Grade,RateContent,RateTime,ReplyContent,ReplyTime,UserID,CommodityID)values(@SnapshotID,@Grade,@RateContent,@RateTime,@ReplyContent,@ReplyTime,@UserID,@CommodityID)";
        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string count_strsql = "Select Count(*) From " + viewName;
        /// <summary>
        /// 数据更新语句
        /// </summary>
        private string update_strsql = "Update  " + tableName + " Set SnapshotID= @SnapshotID ,Grade= @Grade ,RateContent= @RateContent ,RateTime= @RateTime ,ReplyContent= @ReplyContent ,ReplyTime= @ReplyTime ,UserID= @UserID ,CommodityID= @CommodityID   where RateID=@RateID  ";
        /// <summary>
        /// 数据删除语句(根据主键删除)
        /// </summary>
        private string delete_strsql = "Delete  From " + tableName + "  where RateID=@RateID";


        #region  判断是否存在
        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public bool ExistRate(string condition)
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
        public int AddRate(Model.Rate model)
        {
            SqlParameter[] parameters = {
			            
             SqlHelper.MakeInParam("@SnapshotID", SqlDbType.Int,4,model.SnapshotID) ,                        
             SqlHelper.MakeInParam("@Grade", SqlDbType.Int,4,model.Grade) ,                        
             SqlHelper.MakeInParam("@RateContent", SqlDbType.NText,model.RateContent) ,                        
             SqlHelper.MakeInParam("@RateTime", SqlDbType.DateTime,model.RateTime) ,                        
             SqlHelper.MakeInParam("@ReplyContent", SqlDbType.NText,model.ReplyContent) ,                        
             SqlHelper.MakeInParam("@ReplyTime", SqlDbType.DateTime,model.ReplyTime) ,                        
             SqlHelper.MakeInParam("@UserID", SqlDbType.Int,4,model.UserID) ,                        
             SqlHelper.MakeInParam("@CommodityID", SqlDbType.Int,4,model.CommodityID)               
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
        public bool UpdateRate(Model.Rate model)
        {
            SqlParameter[] parameters = {
			           		 SqlHelper.MakeInParam("@RateID", SqlDbType.Int,4, model.RateID) ,            
                       		 SqlHelper.MakeInParam("@SnapshotID", SqlDbType.Int,4, model.SnapshotID) ,            
                       		 SqlHelper.MakeInParam("@Grade", SqlDbType.Int,4, model.Grade) ,            
                       		 SqlHelper.MakeInParam("@RateContent", SqlDbType.NText, model.RateContent) ,            
                       		 SqlHelper.MakeInParam("@RateTime", SqlDbType.DateTime, model.RateTime) ,            
                       		 SqlHelper.MakeInParam("@ReplyContent", SqlDbType.NText, model.ReplyContent) ,            
                       		 SqlHelper.MakeInParam("@ReplyTime", SqlDbType.DateTime, model.ReplyTime) ,            
                       		 SqlHelper.MakeInParam("@UserID", SqlDbType.Int,4, model.UserID) ,            
                       		 SqlHelper.MakeInParam("@CommodityID", SqlDbType.Int,4, model.CommodityID)             
              
            
            };

            return SqlHelper.ExecuteNonQuery(CommandType.Text, update_strsql, parameters) > 0 ? true : false;
        }
        #endregion

        #region  删除数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteRate(int RateID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@RateID", SqlDbType.Int,4)
			};
            parameters[0].Value = RateID;

            return SqlHelper.ExecuteNonQuery(CommandType.Text, delete_strsql, parameters) > 0 ? true : false;

        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteRateList(string RateIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + tableName + " where RateID in (" + RateIDlist + ")  ");
            return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString()) > 0 ? true : false;
        }
        #endregion


        #region 获取对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private Model.Rate GetRateInfo(SqlDataReader dr)
        {
            Model.Rate model = new Model.Rate();
            model.RateID = Utils.StrToInt(dr["RateID"]);
            model.SnapshotID = Utils.StrToInt(dr["SnapshotID"]);
            model.Grade = Utils.StrToInt(dr["Grade"]);
            model.RateContent = dr["RateContent"].ToString();
            model.RateTime = Utils.StrToDateTime(dr["RateTime"].ToString());
            model.ReplyContent = dr["ReplyContent"].ToString();
            model.ReplyTime = Utils.StrToDateTime(dr["ReplyTime"].ToString());
            model.UserID = Utils.StrToInt(dr["UserID"]);
            model.CommodityID = Utils.StrToInt(dr["CommodityID"]);
            model.UserName = dr["UserName"].ToString();
            return model;
        }
        #endregion

        #region  获取一条数据
        /// <summary>
        /// 根据RateID获取一条数据
        /// </summary>
        /// <param name="RateID"></param>
        /// <returns></returns>
        public Model.Rate GetRateInfo(int RateID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from " + viewName + " where RateID=@RateID");

            SqlParameter[] parameters = {
					new SqlParameter("@RateID", SqlDbType.Int,4)
			};
            parameters[0].Value = RateID;

            SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters);
            while (dr.Read())
            {
                return GetRateInfo(dr);
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
        public Model.Rate GetRateInfoByCondition(string condition)
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
                return GetRateInfo(dr);
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
        public List<Model.Rate> GetRateList()
        {
            List<Model.Rate> list = new List<Model.Rate>();
            SqlDataReader dr = SqlHelper.ExecuteReader(select_strsql);
            while (dr.Read())
            {
                list.Add(GetRateInfo(dr));
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
        public List<Model.Rate> GetRateList(string condition)
        {
            string strSql = select_strsql + " where ";

            if (condition == "")
            {
                condition = "1=1";
            }
            strSql += condition;
            List<Model.Rate> list = new List<Model.Rate>();
            SqlDataReader dr = SqlHelper.ExecuteReader(strSql);
            while (dr.Read())
            {
                list.Add(GetRateInfo(dr));
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
        public List<Model.Rate> GetRateList(int pagesize, int pageindex, string condition)
        {
            List<Model.Rate> list = new List<Model.Rate>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, "RateID", "ASC");
            while (dr.Read())
            {
                list.Add(GetRateInfo(dr));
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
        public List<Model.Rate> GetRateList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            List<Model.Rate> list = new List<Model.Rate>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, orderby, sorttype);
            while (dr.Read())
            {
                list.Add(GetRateInfo(dr));
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
        public int GetRateCount(string condition)
        {
            return this.GetCount(viewName, condition);
        }
        #endregion

    }
}