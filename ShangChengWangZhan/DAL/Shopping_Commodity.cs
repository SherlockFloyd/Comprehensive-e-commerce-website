
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
   
    public partial class CommodityProvider : SqlDB<CommodityProvider>
    {
        #region Method
        /// <summary>
        /// 数据库表名
        /// </summary>
        private static string tableName = "Shopping_Commodity";
        /// <summary>
        /// 数据库视图名
        /// </summary>
        private static string viewName = "Shopping_View_Commodity";
        /// <summary>
        /// 数据查询语句(查询全部数据)
        /// </summary>
        private string select_strsql = "Select * from " + viewName;


        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string insert_strsql = "Insert into " + tableName + " (MarketPrice,Price,OnSale,OnSaleTime,Remark,Name,RateTotal,GradeTotal,CreateTime,Photo,Stock,SaleTotal,IsHot,IsNew,IsRecommend,Visits,CommodityNo,ForSerach,Point,UpdateTime,UserID,CateID)values(@MarketPrice,@Price,@OnSale,@OnSaleTime,@Remark,@Name,@RateTotal,@GradeTotal,@CreateTime,@Photo,@Stock,@SaleTotal,@IsHot,@IsNew,@IsRecommend,@Visits,@CommodityNo,@ForSerach,@Point,@UpdateTime,@UserID,@CateID)";
        /// <summary>
        /// 数据插入语句
        /// </summary>
        private string count_strsql = "Select Count(*) From " + viewName;
        /// <summary>
        /// 数据更新语句
        /// </summary>
        private string update_strsql = "Update  " + tableName + " Set MarketPrice= @MarketPrice ,Price= @Price ,OnSale= @OnSale ,OnSaleTime= @OnSaleTime ,Remark= @Remark ,Name= @Name ,RateTotal= @RateTotal ,GradeTotal= @GradeTotal ,CreateTime= @CreateTime ,Photo= @Photo ,Stock= @Stock ,SaleTotal= @SaleTotal ,IsHot= @IsHot ,IsNew= @IsNew ,IsRecommend= @IsRecommend ,Visits= @Visits ,CommodityNo= @CommodityNo ,ForSerach= @ForSerach ,Point= @Point ,UpdateTime= @UpdateTime ,UserID= @UserID ,CateID= @CateID   where CommodityID=@CommodityID  ";
        /// <summary>
        /// 数据删除语句(根据主键删除)
        /// </summary>
        private string delete_strsql = "Delete  From " + tableName + "  where CommodityID=@CommodityID";


        #region  判断是否存在
        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public bool ExistCommodity(string condition)
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
        public int AddCommodity(Model.Commodity model)
        {
            SqlParameter[] parameters = {
			            
             SqlHelper.MakeInParam("@MarketPrice", SqlDbType.Decimal,9,model.MarketPrice) ,                        
             SqlHelper.MakeInParam("@Price", SqlDbType.Decimal,9,model.Price) ,                        
             SqlHelper.MakeInParam("@OnSale", SqlDbType.Int,4,model.OnSale) ,                        
             SqlHelper.MakeInParam("@OnSaleTime", SqlDbType.DateTime,model.OnSaleTime) ,                        
             SqlHelper.MakeInParam("@Remark", SqlDbType.NText,model.Remark) ,                        
             SqlHelper.MakeInParam("@Name", SqlDbType.NVarChar,250,model.Name) ,                        
             SqlHelper.MakeInParam("@RateTotal", SqlDbType.Int,4,model.RateTotal) ,                        
             SqlHelper.MakeInParam("@GradeTotal", SqlDbType.Decimal,9,model.GradeTotal) ,                        
             SqlHelper.MakeInParam("@CreateTime", SqlDbType.DateTime,model.CreateTime) ,                        
             SqlHelper.MakeInParam("@Photo", SqlDbType.NVarChar,50,model.Photo) ,                        
             SqlHelper.MakeInParam("@Stock", SqlDbType.Int,4,model.Stock) ,                        
             SqlHelper.MakeInParam("@SaleTotal", SqlDbType.Int,4,model.SaleTotal) ,                        
             SqlHelper.MakeInParam("@IsHot", SqlDbType.Int,4,model.IsHot) ,                        
             SqlHelper.MakeInParam("@IsNew", SqlDbType.Int,4,model.IsNew) ,                        
             SqlHelper.MakeInParam("@IsRecommend", SqlDbType.Int,4,model.IsRecommend) ,                        
             SqlHelper.MakeInParam("@Visits", SqlDbType.Int,4,model.Visits) ,                        
             SqlHelper.MakeInParam("@CommodityNo", SqlDbType.NVarChar,250,model.CommodityNo) ,                        
             SqlHelper.MakeInParam("@ForSerach", SqlDbType.NVarChar,-1,model.ForSerach) ,                        
             SqlHelper.MakeInParam("@Point", SqlDbType.Int,4,model.Point) ,                        
             SqlHelper.MakeInParam("@UpdateTime", SqlDbType.DateTime,model.UpdateTime) ,                        
             SqlHelper.MakeInParam("@UserID", SqlDbType.Int,4,model.UserID) ,                        
             SqlHelper.MakeInParam("@CateID", SqlDbType.Int,4,model.CateID)               
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
        public bool UpdateCommodity(Model.Commodity model)
        {
            SqlParameter[] parameters = {
			           		 SqlHelper.MakeInParam("@CommodityID", SqlDbType.Int,4, model.CommodityID) ,            
                       		 SqlHelper.MakeInParam("@MarketPrice", SqlDbType.Decimal,9, model.MarketPrice) ,            
                       		 SqlHelper.MakeInParam("@Price", SqlDbType.Decimal,9, model.Price) ,            
                       		 SqlHelper.MakeInParam("@OnSale", SqlDbType.Int,4, model.OnSale) ,            
                       		 SqlHelper.MakeInParam("@OnSaleTime", SqlDbType.DateTime, model.OnSaleTime) ,            
                       		 SqlHelper.MakeInParam("@Remark", SqlDbType.NText, model.Remark) ,            
                       		 SqlHelper.MakeInParam("@Name", SqlDbType.NVarChar,250, model.Name) ,            
                       		 SqlHelper.MakeInParam("@RateTotal", SqlDbType.Int,4, model.RateTotal) ,            
                       		 SqlHelper.MakeInParam("@GradeTotal", SqlDbType.Decimal,9, model.GradeTotal) ,            
                       		 SqlHelper.MakeInParam("@CreateTime", SqlDbType.DateTime, model.CreateTime) ,            
                       		 SqlHelper.MakeInParam("@Photo", SqlDbType.NVarChar,50, model.Photo) ,            
                       		 SqlHelper.MakeInParam("@Stock", SqlDbType.Int,4, model.Stock) ,            
                       		 SqlHelper.MakeInParam("@SaleTotal", SqlDbType.Int,4, model.SaleTotal) ,            
                       		 SqlHelper.MakeInParam("@IsHot", SqlDbType.Int,4, model.IsHot) ,            
                       		 SqlHelper.MakeInParam("@IsNew", SqlDbType.Int,4, model.IsNew) ,            
                       		 SqlHelper.MakeInParam("@IsRecommend", SqlDbType.Int,4, model.IsRecommend) ,            
                       		 SqlHelper.MakeInParam("@Visits", SqlDbType.Int,4, model.Visits) ,            
                       		 SqlHelper.MakeInParam("@CommodityNo", SqlDbType.NVarChar,250, model.CommodityNo) ,            
                       		 SqlHelper.MakeInParam("@ForSerach", SqlDbType.NVarChar,-1, model.ForSerach) ,            
                       		 SqlHelper.MakeInParam("@Point", SqlDbType.Int,4, model.Point) ,            
                       		 SqlHelper.MakeInParam("@UpdateTime", SqlDbType.DateTime, model.UpdateTime) ,            
                       		 SqlHelper.MakeInParam("@UserID", SqlDbType.Int,4, model.UserID) ,            
                       		 SqlHelper.MakeInParam("@CateID", SqlDbType.Int,4, model.CateID)             
              
            
            };

            return SqlHelper.ExecuteNonQuery(CommandType.Text, update_strsql, parameters) > 0 ? true : false;
        }
        #endregion

        #region  删除数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteCommodity(int CommodityID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@CommodityID", SqlDbType.Int,4)
};
            parameters[0].Value = CommodityID;

            return SqlHelper.ExecuteNonQuery(CommandType.Text, delete_strsql, parameters) > 0 ? true : false;

        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteCommodityList(string CommodityIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + tableName + " where CommodityID in (" + CommodityIDlist + ")  ");
            return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString()) > 0 ? true : false;
        }
        #endregion

        #region 获取对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private Model.Commodity GetCommodityInfo(SqlDataReader dr)
        {
            Model.Commodity model = new Model.Commodity();
            model.CommodityID = Utils.StrToInt(dr["CommodityID"]);
            model.MarketPrice = Utils.StrToDecimal(dr["MarketPrice"].ToString());
            model.Price = Utils.StrToDecimal(dr["Price"].ToString()); 
            model.OnSale = Utils.StrToInt(dr["OnSale"]);
            model.OnSaleTime = Utils.StrToDateTime(dr["OnSaleTime"].ToString());
            model.Remark = dr["Remark"].ToString();
            model.Name = dr["Name"].ToString(); 
            model.RateTotal = Utils.StrToInt(dr["RateTotal"]);
            model.GradeTotal = Utils.StrToDecimal(dr["GradeTotal"].ToString()); 
            model.CreateTime = Utils.StrToDateTime(dr["CreateTime"].ToString());
            model.Photo = dr["Photo"].ToString(); 
            model.Stock = Utils.StrToInt(dr["Stock"]);
            model.SaleTotal = Utils.StrToInt(dr["SaleTotal"]);
            model.IsHot = Utils.StrToInt(dr["IsHot"]);
            model.IsNew = Utils.StrToInt(dr["IsNew"]);
            model.IsRecommend = Utils.StrToInt(dr["IsRecommend"]);
            model.Visits = Utils.StrToInt(dr["Visits"]);
            model.CommodityNo = dr["CommodityNo"].ToString();
            model.ForSerach = dr["ForSerach"].ToString(); 
            model.Point = Utils.StrToInt(dr["Point"]);
            model.UpdateTime = Utils.StrToDateTime(dr["UpdateTime"].ToString());
            model.UserID = Utils.StrToInt(dr["UserID"]);
            model.CateID = Utils.StrToInt(dr["CateID"]);
            model.UserName = dr["UserName"].ToString();
            model.RealName = dr["RealName"].ToString();
            return model;
        }
        #endregion

        #region  获取一条数据
        /// <summary>
        /// 根据CommodityID获取一条数据
        /// </summary>
        /// <param name="CommodityID"></param>
        /// <returns></returns>
        public Model.Commodity GetCommodityInfo(int CommodityID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from " + viewName + " where CommodityID=@CommodityID");
            SqlParameter[] parameters = {
					new SqlParameter("@CommodityID", SqlDbType.Int,4)
};
            parameters[0].Value = CommodityID;

            SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters);
            while (dr.Read())
            {
                return GetCommodityInfo(dr);
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
        public Model.Commodity GetCommodityInfoByCondition(string condition)
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
                return GetCommodityInfo(dr);
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
        public List<Model.Commodity> GetCommodityList()
        {
            List<Model.Commodity> list = new List<Model.Commodity>();
            SqlDataReader dr = SqlHelper.ExecuteReader(select_strsql);
            while (dr.Read())
            {
                list.Add(GetCommodityInfo(dr));
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
        public List<Model.Commodity> GetCommodityList(string condition)
        {
            string strSql = select_strsql + " where ";

            if (condition == "")
            {
                condition = "1=1";
            }
            strSql += condition;
            List<Model.Commodity> list = new List<Model.Commodity>();
            SqlDataReader dr = SqlHelper.ExecuteReader(strSql);
            while (dr.Read())
            {
                list.Add(GetCommodityInfo(dr));
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
        public List<Model.Commodity> GetCommodityList(int pagesize, int pageindex, string condition)
        {
            List<Model.Commodity> list = new List<Model.Commodity>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, "CommodityID", "ASC");
            while (dr.Read())
            {
                list.Add(GetCommodityInfo(dr));
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
        public List<Model.Commodity> GetCommodityList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            List<Model.Commodity> list = new List<Model.Commodity>();
            SqlDataReader dr = this.GetList(viewName, pagesize, pageindex, condition, orderby, sorttype);
            while (dr.Read())
            {
                list.Add(GetCommodityInfo(dr));
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
        public int GetCommodityCount(string condition)
        {
            return this.GetCount(viewName, condition);
        }
        #endregion

        #endregion



        #region MethodEx

        /// <summary>
        /// 更新商品库存
        /// </summary>
        /// <param name="CommodityId">库存ID</param>
        /// <param name="quantity">数量</param>
        /// <param name="type">类型[1:销售出库,其他的待定]</param>
        /// <returns></returns>
        public bool UpdateCommodityStock(int CommodityId, int quantity, int type)
        {
            StringBuilder strSql = new StringBuilder();

            if (type == 1)
            {
                strSql.AppendFormat("Update {0} Set Stock=Stock-{1},SaleTotal=SaleTotal+{1} Where CommodityID=" + CommodityId, tableName, quantity, CommodityId);
            }
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0 ? true : false;
        }

        /// <summary>
        /// 批量更新商品上下架状态
        /// </summary>
        /// <param name="Commodityids"></param>
        /// <returns></returns>
        public bool BatchUpdateCommodityStatus(int status, string Commodityids)
        {
            return SqlHelper.ExecuteNonQuery("Update " + tableName + " SET OnSale=" + status + ",OnSaleTime=getdate() Where CommodityID in(" + Commodityids + ")") > 0 ? true : false;
        }



        #endregion



    }
}