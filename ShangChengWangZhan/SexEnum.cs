using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping.Common
{
    
    public enum SexEnum
    {
        /// <summary>
        /// 女
        /// </summary>
        WoMen = 0,
        /// <summary>
        /// 男
        /// </summary>
        Men = 1
    }

    /// <summary>
    /// 性别类
    /// </summary>
    public class SexUtils
    {
        /// <summary>
        /// 获取性别名称
        /// </summary>
        /// <param name="sexInt"></param>
        /// <returns></returns>
        public static string GetSexName(int sexInt)
        {
            string result = "";
            switch (sexInt)
            {
                case (int)SexEnum.Men:
                    result = "男";
                    break;
                case (int)SexEnum.WoMen:
                    result = "女";
                    break;
            }
            return result;
        }

        /// <summary>
        /// 获取性别列表
        /// </summary>
        /// <returns></returns>
        public static List<SexInfo> GetSexInfoList()
        {
            List<SexInfo> list = new List<SexInfo>();

            foreach (int i in Enum.GetValues(typeof(SexEnum)))
            {
                list.Add(new SexInfo() { SexID = i, SexName = GetSexName(i) });
            }

            return list;
        }
    }

    public class SexInfo
    {
        private int _SexID;

        public int SexID
        {
            get { return _SexID; }
            set { _SexID = value; }
        }

        private string _SexName;

        public string SexName
        {
            get { return _SexName; }
            set { _SexName = value; }
        }
    }
}
