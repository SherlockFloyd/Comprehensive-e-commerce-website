
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
    public partial class ConsultProvider : SqlDB<ConsultProvider>
    {
        #region Method
        /// <summary>
        /// 数据库表名
        /// </summary>
        private static string tableName = "Shopping_Consult";
        /// <summary>
        /// 数据库视图名
        /// </summary>
        private static string viewName = "Shopping_View_Consult";
        /// <summary>
        /// 数据查询语句(查询全部数据)
        /// </summary>
        private string select_strsql = "Select * from " + viewName;


        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string insert_strsql = "Insert into " + tableName + " (CreateTime,UserName,CommodityID,Name,UserID,Content,IsReply,ReplyContent,ReplyTime,ReplyIsRead)values(@CreateTime,@UserName,@CommodityID,@Name,@UserID,@Content,@IsReply,@ReplyContent,@ReplyTime,@ReplyIsRead)";
        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string count_strsql = "Select Count(*) From " + viewName;
        /// <summary>
        /// 数据更新语句
        /// </summary>
        private string update_strsql = "Update  " + tableName + " Set CreateTime= @CreateTime ,UserName= @UserName ,CommodityID= @CommodityID ,Name= @Name ,UserID= @UserID ,Content= @Content ,IsReply= @IsReply ,ReplyContent= @ReplyContent ,ReplyTime= @ReplyTime ,ReplyIsRead= @ReplyIsRead   where ConsultID=@ConsultID  ";
        /// <summary>
        /// 数据删除语句(根据主键删除)
        /// </summary>
        private string delete_strsql = "Delete  From " + tableName + "  where ConsultID=@ConsultID";


        #region  判断是否存在
        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public bool ExistConsult(string condition)
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
        public int AddConsult(Model.Consult model)
        {
            SqlParameter[] parameters = {
			            
             SqlHelper.MakeInParam("@CreateTime", SqlDbType.DateTime,model.CreateTime) ,                        
             SqlHelper.MakeInParam("@UserName", SqlDbType.NVarChar,250,model.UserName) ,                        
             SqlHelper.MakeInParam("@CommodityID", SqlDbType.Int,4,model.CommodityID) ,                        
             SqlHelper.MakeInParam("@Name", SqlDbType.NVarChar,250,model.Name) ,                        
             SqlHelper.MakeInParam("@UserID", SqlDbType.Int,4,model.UserID) ,                        
             SqlHelper.MakeInParam("@Content", SqlDbType.NVarChar,250,model.Content) ,                        
             SqlHelper.MakeInParam("@IsReply", SqlDbType.Int,4,model.IsReply) ,                        
             SqlHelper.MakeInParam("@ReplyContent", SqlDbType.NVarChar,250,model.ReplyContent) ,                        
             SqlHelper.MakeInParam("@ReplyTime", SqlDbType.DateTime,model.ReplyTime) ,                        
             SqlHelper.MakeInParam("@ReplyIsRead", SqlDbType.Int,4,model.ReplyIsRead)               
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
        public bool UpdateConsult(Model.Consult model)
        {
            SqlParameter[] parameters = {
			           		 SqlHelper.MakeInParam("@ConsultID", SqlDbType.Int,4, model.ConsultID) ,            
                       		 SqlHelper.MakeInParam("@CreateTime", SqlDbType.DateTime, model.CreateTime) ,            
                       		 SqlHelper.MakeInParam("@UserName", SqlDbType.NVarChar,250, model.UserName) ,            
                       		 SqlHelper.MakeInParam("@CommodityID", SqlDbType.Int,4, model.CommodityID) ,            
                       		 SqlHelper.MakeInParam("@Name", SqlDbType.NVarChar,250, model.Name) ,            
                       		 SqlHelper.MakeInParam("@UserID", SqlDbType.Int,4, model.UserID) ,            
                       		 SqlHelper.MakeInParam("@Content", SqlDbType.NVarChar,250, model.Content) ,            
                       		 SqlHelper.MakeInParam("@IsReply", SqlDbType.Int,4, model.IsReply) ,            
                       		 SqlHelper.MakeInParam("@ReplyContent", SqlDbType.NVarChar,250, model.ReplyContent) ,            
                       		 SqlHelper.MakeInParam("@ReplyTime", SqlDbType.DateTime, model.ReplyTime) ,            
                       		 SqlHelper.MakeInParam("@ReplyIsRead", SqlDbType.Int,4, model.ReplyIsRead)             
              
            
            };

            return SqlHelper.ExecuteNonQuery(CommandType.Text, update_strsql, parameters) > 0 ? true : false;
        }
        #endregion

        #region  删除数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteConsult(int ConsultID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ConsultID", SqlDbType.Int,4)
			};
            parameters[0].Value = ConsultID;

            return SqlHelper.ExecuteNonQuery(CommandType.Text, delete_strsql, parameters) > 0 ? true : false;

        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteConsultList(string ConsultIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + tableName + " where ConsultID in (" + ConsultIDlist + ")  ");
            return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString()) > 0 ? true : false;
        }
        #endregion


        #region 获取对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private Model.Consult GetConsultInfo(SqlDataReader dr)
        {
            Model.Consult model = new Model.Consult();
            model.ConsultID = Utils.StrToInt(dr["ConsultID"]);
            model.CreateTime = Utils.StrToDateTime(dr["CreateTime"].ToString());
            model.UserName = dr["UserName"].ToString(); 
            model.CommodityID = Utils.StrToInt(dr["CommodityID"]);
            model.Name = dr["Name"].ToString();
            model.UserID = Utils.StrToInt(dr["UserID"]);
            model.Content = dr["Content"].ToString(); 
            model.IsReply = Utils.StrToInt(dr["IsReply"]);
            model.Photo = dr["Photo"].ToString();
            model.ReplyContent = dr["ReplyContent"].ToString(); 
            model.ReplyTime = Utils.StrToDateTime(dr["ReplyTime"].ToString());
            model.ReplyIsRead = Utils.StrToInt(dr["ReplyIsRead"]);

            return model;
        }
        #endregion

        #region  获取一条数据
        /// <summary>
        /// 根据ConsultID获取一条数据
        /// </summary>
        /// <param name="ConsultID"></param>
        /// <returns></returns>
        public Model.Consult GetConsultInfo(int ConsultID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from " + viewName + " where ConsultID=@ConsultID");
            SqlParameter[] parameters = {
					new SqlParameter("@ConsultID", SqlDbType.Int,4)
			};
            parameters[0].Value = ConsultID;

            SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters);
            while (dr.Read())
            {
                return GetConsultInfo(dr);
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
        public Model.Consult GetConsultInfoByCondition(string condition)
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
                return GetConsultInfo(dr);
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
        public List<Model.Consult> GetConsultList()
        {
            List<Model.Consult> list = new List<Model.Consult>();
            SqlDataReader dr = SqlHelper.ExecuteReader(select_strsql);
            while (dr.Read())
            {
                list.Add(GetConsultInfo(dr));
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
        public List<Model.Consult> GetConsultList(string condition)
        {
            string strSql = select_strsql + " where ";

            if (condition == "")
            {
                condition = "1=1";
            }
            strSql += condition;
            List<Model.Consult> list = new List<Model.Consult>();
            SqlDataReader dr = SqlHelper.ExecuteReader(strSql);
            while (dr.Read())
            {
                list.Add(GetConsultInfo(dr));
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
        public List<Model.Consult> GetConsultList(int pagesize, int pageindex, string condition)
        {
            List<Model.Consult> list = new List<Model.Consult>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, "ConsultID", "ASC");
            while (dr.Read())
            {
                list.Add(GetConsultInfo(dr));
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
        public List<Model.Consult> GetConsultList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            List<Model.Consult> list = new List<Model.Consult>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, orderby, sorttype);
            while (dr.Read())
            {
                list.Add(GetConsultInfo(dr));
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
        public int GetConsultCount(string condition)
        {
            return this.GetCount(viewName, condition);
        }
        #endregion

        #endregion

        #region MethodEx
        #endregion
    }
}