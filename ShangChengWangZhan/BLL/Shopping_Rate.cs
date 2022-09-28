
using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Shopping.DAL;

namespace Shopping
{

	
	/// </summary>
	public class RateBLL
	{
	
		/// <summary>
        /// 全局变量
        /// </summary>
        private static	RateProvider DAL = RateProvider.GetInstance();
       
		
		/// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
		public static bool ExistRate(string condition)
		{
			return DAL.ExistRate(condition);
		}
		
		/// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
		public static int AddRate(Model.Rate model)
		{
			return DAL.AddRate( model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		/// <param name="model">类实体</param>
		/// <returns></returns>
		public static bool UpdateRate(Model.Rate model)
		{
			return DAL.UpdateRate(model);
		}
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public  static bool DeleteRate(int RateID)
		{
			return DAL.DeleteRate(RateID);
		}
		
		
				
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public static bool DeleteRateList(string RateIDlist )
		{
			return DAL.DeleteRateList( RateIDlist );
		}
        
				
		/// <summary>
        /// 根据RateID获取一条数据
        /// </summary>
        /// <param name="RateID"></param>
        /// <returns></returns>
		public static Model.Rate GetRateInfo(int RateID)
		{
			return DAL.GetRateInfo(RateID);
		}

		/// <summary>
        /// 根据过滤条件获取一条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static Model.Rate GetRateInfoByCondition(string condition)
        {
        	return DAL.GetRateInfoByCondition(condition);
        }
        
        /// <summary>
        /// 获取全部的数据列表
        /// </summary>
        /// <returns></returns>
		public static List<Model.Rate> GetRateList()
        {
        	return DAL.GetRateList();
        }
        
		/// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
		public static List<Model.Rate> GetRateList(string condition)
        {
        	return DAL.GetRateList(condition);
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
		public static List<Model.Rate> GetRateList(int pagesize, int pageindex, string condition)
        {
			return DAL.GetRateList(pagesize,pageindex,condition);
		}
        
		/// <summary>
        /// 根据RateID数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="sorttype">排序类型（ASC，DESC）</param>
        /// <returns></returns>
		public static List<Model.Rate> GetRateList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
           return DAL.GetRateList( pagesize,  pageindex,  condition,  orderby,  sorttype);
        }
		

 		/// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="tableName">表名或视图名</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int GetRateCount(string condition)
        {
            return DAL.GetRateCount(condition);
        }
	}
}