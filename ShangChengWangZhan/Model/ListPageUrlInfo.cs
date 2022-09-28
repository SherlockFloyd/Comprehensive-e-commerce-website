using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping.Model
{
    /// <summary>
    /// 搜索条件实体
    /// </summary>
    public class ListPageUrlInfo
    {

        /// <summary>
        /// 类别ID
        /// </summary>
        private int _CateID;
        public int CateID
        {
            get { return _CateID; }
            set { _CateID = value; }
        }
      
        /// <summary>
        /// 搜索关键字
        /// </summary>
        private string _KeyWord;
        public string KeyWord
        {
            get { return _KeyWord; }
            set { _KeyWord = value; }
        }

        /// <summary>
        /// 热卖
        /// </summary>
        private int _IsHot;
        public int IsHot
        {
            get { return _IsHot; }
            set { _IsHot = value; }
        }
        /// <summary>
        /// 新品
        /// </summary>
        private int _IsNew;
        public int IsNew
        {
            get { return _IsNew; }
            set { _IsNew = value; }
        }

        /// <summary>
        /// 排序类型
        /// </summary>
        private OrderTypeEnum _OrderType;
        public OrderTypeEnum OrderType
        {
            get { return _OrderType; }
            set { _OrderType = value; }
        }


        public ListPageUrlInfo()
        {
        }

        public ListPageUrlInfo(ListPageUrlInfo info)
        {
            CateID = info.CateID;
            KeyWord = info.KeyWord;
            IsHot = info.IsHot;
            IsNew = info.IsNew;
            OrderType = info.OrderType;
        }
    }
}
