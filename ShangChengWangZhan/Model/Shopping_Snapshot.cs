using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Shopping.Model
{
    ///<summary>
    ///	订单快照信息表
    ///	Model实体层 Shopping_Snapshot
    ///</summary>
    public class Snapshot
    {
        #region  TableProperty
        /// <summary>
        /// 快照ID
        /// </summary>		
        private int _snapshotid;
        public int SnapshotID
        {
            get { return _snapshotid; }
            set { _snapshotid = value; }
        }
        /// <summary>
        /// 订单ID
        /// </summary>		
        private int _orderid;
        public int OrderID
        {
            get { return _orderid; }
            set { _orderid = value; }
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
        /// 数量
        /// </summary>		
        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        /// <summary>
        /// 价格
        /// </summary>		
        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        /// <summary>
        /// 总价
        /// </summary>		
        private decimal _totalprice;
        public decimal TotalPrice
        {
            get { return _totalprice; }
            set { _totalprice = value; }
        }
        /// <summary>
        /// 是否评价
        /// </summary>		
        private int _isgrade;
        public int IsGrade
        {
            get { return _isgrade; }
            set { _isgrade = value; }
        }
        #endregion

        #region TablePropertyEx
        /// <summary>
        /// UserName
        /// </summary>		
        private string _username;
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        /// <summary>
        /// CommodityNo
        /// </summary>		
        private string _Commodityno;
        public string CommodityNo
        {
            get { return _Commodityno; }
            set { _Commodityno = value; }
        }
       
        /// <summary>
        /// Point
        /// </summary>		
        private int _point;
        public int Point
        {
            get { return _point; }
            set { _point = value; }
        }
        /// <summary>
        /// Name
        /// </summary>		
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// Photo
        /// </summary>		
        private string _photo;
        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        private int _userid;
        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }

        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        private int _Stock;
        public int Stock
        {
            get { return _Stock; }
            set { _Stock = value; }
        }

        public int Grade
        {
            set;
            get;
        }

        public int HtmlGrade
        {
            get
            {
                return 14 * Grade;
            }
        }
        #endregion

    }
}