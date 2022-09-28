

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
  
    public partial class OrderProvider : SqlDB<OrderProvider>
    {
        #region Method
        /// <summary>
        /// 数据库表名
        /// </summary>
        private static string tableName = "Shopping_Order";
        /// <summary>
        /// 数据库视图名
        /// </summary>
        private static string viewName = "Shopping_View_Order";
        /// <summary>
        /// 数据查询语句(查询全部数据)
        /// </summary>
        private string select_strsql = "Select * from " + viewName;


        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string insert_strsql = "Insert into " + tableName + " (ShipMobile,UserPoint,SavingByCoupon,RealPay,CouponID,CouponNo,PaidTime,ShopID,OrderNo,UserID,TotalPrice,Status,OrderTime,Remark,ShipPeopele,ShipAddress)values(@ShipMobile,@UserPoint,@SavingByCoupon,@RealPay,@CouponID,@CouponNo,@PaidTime,@ShopID,@OrderNo,@UserID,@TotalPrice,@Status,@OrderTime,@Remark,@ShipPeopele,@ShipAddress)";
        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string count_strsql = "Select Count(*) From " + viewName;
        /// <summary>
        /// 数据更新语句
        /// </summary>
        private string update_strsql = "Update  " + tableName + " Set ShipMobile= @ShipMobile ,UserPoint= @UserPoint ,SavingByCoupon= @SavingByCoupon ,RealPay= @RealPay ,CouponID= @CouponID ,CouponNo= @CouponNo ,PaidTime= @PaidTime ,ShopID= @ShopID ,OrderNo= @OrderNo ,UserID= @UserID ,TotalPrice= @TotalPrice ,Status= @Status ,OrderTime= @OrderTime ,Remark= @Remark ,ShipPeopele= @ShipPeopele ,ShipAddress= @ShipAddress   where OrderID=@OrderID  ";
        /// <summary>
        /// 数据删除语句(根据主键删除)
        /// </summary>
        private string delete_strsql = "Delete  From " + tableName + "  where OrderID=@OrderID";


        #region  判断是否存在
        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public bool ExistOrder(string condition)
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
        public int AddOrder(Model.Order model)
        {
            SqlParameter[] parameters = {
			            
             SqlHelper.MakeInParam("@ShipMobile", SqlDbType.NVarChar,20,model.ShipMobile) ,                        
             SqlHelper.MakeInParam("@UserPoint", SqlDbType.Int,4,model.UserPoint) ,                        
             SqlHelper.MakeInParam("@SavingByCoupon", SqlDbType.Decimal,9,model.SavingByCoupon) ,                        
             SqlHelper.MakeInParam("@RealPay", SqlDbType.Decimal,9,model.RealPay) ,                        
             SqlHelper.MakeInParam("@CouponID", SqlDbType.Int,4,model.CouponID) ,                        
             SqlHelper.MakeInParam("@CouponNo", SqlDbType.NVarChar,50,model.CouponNo) ,                        
             SqlHelper.MakeInParam("@PaidTime", SqlDbType.DateTime,model.PaidTime) ,                        
             SqlHelper.MakeInParam("@ShopID", SqlDbType.Int,4,model.ShopID) ,                        
             SqlHelper.MakeInParam("@OrderNo", SqlDbType.NVarChar,50,model.OrderNo) ,                        
             SqlHelper.MakeInParam("@UserID", SqlDbType.Int,4,model.UserID) ,                        
             SqlHelper.MakeInParam("@TotalPrice", SqlDbType.Decimal,9,model.TotalPrice) ,                        
             SqlHelper.MakeInParam("@Status", SqlDbType.Int,4,model.Status) ,                        
             SqlHelper.MakeInParam("@OrderTime", SqlDbType.DateTime,model.OrderTime) ,                        
             SqlHelper.MakeInParam("@Remark", SqlDbType.NText,model.Remark) ,                        
             SqlHelper.MakeInParam("@ShipPeopele", SqlDbType.NVarChar,20,model.ShipPeopele) ,                        
             SqlHelper.MakeInParam("@ShipAddress", SqlDbType.NVarChar,250,model.ShipAddress)               
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
        public bool UpdateOrder(Model.Order model)
        {
            SqlParameter[] parameters = {
			           		 SqlHelper.MakeInParam("@OrderID", SqlDbType.Int,4, model.OrderID) ,            
                       		 SqlHelper.MakeInParam("@ShipMobile", SqlDbType.NVarChar,20, model.ShipMobile) ,            
                       		 SqlHelper.MakeInParam("@UserPoint", SqlDbType.Int,4, model.UserPoint) ,            
                       		 SqlHelper.MakeInParam("@SavingByCoupon", SqlDbType.Decimal,9, model.SavingByCoupon) ,            
                       		 SqlHelper.MakeInParam("@RealPay", SqlDbType.Decimal,9, model.RealPay) ,            
                       		 SqlHelper.MakeInParam("@CouponID", SqlDbType.Int,4, model.CouponID) ,            
                       		 SqlHelper.MakeInParam("@CouponNo", SqlDbType.NVarChar,50, model.CouponNo) ,            
                       		 SqlHelper.MakeInParam("@PaidTime", SqlDbType.DateTime, model.PaidTime) ,            
                       		 SqlHelper.MakeInParam("@ShopID", SqlDbType.Int,4, model.ShopID) ,            
                       		 SqlHelper.MakeInParam("@OrderNo", SqlDbType.NVarChar,50, model.OrderNo) ,            
                       		 SqlHelper.MakeInParam("@UserID", SqlDbType.Int,4, model.UserID) ,            
                       		 SqlHelper.MakeInParam("@TotalPrice", SqlDbType.Decimal,9, model.TotalPrice) ,            
                       		 SqlHelper.MakeInParam("@Status", SqlDbType.Int,4, model.Status) ,            
                       		 SqlHelper.MakeInParam("@OrderTime", SqlDbType.DateTime, model.OrderTime) ,            
                       		 SqlHelper.MakeInParam("@Remark", SqlDbType.NText, model.Remark) ,            
                       		 SqlHelper.MakeInParam("@ShipPeopele", SqlDbType.NVarChar,20, model.ShipPeopele) ,            
                       		 SqlHelper.MakeInParam("@ShipAddress", SqlDbType.NVarChar,250, model.ShipAddress)             
              
            
            };

            return SqlHelper.ExecuteNonQuery(CommandType.Text, update_strsql, parameters) > 0 ? true : false;
        }
        #endregion

        #region  删除数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteOrder(int OrderID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4)
			};
            parameters[0].Value = OrderID;

            return SqlHelper.ExecuteNonQuery(CommandType.Text, delete_strsql, parameters) > 0 ? true : false;

        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteOrderList(string OrderIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + tableName + " where OrderID in (" + OrderIDlist + ")  ");
            return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString()) > 0 ? true : false;
        }
        #endregion


        #region 获取对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private Model.Order GetOrderInfo(SqlDataReader dr)
        {
            Model.Order model = new Model.Order();
            model.OrderID = Utils.StrToInt(dr["OrderID"]);
            model.OrderNo = dr["OrderNo"].ToString();
            model.UserID = Utils.StrToInt(dr["UserID"]);
            model.TotalPrice = Utils.StrToDecimal(dr["TotalPrice"].ToString());
            model.Status = Utils.StrToInt(dr["Status"]);
            model.OrderTime = Utils.StrToDateTime(dr["OrderTime"].ToString());
            model.Remark = dr["Remark"].ToString();
            model.ShipPeopele = dr["ShipPeopele"].ToString();
            model.ShipAddress = dr["ShipAddress"].ToString();
            model.ShipMobile = dr["ShipMobile"].ToString();
            model.UserPoint = Utils.StrToInt(dr["UserPoint"]);
            model.SavingByCoupon = Utils.StrToDecimal(dr["SavingByCoupon"].ToString());
            model.RealPay = Utils.StrToDecimal(dr["RealPay"].ToString());
            model.CouponID = Utils.StrToInt(dr["CouponID"]);
            model.CouponNo = dr["CouponNo"].ToString();
            model.PaidTime = Utils.StrToDateTime(dr["PaidTime"].ToString());
            model.UserName = dr["UserName"].ToString();
            model.ShopID = Utils.StrToInt(dr["ShopID"]);		
            return model;
        }
        #endregion

        #region  获取一条数据
        /// <summary>
        /// 根据OrderID获取一条数据
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public Model.Order GetOrderInfo(int OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from " + viewName + " where OrderID=@OrderID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4)
			};
            parameters[0].Value = OrderID;

            SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters);
            while (dr.Read())
            {
                return GetOrderInfo(dr);
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
        public Model.Order GetOrderInfoByCondition(string condition)
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
                return GetOrderInfo(dr);
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
        public List<Model.Order> GetOrderList()
        {
            List<Model.Order> list = new List<Model.Order>();
            SqlDataReader dr = SqlHelper.ExecuteReader(select_strsql);
            while (dr.Read())
            {
                list.Add(GetOrderInfo(dr));
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
        public List<Model.Order> GetOrderList(string condition)
        {
            string strSql = select_strsql + " where ";

            if (condition == "")
            {
                condition = "1=1";
            }
            strSql += condition;
            List<Model.Order> list = new List<Model.Order>();
            SqlDataReader dr = SqlHelper.ExecuteReader(strSql);
            while (dr.Read())
            {
                list.Add(GetOrderInfo(dr));
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
        public List<Model.Order> GetOrderList(int pagesize, int pageindex, string condition)
        {
            List<Model.Order> list = new List<Model.Order>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, "OrderID", "ASC");
            while (dr.Read())
            {
                list.Add(GetOrderInfo(dr));
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
        public List<Model.Order> GetOrderList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            List<Model.Order> list = new List<Model.Order>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, orderby, sorttype);
            while (dr.Read())
            {
                list.Add(GetOrderInfo(dr));
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
        public int GetOrderCount(string condition)
        {
            return this.GetCount(viewName, condition);
        }
        #endregion

        #endregion

        #region MethodEx
        /// <summary>
        /// 订单状态操作
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        public bool UpdateOrderStatus(int orderId, int orderStatus)
        {
            string strSql = "Update " + tableName + " SET Status=" + orderStatus + " Where OrderID=" + orderId;
            return SqlHelper.ExecuteNonQuery(strSql) > 0 ? true : false;
        }
        #endregion
    }
}