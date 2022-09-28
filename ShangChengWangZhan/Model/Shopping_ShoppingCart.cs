using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Shopping.Model
{
    ///<summary>
    ///	购物车信息表
    ///	Model实体层 Shopping_ShoppingCart
    ///</summary>
    public class ShoppingCartItemInfo
    {
        #region  TableProperty
        /// <summary>
        /// ID
        /// </summary>		
        private int _shoppingcartid;
        public int ShoppingCartID
        {
            get { return _shoppingcartid; }
            set { _shoppingcartid = value; }
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
        /// 价格
        /// </summary>		
        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
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
        /// IsChecked
        /// </summary>		
        private int _ischecked;
        public int IsChecked
        {
            get { return _ischecked; }
            set { _ischecked = value; }
        }
        /// <summary>
        /// 游客ID
        /// </summary>		
        private string _guestid;
        public string GuestID
        {
            get { return _guestid; }
            set { _guestid = value; }
        }
        #endregion

        #region TablePropertyEx
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
       
        /// <summary>
        /// Stock
        /// </summary>		
        private int _stock;
        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }
        public decimal TotalPrice
        {
            get
            {
                return Price * Quantity;
            }
        }

        public int ShopID
        {
            set;
            get;

        }
        #endregion





    }
}