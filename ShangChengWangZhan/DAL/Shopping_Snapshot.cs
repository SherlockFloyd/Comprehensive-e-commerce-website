
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
   
    ///	订单快照信息表
    ///	数据层实例化接口类 Shopping_Snapshot
    /// 主要完成对数据库的基本操作
    /// </summary>
    public partial class SnapshotProvider : SqlDB<SnapshotProvider>
    {
        #region Method
        /// <summary>
        /// 数据库表名
        /// </summary>
        private static string tableName = "Shopping_Snapshot";
        /// <summary>
        /// 数据库视图名
        /// </summary>
        private static string viewName = "Shopping_View_Snapshot";
        /// <summary>
        /// 数据查询语句(查询全部数据)
        /// </summary>
        private string select_strsql = "Select * from " + viewName;


        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string insert_strsql = "Insert into " + tableName + " (OrderID,CommodityID,Quantity,Price,TotalPrice,IsGrade)values(@OrderID,@CommodityID,@Quantity,@Price,@TotalPrice,@IsGrade)";
        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string count_strsql = "Select Count(*) From " + viewName;
        /// <summary>
        /// 数据更新语句
        /// </summary>
        private string update_strsql = "Update  " + tableName + " Set OrderID= @OrderID ,CommodityID= @CommodityID ,Quantity= @Quantity ,Price= @Price ,TotalPrice= @TotalPrice ,IsGrade= @IsGrade where SnapshotID=@SnapshotID  ";
        /// <summary>
        /// 数据删除语句(根据主键删除)
        /// </summary>
        private string delete_strsql = "Delete  From " + tableName + " where SnapshotID=@SnapshotID";


        #region  判断是否存在
        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public bool ExistSnapshot(string condition)
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
        public int AddSnapshot(Model.Snapshot model)
        {
            SqlParameter[] parameters = {
			            
             SqlHelper.MakeInParam("@OrderID", SqlDbType.Int,4,model.OrderID) ,                        
             SqlHelper.MakeInParam("@CommodityID", SqlDbType.Int,4,model.CommodityID) ,                        
             SqlHelper.MakeInParam("@Quantity", SqlDbType.Int,4,model.Quantity) ,                        
             SqlHelper.MakeInParam("@Price", SqlDbType.Decimal,9,model.Price) ,                        
             SqlHelper.MakeInParam("@TotalPrice", SqlDbType.Decimal,9,model.TotalPrice) ,                        
             SqlHelper.MakeInParam("@IsGrade", SqlDbType.Int,4,model.IsGrade)               
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
        public bool UpdateSnapshot(Model.Snapshot model)
        {
            SqlParameter[] parameters = {
			           		 SqlHelper.MakeInParam("@SnapshotID", SqlDbType.Int,4, model.SnapshotID) ,            
                       		 SqlHelper.MakeInParam("@OrderID", SqlDbType.Int,4, model.OrderID) ,            
                       		 SqlHelper.MakeInParam("@CommodityID", SqlDbType.Int,4, model.CommodityID) ,            
                       		 SqlHelper.MakeInParam("@Quantity", SqlDbType.Int,4, model.Quantity) ,            
                       		 SqlHelper.MakeInParam("@Price", SqlDbType.Decimal,9, model.Price) ,            
                       		 SqlHelper.MakeInParam("@TotalPrice", SqlDbType.Decimal,9, model.TotalPrice) ,            
                       		 SqlHelper.MakeInParam("@IsGrade", SqlDbType.Int,4, model.IsGrade)             
              
            
            };

            return SqlHelper.ExecuteNonQuery(CommandType.Text, update_strsql, parameters) > 0 ? true : false;
        }
        #endregion

        #region  删除数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteSnapshot(int SnapshotID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@SnapshotID", SqlDbType.Int,4)};
            parameters[0].Value = SnapshotID;

            return SqlHelper.ExecuteNonQuery(CommandType.Text, delete_strsql, parameters) > 0 ? true : false;

        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteSnapshotList(string SnapshotIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + tableName + " where SnapshotID in (" + SnapshotIDlist + ")  ");
            return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString()) > 0 ? true : false;
        }
        #endregion

        #region 获取对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private Model.Snapshot GetSnapshotInfo(SqlDataReader dr)
        {
            Model.Snapshot model = new Model.Snapshot();
            model.SnapshotID = Utils.StrToInt(dr["SnapshotID"]);
       
            model.Name = dr["Name"].ToString();
            model.Photo = dr["Photo"].ToString(); 
            model.UserID = Utils.StrToInt(dr["UserID"]);
            model.Status = Utils.StrToInt(dr["Status"]);
            model.Grade = Utils.StrToInt(dr["Grade"]);
            model.OrderID = Utils.StrToInt(dr["OrderID"]);
            model.CommodityID = Utils.StrToInt(dr["CommodityID"]);
            model.Quantity = Utils.StrToInt(dr["Quantity"]);
            model.Price = Utils.StrToDecimal(dr["Price"].ToString());
            model.TotalPrice = Utils.StrToDecimal(dr["TotalPrice"].ToString()); 
            model.IsGrade = Utils.StrToInt(dr["IsGrade"]);
            model.UserName = dr["UserName"].ToString();
            model.CommodityNo = dr["CommodityNo"].ToString();
            model.Point = Utils.StrToInt(dr["Point"]);
            model.Stock = Utils.StrToInt(dr["Stock"]);	

            return model;
        }
        #endregion

        #region  获取一条数据
        /// <summary>
        /// 根据SnapshotID获取一条数据
        /// </summary>
        /// <param name="SnapshotID"></param>
        /// <returns></returns>
        public Model.Snapshot GetSnapshotInfo(int SnapshotID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from " + viewName + " where SnapshotID=@SnapshotID");
            SqlParameter[] parameters = {
					new SqlParameter("@SnapshotID", SqlDbType.Int,4)};
            parameters[0].Value = SnapshotID;

            SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters);
            while (dr.Read())
            {
                return GetSnapshotInfo(dr);
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
        public Model.Snapshot GetSnapshotInfoByCondition(string condition)
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
                return GetSnapshotInfo(dr);
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
        public List<Model.Snapshot> GetSnapshotList()
        {
            List<Model.Snapshot> list = new List<Model.Snapshot>();
            SqlDataReader dr = SqlHelper.ExecuteReader(select_strsql);
            while (dr.Read())
            {
                list.Add(GetSnapshotInfo(dr));
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
        public List<Model.Snapshot> GetSnapshotList(string condition)
        {
            string strSql = select_strsql + " where ";

            if (condition == "")
            {
                condition = "1=1";
            }
            strSql += condition;
            List<Model.Snapshot> list = new List<Model.Snapshot>();
            SqlDataReader dr = SqlHelper.ExecuteReader(strSql);
            while (dr.Read())
            {
                list.Add(GetSnapshotInfo(dr));
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
        public List<Model.Snapshot> GetSnapshotList(int pagesize, int pageindex, string condition)
        {
            List<Model.Snapshot> list = new List<Model.Snapshot>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, "SnapshotID", "ASC");
            while (dr.Read())
            {
                list.Add(GetSnapshotInfo(dr));
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
        public List<Model.Snapshot> GetSnapshotList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            List<Model.Snapshot> list = new List<Model.Snapshot>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, orderby, sorttype);
            while (dr.Read())
            {
                list.Add(GetSnapshotInfo(dr));
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
        public int GetSnapshotCount(string condition)
        {
            return this.GetCount(viewName, condition);
        }
        #endregion

        #endregion

        #region MethodEx


        #endregion
    }
}