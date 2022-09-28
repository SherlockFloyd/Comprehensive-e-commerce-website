
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
    /// <summary>
    ///	管理员信息表
    ///	数据层实例化接口类 Shopping_Admin
    /// 主要完成对数据库的基本操作
    /// </summary>
    public partial class AdminProvider : SqlDB<AdminProvider>
    {
        /// <summary>
        /// 数据库表名
        /// </summary>
        private static string tableName = "Shopping_Admin";
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
        private string insert_strsql = "Insert into " + tableName + " (AdminName,Password,GroupID,LastLoginTime,LoginTime,LoginTimes,Status,CreateTime,LastLoginIP,LoginIP)values(@AdminName,@Password,@GroupID,@LastLoginTime,@LoginTime,@LoginTimes,@Status,@CreateTime,@LastLoginIP,@LoginIP)";
        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string count_strsql = "Select Count(*) From " + viewName;
        /// <summary>
        /// 数据更新语句
        /// </summary>
        private string update_strsql = "Update  " + tableName + " Set AdminName= @AdminName ,Password= @Password ,GroupID= @GroupID ,LastLoginTime= @LastLoginTime  ,LoginTime= @LoginTime  ,LoginTimes= @LoginTimes ,Status= @Status ,CreateTime= @CreateTime,LastLoginIP= @LastLoginIP,LoginIP= LoginIP   where AdminID=@AdminID  ";
        /// <summary>
        /// 数据删除语句(根据主键删除)
        /// </summary>
        private string delete_strsql = "Delete  From " + tableName + "  where AdminID=@AdminID";


        #region  判断是否存在
        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public bool ExistAdmin(string condition)
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
        public int AddAdmin(Model.Admin model)
        {
            SqlParameter[] parameters = {
			            
             SqlHelper.MakeInParam("@AdminName", SqlDbType.NVarChar,20,model.AdminName) ,                        
             SqlHelper.MakeInParam("@Password", SqlDbType.NVarChar,50,model.Password) ,                        
             SqlHelper.MakeInParam("@GroupID", SqlDbType.Int,4,model.GroupID) ,                        
             SqlHelper.MakeInParam("@LastLoginTime", SqlDbType.DateTime,model.LastLoginTime) ,                        
             SqlHelper.MakeInParam("@LastLoginIP", SqlDbType.NVarChar,20,model.LastLoginIP) ,                        
             SqlHelper.MakeInParam("@LoginTime", SqlDbType.DateTime,model.LoginTime) ,                        
             SqlHelper.MakeInParam("@LoginIP", SqlDbType.NVarChar,20,model.LoginIP) ,                        
             SqlHelper.MakeInParam("@LoginTimes", SqlDbType.Int,4,model.LoginTimes) ,                        
             SqlHelper.MakeInParam("@Status", SqlDbType.Int,4,model.Status) ,                        
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
        public bool UpdateAdmin(Model.Admin model)
        {
            SqlParameter[] parameters = {
			           		 SqlHelper.MakeInParam("@AdminID", SqlDbType.Int,4, model.AdminID) ,            
                       		 SqlHelper.MakeInParam("@AdminName", SqlDbType.NVarChar,20, model.AdminName) ,            
                       		 SqlHelper.MakeInParam("@Password", SqlDbType.NVarChar,50, model.Password) ,            
                       		 SqlHelper.MakeInParam("@GroupID", SqlDbType.Int,4, model.GroupID) ,            
                       		 SqlHelper.MakeInParam("@LastLoginTime", SqlDbType.DateTime, model.LastLoginTime) ,            
                             SqlHelper.MakeInParam("@LastLoginIP", SqlDbType.NVarChar,20, model.LastLoginIP) ,            
                       		 SqlHelper.MakeInParam("@LoginTime", SqlDbType.DateTime, model.LoginTime) ,            
                             SqlHelper.MakeInParam("@LoginIP", SqlDbType.NVarChar,20, model.LoginIP) ,            
                       		 SqlHelper.MakeInParam("@LoginTimes", SqlDbType.Int,4, model.LoginTimes) ,            
                       		 SqlHelper.MakeInParam("@Status", SqlDbType.Int,4, model.Status) ,            
                       		 SqlHelper.MakeInParam("@CreateTime", SqlDbType.DateTime, model.CreateTime)             
              
            
            };

            return SqlHelper.ExecuteNonQuery(CommandType.Text, update_strsql, parameters) > 0 ? true : false;
        }
        #endregion

        #region  删除数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteAdmin(int AdminID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@AdminID", SqlDbType.Int,4)
			};
            parameters[0].Value = AdminID;

            return SqlHelper.ExecuteNonQuery(CommandType.Text, delete_strsql, parameters) > 0 ? true : false;

        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteAdminList(string AdminIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + tableName + " where AdminID in (" + AdminIDlist + ")  ");
            return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString()) > 0 ? true : false;
        }
        #endregion


        #region 获取对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private Model.Admin GetAdminInfo(SqlDataReader dr)
        {
            Model.Admin model = new Model.Admin();
            model.AdminID = Utils.StrToInt(dr["AdminID"]);


            model.AdminName = dr["AdminName"].ToString();

            model.Password = dr["Password"].ToString();
            model.GroupID = Utils.StrToInt(dr["GroupID"]);

            model.LastLoginTime = Utils.StrToDateTime(dr["LastLoginTime"].ToString());


            model.LastLoginIP = dr["LastLoginIP"].ToString();
            model.LoginTime = Utils.StrToDateTime(dr["LoginTime"].ToString());


            model.LoginIP = dr["LoginIP"].ToString();
            model.LoginTimes = Utils.StrToInt(dr["LoginTimes"]);

            model.Status = Utils.StrToInt(dr["Status"]);

            model.CreateTime = Utils.StrToDateTime(dr["CreateTime"].ToString());


            return model;
        }
        #endregion

        #region  获取一条数据
        /// <summary>
        /// 根据AdminID获取一条数据
        /// </summary>
        /// <param name="AdminID"></param>
        /// <returns></returns>
        public Model.Admin GetAdminInfo(int AdminID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from " + viewName + " where AdminID=@AdminID");

            SqlParameter[] parameters = {
					new SqlParameter("@AdminID", SqlDbType.Int,4)
			};
            parameters[0].Value = AdminID;

            SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters);
            while (dr.Read())
            {
                return GetAdminInfo(dr);
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
        public Model.Admin GetAdminInfoByCondition(string condition)
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
                return GetAdminInfo(dr);
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
        public List<Model.Admin> GetAdminList()
        {
            List<Model.Admin> list = new List<Model.Admin>();
            SqlDataReader dr = SqlHelper.ExecuteReader(select_strsql);
            while (dr.Read())
            {
                list.Add(GetAdminInfo(dr));
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
        public List<Model.Admin> GetAdminList(string condition)
        {
            string strSql = select_strsql + " where ";

            if (condition == "")
            {
                condition = "1=1";
            }
            strSql += condition;
            List<Model.Admin> list = new List<Model.Admin>();
            SqlDataReader dr = SqlHelper.ExecuteReader(strSql);
            while (dr.Read())
            {
                list.Add(GetAdminInfo(dr));
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
        public List<Model.Admin> GetAdminList(int pagesize, int pageindex, string condition)
        {
            List<Model.Admin> list = new List<Model.Admin>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, "AdminID", "ASC");
            while (dr.Read())
            {
                list.Add(GetAdminInfo(dr));
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
        public List<Model.Admin> GetAdminList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            List<Model.Admin> list = new List<Model.Admin>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, orderby, sorttype);
            while (dr.Read())
            {
                list.Add(GetAdminInfo(dr));
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
        public int GetAdminCount(string condition)
        {
            return this.GetCount(viewName, condition);
        }
        #endregion


        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool UpdatePwd(int adminID, string password)
        {
            return SqlHelper.ExecuteNonQuery("Update " + tableName + " SET Password='" + password + "' Where AdminID=" + adminID) > 0 ? true : false;
        }
    }
}