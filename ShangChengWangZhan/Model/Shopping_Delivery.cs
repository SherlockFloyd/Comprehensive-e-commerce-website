using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Shopping.Model
{
    ///<summary>
    ///	收货地址信息表
    ///	Model实体层 Shopping_Delivery
    ///</summary>
    public class Delivery
    {

        #region  TableProperty
        /// <summary>
        /// ID
        /// </summary>		
        private int _deliveryid;
        public int DeliveryID
        {
            get { return _deliveryid; }
            set { _deliveryid = value; }
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
        /// 收货人
        /// </summary>		
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>		
        private string _tel;
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        /// <summary>
        /// 地址
        /// </summary>		
        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        /// <summary>
        /// 是否默认
        /// </summary>		
        private int _isdefault;
        public int IsDefault
        {
            get { return _isdefault; }
            set { _isdefault = value; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        #endregion

        #region TablePropertyEx

        #endregion
    }
}