using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Shopping.Model
{
	///<summary>
    ///	积分记录表
    ///	Model实体层 Shopping_UsePointLog
    ///</summary>
	public class UsePointLog
	{     
	
		#region  TableProperty
      	        /// <summary>
		/// ID
        /// </summary>		
		private int _logid;
        public int LogID
        {
            get{ return _logid; }
            set{ _logid = value; }
        }        
		        /// <summary>
		/// 订单ID
        /// </summary>		
		private int _orderid;
        public int OrderID
        {
            get{ return _orderid; }
            set{ _orderid = value; }
        }        
		        /// <summary>
		/// 积分
        /// </summary>		
		private int _point;
        public int Point
        {
            get{ return _point; }
            set{ _point = value; }
        }        
		        /// <summary>
		/// 用户ID
        /// </summary>		
		private int _userid;
        public int UserID
        {
            get{ return _userid; }
            set{ _userid = value; }
        }        
		        /// <summary>
		/// IP地址
        /// </summary>		
		private string _ip;
        public string IP
        {
            get{ return _ip; }
            set{ _ip = value; }
        }        
		        /// <summary>
		/// 状态
        /// </summary>		
		private int _status;
        public int Status
        {
            get{ return _status; }
            set{ _status = value; }
        }        
		        /// <summary>
		/// 内容
        /// </summary>		
		private string _message;
        public string Message
        {
            get{ return _message; }
            set{ _message = value; }
        }        
		        /// <summary>
		/// 更新时间
        /// </summary>		
		private DateTime _updatetime;
        public DateTime UpdateTime
        {
            get{ return _updatetime; }
            set{ _updatetime = value; }
        }        
		   		#endregion 
   		
   		#region TablePropertyEx
   		
   		#endregion
	}
}