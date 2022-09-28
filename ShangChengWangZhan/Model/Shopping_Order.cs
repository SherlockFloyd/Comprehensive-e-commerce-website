using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Shopping.Model
{
    ///<summary>
    ///	订单信息表
    ///	Model实体层 Shopping_Order
    ///</summary>
    public class Order
    {
        #region  TableProperty
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
        /// 订单编号
        /// </summary>		
        private string _orderno;
        public string OrderNo
        {
            get { return _orderno; }
            set { _orderno = value; }
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
        /// 订单总价
        /// </summary>		
        private decimal _totalprice;
        public decimal TotalPrice
        {
            get { return _totalprice; }
            set { _totalprice = value; }
        }
        /// <summary>
        /// 订单状态
        /// </summary>		
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// 订单时间
        /// </summary>		
        private DateTime _ordertime;
        public DateTime OrderTime
        {
            get { return _ordertime; }
            set { _ordertime = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>		
        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// 收货人
        /// </summary>		
        private string _shippeopele;
        public string ShipPeopele
        {
            get { return _shippeopele; }
            set { _shippeopele = value; }
        }
        /// <summary>
        /// 收货地址
        /// </summary>		
        private string _shipaddress;
        public string ShipAddress
        {
            get { return _shipaddress; }
            set { _shipaddress = value; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>		
        private string _shipmobile;
        public string ShipMobile
        {
            get { return _shipmobile; }
            set { _shipmobile = value; }
        }
        /// <summary>
        /// 积分使用数量
        /// </summary>		
        private int _userpoint;
        public int UserPoint
        {
            get { return _userpoint; }
            set { _userpoint = value; }
        }
        /// <summary>
        /// 优惠券优惠金额
        /// </summary>		
        private decimal _savingbycoupon;
        public decimal SavingByCoupon
        {
            get { return _savingbycoupon; }
            set { _savingbycoupon = value; }
        }
        /// <summary>
        /// 实际付款金额
        /// </summary>		
        private decimal _realpay;
        public decimal RealPay
        {
            get { return _realpay; }
            set { _realpay = value; }
        }
        /// <summary>
        /// 优惠券ID
        /// </summary>		
        private int _couponid;
        public int CouponID
        {
            get { return _couponid; }
            set { _couponid = value; }
        }
        /// <summary>
        /// 优惠券编号
        /// </summary>		
        private string _couponno;
        public string CouponNo
        {
            get { return _couponno; }
            set { _couponno = value; }
        }
        /// <summary>
        /// 付款时间
        /// </summary>		
        private DateTime _paidtime;
        public DateTime PaidTime
        {
            get { return _paidtime; }
            set { _paidtime = value; }
        }

        /// <summary>
        /// 用户ID 谁发布的商品等价于UserID
        /// </summary>		
        public int ShopID
        {
            get;
            set;
        }
        #endregion

        #region TablePropertyEx
        private string _username;
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        public string OrderStatusName
        {
            get
            {
                return OrderUtils.GetOrderStatusName(Status);
            }
        }


        #endregion




    }
}