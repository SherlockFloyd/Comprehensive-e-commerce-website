using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping.Model
{
    /// <summary>
    /// 在线会员实体
    /// </summary>
    public class OnLineUserInfo
    {
        private int _UserID;
        /// <summary>
        /// 会员ID
        /// </summary>
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        private string _GuestID;
        /// <summary>
        /// 游客信息
        /// </summary>
        public string GuestID
        {
            get { return _GuestID; }
            set { _GuestID = value; }
        }

        private string _UserName;
        /// <summary>
        /// 会员名
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _Password;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private int _Point = 0;
        /// <summary>
        /// 积分
        /// </summary>
        public int Point
        {
            get { return _Point; }
            set { _Point = value; }
        }
    }
}
