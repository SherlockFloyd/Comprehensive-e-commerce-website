using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Shopping.Model
{
    ///<summary>
    ///	商品信息表
    ///	Model实体层 Shopping_Commodity
    ///</summary>
    public class Commodity
    {

        #region  TableProperty

        /// <summary>
        /// ID
        /// </summary>		
        public int CommodityID
        {
            get;
            set;
        }
        /// <summary>
        /// 名称
        /// </summary>		
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 编号
        /// </summary>		
        public string CommodityNo
        {
            get;
            set;
        }
        /// <summary>
        /// 类别ID
        /// </summary>		
        public int CateID
        {
            get;
            set;
        }
        /// <summary>
        /// 市场价
        /// </summary>		
        public decimal MarketPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 售价
        /// </summary>		
        public decimal Price
        {
            get;
            set;
        }
        /// <summary>
        /// 上架状态
        /// </summary>		
        public int OnSale
        {
            get;
            set;
        }
        /// <summary>
        /// 上架时间
        /// </summary>		
        public DateTime OnSaleTime
        {
            get;
            set;
        }
        /// <summary>
        /// 描述
        /// </summary>		
        public string Remark
        {
            get;
            set;
        }
        /// <summary>
        /// 评价总数
        /// </summary>		
        public int RateTotal
        {
            get;
            set;
        }
        /// <summary>
        /// 评价总分
        /// </summary>		
        public decimal GradeTotal
        {
            get;
            set;
        }
        /// <summary>
        /// 添加时间
        /// </summary>		
        public DateTime CreateTime
        {
            get;
            set;
        }
        /// <summary>
        /// 图片
        /// </summary>		
        public string Photo
        {
            get;
            set;
        }
        /// <summary>
        /// 库存
        /// </summary>		
        public int Stock
        {
            get;
            set;
        }
        /// <summary>
        /// 销售总量
        /// </summary>		
        public int SaleTotal
        {
            get;
            set;
        }
        /// <summary>
        /// 是否热销
        /// </summary>		
        public int IsHot
        {
            get;
            set;
        }
        /// <summary>
        /// 是否新品
        /// </summary>		
        public int IsNew
        {
            get;
            set;
        }
        /// <summary>
        /// 是否推荐
        /// </summary>		
        public int IsRecommend
        {
            get;
            set;
        }
        /// <summary>
        /// 浏览量
        /// </summary>		
        public int Visits
        {
            get;
            set;
        }
        /// <summary>
        /// 搜索辅助
        /// </summary>		
        public string ForSerach
        {
            get;
            set;
        }
        /// <summary>
        /// 赠送积分
        /// </summary>		
        public int Point
        {
            get;
            set;
        }
        /// <summary>
        /// 更新时间
        /// </summary>		
        public DateTime UpdateTime
        {
            get;
            set;
        }
        /// <summary>
        /// 用户ID
        /// </summary>		
        public int UserID
        {
            get;
            set;
        }
        #endregion

        #region TablePropertyEx
        /// <summary>
        /// CateName
        /// </summary>		
        private string _catename;
        public string CateName
        {
            get { return _catename; }
            set { _catename = value; }
        }
         


        public string DetailUrl
        {
            get
            {
                return "Detail.aspx?Commodityid=" + CommodityID;
            }

        }

        public string UserName
        {
            set;
            get;
        }

        public string RealName
        {
            set;
            get;
        }

        #endregion
    }
}