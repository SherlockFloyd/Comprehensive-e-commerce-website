
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

	public partial class UsePointLogProvider: SqlDB<UsePointLogProvider>
	{
		#region Method
		/// <summary>
        /// 数据库表名
        /// </summary>
		private static string tableName="Shopping_UsePointLog";
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
        private string insert_strsql="Insert into "+tableName+" (OrderID,Point,UserID,IP,Status,Message,UpdateTime)values(@OrderID,@Point,@UserID,@IP,@Status,@Message,@UpdateTime)";
        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string count_strsql="Select Count(*) From "+viewName;        
        /// <summary>
        /// 数据更新语句
        /// </summary>
        private string update_strsql="Update  "+tableName+" Set OrderID= @OrderID ,Point= @Point ,UserID= @UserID ,IP= @IP ,Status= @Status ,Message= @Message ,UpdateTime= @UpdateTime   where LogID=@LogID  ";
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
		public bool ExistUsePointLog(string condition)
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
		public int AddUsePointLog(Model.UsePointLog model)
		{
			SqlParameter[] parameters = {
			            
             SqlHelper.MakeInParam("@OrderID", SqlDbType.Int,4,model.OrderID) ,                        
             SqlHelper.MakeInParam("@Point", SqlDbType.Int,4,model.Point) ,                        
             SqlHelper.MakeInParam("@UserID", SqlDbType.Int,4,model.UserID) ,                        
             SqlHelper.MakeInParam("@IP", SqlDbType.NVarChar,20,model.IP) ,                        
             SqlHelper.MakeInParam("@Status", SqlDbType.Int,4,model.Status) ,                        
             SqlHelper.MakeInParam("@Message", SqlDbType.NVarChar,250,model.Message) ,                        
             SqlHelper.MakeInParam("@UpdateTime", SqlDbType.DateTime,model.UpdateTime)               
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
		public bool UpdateUsePointLog(Model.UsePointLog model)
		{
			SqlParameter[] parameters = {
			           		 SqlHelper.MakeInParam("@LogID", SqlDbType.Int,4, model.LogID) ,            
                       		 SqlHelper.MakeInParam("@OrderID", SqlDbType.Int,4, model.OrderID) ,            
                       		 SqlHelper.MakeInParam("@Point", SqlDbType.Int,4, model.Point) ,            
                       		 SqlHelper.MakeInParam("@UserID", SqlDbType.Int,4, model.UserID) ,            
                       		 SqlHelper.MakeInParam("@IP", SqlDbType.NVarChar,20, model.IP) ,            
                       		 SqlHelper.MakeInParam("@Status", SqlDbType.Int,4, model.Status) ,            
                       		 SqlHelper.MakeInParam("@Message", SqlDbType.NVarChar,250, model.Message) ,            
                       		 SqlHelper.MakeInParam("@UpdateTime", SqlDbType.DateTime, model.UpdateTime)             
              
            
            };
            
  			return SqlHelper.ExecuteNonQuery(CommandType.Text, update_strsql, parameters)>0?true:false;
		}
        #endregion
        
        #region  删除数据
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteUsePointLog(int LogID)
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
		public bool DeleteUsePointLogList(string LogIDlist )
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
		private Model.UsePointLog GetUsePointLogInfo(SqlDataReader dr)
		{
			Model.UsePointLog model=new Model.UsePointLog();
							model.LogID=Utils.StrToInt(dr["LogID"]);										
																															model.OrderID=Utils.StrToInt(dr["OrderID"]);										
																															model.Point=Utils.StrToInt(dr["Point"]);										
																															model.UserID=Utils.StrToInt(dr["UserID"]);										
																																									
												model.IP= dr["IP"].ToString();																			model.Status=Utils.StrToInt(dr["Status"]);										
																																									
												model.Message= dr["Message"].ToString();																											model.UpdateTime=Utils.StrToDateTime(dr["UpdateTime"].ToString());		
																																	
			return model;
		}
        #endregion
        
        #region  获取一条数据
		/// <summary>
        /// 根据LogID获取一条数据
        /// </summary>
        /// <param name="LogID"></param>
        /// <returns></returns>
		public Model.UsePointLog GetUsePointLogInfo (int LogID)
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
                return GetUsePointLogInfo(dr);
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
        public Model.UsePointLog GetUsePointLogInfoByCondition(string condition)
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
                return GetUsePointLogInfo(dr);
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
		public List<Model.UsePointLog> GetUsePointLogList()
        {
            List<Model.UsePointLog> list = new List<Model.UsePointLog>();
            SqlDataReader dr = SqlHelper.ExecuteReader(select_strsql);
            while (dr.Read())
            {
                list.Add(GetUsePointLogInfo(dr));
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
		public List<Model.UsePointLog> GetUsePointLogList(string condition)
        {
        	string strSql=select_strsql+" where ";
            
            if(condition=="")
            {
            	condition="1=1";
            }
            strSql+=condition;
            List<Model.UsePointLog> list = new List<Model.UsePointLog>();
            SqlDataReader dr = SqlHelper.ExecuteReader(strSql);
            while (dr.Read())
            {
                list.Add(GetUsePointLogInfo(dr));
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
		public List<Model.UsePointLog> GetUsePointLogList(int pagesize, int pageindex, string condition)
        {
            List<Model.UsePointLog> list = new List<Model.UsePointLog>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, "LogID", "ASC");
            while (dr.Read())
            {
                list.Add(GetUsePointLogInfo(dr));
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
		public List<Model.UsePointLog> GetUsePointLogList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            List<Model.UsePointLog> list = new List<Model.UsePointLog>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, orderby, sorttype);
            while (dr.Read())
            {
                list.Add(GetUsePointLogInfo(dr));
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
        public int GetUsePointLogCount(string condition)
        {
            return this.GetCount(viewName, condition);
        }
        #endregion
		
		#endregion
		
		#region MethodEx
		#endregion
	}
}