using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Shopping.Model
{
    ///<summary>
    ///	会员信息表
    ///	Model实体层 Shopping_User
    ///</summary>
    public class User
    {

        #region  TableProperty
        /// <summary>
        /// ID
        /// </summary>		
        private int _userid;
        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// 用户名
        /// </summary>		
        private string _username;
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        /// <summary>
        /// Sex
        /// </summary>		
        private int _sex;
        public int Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        /// <summary>
        /// BirthDay
        /// </summary>		
        private DateTime _birthday;
        public DateTime BirthDay
        {
            get { return _birthday; }
            set { _birthday = value; }
        }
        /// <summary>
        /// 积分
        /// </summary>		
        private int _point;
        public int Point
        {
            get { return _point; }
            set { _point = value; }
        }
        /// <summary>
        /// 邮箱地址
        /// </summary>		
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        /// <summary>
        /// 邮箱地址是否验证
        /// </summary>		
        private int _emailischecked;
        public int EmailIsChecked
        {
            get { return _emailischecked; }
            set { _emailischecked = value; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>		
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        /// <summary>
        /// 联系地址
        /// </summary>		
        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        /// <summary>
        /// 密码
        /// </summary>		
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        /// <summary>
        /// 注册时间
        /// </summary>		
        private DateTime _regtime;
        public DateTime RegTime
        {
            get { return _regtime; }
            set { _regtime = value; }
        }
        /// <summary>
        /// 上次登录时间
        /// </summary>		
        private DateTime _lastlogintime;
        public DateTime LastLoginTime
        {
            get { return _lastlogintime; }
            set { _lastlogintime = value; }
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
            get { return _logintime; }
            set { _logintime = value; }
        }
        /// <summary>
        /// 登录IP
        /// </summary>		
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
            get { return _logintimes; }
            set { _logintimes = value; }
        }
        /// <summary>
        /// 账户状态
        /// </summary>		
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>		
        private string _realname;
        public string RealName
        {
            get { return _realname; }
            set { _realname = value; }
        }
        /// <summary>
        /// 邮编地址
        /// </summary>		
        private int _post;
        public int Post
        {
            get { return _post; }
            set { _post = value; }
        }
        #endregion

        #region TablePropertyEx

        #endregion
    }
}