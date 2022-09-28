using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Shopping.Model
{
    ///<summary>
    ///	咨询信息表
    ///	Model实体层 Shopping_Consult
    ///</summary>
    public class Consult
    {

        #region  TableProperty
        /// <summary>
        /// ID
        /// </summary>		
        private int _consultid;
        public int ConsultID
        {
            get { return _consultid; }
            set { _consultid = value; }
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
        /// 商品名称
        /// </summary>		
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
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
        /// UserName
        /// </summary>		
        private string _username;
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        /// <summary>
        /// 咨询内容
        /// </summary>		
        private string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        /// <summary>
        /// 是否回复
        /// </summary>		
        private int _isreply;
        public int IsReply
        {
            get { return _isreply; }
            set { _isreply = value; }
        }
        /// <summary>
        /// 回复内容
        /// </summary>		
        private string _replycontent;
        public string ReplyContent
        {
            get { return _replycontent; }
            set { _replycontent = value; }
        }
        /// <summary>
        /// 回复时间
        /// </summary>		
        private DateTime _replytime;
        public DateTime ReplyTime
        {
            get { return _replytime; }
            set { _replytime = value; }
        }
        /// <summary>
        /// 回复内容用户是否已读
        /// </summary>		
        private int _replyisread;
        public int ReplyIsRead
        {
            get { return _replyisread; }
            set { _replyisread = value; }
        }
        /// <summary>
        /// 咨询时间
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        #endregion

        #region TablePropertyEx
        /// <summary>
        /// 图片
        /// </summary>		
        private string _photo;
        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }
        #endregion
    }
}