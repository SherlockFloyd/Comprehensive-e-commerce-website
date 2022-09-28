using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Shopping.Model
{
    ///<summary>
    ///	浏览信息记录表
    ///	Model实体层 Shopping_VisitLog
    ///</summary>
    public class VisitLog
    {

        #region  TableProperty
        /// <summary>
        /// ID
        /// </summary>		
        private int _logid;
        public int LogID
        {
            get { return _logid; }
            set { _logid = value; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>		
        private int _userid;
        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// 商品ID
        /// </summary>		
        private int _Commodityid;
        public int CommodityID
        {
            get { return _Commodityid; }
            set { _Commodityid = value; }
        }
        /// <summary>
        /// 浏览次数
        /// </summary>		
        private int _visits;
        public int Visits
        {
            get { return _visits; }
            set { _visits = value; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>		
        private DateTime _updatetime;
        public DateTime UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }
        /// <summary>
        /// 游客
        /// </summary>		
        private string _guestid;
        public string GuestID
        {
            get { return _guestid; }
            set { _guestid = value; }
        }
        #endregion

        #region TablePropertyEx

        public string Name
        {
            set;
            get;
        }
        public string Photo
        {
            set;
            get;
        }

        public decimal Price
        {
            set;
            get;
        }

        public decimal MarketPrice
        {
            set;
            get;
        }
        #endregion
    }
}