
using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Shopping.Model;
using Shopping.Data;


namespace Shopping
{

	
	/// </summary>
	public class AttentionBLL
	{
		#region #Method
		/// <summary>
        /// 全局变量
        /// </summary>
        private static	AttentionProvider DAL = AttentionProvider.GetInstance();
       
		
		/// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
		public static bool ExistAttention(string condition)
		{
			return DAL.ExistAttention(condition);
		}
		
		/// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
		public static int AddAttention(Model.Attention model)
		{
			return DAL.AddAttention( model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		/// <param name="model">类实体</param>
		/// <returns></returns>
		public static bool UpdateAttention(Model.Attention model)
		{
			return DAL.UpdateAttention(model);
		}
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public  static bool DeleteAttention(int AttentionID)
		{
			return DAL.DeleteAttention(AttentionID);
		}
		
		
				
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public static bool DeleteAttentionList(string AttentionIDlist )
		{
			return DAL.DeleteAttentionList( AttentionIDlist );
		}
        
				
		/// <summary>
        /// 根据AttentionID获取一条数据
        /// </summary>
        /// <param name="AttentionID"></param>
        /// <returns></returns>
		public static Model.Attention GetAttentionInfo(int AttentionID)
		{
			return DAL.GetAttentionInfo(AttentionID);
		}

		/// <summary>
        /// 根据过滤条件获取一条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static Model.Attention GetAttentionInfoByCondition(string condition)
        {
        	return DAL.GetAttentionInfoByCondition(condition);
        }
        
        /// <summary>
        /// 获取全部的数据列表
        /// </summary>
        /// <returns></returns>
		public static List<Model.Attention> GetAttentionList()
        {
        	return DAL.GetAttentionList();
        }
        
		/// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
		public static List<Model.Attention> GetAttentionList(string condition)
        {
        	return DAL.GetAttentionList(condition);
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
		public static List<Model.Attention> GetAttentionList(int pagesize, int pageindex, string condition)
        {
			return DAL.GetAttentionList(pagesize,pageindex,condition);
		}
        
		/// <summary>
        /// 根据AttentionID数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="sorttype">排序类型（ASC，DESC）</param>
        /// <returns></returns>
		public static List<Model.Attention> GetAttentionList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
           return DAL.GetAttentionList( pagesize,  pageindex,  condition,  orderby,  sorttype);
        }
		

 		/// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="tableName">表名或视图名</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int GetAttentionCount(string condition)
        {
            return DAL.GetAttentionCount(condition);
        }
        #endregion 
        
        #region MethodEx
        #endregion
	}
}