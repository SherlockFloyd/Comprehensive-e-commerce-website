using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Shopping.Common;
namespace Shopping.Model
{
    ///<summary>
    ///	评价信息表
    ///	Model实体层 Shopping_Rate
    ///</summary>
    public class Rate
    {
        /// <summary>
        /// ID
        /// </summary>		
        private int _rateid;
        public int RateID
        {
            get { return _rateid; }
            set { _rateid = value; }
        }
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
        /// 分数
        /// </summary>		
        private int _grade;
        public int Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }
        /// <summary>
        /// 评价内容
        /// </summary>		
        private string _ratecontent;
        public string RateContent
        {
            get { return _ratecontent; }
            set { _ratecontent = value; }
        }
        /// <summary>
        /// 评价时间
        /// </summary>		
        private DateTime _ratetime;
        public DateTime RateTime
        {
            get { return _ratetime; }
            set { _ratetime = value; }
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

        public int HtmlGrade
        {
            get
            {
                return 14 * Grade;
            }
        }
        public string UserName { set; get; }

        
    }
}