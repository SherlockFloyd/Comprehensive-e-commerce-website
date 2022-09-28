using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Shopping.Model
{
    ///<summary>
    ///	关注信息表
    ///	Model实体层 Shopping_Attention
    ///</summary>
    public class Attention
    {

        #region  TableProperty
        /// <summary>
        /// ID
        /// </summary>		
        public int AttentionID
        {
            get;
            set;
        }
        /// <summary>
        /// 商品ID
        /// </summary>		
        public int CommodityID
        {
            get;
            set;
        }
        /// <summary>
        /// 商品名称
        /// </summary>		
        public string CommodityName
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
        /// <summary>
        /// 关注时间
        /// </summary>		
        public DateTime CreateTime
        {
            get;
            set;
        }
        #endregion

        #region TablePropertyEx
        /// <summary>
        /// 图片
        /// </summary>		
        private string _photo;
        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }
        #endregion
    }
}