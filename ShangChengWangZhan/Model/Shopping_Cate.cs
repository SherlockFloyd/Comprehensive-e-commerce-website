using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Shopping.Model
{
    ///<summary>
    ///	商品类别信息表
    ///	Model实体层 Shopping_Cate
    ///</summary>
    public class Cate
    {
        /// <summary>
        /// ID
        /// </summary>		
        private int _cateid;
        public int CateID
        {
            get { return _cateid; }
            set { _cateid = value; }
        }
        
        /// <summary>
        /// 名称
        /// </summary>		
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
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

    }
}