
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
    
    public partial class UserProvider : SqlDB<UserProvider>
    {
        #region Method
        /// <summary>
        /// 数据库表名
        /// </summary>
        private static string tableName = "Shopping_User";
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
        private string insert_strsql = "Insert into " + tableName + " (Password,RegTime,LastLoginTime,LastLoginIP,LoginTime,LoginIP,LoginTimes,Status,RealName,Post,UserName,Sex,BirthDay,Point,Email,EmailIsChecked,Phone,Address)values(@Password,@RegTime,@LastLoginTime,@LastLoginIP,@LoginTime,@LoginIP,@LoginTimes,@Status,@RealName,@Post,@UserName,@Sex,@BirthDay,@Point,@Email,@EmailIsChecked,@Phone,@Address)";
        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string count_strsql = "Select Count(*) From " + viewName;
        /// <summary>
        /// 数据更新语句
        /// </summary>
        private string update_strsql = "Update  " + tableName + " Set Password= @Password ,RegTime= @RegTime ,LastLoginTime= @LastLoginTime ,LastLoginIP= @LastLoginIP ,LoginTime= @LoginTime ,LoginIP= @LoginIP ,LoginTimes= @LoginTimes ,Status= @Status ,RealName= @RealName ,Post= @Post ,UserName= @UserName ,Sex= @Sex ,BirthDay= @BirthDay ,Point= @Point ,Email= @Email ,EmailIsChecked= @EmailIsChecked ,Phone= @Phone ,Address= @Address   where UserID=@UserID  ";
        /// <summary>
        /// 数据删除语句(根据主键删除)
        /// </summary>
        private string delete_strsql = "Delete  From " + tableName + "  where UserID=@UserID";


        #region  判断是否存在
        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public bool ExistUser(string condition)
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
        public int AddUser(Model.User model)
        {
            SqlParameter[] parameters = {
			            
             SqlHelper.MakeInParam("@Password", SqlDbType.NVarChar,50,model.Password) ,                        
             SqlHelper.MakeInParam("@RegTime", SqlDbType.DateTime,model.RegTime) ,                        
             SqlHelper.MakeInParam("@LastLoginTime", SqlDbType.DateTime,model.LastLoginTime) ,                        
             SqlHelper.MakeInParam("@LastLoginIP", SqlDbType.NVarChar,20,model.LastLoginIP) ,                        
             SqlHelper.MakeInParam("@LoginTime", SqlDbType.DateTime,model.LoginTime) ,                        
             SqlHelper.MakeInParam("@LoginIP", SqlDbType.NVarChar,20,model.LoginIP) ,                        
             SqlHelper.MakeInParam("@LoginTimes", SqlDbType.Int,4,model.LoginTimes) ,                        
             SqlHelper.MakeInParam("@Status", SqlDbType.Int,4,model.Status) ,                        
             SqlHelper.MakeInParam("@RealName", SqlDbType.NVarChar,20,model.RealName) ,                        
             SqlHelper.MakeInParam("@Post", SqlDbType.Int,4,model.Post) ,                        
             SqlHelper.MakeInParam("@UserName", SqlDbType.NVarChar,250,model.UserName) ,                        
             SqlHelper.MakeInParam("@Sex", SqlDbType.Int,4,model.Sex) ,                        
             SqlHelper.MakeInParam("@BirthDay", SqlDbType.DateTime,model.BirthDay) ,                        
             SqlHelper.MakeInParam("@Point", SqlDbType.Int,4,model.Point) ,                        
             SqlHelper.MakeInParam("@Email", SqlDbType.NVarChar,250,model.Email) ,                        
             SqlHelper.MakeInParam("@EmailIsChecked", SqlDbType.Int,4,model.EmailIsChecked) ,                        
             SqlHelper.MakeInParam("@Phone", SqlDbType.NVarChar,20,model.Phone) ,                        
             SqlHelper.MakeInParam("@Address", SqlDbType.NVarChar,250,model.Address)               
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
        public bool UpdateUser(Model.User model)
        {
            SqlParameter[] parameters = {
			           		 SqlHelper.MakeInParam("@UserID", SqlDbType.Int,4, model.UserID) ,            
                       		 SqlHelper.MakeInParam("@Password", SqlDbType.NVarChar,50, model.Password) ,            
                       		 SqlHelper.MakeInParam("@RegTime", SqlDbType.DateTime, model.RegTime) ,            
                       		 SqlHelper.MakeInParam("@LastLoginTime", SqlDbType.DateTime, model.LastLoginTime) ,            
                       		 SqlHelper.MakeInParam("@LastLoginIP", SqlDbType.NVarChar,20, model.LastLoginIP) ,            
                       		 SqlHelper.MakeInParam("@LoginTime", SqlDbType.DateTime, model.LoginTime) ,            
                       		 SqlHelper.MakeInParam("@LoginIP", SqlDbType.NVarChar,20, model.LoginIP) ,            
                       		 SqlHelper.MakeInParam("@LoginTimes", SqlDbType.Int,4, model.LoginTimes) ,            
                       		 SqlHelper.MakeInParam("@Status", SqlDbType.Int,4, model.Status) ,            
                       		 SqlHelper.MakeInParam("@RealName", SqlDbType.NVarChar,20, model.RealName) ,            
                       		 SqlHelper.MakeInParam("@Post", SqlDbType.Int,4, model.Post) ,            
                       		 SqlHelper.MakeInParam("@UserName", SqlDbType.NVarChar,250, model.UserName) ,            
                       		 SqlHelper.MakeInParam("@Sex", SqlDbType.Int,4, model.Sex) ,            
                       		 SqlHelper.MakeInParam("@BirthDay", SqlDbType.DateTime, model.BirthDay) ,            
                       		 SqlHelper.MakeInParam("@Point", SqlDbType.Int,4, model.Point) ,            
                       		 SqlHelper.MakeInParam("@Email", SqlDbType.NVarChar,250, model.Email) ,            
                       		 SqlHelper.MakeInParam("@EmailIsChecked", SqlDbType.Int,4, model.EmailIsChecked) ,            
                       		 SqlHelper.MakeInParam("@Phone", SqlDbType.NVarChar,20, model.Phone) ,            
                       		 SqlHelper.MakeInParam("@Address", SqlDbType.NVarChar,250, model.Address)             
              
            
            };

            return SqlHelper.ExecuteNonQuery(CommandType.Text, update_strsql, parameters) > 0 ? true : false;
        }
        #endregion

        #region  删除数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteUser(int UserID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
};
            parameters[0].Value = UserID;

            return SqlHelper.ExecuteNonQuery(CommandType.Text, delete_strsql, parameters) > 0 ? true : false;

        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteUserList(string UserIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + tableName + " where UserID in (" + UserIDlist + ")  ");
            return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString()) > 0 ? true : false;
        }
        #endregion


        #region 获取对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private Model.User GetUserInfo(SqlDataReader dr)
        {
            Model.User model = new Model.User();
            model.UserID = Utils.StrToInt(dr["UserID"]);
            model.Password = dr["Password"].ToString(); 
            model.RegTime = Utils.StrToDateTime(dr["RegTime"].ToString());
            model.LastLoginTime = Utils.StrToDateTime(dr["LastLoginTime"].ToString());
            model.LastLoginIP = dr["LastLoginIP"].ToString(); 
            model.LoginTime = Utils.StrToDateTime(dr["LoginTime"].ToString());
            model.LoginIP = dr["LoginIP"].ToString(); 
            model.LoginTimes = Utils.StrToInt(dr["LoginTimes"]);
            model.Status = Utils.StrToInt(dr["Status"]);
            model.RealName = dr["RealName"].ToString(); 
            model.Post = Utils.StrToInt(dr["Post"]);
            model.UserName = dr["UserName"].ToString(); 
            model.Sex = Utils.StrToInt(dr["Sex"]);
            model.BirthDay = Utils.StrToDateTime(dr["BirthDay"].ToString());
            model.Point = Utils.StrToInt(dr["Point"]);
            model.Email = dr["Email"].ToString();
            model.EmailIsChecked = Utils.StrToInt(dr["EmailIsChecked"]);
            model.Phone = dr["Phone"].ToString();
            model.Address = dr["Address"].ToString();
            return model;
        }
        #endregion

        #region  获取一条数据
        /// <summary>
        /// 根据UserID获取一条数据
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public Model.User GetUserInfo(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from " + viewName + " where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
};
            parameters[0].Value = UserID;

            SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters);
            while (dr.Read())
            {
                return GetUserInfo(dr);
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
        public Model.User GetUserInfoByCondition(string condition)
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
                return GetUserInfo(dr);
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
        public List<Model.User> GetUserList()
        {
            List<Model.User> list = new List<Model.User>();
            SqlDataReader dr = SqlHelper.ExecuteReader(select_strsql);
            while (dr.Read())
            {
                list.Add(GetUserInfo(dr));
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
        public List<Model.User> GetUserList(string condition)
        {
            string strSql = select_strsql + " where ";

            if (condition == "")
            {
                condition = "1=1";
            }
            strSql += condition;
            List<Model.User> list = new List<Model.User>();
            SqlDataReader dr = SqlHelper.ExecuteReader(strSql);
            while (dr.Read())
            {
                list.Add(GetUserInfo(dr));
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
        public List<Model.User> GetUserList(int pagesize, int pageindex, string condition)
        {
            List<Model.User> list = new List<Model.User>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, "UserID", "ASC");
            while (dr.Read())
            {
                list.Add(GetUserInfo(dr));
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
        public List<Model.User> GetUserList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            List<Model.User> list = new List<Model.User>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, orderby, sorttype);
            while (dr.Read())
            {
                list.Add(GetUserInfo(dr));
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
        public int GetUserCount(string condition)
        {
            return this.GetCount(viewName, condition);
        }
        #endregion

        #endregion

        #region MethodEx

        /// <summary>
        /// 更新积分
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool UpdateUserPoint(int userID, int point)
        {
            return SqlHelper.ExecuteNonQuery("UPDATE " + tableName + " SET Point=Point+" + point + " Where UserID=" + userID) > 0 ? true : false;
        }
        #endregion
    }
}