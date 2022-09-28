using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Shopping.Model
{
    ///<summary>
    ///	公告信息表
    ///	Model实体层 Shopping_Notice
    ///</summary>
    public class Notice
    {
        /// <summary>
        /// ID
        /// </summary>		
        private int _noticeid;
        public int NoticeID
        {
            get { return _noticeid; }
            set { _noticeid = value; }
        }
        /// <summary>
        /// 主题
        /// </summary>		
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// 内容
        /// </summary>		
        private string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; }
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
        /// <summary>
        /// 管理员ID
        /// </summary>		
        private int _adminid;
        public int AdminID
        {
            get { return _adminid; }
            set { _adminid = value; }
        }

    }
}