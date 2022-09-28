
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
    public partial class VisitLogProvider : SqlDB<VisitLogProvider>
    {
        #region Method
        /// <summary>
        /// 数据库表名
        /// </summary>
        private static string tableName = "Shopping_VisitLog";
        /// <summary>
        /// 数据库视图名
        /// </summary>
        private static string viewName = "Shopping_View_VisitLog";
        /// <summary>
        /// 数据查询语句(查询全部数据)
        /// </summary>
        private string select_strsql = "Select * from " + viewName;



        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string insert_strsql = "Insert into " + tableName + " (UserID,CommodityID,Visits,UpdateTime,GuestID)values(@UserID,@CommodityID,@Visits,@UpdateTime,@GuestID)";
        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string count_strsql = "Select Count(*) From " + viewName;
        /// <summary>
        /// 数据更新语句
        /// </summary>
        private string update_strsql = "Update  " + tableName + " Set UserID= @UserID ,CommodityID= @CommodityID ,Visits= @Visits ,UpdateTime= @UpdateTime ,GuestID= @GuestID   where LogID=@LogID  ";
        /// <summary>
        /// 数据删除语句(根据主键删除)
        /// </summary>
        private string delete_strsql = "Delete  From " + tableName + "  where LogID=@LogID";


        #region  判断是否存在
        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public bool ExistVisitLog(string condition)
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
        public int AddVisitLog(Model.VisitLog model)
        {
            SqlParameter[] parameters = {
			            
             SqlHelper.MakeInParam("@UserID", SqlDbType.Int,4,model.UserID) ,                        
             SqlHelper.MakeInParam("@CommodityID", SqlDbType.Int,4,model.CommodityID) ,                        
             SqlHelper.MakeInParam("@Visits", SqlDbType.Int,4,model.Visits) ,                        
             SqlHelper.MakeInParam("@UpdateTime", SqlDbType.DateTime,model.UpdateTime) ,                        
             SqlHelper.MakeInParam("@GuestID", SqlDbType.NVarChar,50,model.GuestID)               
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
        public bool UpdateVisitLog(Model.VisitLog model)
        {
            SqlParameter[] parameters = {
			           		 SqlHelper.MakeInParam("@LogID", SqlDbType.Int,4, model.LogID) ,            
                       		 SqlHelper.MakeInParam("@UserID", SqlDbType.Int,4, model.UserID) ,            
                       		 SqlHelper.MakeInParam("@CommodityID", SqlDbType.Int,4, model.CommodityID) ,            
                       		 SqlHelper.MakeInParam("@Visits", SqlDbType.Int,4, model.Visits) ,            
                       		 SqlHelper.MakeInParam("@UpdateTime", SqlDbType.DateTime, model.UpdateTime) ,            
                       		 SqlHelper.MakeInParam("@GuestID", SqlDbType.NVarChar,50, model.GuestID)             
              
            
            };

            return SqlHelper.ExecuteNonQuery(CommandType.Text, update_strsql, parameters) > 0 ? true : false;
        }
        #endregion

        #region  删除数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteVisitLog(int LogID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.Int,4)
			};
            parameters[0].Value = LogID;

            return SqlHelper.ExecuteNonQuery(CommandType.Text, delete_strsql, parameters) > 0 ? true : false;

        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteVisitLogList(string LogIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + tableName + " where LogID in (" + LogIDlist + ")  ");
            return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString()) > 0 ? true : false;
        }
        #endregion


        #region 获取对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private Model.VisitLog GetVisitLogInfo(SqlDataReader dr)
        {
            Model.VisitLog model = new Model.VisitLog();
            model.LogID = Utils.StrToInt(dr["LogID"]);
            model.MarketPrice = Utils.StrToDecimal(dr["MarketPrice"].ToString()); model.UserID = Utils.StrToInt(dr["UserID"]);
            model.CommodityID = Utils.StrToInt(dr["CommodityID"]);
            model.Visits = Utils.StrToInt(dr["Visits"]);
            model.UpdateTime = Utils.StrToDateTime(dr["UpdateTime"].ToString());
            model.GuestID = dr["GuestID"].ToString();
            model.Photo = dr["Photo"].ToString();
            model.Name = dr["Name"].ToString();
            model.Price = Utils.StrToDecimal(dr["Price"].ToString());
            return model;
        }
        #endregion

        #region  获取一条数据
        /// <summary>
        /// 根据LogID获取一条数据
        /// </summary>
        /// <param name="LogID"></param>
        /// <returns></returns>
        public Model.VisitLog GetVisitLogInfo(int LogID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from " + viewName + " where LogID=@LogID");
            SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.Int,4)
			};
            parameters[0].Value = LogID;

            SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters);
            while (dr.Read())
            {
                return GetVisitLogInfo(dr);
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
        public Model.VisitLog GetVisitLogInfoByCondition(string condition)
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
                return GetVisitLogInfo(dr);
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
        public List<Model.VisitLog> GetVisitLogList()
        {
            List<Model.VisitLog> list = new List<Model.VisitLog>();
            SqlDataReader dr = SqlHelper.ExecuteReader(select_strsql);
            while (dr.Read())
            {
                list.Add(GetVisitLogInfo(dr));
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
        public List<Model.VisitLog> GetVisitLogList(string condition)
        {
            string strSql = select_strsql + " where ";

            if (condition == "")
            {
                condition = "1=1";
            }
            strSql += condition;
            List<Model.VisitLog> list = new List<Model.VisitLog>();
            SqlDataReader dr = SqlHelper.ExecuteReader(strSql);
            while (dr.Read())
            {
                list.Add(GetVisitLogInfo(dr));
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
        public List<Model.VisitLog> GetVisitLogList(int pagesize, int pageindex, string condition)
        {
            List<Model.VisitLog> list = new List<Model.VisitLog>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, "LogID", "ASC");
            while (dr.Read())
            {
                list.Add(GetVisitLogInfo(dr));
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
        public List<Model.VisitLog> GetVisitLogList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            List<Model.VisitLog> list = new List<Model.VisitLog>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, orderby, sorttype);
            while (dr.Read())
            {
                list.Add(GetVisitLogInfo(dr));
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
        public int GetVisitLogCount(string condition)
        {
            return this.GetCount(viewName, condition);
        }
        #endregion

        #endregion

        #region MethodEx

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteVisitLogByGuestID(string GuestID)
        {
            string strSql = "DELETE FROM " + tableName + " Where GuestID='" + GuestID + "'";

            return SqlHelper.ExecuteNonQuery(strSql) > 0 ? true : false;

        }
        public List<Model.VisitLog> GetVisitLogListByGuestID(int top, string GuestID)
        {
            List<Model.VisitLog> list = new List<VisitLog>();
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT ");
            if (top > 0)
            {
                strSql.AppendFormat(" TOP {0} ", top);
            }
            strSql.AppendFormat(" * FROM {0} Where GuestID='{1}' Order BY UpdateTime DESC", viewName, GuestID);

            SqlDataReader dr = SqlHelper.ExecuteReader(strSql.ToString());

            while (dr.Read())
            {
                list.Add(GetVisitLogInfo(dr));
            }

            dr.Close();
            dr.Dispose();

            return list;
        }

        public List<Model.VisitLog> GetVisitLogListByUserID(int top, int UserID)
        {
            List<Model.VisitLog> list = new List<VisitLog>();
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT ");
            if (top > 0)
            {
                strSql.AppendFormat(" TOP {0} ", top);
            }
            strSql.AppendFormat(" * FROM {0} Where UserID={1} Order BY UpdateTime DESC", viewName, UserID);

            SqlDataReader dr = SqlHelper.ExecuteReader(strSql.ToString());

            while (dr.Read())
            {
                list.Add(GetVisitLogInfo(dr));
            }

            dr.Close();
            dr.Dispose();

            return list;
        }

        /// <summary>
        /// 获取看过此商品的人还看过的商品信息
        /// </summary>
        /// <param name="CommodityID"></param>
        /// <returns></returns>
        public DataTable GetVisitLogOther(int top,int CommodityID)
        {
            if (top <= 0)
            {
                top = 1;
            }

            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat("SELECT Top {0}  CommodityID,Price,photo, Name, sum(Visits) VisitsTotal FROM  {1} where UserID in( SELECT UserID from {1} where CommodityID={2}) and CommodityID!={2} Group by CommodityID,Price,photo, Name Order by VisitsTotal DESC", top, viewName, CommodityID);

            return SqlHelper.ExecuteDataset(strSql.ToString()).Tables[0];
        }

        #endregion
    }
}