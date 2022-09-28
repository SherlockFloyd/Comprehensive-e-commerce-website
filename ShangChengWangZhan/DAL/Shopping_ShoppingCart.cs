
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
   
    ///	购物车信息表
    ///	数据层实例化接口类 Shopping_ShoppingCart
    /// 主要完成对数据库的基本操作
    /// </summary>
    public partial class ShoppingCartItemInfoProvider : SqlDB<ShoppingCartItemInfoProvider>
    {
        #region Method
        /// <summary>
        /// 数据库表名
        /// </summary>
        private static string tableName = "Shopping_ShoppingCart";
        /// <summary>
        /// 数据库视图名
        /// </summary>
        private static string viewName = "Shopping_View_ShoppingCart";
        /// <summary>
        /// 数据查询语句(查询全部数据)
        /// </summary>
        private string select_strsql = "Select * from " + viewName;


        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string insert_strsql = "Insert into " + tableName + " (UserID,CommodityID,Price,Quantity,IsChecked,GuestID)values(@UserID,@CommodityID,@Price,@Quantity,@IsChecked,@GuestID)";
        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string count_strsql = "Select Count(*) From " + viewName;
        /// <summary>
        /// 数据更新语句
        /// </summary>
        private string update_strsql = "Update  " + tableName + " Set UserID= @UserID ,CommodityID= @CommodityID ,Price= @Price ,Quantity= @Quantity ,IsChecked= @IsChecked ,GuestID= @GuestID   where ShoppingCartID=@ShoppingCartID  ";
        /// <summary>
        /// 数据删除语句(根据主键删除)
        /// </summary>
        private string delete_strsql = "Delete  From " + tableName + "  where ShoppingCartID=@ShoppingCartID";


        #region  判断是否存在
        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public bool ExistShoppingCart(string condition)
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
        public int AddShoppingCart(Model.ShoppingCartItemInfo model)
        {
            SqlParameter[] parameters = {
			            
             SqlHelper.MakeInParam("@UserID", SqlDbType.Int,4,model.UserID) ,                        
             SqlHelper.MakeInParam("@CommodityID", SqlDbType.Int,4,model.CommodityID) ,                        
             SqlHelper.MakeInParam("@Price", SqlDbType.Decimal,9,model.Price) ,                        
             SqlHelper.MakeInParam("@Quantity", SqlDbType.Int,4,model.Quantity) ,                        
             SqlHelper.MakeInParam("@IsChecked", SqlDbType.Int,4,model.IsChecked) ,                        
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
        public bool UpdateShoppingCart(Model.ShoppingCartItemInfo model)
        {
            SqlParameter[] parameters = {
			           		 SqlHelper.MakeInParam("@ShoppingCartID", SqlDbType.Int,4, model.ShoppingCartID) ,            
                       		 SqlHelper.MakeInParam("@UserID", SqlDbType.Int,4, model.UserID) ,            
                       		 SqlHelper.MakeInParam("@CommodityID", SqlDbType.Int,4, model.CommodityID) ,            
                       		 SqlHelper.MakeInParam("@Price", SqlDbType.Decimal,9, model.Price) ,            
                       		 SqlHelper.MakeInParam("@Quantity", SqlDbType.Int,4, model.Quantity) ,            
                       		 SqlHelper.MakeInParam("@IsChecked", SqlDbType.Int,4, model.IsChecked) ,            
                       		 SqlHelper.MakeInParam("@GuestID", SqlDbType.NVarChar,50, model.GuestID)             
              
            
            };

            return SqlHelper.ExecuteNonQuery(CommandType.Text, update_strsql, parameters) > 0 ? true : false;
        }
        #endregion

        #region  删除数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteShoppingCart(int ShoppingCartID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ShoppingCartID", SqlDbType.Int,4)
			};
            parameters[0].Value = ShoppingCartID;

            return SqlHelper.ExecuteNonQuery(CommandType.Text, delete_strsql, parameters) > 0 ? true : false;

        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteShoppingCartList(string ShoppingCartIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + tableName + " where ShoppingCartID in (" + ShoppingCartIDlist + ")  ");
            return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString()) > 0 ? true : false;
        }
        #endregion


        #region 获取对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private Model.ShoppingCartItemInfo GetShoppingCartInfo(SqlDataReader dr)
        {
            Model.ShoppingCartItemInfo model = new Model.ShoppingCartItemInfo();
            model.ShoppingCartID = Utils.StrToInt(dr["ShoppingCartID"]);
            model.Stock = Utils.StrToInt(dr["Stock"]);
            model.UserID = Utils.StrToInt(dr["UserID"]);
            model.CommodityID = Utils.StrToInt(dr["CommodityID"]);
            model.Price = Utils.StrToDecimal(dr["Price"].ToString()); model.Quantity = Utils.StrToInt(dr["Quantity"]);
            model.IsChecked = Utils.StrToInt(dr["IsChecked"]);
            model.GuestID = dr["GuestID"].ToString();
            model.Name = dr["Name"].ToString();
            model.Photo = dr["Photo"].ToString();
            model.ShopID =Utils.StrToInt(dr["ShopID"]);
            return model;
        }
        #endregion

        #region  获取一条数据
        /// <summary>
        /// 根据ShoppingCartID获取一条数据
        /// </summary>
        /// <param name="ShoppingCartID"></param>
        /// <returns></returns>
        public Model.ShoppingCartItemInfo GetShoppingCartInfo(int ShoppingCartID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from " + viewName + " where ShoppingCartID=@ShoppingCartID");
            SqlParameter[] parameters = {
					new SqlParameter("@ShoppingCartID", SqlDbType.Int,4)
			};
            parameters[0].Value = ShoppingCartID;

            SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters);
            while (dr.Read())
            {
                return GetShoppingCartInfo(dr);
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
        public Model.ShoppingCartItemInfo GetShoppingCartInfoByCondition(string condition)
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
                return GetShoppingCartInfo(dr);
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
        public List<Model.ShoppingCartItemInfo> GetShoppingCartList()
        {
            List<Model.ShoppingCartItemInfo> list = new List<Model.ShoppingCartItemInfo>();
            SqlDataReader dr = SqlHelper.ExecuteReader(select_strsql);
            while (dr.Read())
            {
                list.Add(GetShoppingCartInfo(dr));
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
        public List<Model.ShoppingCartItemInfo> GetShoppingCartList(string condition)
        {
            string strSql = select_strsql + " where ";

            if (condition == "")
            {
                condition = "1=1";
            }
            strSql += condition;
            List<Model.ShoppingCartItemInfo> list = new List<Model.ShoppingCartItemInfo>();
            SqlDataReader dr = SqlHelper.ExecuteReader(strSql);
            while (dr.Read())
            {
                list.Add(GetShoppingCartInfo(dr));
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
        public List<Model.ShoppingCartItemInfo> GetShoppingCartList(int pagesize, int pageindex, string condition)
        {
            List<Model.ShoppingCartItemInfo> list = new List<Model.ShoppingCartItemInfo>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, "ShoppingCartID", "ASC");
            while (dr.Read())
            {
                list.Add(GetShoppingCartInfo(dr));
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
        public List<Model.ShoppingCartItemInfo> GetShoppingCartList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            List<Model.ShoppingCartItemInfo> list = new List<Model.ShoppingCartItemInfo>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, orderby, sorttype);
            while (dr.Read())
            {
                list.Add(GetShoppingCartInfo(dr));
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
        public int GetShoppingCartCount(string condition)
        {
            return this.GetCount(viewName, condition);
        }
        #endregion

        #endregion

        #region MethodEx

        /// <summary>
        /// 删除游客购物车的项
        /// </summary>
        /// <param name="guestID"></param>
        /// <returns></returns>
        public bool DeleteShoppingCartByGuestID(string guestID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("DELETE FROM {0} Where guestID='{1}' ", tableName, guestID);
            return ((int)SqlHelper.ExecuteNonQuery(strSql.ToString())) > 0 ? true : false;
        }

        /// <summary>
        /// 清空购物车
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool ClearShoppingCart(int userID, int IsChecked)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("DELETE FROM {0} Where UserID={1} AND IsChecked={2}", tableName, userID, IsChecked);
            return ((int)SqlHelper.ExecuteNonQuery(strSql.ToString())) > 0 ? true : false;
        }
        #endregion

    }
}