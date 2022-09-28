
using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Shopping.DAL;

namespace Shopping.BLL
{

  
    public class CommodityBLL
    {

        #region #Method
        /// <summary>
        /// 全局变量
        /// </summary>
        private static CommodityProvider DAL = CommodityProvider.GetInstance();


        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static bool ExistCommodity(string condition)
        {
            return DAL.ExistCommodity(condition);
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static int AddCommodity(Model.Commodity model)
        {
            return DAL.AddCommodity(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">类实体</param>
        /// <returns></returns>
        public static bool UpdateCommodity(Model.Commodity model)
        {
            return DAL.UpdateCommodity(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteCommodity(int CommodityID)
        {
            return DAL.DeleteCommodity(CommodityID);
        }



        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteCommodityList(string CommodityIDlist)
        {
            return DAL.DeleteCommodityList(CommodityIDlist);
        }


        /// <summary>
        /// 根据CommodityID获取一条数据
        /// </summary>
        /// <param name="CommodityID"></param>
        /// <returns></returns>
        public static Model.Commodity GetCommodityInfo(int CommodityID)
        {
            return DAL.GetCommodityInfo(CommodityID);
        }

        /// <summary>
        /// 根据过滤条件获取一条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static Model.Commodity GetCommodityInfoByCondition(string condition)
        {
            return DAL.GetCommodityInfoByCondition(condition);
        }

        /// <summary>
        /// 获取全部的数据列表
        /// </summary>
        /// <returns></returns>
        public static List<Model.Commodity> GetCommodityList()
        {
            return DAL.GetCommodityList();
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.Commodity> GetCommodityList(string condition)
        {
            return DAL.GetCommodityList(condition);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns>
        public static List<Model.Commodity> GetCommodityList(int pagesize, int pageindex, string condition)
        {
            return DAL.GetCommodityList(pagesize, pageindex, condition);
        }

        /// <summary>
        /// 根据CommodityID数据列表
        /// </summary>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="sorttype">排序类型（ASC，DESC）</param>
        /// <returns></returns>
        public static List<Model.Commodity> GetCommodityList(int pagesize, int pageindex, string condition, string orderby, string sorttype)
        {
            return DAL.GetCommodityList(pagesize, pageindex, condition, orderby, sorttype);
        }


        /// <summary>
        /// 根据条件获取前几条信息
        /// </summary>
        /// <param name="top"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static List<Model.Commodity> GetCommodityList(int top, string condition)
        {
            return DAL.GetCommodityList(top, 1, condition);
        }
        /// <summary>
        /// 根据条件获取前几条信息
        /// </summary>
        /// <param name="top"></param>
        /// <param name="condition"></param>
        /// <param name="orderby"></param>
        /// <param name="sorttype"></param>
        /// <returns></returns>
        public static List<Model.Commodity> GetCommodityList(int top, string condition, string orderby, string sorttype)
        {
            return DAL.GetCommodityList(top, 1, condition, orderby, sorttype);
        }
        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="tableName">表名或视图名</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int GetCommodityCount(string condition)
        {
            return DAL.GetCommodityCount(condition);
        }
        #endregion

        #region MethodEx

        /// <summary>
        /// 更新商品库存
        /// </summary>
        /// <param name="CommodityId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public static bool UpdateCommodityStock(int CommodityId, int quantity, int type)
        {
            return DAL.UpdateCommodityStock(CommodityId, quantity, type);
        }

        /// <summary>
        /// 批量更新商品上下架状态
        /// </summary>
        /// <param name="Commodityids"></param>
        /// <returns></returns>
        public static bool BatchUpdateCommodityStatus(int status, string Commodityids)
        {
            return DAL.BatchUpdateCommodityStatus(status, Commodityids);
        }







        public static string GetCommodityStatus(Model.Commodity CommodityInfo)
        {
            string result = "";
            if (CommodityInfo.IsRecommend == 1)
            {
                result = "<em class=\"icons icon-recommend\"></em>";
            }
            if (CommodityInfo.IsNew == 1)
            {
                result = "<em class=\"icons icon-new\"></em>";
            }
            if (CommodityInfo.IsHot == 1)
            {
                result = "<em class=\"icons icon-hot\"></em>";
            }
            return result;
        }

        /// <summary>
        /// 根据CommodityID检查库存
        /// </summary>
        /// <param name="CommodityId"></param>
        /// <returns></returns>
        public static int CheckStock(int CommodityId, int quantity)
        {
            Model.Commodity CommodityInfo = GetCommodityInfo(CommodityId);

            if (CommodityInfo != null)
            {
                return (CommodityInfo.Stock > quantity) ? 1 : -1;
            }
            return 0;
        }

        #endregion
    }
}