
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
    public partial class DeliveryProvider : SqlDB<DeliveryProvider>
    {
        #region Method
        /// <summary>
        /// 数据库表名
        /// </summary>
        private static string tableName = "Shopping_Delivery";
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
        private string insert_strsql = "Insert into " + tableName + " (UserID,Name,Tel,Address,IsDefault,CreateTime)values(@UserID,@Name,@Tel,@Address,@IsDefault,@CreateTime)";
        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string count_strsql = "Select Count(*) From " + viewName;
        /// <summary>
        /// 数据更新语句
        /// </summary>
        private string update_strsql = "Update  " + tableName + " Set UserID= @UserID ,Name= @Name ,Tel= @Tel ,Address= @Address ,IsDefault= @IsDefault ,CreateTime= @CreateTime   where DeliveryID=@DeliveryID  ";
        /// <summary>
        /// 数据删除语句(根据主键删除)
        /// </summary>
        private string delete_strsql = "Delete  From " + tableName + "  where DeliveryID=@DeliveryID";


        #region  判断是否存在
        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public bool ExistDelivery(string condition)
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
        public int AddDelivery(Model.Delivery model)
        {
            SqlParameter[] parameters = {
			            
             SqlHelper.MakeInParam("@UserID", SqlDbType.Int,4,model.UserID) ,                        
             SqlHelper.MakeInParam("@Name", SqlDbType.NVarChar,20,model.Name) ,                        
             SqlHelper.MakeInParam("@Tel", SqlDbType.NVarChar,20,model.Tel) ,                        
             SqlHelper.MakeInParam("@Address", SqlDbType.NVarChar,250,model.Address) ,                        
             SqlHelper.MakeInParam("@IsDefault", SqlDbType.Int,4,model.IsDefault) ,                        
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
        public bool UpdateDelivery(Model.Delivery model)
        {
            SqlParameter[] parameters = {
			           		 SqlHelper.MakeInParam("@DeliveryID", SqlDbType.Int,4, model.DeliveryID) ,            
                       		 SqlHelper.MakeInParam("@UserID", SqlDbType.Int,4, model.UserID) ,            
                       		 SqlHelper.MakeInParam("@Name", SqlDbType.NVarChar,20, model.Name) ,            
                       		 SqlHelper.MakeInParam("@Tel", SqlDbType.NVarChar,20, model.Tel) ,            
                       		 SqlHelper.MakeInParam("@Address", SqlDbType.NVarChar,250, model.Address) ,            
                       		 SqlHelper.MakeInParam("@IsDefault", SqlDbType.Int,4, model.IsDefault) ,            
                       		 SqlHelper.MakeInParam("@CreateTime", SqlDbType.DateTime, model.CreateTime)             
              
            
            };

            return SqlHelper.ExecuteNonQuery(CommandType.Text, update_strsql, parameters) > 0 ? true : false;
        }
        #endregion

        #region  删除数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteDelivery(int DeliveryID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@DeliveryID", SqlDbType.Int,4)
};
            parameters[0].Value = DeliveryID;

            return SqlHelper.ExecuteNonQuery(CommandType.Text, delete_strsql, parameters) > 0 ? true : false;

        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteDeliveryList(string DeliveryIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + tableName + " where DeliveryID in (" + DeliveryIDlist + ")  ");
            return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString()) > 0 ? true : false;
        }
        #endregion


        #region 获取对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private Model.Delivery GetDeliveryInfo(SqlDataReader dr)
        {
            Model.Delivery model = new Model.Delivery();
            model.DeliveryID = Utils.StrToInt(dr["DeliveryID"]);
            model.UserID = Utils.StrToInt(dr["UserID"]);

            model.Name = dr["Name"].ToString();
            model.Tel = dr["Tel"].ToString();
            model.Address = dr["Address"].ToString(); model.IsDefault = Utils.StrToInt(dr["IsDefault"]);
            model.CreateTime = Utils.StrToDateTime(dr["CreateTime"].ToString());

            return model;
        }
        #endregion

        #region  获取一条数据
        /// <summary>
        /// 根据DeliveryID获取一条数据
        /// </summary>
        /// <param name="DeliveryID"></param>
        /// <returns></returns>
        public Model.Delivery GetDeliveryInfo(int DeliveryID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from " + viewName + " where DeliveryID=@DeliveryID");
            SqlParameter[] parameters = {
					new SqlParameter("@DeliveryID", SqlDbType.Int,4)
};
            parameters[0].Value = DeliveryID;

            SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters);
            while (dr.Read())
            {
                return GetDeliveryInfo(dr);
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
        public Model.Delivery GetDeliveryInfoByCondition(string condition)
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
                return GetDeliveryInfo(dr);
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
        public List<Model.Delivery> GetDeliveryList()
        {
            List<Model.Delivery> list = new List<Model.Delivery>();
            SqlDataReader dr = SqlHelper.ExecuteReader(select_strsql);
            while (dr.Read())
            {
                list.Add(GetDeliveryInfo(dr));
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
        public List<Model.Delivery> GetDeliveryList(string condition)
        {
            string strSql = select_strsql + " where ";

            if (condition == "")
            {
                condition = "1=1";
            }
            strSql += condition;
            List<Model.Delivery> list = new List<Model.Delivery>();
            SqlDataReader dr = SqlHelper.ExecuteReader(strSql);
            while (dr.Read())
            {
                list.Add(GetDeliveryInfo(dr));
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
        public List<Model.Delivery> GetDeliveryList(int pagesize, int pageindex, string condition)
        {
            List<Model.Delivery> list = new List<Model.Delivery>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, "DeliveryID", "ASC");
            while (dr.Read())
            {
                list.Add(GetDeliveryInfo(dr));
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
        public List<Model.Delivery> GetDeliveryList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            List<Model.Delivery> list = new List<Model.Delivery>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, orderby, sorttype);
            while (dr.Read())
            {
                list.Add(GetDeliveryInfo(dr));
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
        public int GetDeliveryCount(string condition)
        {
            return this.GetCount(viewName, condition);
        }
        #endregion

        #endregion

        #region MethodEx

        /// <summary>
        /// 根据用户ID获取用户的收货地址
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Delivery> GetDeliveryList(int userId)
        {
            return GetDeliveryList("UserID=" + userId);
        }

        /// <summary>
        /// 设置默认地址
        /// </summary>
        /// <param name="delivertyID"></param>
        public bool SetDefaultDelivery(int delivertyID, int userID)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString);
            conn.Open();
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    //删除旧的关联 
                    string sql = "Update " + tableName + " SET IsDefault=1 Where DeliveryID=" + delivertyID + " AND UserID=" + userID;
                    string sql1 = "Update " + tableName + " SET IsDefault=0 Where DeliveryID !=" + delivertyID + " AND UserID=" + userID;
                    SqlHelper.ExecuteNonQuery(sql);
                    SqlHelper.ExecuteNonQuery(sql1);

                    trans.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    result = false;
                    throw ex;
                }
            }
            conn.Close();

            return result;
        }

        #endregion
    }
}