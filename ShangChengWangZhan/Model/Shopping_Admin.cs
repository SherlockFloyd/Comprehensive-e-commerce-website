using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Shopping.Model
{
	///<summary>
    ///	管理员信息表
    ///	Model实体层 Shopping_Admin
    ///</summary>
	public class Admin
	{     
      	        /// <summary>
		/// 管理员ID
        /// </summary>		
		private int _adminid;
        public int AdminID
        {
            get{ return _adminid; }
            set{ _adminid = value; }
        }        
		        /// <summary>
		/// 用户名
        /// </summary>		
		private string _adminname;
        public string AdminName
        {
            get{ return _adminname; }
            set{ _adminname = value; }
        }        
		        /// <summary>
		/// 密码
        /// </summary>		
		private string _password;
        public string Password
        {
            get{ return _password; }
            set{ _password = value; }
        }        
		        /// <summary>
		/// 组ID
        /// </summary>		
		private int _groupid;
        public int GroupID
        {
            get{ return _groupid; }
            set{ _groupid = value; }
        }        
		        /// <summary>
		/// 上次登录时间
        /// </summary>		
		private DateTime _lastlogintime;
        public DateTime LastLoginTime
        {
            get{ return _lastlogintime; }
            set{ _lastlogintime = value; }
        }        
		        /// <summary>
		/// 上次登录IP
        /// </summary>		
        private string _lastloginip;
        public string LastLoginIP
        {
            get { return _lastloginip; }
            set { _lastloginip = value; }
        }        
		        /// <summary>
		/// 登录时间
        /// </summary>		
		private DateTime _logintime;
        public DateTime LoginTime
        {
            get{ return _logintime; }
            set{ _logintime = value; }
        }        
		        /// <summary>
		/// 登录IP
        ///// </summary>		
        private string _loginip;
        public string LoginIP
        {
            get { return _loginip; }
            set { _loginip = value; }
        }        
		        /// <summary>
		/// 登录次数
        /// </summary>		
		private int _logintimes;
        public int LoginTimes
        {
            get{ return _logintimes; }
            set{ _logintimes = value; }
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
		/// 添加时间
        /// </summary>		
		private DateTime _createtime;
        public DateTime CreateTime
        {
            get{ return _createtime; }
            set{ _createtime = value; }
        }        
		   
	}
}