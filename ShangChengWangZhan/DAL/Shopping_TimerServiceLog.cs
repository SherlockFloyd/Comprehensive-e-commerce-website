
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
    ///	定时更新记录表
    ///	数据层实例化接口类 Shopping_TimerServiceLog
    /// 主要完成对数据库的基本操作
	/// </summary>
	public partial class TimerServiceLogProvider: SqlDB<TimerServiceLogProvider>
	{
		#region Method
		/// <summary>
        /// 数据库表名
        /// </summary>
		private static string tableName="Shopping_TimerServiceLog";
		/// <summary>
        /// 数据库视图名
        /// </summary>
        private static string viewName=tableName;
        /// <summary>
        /// 数据查询语句(查询全部数据)
        /// </summary>
        private string select_strsql="Select * from "+viewName;
        
        
        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string insert_strsql="Insert into "+tableName+" (LogName,StartTime,EndTime)values(@LogName,@StartTime,@EndTime)";
        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string count_strsql="Select Count(*) From "+viewName;        
        /// <summary>
        /// 数据更新语句
        /// </summary>
        private string update_strsql="Update  "+tableName+" Set LogName= @LogName ,StartTime= @StartTime ,EndTime= @EndTime   where LogID=@LogID  ";
        /// <summary>
        /// 数据删除语句(根据主键删除)
        /// </summary>
        private string delete_strsql="Delete  From "+tableName+"  where LogID=@LogID";
		
        
        #region  判断是否存在
		/// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
		public bool ExistTimerServiceLog(string condition)
		{
			return this.GetCount(tableName,condition)>0?true:false;
		}
		#endregion
        
        
        #region 添加一条记录
		/// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
		public int AddTimerServiceLog(Model.TimerServiceLog model)
		{
			SqlParameter[] parameters = {
			            
             SqlHelper.MakeInParam("@LogName", SqlDbType.NVarChar,250,model.LogName) ,                        
             SqlHelper.MakeInParam("@StartTime", SqlDbType.DateTime,model.StartTime) ,                        
             SqlHelper.MakeInParam("@EndTime", SqlDbType.DateTime,model.EndTime)               
            };
            
			int resultId=0;
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
		public bool UpdateTimerServiceLog(Model.TimerServiceLog model)
		{
			SqlParameter[] parameters = {
			           		 SqlHelper.MakeInParam("@LogID", SqlDbType.Int,4, model.LogID) ,            
                       		 SqlHelper.MakeInParam("@LogName", SqlDbType.NVarChar,250, model.LogName) ,            
                       		 SqlHelper.MakeInParam("@StartTime", SqlDbType.DateTime, model.StartTime) ,            
                       		 SqlHelper.MakeInParam("@EndTime", SqlDbType.DateTime, model.EndTime)             
              
            
            };
            
  			return SqlHelper.ExecuteNonQuery(CommandType.Text, update_strsql, parameters)>0?true:false;
		}
        #endregion
        
        #region  删除数据
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteTimerServiceLog(int LogID)
		{
						SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.Int,4)
			};
			parameters[0].Value = LogID;

			return  SqlHelper.ExecuteNonQuery(CommandType.Text, delete_strsql, parameters)>0?true:false;

		}
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteTimerServiceLogList(string LogIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from "+tableName+" where LogID in ("+LogIDlist + ")  ");
			return  SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString())>0?true:false;
		}
				#endregion
        
        
        #region 获取对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		private Model.TimerServiceLog GetTimerServiceLogInfo(SqlDataReader dr)
		{
			Model.TimerServiceLog model=new Model.TimerServiceLog();
							model.LogID=Utils.StrToInt(dr["LogID"]);										
																																									
												model.LogName= dr["LogName"].ToString();																											model.StartTime=Utils.StrToDateTime(dr["StartTime"].ToString());		
																																							model.EndTime=Utils.StrToDateTime(dr["EndTime"].ToString());		
																																	
			return model;
		}
        #endregion
        
        #region  获取一条数据
		/// <summary>
        /// 根据LogID获取一条数据
        /// </summary>
        /// <param name="LogID"></param>
        /// <returns></returns>
		public Model.TimerServiceLog GetTimerServiceLogInfo (int LogID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from "+viewName+" where LogID=@LogID");
						SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.Int,4)
			};
			parameters[0].Value = LogID;

			SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters);
            while (dr.Read())
            {
                return GetTimerServiceLogInfo(dr);
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
        public Model.TimerServiceLog GetTimerServiceLogInfoByCondition(string condition)
        {
        	if(condition=="")
            {
            	return null;
            }
        	StringBuilder strSql=new StringBuilder();
            strSql.Append("Select TOP 1 * From "+viewName+" where "+condition);
            SqlDataReader dr = SqlHelper.ExecuteReader(strSql.ToString());
            while (dr.Read())
            {
                return GetTimerServiceLogInfo(dr);
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
		public List<Model.TimerServiceLog> GetTimerServiceLogList()
        {
            List<Model.TimerServiceLog> list = new List<Model.TimerServiceLog>();
            SqlDataReader dr = SqlHelper.ExecuteReader(select_strsql);
            while (dr.Read())
            {
                list.Add(GetTimerServiceLogInfo(dr));
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
		public List<Model.TimerServiceLog> GetTimerServiceLogList(string condition)
        {
        	string strSql=select_strsql+" where ";
            
            if(condition=="")
            {
            	condition="1=1";
            }
            strSql+=condition;
            List<Model.TimerServiceLog> list = new List<Model.TimerServiceLog>();
            SqlDataReader dr = SqlHelper.ExecuteReader(strSql);
            while (dr.Read())
            {
                list.Add(GetTimerServiceLogInfo(dr));
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
		public List<Model.TimerServiceLog> GetTimerServiceLogList(int pagesize, int pageindex, string condition)
        {
            List<Model.TimerServiceLog> list = new List<Model.TimerServiceLog>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, "LogID", "ASC");
            while (dr.Read())
            {
                list.Add(GetTimerServiceLogInfo(dr));
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
		public List<Model.TimerServiceLog> GetTimerServiceLogList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            List<Model.TimerServiceLog> list = new List<Model.TimerServiceLog>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, orderby, sorttype);
            while (dr.Read())
            {
                list.Add(GetTimerServiceLogInfo(dr));
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
        public int GetTimerServiceLogCount(string condition)
        {
            return this.GetCount(viewName, condition);
        }
        #endregion
		
		#endregion
		
		#region MethodEx

        /// <summary>
        /// 更新结束时间
        /// </summary>
        /// <param name="LogID"></param>
        /// <returns></returns>
        public bool UpdateEndTime(int LogID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update Shopping_TimerServiceLog set EndTime = getdate() where LogID = " + LogID);
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0 ? true : false;
        }
       
		#endregion
	}
}